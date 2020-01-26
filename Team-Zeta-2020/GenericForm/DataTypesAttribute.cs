using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PX.Data;

namespace GenericForm
{
    public class DataTypesAttribute : PXStringListAttribute
    {
        public const string String = "ST";
        public const string Int = "IN";
        public const string Bool = "BL";
        public const string Datetime = "DT";
        public const string Dec = "DE";


        public DataTypesAttribute() : base(
            new [] { String, Int, Bool, Datetime, Dec },
            new [] { "String", "Integer", "Boolean", "DateTime", "Decimal" })
        {

        }
    }
}
