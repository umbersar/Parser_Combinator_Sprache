using System;
using System.Collections.Generic;
using System.Text;

namespace sprache_siteData_NT_Model {

    public enum NT_Site_DataRow_Token {

    }
    public class Site_Data_Row {
        int id;
        int survey_id;
        string site_no;
        string date_entered;

        string photo_filmnumber;
        string photo_year;
        string photo_run;
        string photo_framenumber;
        string photo_refeast;
        string photo_refnorth;
        string landuse;

        Site_Data_Geometry geometry;

        public Site_Data_Row(int iD, int sURVEY_ID, string sITE_NO, string dATE_ENTERED, string pHOTO_FILMNUMBER, string pHOTO_YEAR, string pHOTO_RUN, string pHOTO_FRAMENUMBER,
                            string pHOTO_REFEAST, string pHOTO_REFNORTH, string lANDUSE, Site_Data_Geometry gEOMETRY, string dATE_DESCRIBED, string lANDUSE_LUMP_2007, string gDA94_LATITUDE,
                            string gDA94_LONGITUDE, string aNALYTICAL_SITE, string aNALYTICAL_SITE_TYPE, string cONSIDERED_ACCURACY, string pOSITIONAL_METHOD, string pHOTO_REFERENCE) {
            ID = iD;
            SURVEY_ID = sURVEY_ID;
            SITE_NO = sITE_NO;
            GEOMETRY = gEOMETRY;
            DATE_ENTERED = dATE_ENTERED;
            PHOTO_FILMNUMBER = pHOTO_FILMNUMBER;
            PHOTO_YEAR = pHOTO_YEAR;
            PHOTO_RUN = pHOTO_RUN;
            PHOTO_FRAMENUMBER = pHOTO_FRAMENUMBER;
            PHOTO_REFEAST = pHOTO_REFEAST;
            PHOTO_REFNORTH = pHOTO_REFNORTH;
            LANDUSE = lANDUSE;
            DATE_DESCRIBED = dATE_DESCRIBED;
            LANDUSE_LUMP_2007 = lANDUSE_LUMP_2007;
            GDA94_LATITUDE = gDA94_LATITUDE;
            GDA94_LONGITUDE = gDA94_LONGITUDE;
            ANALYTICAL_SITE = aNALYTICAL_SITE;
            ANALYTICAL_SITE_TYPE = aNALYTICAL_SITE_TYPE;
            CONSIDERED_ACCURACY = cONSIDERED_ACCURACY;
            POSITIONAL_METHOD = pOSITIONAL_METHOD;
            PHOTO_REFERENCE = pHOTO_REFERENCE;
        }

        public int ID { get => id; set => id = value; }
        public int SURVEY_ID { get => survey_id; set => survey_id = value; }
        public string SITE_NO { get => site_no; set => site_no = value; }
        public Site_Data_Geometry GEOMETRY { get => geometry; set => geometry = value; }
        public string DATE_ENTERED { get => date_entered; set => date_entered = value; }
        public string PHOTO_FILMNUMBER { get => photo_filmnumber; set => photo_filmnumber = value; }
        public string PHOTO_YEAR { get => photo_year; set => photo_year = value; }
        public string PHOTO_RUN { get => photo_run; set => photo_run = value; }
        public string PHOTO_FRAMENUMBER { get => photo_framenumber; set => photo_framenumber = value; }
        public string PHOTO_REFEAST { get => photo_refeast; set => photo_refeast = value; }
        public string PHOTO_REFNORTH { get => photo_refnorth; set => photo_refnorth = value; }
        public string LANDUSE { get => landuse; set => landuse = value; }
        public string DATE_DESCRIBED { get; set; }
        public string LANDUSE_LUMP_2007 { get; set; }
        public string GDA94_LATITUDE { get; set; }
        public string GDA94_LONGITUDE { get; set; }
        public string ANALYTICAL_SITE { get; set; }
        public string ANALYTICAL_SITE_TYPE { get; set; }
        public string CONSIDERED_ACCURACY { get; set; }
        public string POSITIONAL_METHOD { get; set; }
        public string PHOTO_REFERENCE { get; set; }

        public override string ToString() {
            string site_data_row = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20}",
                              ID, SURVEY_ID, SITE_NO, DATE_ENTERED, PHOTO_FILMNUMBER, PHOTO_YEAR, PHOTO_RUN, PHOTO_FRAMENUMBER,
                              PHOTO_REFEAST, PHOTO_REFNORTH, LANDUSE, GEOMETRY, DATE_DESCRIBED, LANDUSE_LUMP_2007,
                              GDA94_LATITUDE, GDA94_LONGITUDE, ANALYTICAL_SITE, ANALYTICAL_SITE_TYPE, CONSIDERED_ACCURACY,
                              POSITIONAL_METHOD, PHOTO_REFERENCE);
            return site_data_row;
        }
    }
}
