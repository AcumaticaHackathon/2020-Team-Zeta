using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericFormTZ;
using PX.Data;

namespace GenericForm
{
    public class GFFormBuilder : PXGraph<GFFormBuilder, CSUserDefDataHeader>
    {
        public PXSelect<CSUserDefDataHeader> Header;

        public PXSelect<CSUserDefDataDetail,
            Where<CSUserDefDataDetail.userDefDataID, Equal<Current<CSUserDefDataHeader.userDefDataID>>>> Details;


    }
}
