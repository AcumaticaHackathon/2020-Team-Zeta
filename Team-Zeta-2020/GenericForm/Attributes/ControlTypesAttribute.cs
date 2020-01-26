using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PX.Data;

namespace GF.Attributes
{
    public class ControlTypesAttribute : PXIntListAttribute
    {
        public const int Text = 1;
        public const int Combo = 2;
        public const int CheckBox = 4;
        public const int Datetime = 5;
        public const int MultiSelectCombo = 6;
        public const int GISelector = 7;

        public ControlTypesAttribute() : base(
            new int[] { Text, Combo, MultiSelectCombo, CheckBox, Datetime, GISelector }, 
            new string[] { "Text", "Combo", "Multi Select Combo", "Checkbox", "Datetime", "Selector" })
        {
            
        }
    }
}
