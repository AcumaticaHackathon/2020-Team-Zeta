using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GF.DAC;
using PX.Data;
using PX.SiteMap.Graph;
using PX.SiteMap.DAC;
using PX.Web.UI;

namespace GF
{
    public class GFFormBuilder : PXGraph<GFFormBuilder, CSUserDefDataHeader>
    {
        public PXSelect<CSUserDefDataHeader> Header;

        public PXSelect<CSUserDefDataDetail,
            Where<CSUserDefDataDetail.userDefDataID, Equal<Current<CSUserDefDataHeader.userDefDataID>>>, 
            OrderBy<Asc<CSUserDefDataDetail.sequenceNo>>> Details;
        public delegate void PersistDelegate();
        [PXOverride]
        public void _(Events.RowPersisting<CSUserDefDataHeader> e)
        {
            var siteMapGraph = PXGraph.CreateInstance<SiteMapMaint>();
            var header = Header.Current;
            foreach (CSUserDefDataDetail detail in Details.Select())
            {
                var siteMapRow = new SiteMap()
                {
                    ScreenID = detail.DataElementName,
                    Url = $"~/Pages/CS/{detail.DataElementName}.aspx",
                    Title = header.Description
                };
                siteMapGraph.SiteMap.Insert(siteMapRow);
            }
            siteMapGraph.Actions.PressSave();
        }

        public PXAction<CSUserDefDataHeader> moveUp;
        [PXButton(CommitChanges = true)]
        [PXUIField(DisplayName = "Move Up")]

        protected virtual void MoveUp()
        {
            var row = Details.Current as CSUserDefDataDetail;
            var rowPrev = Details.Select().RowCast<CSUserDefDataDetail>().FirstOrDefault(x => x.SequenceNo == (row.SequenceNo - 1));
            if (rowPrev == null)
                return;
            rowPrev.SequenceNo = rowPrev.SequenceNo + 1;
            row.SequenceNo = row.SequenceNo - 1;
            Details.Update(rowPrev);
            Details.Update(row);
            Actions.PressSave();
        }

        public PXAction<CSUserDefDataHeader> moveDown;
        [PXButton(CommitChanges = true)]
        [PXUIField(DisplayName = "Move Down")]

        protected virtual void MoveDown()
        {
            var row = Details.Current as CSUserDefDataDetail;
            var rowNext = Details.Select().RowCast<CSUserDefDataDetail>().FirstOrDefault(x => x.SequenceNo == (row.SequenceNo + 1));
            if (rowNext == null)
                return;
            rowNext.SequenceNo = rowNext.SequenceNo - 1;
            row.SequenceNo = row.SequenceNo + 1;
            Details.Update(rowNext);
            Details.Update(row);
            Actions.PressSave();
        }

        public PXAction<CSUserDefDataHeader> openScreen;
        [PXButton()]
        [PXUIField(DisplayName = "Open Screen")]
        protected virtual void OpenScreen()
        {
            var row = Header.Current as CSUserDefDataHeader;
            if (row is null || string.IsNullOrEmpty(row.SiteMapID)) return;
            throw new PXRedirectByScreenIDException(row.SiteMapID, PXBaseRedirectException.WindowMode.NewWindow);
        }

        protected virtual void _(Events.RowInserted<CSUserDefDataDetail> e)
        {
            e.Row.SequenceNo = Details.Select().FirstTableItems.Count() - 1;
        }
    }
}
