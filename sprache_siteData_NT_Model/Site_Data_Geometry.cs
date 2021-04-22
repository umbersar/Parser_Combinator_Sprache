using System;
using System.Collections.Generic;
using System.Text;

namespace sprache_siteData_NT_Model {
    public class Site_Data_Geometry {
        public string sdo_geom_string { get; set; }
        public int firstNumber { get; set; }
        public int secondNumber { get; set; }
        public string sdo_point_string { get; set; }
        public decimal firstDecimal { get; set; }
        public decimal secondDecimal { get; set; }
        public string thirdDecimal { get; set; }
        public string fourthDecimal { get; set; }
        public string fifthDecimal { get; set; }

        //this is where i replace the comma separator with + or it could be to anything else.
        public override string ToString() {
            string geom = string.Format("{0}({1}+{2}+{3}({4}+{5}+{6})+{7}+{8})",
                sdo_geom_string, firstNumber, secondNumber, sdo_point_string, firstDecimal, secondDecimal, thirdDecimal, fourthDecimal, fifthDecimal);

            return geom;
        }
    }
}
