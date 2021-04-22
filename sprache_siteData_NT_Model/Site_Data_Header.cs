using System;
using System.Collections.Generic;
using System.Text;

namespace sprache_siteData_NT_Model {
    public class Site_Data_Header {
        public string ID_Col_Header { get; set; }
        public string SURVEY_ID__Col_Header { get; set; }
        public string SITE_NO_Col_Header { get; set; }
        public string GEOMETRY_Col_Header { get; set; }
        public string DATE_ENTERED_Col_Header { get; set; }
        public string PHOTO_FILMNUMBER_Col_Header { get; set; }
        public string PHOTO_YEAR_Col_Header { get; set; }
        public string PHOTO_RUN_Col_Header { get; set; }
        public string PHOTO_FRAMENUMBER_Col_Header { get; set; }
        public string PHOTO_REFEAST_Col_Header { get; set; }
        public string PHOTO_REFNORTH_Col_Header { get; set; }
        public string LANDUSE_Col_Header { get; set; }
        public string DATE_DESCRIBED_Col_Header { get; set; }
        public string LANDUSE_LUMP_2007_Col_Header { get; set; }
        public string GDA94_LATITUDE_Col_Header { get; set; }
        public string GDA94_LONGITUDE_Col_Header { get; set; }
        public string ANALYTICAL_SITE_Col_Header { get; set; }
        public string ANALYTICAL_SITE_TYPE_Col_Header { get; set; }
        public string CONSIDERED_ACCURACY_Col_Header { get; set; }
        public string POSITIONAL_METHOD_Col_Header { get; set; }
        public string PHOTO_REFERENCE_Col_Header { get; set; }

        public Site_Data_Header(string iD_Col_Header, string sURVEY_ID__Col_Header, string sITE_NO_Col_Header, string gEOMETRY_Col_Header, string dATE_ENTERED_Col_Header, string pHOTO_FILMNUMBER_Col_Header, string pHOTO_YEAR_Col_Header, string pHOTO_RUN_Col_Header, string pHOTO_FRAMENUMBER_Col_Header, string pHOTO_REFEAST_Col_Header, string pHOTO_REFNORTH_Col_Header, string lANDUSE_Col_Header, string dATE_DESCRIBED_Col_Header, string lANDUSE_LUMP_2007_Col_Header, string gDA94_LATITUDE_Col_Header, string gDA94_LONGITUDE_Col_Header, string aNALYTICAL_SITE_Col_Header, string aNALYTICAL_SITE_TYPE_Col_Header, string cONSIDERED_ACCURACY_Col_Header, string pOSITIONAL_METHOD_Col_Header, string pHOTO_REFERENCE_Col_Header) {
            ID_Col_Header = iD_Col_Header;
            SURVEY_ID__Col_Header = sURVEY_ID__Col_Header;
            SITE_NO_Col_Header = sITE_NO_Col_Header;
            GEOMETRY_Col_Header = gEOMETRY_Col_Header;
            DATE_ENTERED_Col_Header = dATE_ENTERED_Col_Header;
            PHOTO_FILMNUMBER_Col_Header = pHOTO_FILMNUMBER_Col_Header;
            PHOTO_YEAR_Col_Header = pHOTO_YEAR_Col_Header;
            PHOTO_RUN_Col_Header = pHOTO_RUN_Col_Header;
            PHOTO_FRAMENUMBER_Col_Header = pHOTO_FRAMENUMBER_Col_Header;
            PHOTO_REFEAST_Col_Header = pHOTO_REFEAST_Col_Header;
            PHOTO_REFNORTH_Col_Header = pHOTO_REFNORTH_Col_Header;
            LANDUSE_Col_Header = lANDUSE_Col_Header;
            DATE_DESCRIBED_Col_Header = dATE_DESCRIBED_Col_Header;
            LANDUSE_LUMP_2007_Col_Header = lANDUSE_LUMP_2007_Col_Header;
            GDA94_LATITUDE_Col_Header = gDA94_LATITUDE_Col_Header;
            GDA94_LONGITUDE_Col_Header = gDA94_LONGITUDE_Col_Header;
            ANALYTICAL_SITE_Col_Header = aNALYTICAL_SITE_Col_Header;
            ANALYTICAL_SITE_TYPE_Col_Header = aNALYTICAL_SITE_TYPE_Col_Header;
            CONSIDERED_ACCURACY_Col_Header = cONSIDERED_ACCURACY_Col_Header;
            POSITIONAL_METHOD_Col_Header = pOSITIONAL_METHOD_Col_Header;
            PHOTO_REFERENCE_Col_Header = pHOTO_REFERENCE_Col_Header;
        }

        public override string ToString() {
            string site_data_header = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20}",
                              ID_Col_Header, SURVEY_ID__Col_Header, SITE_NO_Col_Header, DATE_ENTERED_Col_Header, PHOTO_FILMNUMBER_Col_Header, PHOTO_YEAR_Col_Header, PHOTO_RUN_Col_Header, PHOTO_FRAMENUMBER_Col_Header,
                              PHOTO_REFEAST_Col_Header, PHOTO_REFNORTH_Col_Header, LANDUSE_Col_Header, GEOMETRY_Col_Header, DATE_DESCRIBED_Col_Header, LANDUSE_LUMP_2007_Col_Header,
                              GDA94_LATITUDE_Col_Header, GDA94_LONGITUDE_Col_Header, ANALYTICAL_SITE_TYPE_Col_Header, ANALYTICAL_SITE_TYPE_Col_Header, CONSIDERED_ACCURACY_Col_Header,
                              POSITIONAL_METHOD_Col_Header, PHOTO_REFERENCE_Col_Header);
            return site_data_header;
        }
    }
}
