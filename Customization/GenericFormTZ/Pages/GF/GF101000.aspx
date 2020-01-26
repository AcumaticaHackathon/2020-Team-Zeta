<%@ Page Language="C#" MasterPageFile="~/MasterPages/FormDetail.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="GF101000.aspx.cs" Inherits="Page_GF101000" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPages/FormDetail.master" %>

<asp:Content ID="cont1" ContentPlaceHolderID="phDS" Runat="Server">
	<px:PXDataSource ID="ds" runat="server" Visible="True" Width="100%"
        TypeName="GF.GFFormBuilder"
        PrimaryView="Header">
		<CallbackCommands>
            <px:PXDSCallbackCommand CommitChanges="True" Name="moveDown" Visible="False" />
            <px:PXDSCallbackCommand CommitChanges="True" Name="moveUp" Visible="False" />
		</CallbackCommands>
	</px:PXDataSource>
</asp:Content>
<asp:Content ID="cont2" ContentPlaceHolderID="phF" Runat="Server">
	<px:PXFormView ID="form" runat="server" DataSourceID="ds" DataMember="Header" Width="100%" Height="100px" AllowAutoHide="false">
		<Template>
			<px:PXLayoutRule ID="PXLayoutRule1" runat="server" StartRow="True"/>
            <px:PXTextEdit ID="selDataTypeID" runat="server" DataField="UserDefDataCD" CommitChanges="True"/>
            <px:PXTextEdit ID="txtHeaderDesc" DataField="Description" runat="server"  />
            <px:PXTextEdit ID="txtSiteMapID" DataField="SiteMapID" runat="server"  />
		</Template>
	</px:PXFormView>
</asp:Content>
<asp:Content ID="cont3" ContentPlaceHolderID="phG" Runat="Server">
	<px:PXGrid ID="grid" runat="server" DataSourceID="ds" Width="100%" Height="150px" SkinID="Details" AllowAutoHide="false">
		<Levels>
			<px:PXGridLevel DataMember="Details">
			    <Columns>
                    <px:PXGridColumn DataField="DataElementName" />
                    <px:PXGridColumn DataField="DataElementType" Type="DropDownList" />
                    <px:PXGridColumn DataField="ControlType" Type="DropDownList" />
			    </Columns>
			</px:PXGridLevel>
		</Levels>
		<AutoSize Container="Window" Enabled="True" MinHeight="150" />
		<ActionBar >
			<CustomItems>
                <px:PXToolBarButton CommandName="moveUp" CommandSourceID="ds" DependOnGrid="grid">
                    <AutoCallBack>
                        <Behavior CommitChanges="True" PostData="Page" />
                    </AutoCallBack>
                </px:PXToolBarButton>
                <px:PXToolBarButton CommandName="moveDown" CommandSourceID="ds" DependOnGrid="grid">
                    <AutoCallBack>
                        <Behavior CommitChanges="True" PostData="Page" />
                    </AutoCallBack>
                </px:PXToolBarButton>
            </CustomItems>
		</ActionBar>
	</px:PXGrid>
</asp:Content>