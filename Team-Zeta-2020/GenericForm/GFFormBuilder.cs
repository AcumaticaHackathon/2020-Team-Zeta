using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GF.DAC;
using PX.Data;

namespace GF
{
    public class GFFormBuilder : PXGraph<GFFormBuilder, CSUserDefDataHeader>
    {
        public PXSelect<CSUserDefDataHeader> Header;

        public PXSelect<CSUserDefDataDetail,
            Where<CSUserDefDataDetail.userDefDataID, Equal<Current<CSUserDefDataHeader.userDefDataID>>>> Details;


    }
}
