using System;
using System.Web;
using System.Web.Compilation;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Web.UI.Design;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using PX.Data;
using PX.Data.Description.GI;
using PX.Data.Maintenance.GI;
using System.Collections.Specialized;
using System.Drawing;
using PX.Common;
using PX.Web.UI.TestGen;

namespace PX.Web.UI
{
	public class PXGenericDataSource : PXDataSource
	{
		private readonly object _syncObj = new object();
		private bool _prepared;

		private PXGenericInqGrph GenDataGraph
		{
			get { return (PXGenericInqGrph) DataGraph; }
		}

		#region Ctor
		public PXGenericDataSource()
			: base()
		{
			this.PrimaryView = "Filter";
		}
		#endregion

		#region Public properties
		/// <summary>
		/// Gets or sets ID of the form which will contain generated filter controls.
		/// </summary>
		private string formID = string.Empty;
		[Category("Data"), DefaultValue("")]
		[Description("The ID of the form that should contain generated filter controls.")]
		public string FormID
		{
			get { return this.formID; }
			set { this.formID = value; }
		}

		/// <summary>
		/// Gets or sets ID of the grid which will contain results of inquiry.
		/// </summary>
		private string gridID = string.Empty;
		[Category("Data"), DefaultValue(""), ScriptBrowsable]
		[Description("The ID of the grid that should contain results of the inquiry.")]
		public string GridID
		{
			get { return this.gridID; }
			set { this.gridID = value; }
		}

		[Browsable(false)]
		public override string TypeName
		{
			get
			{
				return typeof(PXGenericInqGrph).FullName;
			}
			set { }
		}
		#endregion

		#region Overridables

		protected override PXGraph InstantiateDataGraph(Type type)
		{
			if (type == typeof (PXGenericInqGrph) && HttpContext.Current != null && HttpContext.Current.Request != null)
			{
				var queryString = ((PXPage) Page).QueryString;
				string id = queryString["ID"];
				string name = queryString["Name"];

				if (!String.IsNullOrEmpty(id) || !String.IsNullOrEmpty(name))
				{
					Dictionary<String, String> parameters = null;
					if (PXPageCache.IsReloadPage || !this.Page.IsCallback)
					{
						parameters = new Dictionary<String, String>();
						foreach (string param in HttpContext.Current.Request.QueryString.AllKeys)
						{
							if (param == null || String.Equals(param, "ID", StringComparison.OrdinalIgnoreCase) || String.Equals(param, "Name", StringComparison.OrdinalIgnoreCase))
								continue;
							parameters[param] = HttpContext.Current.Request.QueryString[param];
						}
					}

					return PXGenericInqGrph.CreateInstance(id, name, parameters);
				}

				string screenID = PXContext.GetScreenID()?.Replace(".", "");
				if (!String.IsNullOrEmpty(screenID))
					return PXGenericInqGrph.CreateInstance(screenID);
			}

			return base.InstantiateDataGraph(type);
		}

		protected override void CreateChildControls()
		{
			base.CreateChildControls();
			PrepareScreen();
		}

		public void PrepareScreen()
		{
			if (string.IsNullOrEmpty(this.formID))
				throw new Exception(Msg.GetLocal(Msg.ErrFormNotDefined));
			if (string.IsNullOrEmpty(this.gridID))
				throw new Exception(Msg.GetLocal(Msg.ErrGridNotDefined));

			lock (_syncObj)
				if (!_prepared)
				{
					_prepared = true;
					PXFormView form = FindForm();
					PXGrid grid = FindGrid();
					if (form == null)
						throw new Exception(Msg.GetLocal(Msg.ErrFormNotFound));
					if (grid == null)
						throw new Exception(Msg.GetLocal(Msg.ErrGridNotFound));

					form.InvalidateDataControls();
					
					Dictionary<String, String> parameters = null;
					if (PXPageCache.IsReloadPage || !this.Page.IsCallback)
					{
						parameters = new Dictionary<String, String>();
						foreach (String param in HttpContext.Current.Request.QueryString.AllKeys)
						{
							if (param == "ID" || param == "Name" || param == null) continue;
							parameters[param] = HttpContext.Current.Request.QueryString[param];
						}
					}

					this.GenerateControls(form, grid, parameters);
				}
		}

		private PXGrid FindGrid()
		{
			var pageInfo = PageInfo.Current;
			if (pageInfo != null && pageInfo.DataboundControls != null)
				foreach (var control in pageInfo.DataboundControls)
					if (control.ID == this.gridID)
						return control as PXGrid;
			return ControlHelper.FindControl(this.gridID, this.Page) as PXGrid;
		}

		private PXFormView FindForm()
		{
			var pageInfo = PageInfo.Current;
			if (pageInfo != null && pageInfo.DataboundControls != null)
				foreach (var control in pageInfo.DataboundControls)
					if (control.ID == this.formID)
						return control as PXFormView;
			return ControlHelper.FindControl(this.formID, this.Page) as PXFormView;
		}

		protected override Type GetPreferredGraphTypeForEdit(string viewName)
		{
			return null; // can't determine preferred graph type because Generic Inquiry graph doesn't know anything about that
		}

		internal protected override IEnumerable ExecuteSelect(string viewName, DataSourceSelectArguments arguments, PXDSSelectArguments pxarguments)
		{
			if (viewName == GenDataGraph.Results.Name)
			{
				PXGrid grid = FindGrid();

				if (arguments.MaximumRows == 1)
				{
					if (grid != null && pxarguments.Searches.Count > 0)
					{
						grid.DataBind();

						GenericResult search = (GenericResult)GenDataGraph.Results.Cache.CreateInstance();
						for (int i = 0; i < GenDataGraph.Results.Cache.Keys.Count; i++)
						{
							string key = GenDataGraph.Results.Cache.Keys[i];
							GenDataGraph.Results.Cache.SetValueExt(search, key, pxarguments.Searches[i]);
						}
						GenericResult record = GenDataGraph.Results.Cache.Locate(search) as GenericResult;
						if (record != null)
						{
							GenDataGraph.Results.Current = record;
							return new GenericResult[] { record };
						}
					}
				}
			}

			return base.ExecuteSelect(viewName, arguments, pxarguments);
		}

		protected override IEnumerable<Type> GetFilterStateExtTables(IEnumerable<IBqlParameter> parameters, IEnumerable<Type> primaryViewTables)
		{
			if (parameters == null || GenDataGraph == null || GenDataGraph.Description == null) return Enumerable.Empty<Type>();
			primaryViewTables = GenDataGraph.Description.Tables.Select(_ => PXBuildManager.GetType(_.Name, false)).Where(_ => _ != null);
			return base.GetFilterStateExtTables(parameters, primaryViewTables);
		}

		protected override PXCommandState TryGetVirtualCommandState(string commandName, string commandPostfix)
		{
			if (!string.IsNullOrEmpty(commandName) && commandName.EndsWith(commandPostfix))
			{
				string dataMember = commandName.Substring(0, commandName.Length - commandPostfix.Length);
				
				if (GenDataGraph.Design != null && PXList.Provider.HasList(GenDataGraph.Design.PrimaryScreenID) && dataMember == PXGenericInqGrph.PrimaryViewName)
				{
					PXSiteMapNode primaryNode = GIScreenHelper.GetSiteMapNode(GenDataGraph.Design.PrimaryScreenID);
					Type primaryCacheType = GIScreenHelper.GetCacheType(GenDataGraph.Design.PrimaryScreenID);
					string primaryView = PXPageIndexingService.GetPrimaryView(primaryNode.GraphType);
					string primaryCommandName = primaryView + commandPostfix;
					
					PXCacheRights rights;
					List<string> invisibled;
					List<string> disabled;
					PXAccess.Provider.GetRights(primaryNode.ScreenID, primaryNode.GraphType, primaryCacheType, out rights, out invisibled, out disabled);
					bool enabled = (invisibled == null || !invisibled.Contains(primaryCommandName)) && (disabled == null || !disabled.Contains(primaryCommandName));
					return new PXCommandState(true, enabled);
				}
				return base.TryGetVirtualCommandState(commandName, commandPostfix);
			}
			return null;
		}

		/// <summary>
		/// Performs the additional JavaScript properties registration.
		/// </summary>		
		protected override void RegisterScriptProperties(JSObject obj)
		{
			base.RegisterScriptProperties(obj);

			if (obj.BaseObject == this)
			{
				obj.Append("LayeredActions", this.GenDataGraph.LayeredNavigationActions);
			}
			else if (obj.BaseObject is PXGenericInqGrph.LayeredNavigationAction)
			{
				var na = (PXGenericInqGrph.LayeredNavigationAction)obj.BaseObject;
				obj.Append("Action", na.ActionName, null);
				obj.Append("Icon", na.Icon, null);
				obj.Append("ToolTip", na.ToolTip, null);
			}
		}
		#endregion

		private void GenerateControls(PXFormView form, PXGrid grid, Dictionary<String, String> parameters)
				{
			if (GenDataGraph.Design != null)
			{
				this.GenerateOnForm(form);
				this.GenerateOnGrid(grid);
			}
		}

		#region Form controls generation
		private void GenerateOnForm(PXFormView form)
		{
			form.Caption = PXMessages.LocalizeFormatNoPrefix(ActionsMessages.GIFilter); // graph.Design.FilterCaption;
			List<KeyValuePair<WebControl, GIFilter>> controls = new List<KeyValuePair<WebControl, GIFilter>>();
			for (int i = 0; i < GenDataGraph.Filter.Cache.Fields.Count; i++)
			{
				string field = GenDataGraph.Filter.Cache.Fields[i];
				PXFieldState state = GenDataGraph.Filter.Cache.GetStateExt(null, field) as PXFieldState;
				if (state == null)	continue;

				GIFilter filter = GenDataGraph.FilterDefinitions.FirstOrDefault(f => f.Name == field);
				WebControl control = this.GenerateSingleControl(form, state, field);
				controls.Add(new KeyValuePair<WebControl,GIFilter>(control, filter));

				if (control is ISizedControl && filter.Size != null)
					((ISizedControl)control).Size = filter.Size;
				if (control is ILabeledControl && filter.LabelSize != null)
					((ILabeledControl)control).LabelWidth = PXLayoutGenerator.GetLabelSize(filter.LabelSize);				
			}
			if (controls.Count <= 0)
			{
				form.Visible = false;
				return;
			}

			Int32 counter = 0;
			Int32 colscount = GenDataGraph.Design.FilterColCount == null || GenDataGraph.Design.FilterColCount.Value > 20 || GenDataGraph.Design.FilterColCount.Value <= 0
				? 3 : GenDataGraph.Design.FilterColCount.Value;

			//Int32 controlscount = 0, rowscount = 0;
			Int32 controlscount = controls.Count + controls.Select(p => p.Value).Sum(f =>
					f.ColSpan == null || f.ColSpan <= 1 ? 0 : (f.ColSpan > colscount ? colscount : f.ColSpan) - 1).Value; ;
			Int32 rowscount = (Int32)Math.Floor((double)controlscount / (double)colscount);
			if (rowscount != controls.Count)
			{
				Int32 estimatedControls = controls.Count + controls.Take(controls.Count - (controlscount - rowscount * colscount)).Select(p => p.Value).Sum(f =>
					f.ColSpan == null || f.ColSpan <= 1 ? 0 : (f.ColSpan > colscount ? colscount : f.ColSpan) - 1).Value;
				Int32 estimatedRows = (Int32)Math.Ceiling((double)estimatedControls / (double)colscount);

				if (estimatedRows > rowscount) rowscount = estimatedRows;
			}
			
			Int32[,] matrix = new Int32[rowscount, colscount];
			for (int i = 0; i < colscount; i++)
			{
				if (controls.Count <= 0) break;

				form.TemplateContainer.Controls.Add(new PXLayoutRule() { ID = "layrul" + (counter++).ToString(), StartColumn = true, LabelsWidth = "SM", ControlSize = "M" });
				for (int j = 0; j < rowscount; j++)
				{
					if (controls.Count <= 0) break;
					if (matrix[j,i] != 0) continue;					

					KeyValuePair<WebControl, GIFilter> pair = controls.FirstOrDefault();
					Int32 colspan = (i == colscount - 1) || (pair.Value.ColSpan == null) || (pair.Value.ColSpan <= 1) ? 1 : (pair.Value.ColSpan.Value > colscount ? colscount : pair.Value.ColSpan.Value);
					
					if (colspan > 1)
					{
						form.TemplateContainer.Controls.Add(new PXLayoutRule() { ID = "layrul" + (counter++).ToString(), ColumnSpan = colspan });
						for (int k = i; k < colspan; k++)
						{
							matrix[j, k] = 1;
						}
					}

					form.TemplateContainer.Controls.Add(pair.Key);

					if (colspan > 1)
					{
						form.TemplateContainer.Controls.Add(new PXLayoutRule() { ID = "layrul" + (counter++).ToString() });
					}

					matrix[j, i] = 1;
					controls.RemoveAt(0);
				}
			}
			foreach(WebControl control in controls.Select(p => p.Key))
				form.TemplateContainer.Controls.Add(control);
		}

		private WebControl GenerateSingleControl(PXFormView form, PXFieldState state, string fname)
		{
			PXFieldSchema schema = this.CreateFieldSchema(state, fname);
			PXSchemaGenerator generator = new PXSchemaGenerator(form, null);
			WebControl control = generator.CreateControlForField(schema);
			
			if (control is IFieldEditor)
			{
				((IFieldEditor)control).Required = state.Required ?? false;
			}
			if(control is PXBranchSelector bs)
			{
				bs.DataSourceID = this.ID;
				bs.DataMember = state.ViewName;
				var ed = (IFieldEditor)bs;
				ed.SynchronizeState(state);
				bs.Load += (s, e) => ed.SynchronizeState(state);
			}
			if (control is PXSelectorBase)
			{
				var sel = (PXSelectorBase)control;
				sel.DataSourceID = this.ID;
				sel.DataMember = state.ViewName;
				sel.AutoGenerateColumns = true;
				sel.AutoRefresh = true;
				var ed = (IFieldEditor) sel;
				ed.SynchronizeState(state);
				sel.Load += (s, e) => ed.SynchronizeState(state);
				sel.GridProperties.PagerSettings.Mode = GridPagerMode.NextPrevFirstLast;
			}
			if (control is PXTextEdit)
			{
				//this is needed because it was commented in SchemaGenerator.SetControlProperties
				((PXTextEdit)control).MaxLength = schema.MaxLength;
			}
			if (control is PXNumberEdit)
			{
				((PXNumberEdit)control).SynchronizeState(state);
			}
			//if (control is PXDateTimeEdit)
			//{
			//	((PXDateTimeEdit)control).ShowRelativeDates = true;
			//}

			SetProperty(control, "LabelID", null);
			SetProperty(control, "HintLabelID", null);

			control.ApplyStyleSheetSkin(this.Page);
			this.SetAutoCallback(form, control);

			return control;
		}

		private PXFieldSchema CreateFieldSchema(PXFieldState state, string fname)
		{
			IDataSourceFieldSchema f = state;
			TypeCode dataType = Type.GetTypeCode(f.DataType);
			PXFieldSchema fieldSchema = new PXFieldSchema(true, fname, dataType);
			fieldSchema.ControlType = PXSchemaGenerator.GetControlType(f);
			fieldSchema.PrimaryKey = f.PrimaryKey;
			fieldSchema.ReadOnly = f.IsReadOnly;
			fieldSchema.AllowNull = f.Nullable;
			fieldSchema.MaxLength = (f.Length > 0) ? f.Length : 0;
			fieldSchema.Precision = (f.Precision > 0) ? f.Precision : 0;
			fieldSchema.Width = PXGrid.DefaultColWidth(dataType, f.Length);
			fieldSchema.Caption = state.DisplayName;
			fieldSchema.ViewName = state.ViewName;
			fieldSchema.HintField = state.DescriptionName;
			fieldSchema.FieldList = state.FieldList;
			fieldSchema.HeaderList = state.HeaderList;
			fieldSchema.DefaultValue = state.DefaultValue;
			this.SetSchemaProperties(fieldSchema, state);
			return fieldSchema;
		}
		private void SetSchemaProperties(PXFieldSchema item, PXFieldState state)
		{
			PXStringState strS = state as PXStringState;
			if (strS != null)
			{
				item.InputMask = strS.InputMask;
				item.AllowedValues = strS.AllowedValues;
				item.AllowedLabels = strS.AllowedLabels;
				item.ExclusiveValues = strS.ExclusiveValues;
			}

			PXSegmentedState segS = state as PXSegmentedState;
			if (segS != null)
			{
				item.Wildcard = segS.Wildcard;
				if (segS.Segments != null)
				{
					item.Segments = new PXSegment[segS.Segments.Length];
					segS.Segments.CopyTo(item.Segments, 0);
				}
			}

			PXIntState intS = state as PXIntState;
			if (intS != null)
			{
				item.MaxValue = intS.MaxValue;
				item.MinValue = intS.MinValue;
                item.ExclusiveValues = intS.ExclusiveValues;

                int[] vals = intS.AllowedValues;
				if (vals != null && vals.Length > 0)
				{
					item.AllowedValues = new string[vals.Length];
					for (int i = 0; i < vals.Length; i++)
						item.AllowedValues[i] = vals[i].ToString();
					item.AllowedLabels = intS.AllowedLabels;
				}
			}

			PXDoubleState doubS = state as PXDoubleState;
			if (doubS != null)
			{
				item.MaxValue = doubS.MaxValue;
				item.MinValue = doubS.MinValue;
			}

			PXFloatState floatS = state as PXFloatState;
			if (floatS != null)
			{
				item.MaxValue = floatS.MaxValue;
				item.MinValue = floatS.MinValue;
			}

			PXDecimalState decS = state as PXDecimalState;
			if (decS != null)
			{
				item.MaxValue = decS.MaxValue;
				item.MinValue = decS.MinValue;
			}

			PXDateState dateS = state as PXDateState;
			if (dateS != null)
			{
				item.MaxValue = dateS.MaxValue;
				item.MinValue = dateS.MinValue;
				item.InputMask = dateS.InputMask;
				item.DisplayMask = dateS.DisplayMask;
			}
		}
		private void SetAutoCallback(PXFormView form, WebControl control)
		{
			System.Reflection.PropertyInfo prop = control.GetType().GetProperty("AutoCallBack");
			if (prop == null)
				return;
			PXCallbackSettings settings = prop.GetValue(control, null) as PXCallbackSettings;
			settings.Command = "Save";
			settings.Enabled = true;
			settings.Target = form.ID;
		}
		private void SetProperty(Object obj, String property, Object value)
		{
			System.Reflection.PropertyInfo info = obj.GetType().GetProperty(property, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
			if (info != null) info.SetValue(obj, value, null);
		}
		#endregion

		#region Grid columns generation

		private void GenerateOnGrid(PXGrid grid)
		{
			bool hasPrimaryScreen = !String.IsNullOrEmpty(GenDataGraph.Design.PrimaryScreenID);
			bool isList = PXSiteMap.CurrentNode != null && PXList.Provider.IsList(PXSiteMap.CurrentNode.ScreenID);

			PXSiteMapNode[] primaryScreenNodes = hasPrimaryScreen 
				? PXSiteMap.Provider.FindSiteMapNodesByScreenID(GenDataGraph.Design.PrimaryScreenID).ToArray() 
				: new PXSiteMapNode[0]; // for determining on which columns show a hyperlink

			PXFormView form = new PXFormView();
			PXSchemaGenerator generator = new PXSchemaGenerator(form, null);

			grid.Select += Grid_OnSelect; // configure grid for searching record when navigating from the Entry Screen
			grid.BeforeNavigate += Grid_OnBeforeNavigate; // to set valid current before navigation in case of self-joins
			grid.BeforeExportToExcel += Grid_OnBeforeExportToExcel;
			grid.DataBound += Grid_OnDataBound;
			grid.RowDataBound += Grid_OnRowDataBound;
            var descr = GenDataGraph.Description;
            if (descr.Sorts != null && descr.Sorts.Any())
            {
                foreach (var sort in descr.Sorts)
                {
                    string sortOrder;
                    var result = descr.Results.FirstOrDefault(res => res.ObjectName + "." + res.Field == sort.DataFieldName);
					if (result != null)
						sortOrder = result.FieldName;
					else if (sort.DataFieldName.StartsWith("="))
						continue;
					else
                        sortOrder = sort.DataFieldName.Replace('.', '_');
                    if (sort.SortOrder == "D")
                        sortOrder += " desc";
                    if (!string.IsNullOrEmpty(grid.Levels[0].SortOrder))
                        grid.Levels[0].SortOrder = string.Join(",", grid.Levels[0].SortOrder, sortOrder);
                    else
                        grid.Levels[0].SortOrder = sortOrder;
                }
            }

			form.DataSourceID = this.ID;
			grid.Caption = PXMessages.LocalizeFormatNoPrefix(ActionsMessages.GIResult); // graph.Design.ResultsCaption;
			grid.AutoSize.Enabled = true;
			grid.AutoSize.Container = DockContainer.Window;
			grid.Mode.AllowAddNew = false;
			grid.Mode.AllowDelete = false;
			grid.Mode.AllowUpdate = false;
			grid.AllowPaging = true;
			grid.Layout.FooterVisible = GenDataGraph.BaseQueryDescription.TotalFields.Any();
			if (GenDataGraph.Design.PageSize != null && GenDataGraph.Design.PageSize.Value > 0)
				grid.PageSize = GenDataGraph.Design.PageSize.Value;
			else grid.AdjustPageSize = GridPageSizeMode.Auto;
			
			if (GenDataGraph.NoteFields != null && GenDataGraph.NoteFields.Count > 0)
			{
				grid.NoteIndicator = true;
				grid.FilesIndicator = true;
			}
			grid.Levels[0].DataKeyNames = GenDataGraph.Results.Cache.Keys.ToArray();
			grid.ResetColumnsGenerated();

			// In case when system columns have already been generated at this moment
			List<PXGridColumn> systemColumns = new List<PXGridColumn>();
			var gridKeys = new HashSet<string>(grid.DataKeyNames, StringComparer.OrdinalIgnoreCase);
			foreach (PXGridColumn col in grid.Columns)
			{
				if (!String.IsNullOrEmpty(col.DataField) && gridKeys.Contains(col.DataField))
				{
					systemColumns.Add(col);
				}
			}
			foreach (PXGridColumn sysColumn in systemColumns)
			{
				grid.Columns.Remove(sysColumn);
			}

			List<string> fastFilterFields = new List<string>(); // fields for quick search (text input field that searches across all the columns)
			List<string> quickFilterFields = new List<string>(); // fields for default quick filter, they are shown on "All Records" tab
			foreach (string field in GenDataGraph.Results.Cache.BqlFields.Select(t => t.Name).Concat(GenDataGraph.Columns))
			{
				if (GenericResult.IsAuxiliaryField(field) || GenDataGraph.IsAuxiliaryField(field)) continue;
				if (GenDataGraph.NoteFields.Contains(field)) continue;

				// Do not show Row Number for LEP because we cannot calculate it when navigating back from the entry screen
				if (hasPrimaryScreen && isList && String.Equals(field, typeof (GenericResult.row).Name, StringComparison.OrdinalIgnoreCase))
					continue;

				GIResult fieldDescription = GenDataGraph.ResultColumns.FirstOrDefault(r => String.Equals(r.FieldName, field, StringComparison.OrdinalIgnoreCase));
				PXFieldState state = GenDataGraph.Results.Cache.GetStateExt(null, field) as PXFieldState;
				if (state == null) continue;

				// Get navigation (drilldown) command name
				string linkCommand = PXGenericInqGrph.GetNavigateToActionName(field);
				if (GenDataGraph.Actions[linkCommand] == null)
					linkCommand = null;

				PXFieldSchema schema = this.CreateFieldSchema(state, field);
				// If there is no custom navigation, show default drilldown link which operates through PXBaseDataSource.GetEditUrl() method (using PXPrimaryGraphAttribute)
				if (linkCommand == null && !String.IsNullOrEmpty(schema.ViewName) 
					&& (schema.ControlType == PXSchemaControl.Selector || schema.ControlType == PXSchemaControl.SegmentMask))
				{
					PXDataSourceView dsView = (PXDataSourceView) GetView(schema.ViewName);
					IEnumerable<PXSelectorAttribute> selectors = GenDataGraph.Results.Cache.GetAttributesReadonly(field, true).OfType<PXSelectorAttribute>();
					HashSet<string> keys = new HashSet<string>(dsView.GetKeyNames(), StringComparer.OrdinalIgnoreCase);

					bool donotedit = false;
					GIResult res = GenDataGraph.Description.Results.FirstOrDefault(_ => String.Equals(_.FieldName, field, StringComparison.OrdinalIgnoreCase));
					if (res != null && res.DefaultNav == false && res.NavigationNbr == null)
					{
						donotedit = true;
					}
					if (!donotedit)
					{
						// if selector point to key field, add navigation by this field
						if (selectors.Any(s => keys.Contains(s.Field.Name) || s.SubstituteKey != null && keys.Contains(s.SubstituteKey.Name)) && !String.IsNullOrEmpty(state.ViewName))
						{
							bool showLink = true;
							// Show only those links which differ from primary screen navigation
							if (hasPrimaryScreen)
							{
								Type gt = GetGraphType(state.ViewName);
								if (gt != null)
								{
									showLink = primaryScreenNodes.Any(n => n.GraphType != gt.FullName);
								}
							}

							if (showLink)
							{
								WebControl control = generator.CreateControlForField(schema);
								((PXSelectorBase)control).AllowEdit = true; // true for displaying a hyperlink
								grid.Levels[0].AppendFieldEditor(control);
							}
						}
					}
				}
				
				PXGridColumn col = new PXGridColumn();
				col.DataField = state.Name;
				//col.DataField = field;
				col.DataType = Type.GetTypeCode(state.DataType);
				col.Header.Text = string.IsNullOrEmpty(state.DisplayName) ? state.Name : state.DisplayName;
				if (state is PXTimeState)
					col.MatrixMode = true;
				// If not defined, autogenerate length
				if (fieldDescription != null && fieldDescription.Width.HasValue)
					col.Width = Unit.Pixel(fieldDescription.Width.Value);
				else
					PXGrid.CalculateColumnWidth(col, state);
				
				// TODO: remove this block once AC-98392 (Paging with Count feature) merged
				if (fieldDescription == null || GenDataGraph.IsVirtualField(fieldDescription.FieldName))
				{
					col.AllowSort = false;
				}

				switch (col.DataType)
				{
					case TypeCode.Char:
					case TypeCode.String: col.TextAlign = HorizontalAlign.Left; break;
					case TypeCode.Boolean: col.Type = GridColumnType.CheckBox; col.TextAlign = HorizontalAlign.Center; break;
					case TypeCode.Int16:
					case TypeCode.Int32:
					case TypeCode.Int64:
					case TypeCode.SByte:
					case TypeCode.Single:
					case TypeCode.UInt16:
					case TypeCode.UInt32:
					case TypeCode.UInt64:
					case TypeCode.Byte:
					case TypeCode.DateTime:
					case TypeCode.Decimal:
					case TypeCode.Double: col.TextAlign = HorizontalAlign.Right; break;
				}

				col.LinkCommand = linkCommand;

				grid.Columns.Add(col);

				if (fieldDescription != null)
				{
					if (fieldDescription.FastFilter == true
						&& !GenDataGraph.IsVirtualField(fieldDescription.FieldName) 
						&& col.DataType != TypeCode.DateTime 
						&& col.DataType != TypeCode.Object)
					{
						fastFilterFields.Add(col.DataField);
					}
					if (fieldDescription.QuickFilter == true)
					{
						quickFilterFields.Add(col.DataField);
					}
				}
			}

			var existingDataFields =
				new HashSet<string>(grid.Columns.Items.Where(c => !String.IsNullOrEmpty(c.DataField)).Select(c => c.DataField), StringComparer.OrdinalIgnoreCase);

			foreach (PXGridColumn sysColumn in systemColumns)
			{
				if (!existingDataFields.Contains(sysColumn.DataField))
					grid.Columns.Add(sysColumn);
			}

			if (grid.IsColumnsGenerated)
				grid.LoadLayout();

			grid.FastFilterFields = fastFilterFields.ToArray();
			grid.QuickFilterFields = quickFilterFields.ToArray();

			grid.RestrictFields = true;
		}

		private void Grid_OnBeforeExportToExcel(object sender, PXGridExportToExcelEventArgs e)
		{
			PXGrid grid = (PXGrid) sender;
			e.ExportTop = 0;
			int inqTop = GenDataGraph.Design.ExportTop ?? 0;
			int globalTop = WebConfig.GenericInquiryExportToExcelRowLimit;
			try
			{
				if (inqTop > 0 && grid.TotalRowCount > inqTop)
				{
					if (GenDataGraph.Results.View.Ask(null, ActionsMessages.Warning,
						    PXLocalizer.LocalizeFormat(ActionsMessages.GIExportToExcelInquiryLimitExceeded, inqTop),
						    MessageButtons.OKCancel, MessageIcon.Warning) != WebDialogResult.OK)
					{
						e.Cancel = true;
					}

					e.ExportTop = inqTop;
				}
				else if (grid.TotalRowCount > globalTop)
				{
					WebDialogResult result = GenDataGraph.Results.View.Ask(null, ActionsMessages.Warning,
						PXLocalizer.LocalizeFormat(ActionsMessages.GIExportToExcelGlobalLimitExceeded, globalTop),
						MessageButtons.YesNoCancel,
						new Dictionary<WebDialogResult, string>()
						{
							{ WebDialogResult.Yes, ActionsMessages.GIExportToExcelGlobalLimitExceededBtnApply },
							{ WebDialogResult.No, ActionsMessages.GIExportToExcelGlobalLimitExceededBtnIgnore },
						},
						MessageIcon.Warning);
					switch (result)
					{
						case WebDialogResult.Yes:
							e.ExportTop = globalTop;
							break;
						case WebDialogResult.No:
							e.ExportTop = 0;
							break;
						case WebDialogResult.Cancel:
							e.Cancel = true;
							break;
					}
				}
				else if (grid.TotalRowCount == -1)
				{
					int noCountTop = inqTop > 0 ? inqTop : globalTop;
					if (GenDataGraph.Results.View.Ask(null, ActionsMessages.Warning,
						    PXLocalizer.LocalizeFormat(ActionsMessages.GIExportToExcelNoRecordCount, noCountTop),
						    MessageButtons.OKCancel, MessageIcon.Warning) != WebDialogResult.OK)
					{
						e.Cancel = true;
					}

					e.ExportTop = noCountTop;
				}
			}
			catch (PXDialogRequiredException ex)
			{
				ex.DataSourceID = grid.DataSourceID; // have to set it here because we're outside of data source execution flow (inside the grid)
				throw;
			}
		}

		Dictionary<string, Type> _graphTypes = new Dictionary<string, Type>();
		private Type GetGraphType(string viewName)
		{
			Type type = null;
			if (!_graphTypes.TryGetValue(viewName, out type))
			{
				type = PXRedirectHelper.GetGraphType(DataGraph.Caches[GetItemType(viewName)]);
				_graphTypes.Add(viewName, type);
			}

			return type;
		}

		private void Grid_EditorsCreated(object sender, EventArgs e)
		{
			PXGrid grid = sender as PXGrid;
			if (grid != null)
			{
				var de = grid.PrimaryLevel.GetStandardEditor(GridStandardEditor.Date) as PXDateTimeEdit;
				if (de != null)
				{
					de.ShowRelativeDates = true;
				}
			}
		}

		private void Grid_OnSelect(object sender, PXSelectEventArgs e)
		{
			PXGrid grid = (PXGrid)sender;

			GenDataGraph.VisibleColumns = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
			grid.Layout.FooterVisible = false;

			foreach (var col in grid.Columns.Cast<PXGridColumn>()
				.Where(c => !String.IsNullOrEmpty(c.DataField) && (c.Visible || c.IsDataKey)))
			{
				GenDataGraph.VisibleColumns.Add(col.DataField);

				if (GetTotalField(col) != null)
					grid.Layout.FooterVisible = true;
			}

			grid.FastFilterFields = grid.FastFilterFields.Where(f => GenDataGraph.VisibleColumns.Contains(f)).ToArray();

			if (!String.IsNullOrEmpty(GenDataGraph.Design?.PrimaryScreenID))
			{
				GenDataGraph.Results.Cache.ActiveRow = GenDataGraph.EditCurrent;
				GenDataGraph.EditCurrent = null;
			}
		}

		private void Grid_OnBeforeNavigate(object sender, PXGridNavigateEventArgs e)
		{
			GenDataGraph.Results.Cache.SetCurrentForField(e.Column.DataField);
		}

		private void Grid_OnRowDataBound(object sender, PXGridRowEventArgs e)
		{
			// Conditional Formatting
			if (!(e.Row.DataItem is GenericResult row))
				return;

			string rowStyle = null;
			if (!string.IsNullOrEmpty(GenDataGraph.Design?.RowStyleFormula)) 
				rowStyle = GIFormulaParser.Evaluate(GenDataGraph, row, GenDataGraph.Design.RowStyleFormula, true, false) as string;

			if (!string.IsNullOrEmpty(rowStyle))
			{
				foreach (PXGridCell cell in e.Row.Cells)
					cell.Style.CssClass = rowStyle;
			}

			foreach (GIResult col in GenDataGraph.ResultColumns)
			{
				if (string.IsNullOrEmpty(col.StyleFormula))
					continue;

				var columnStyle = GIFormulaParser.Evaluate(GenDataGraph, row, col.StyleFormula, true, false) as string;
				if (string.IsNullOrEmpty(columnStyle))
					continue;

				var cell = e.Row.Cells[col.FieldName];
				if (cell != null) cell.Style.CssClass = columnStyle;
			}
		}

		private void Grid_OnDataBound(object sender, EventArgs e)
		{
			// Totals
			PXGrid grid = (PXGrid)sender;

			GenericResult row = GenDataGraph.TotalCurrent;
			if (row == null) return;

			foreach (PXGridColumn col in grid.Columns)
			{
				PXAggregateField totalField = GetTotalField(col);
				if (totalField == null) continue;

				string fieldName = totalField.Function == AggregateFunction.Count
					? totalField.Table.Alias + "_" + totalField.Alias
					: col.DataField;

				object value = PXFieldState.UnwrapValue(GenDataGraph.Results.GetValueExt(row, fieldName));
				object valueLabel = totalField.Function == AggregateFunction.Count ?
					col.GetValueText(col.NormalizeValue(value), false) :
					col.FormatValue(col.NormalizeValue(value));
				string label = PXLocalizer.Localize(totalField.Function.ToString());
				col.Footer.Text = label + ": " + valueLabel;
			}

			GenDataGraph.TotalCurrent = null;
		}

		private PXAggregateField GetTotalField(PXGridColumn col)
		{
			var hasCountAggr = GenDataGraph.BaseQueryDescription.AggregateFields.Any(f => 
				f.Function == AggregateFunction.Count
				&& String.Equals(f.Table.Alias + "_" + f.Alias, col.DataField, StringComparison.OrdinalIgnoreCase));
			return GenDataGraph.BaseQueryDescription.TotalFields.Find(f =>
				String.Equals(f.Table.Alias + "_" + (hasCountAggr ? f.Alias : f.Name), col.DataField, StringComparison.OrdinalIgnoreCase));
		}

		#endregion
	}

	public class PXGenericFormView : PXFormView
	{
		public PXGenericFormView()
			: base()
		{
			base.AutoFillSearches = false;
		}
		//protected override PXDSSelectArguments CreateSelectArgumentsExt()
		//{
		//	PXDSSelectArguments arg = base.CreateSelectArgumentsExt();
		//	arg.Searches.Clear();
		//	return arg;
		//}

		protected override string ClientClassName
		{
			get
			{
				return typeof(PXFormView).Name;
			}
		}
	}
}
