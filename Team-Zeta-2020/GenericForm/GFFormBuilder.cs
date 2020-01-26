using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GF.DAC;
using PX.Data;
using PX.SiteMap.DAC;
using PX.SiteMap.Graph;

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
        public void Persist(Action baseMethod)
        {
            var siteMapGraph = PXGraph.CreateInstance<SiteMapMaint>();
            foreach(CSUserDefDataDetail detail in Details.Select())
            {
                var siteMapRow = new SiteMap()
                {
                    ScreenID = detail.DataElementName,
                    Url = $"~/Pages/CS/{detail.DataElementName}.aspx"
                };
                siteMapGraph.SiteMap.Insert(siteMapRow);
            }
        }

        public PXAction<CSUserDefDataHeader> moveRow;
        [PXButton]
        [PXUIField(DisplayName = "Move Up")]

        protected virtual void MoveRow()
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
        [PXButton]
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

        protected virtual void _(Events.RowInserted<CSUserDefDataDetail> e)
        {
            e.Row.SequenceNo = Details.Select().FirstTableItems.Count() - 1;
        }
    }
}
