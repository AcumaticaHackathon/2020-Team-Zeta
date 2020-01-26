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
            Where<CSUserDefDataDetail.userDefDataID, Equal<Current<CSUserDefDataHeader.userDefDataID>>>> Details;
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


        protected virtual void _(Events.RowInserted<CSUserDefDataDetail> e)
        {
            e.Row.SequenceNo = Details.Select().FirstTableItems.Count() - 1;
        }
    }
}
