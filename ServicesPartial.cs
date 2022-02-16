using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageSchool
{
    partial class Services
    {
        public bool IsDiscountExist { get => discount > 0; }
        public double CostWithDoscount { get => (double)cost * (1 - (double)discount); }
        public double DurationInMinute { get => (double)duration / 60; }
        public string DisountPercent { get
            {
                if (discount == 0)
                {
                    return "";
                }
                else 
                {
                    return "*скидка " + (double)discount * 100 + "%";
                } 
                
            }
        }
                
    }
}
