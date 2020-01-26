using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GF.DAC;
using PX.Data;

namespace GF
{
    public class GFFormSaver : PXGraph<GFFormSaver>
    {
        public PXSave<CSMyAnswers> Save;
        public PXSelect<CSMyAnswers> Items;
    }
}
