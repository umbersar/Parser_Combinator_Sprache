using sprache_siteData_NT_Model;
using Sprache;
using System;

namespace sprache_siteData_NT_Grammar {
    public static class NT_Site_Data_File_Grammar {
        public static Parser<char> Comma =
             Parse.Char(',').Token();

        public static Parser<string> Number =
            Parse.Number.Text().Token();

        public static Parser<string> Decimal =
            Parse.Decimal.Text().Token();

        //reads quoted text but would not read empty string. So it enforces a column to have a value.
        public static Parser<string> QuotedText =
            (from lquot in Parse.Char('"')
             from content in Parse.CharExcept('"').Many().Text()
             from rquot in Parse.Char('"')
             select content).Token();

        public static Parser<string> QuotedText_WithEmptyStrings =
            QuotedText.Or(Parse.String(string.Empty).Text().Token());

        public static Parser<string> Number_WithEmptyStrings =
            Number.Or(Parse.String(string.Empty).Text().Token());

        public static Parser<IOption<string>> QuotedText_WithEmptyStrings_Nullable =
            QuotedText.Or(Parse.String(string.Empty).Text()).Optional();

        public static Parser<string> SIGNED_DECIMAL_Parser =
            from sign in Parse.Char('-').Optional()
            from decimalNum in Parse.Decimal.Text().Token()
            select ((sign.IsDefined ? -1 : 1) * decimal.Parse(decimalNum)).ToString();

        public static Parser<string> SIGNED_DECIMAL_OrNULL_Parser =
            SIGNED_DECIMAL_Parser.Or(Parse.String("NULL").Text()).Token();

        public static Parser<string> SIGNED_DECIMAL_OrEmptyString_Parser =
            SIGNED_DECIMAL_Parser.Or(Parse.String(string.Empty).Text()).Token();

        internal static Parser<string> ID_Parser = Number;//Parse.Number.Text().Token();
        internal static Parser<string> SURVEY_ID_Parser = Number;// Parse.Number.Text().Token();
        internal static Parser<string> NEW_LINE_Parser = Parse.LineEnd.Text().Token();
        public static Parser<string> SITE_NO_Parser = QuotedText;//SITE_ID has chars as well as numbers in the associated string


        //public static Parser<string> PHOTO_FILMNUMBER_Parser = QuotedText;//PHOTO_FILMNUMBER has chars as well as numbers in the associated string
        //public static Parser<IOption<string>> PHOTO_FILMNUMBER_Parser = QuotedText_WithEmptyStrings_Nullable;//PHOTO_FILMNUMBER has chars as well as numbers in the associated string

        public static Parser<string> PHOTO_FILMNUMBER_Parser = QuotedText_WithEmptyStrings;//PHOTO_FILMNUMBER has chars as well as numbers in the associated string        
        public static Parser<string> PHOTO_YEAR_Parser = QuotedText_WithEmptyStrings;//PHOTO_YEAR has chars as well as numbers in the associated string
        public static Parser<string> PHOTO_RUN_Parser = QuotedText_WithEmptyStrings;//PHOTO_RUN has chars as well as numbers in the associated string
        public static Parser<string> PHOTO_FRAMENUMBER_Parser = QuotedText_WithEmptyStrings;//PHOTO_FRAMENUMBER has chars as well as numbers in the associated string
        public static Parser<string> PHOTO_REFEAST_Parser = Number_WithEmptyStrings;//PHOTO_REFEAST has chars as well as numbers in the associated string
        public static Parser<string> PHOTO_REFNORTH_Parser = Number_WithEmptyStrings;//PHOTO_REFNORTH has chars as well as numbers in the associated string
        public static Parser<string> LANDUSE_Parser = QuotedText_WithEmptyStrings;//LANDUSE has chars as well as numbers in the associated string


        public static Parser<string> MONTH_Parser =
            from month in Parse.String("JAN").Or(Parse.String("FEB")).Or(Parse.String("MAR"))
            .Or(Parse.String("APR")).Or(Parse.String("MAY")).Or(Parse.String("JUN")).Or(Parse.String("JUL")).Or(Parse.String("AUG"))
                .Or(Parse.String("SEP")).Or(Parse.String("OCT")).Or(Parse.String("NOV")).Or(Parse.String("DEC")).Text().Token()
            select month;


        public static Parser<string> DATE_Parser =
            from day in Number//Parse.Number.Text().Token()
            from s1 in Parse.Char('/')
            from month in MONTH_Parser //this could have been implemented as Or'ed string based on month names
                                       //from month in Parse.CharExcept('/').Many()
            from s2 in Parse.Char('/')
            from year in Number//Parse.Number.Text().Token()
            select day + s1 + month + s2 + year;

        public static Parser<string> DATE_ENTERED_Parser =
            DATE_Parser;

        public static Parser<string> DATE_DESCRIBED_Parser =
            DATE_Parser.Or(Parse.String(string.Empty).Text());

        public static Parser<string> LANDUSE_LUMP_2007_Parser =
            QuotedText_WithEmptyStrings;

        public static Parser<string> GDA94_LATITUDE_Parser =
            SIGNED_DECIMAL_OrEmptyString_Parser;

        public static Parser<string> GDA94_LONGITUDE_Parser =
            SIGNED_DECIMAL_OrEmptyString_Parser;


        public static Parser<string> ANALYTICAL_SITE_Parser =
            QuotedText_WithEmptyStrings;

        public static Parser<string> ANALYTICAL_SITE_TYPE_Parser =
            QuotedText_WithEmptyStrings;

        public static Parser<string> CONSIDERED_ACCURACY_Parser =
            QuotedText_WithEmptyStrings;

        public static Parser<string> POSITIONAL_METHOD_Parser =
            QuotedText_WithEmptyStrings;

        public static Parser<string> PHOTO_REFERENCE_Parser =
            QuotedText_WithEmptyStrings;

        //public static Parser<DateTime> DATE_ENTERED_Parser =
        //    from day in Parse.Number
        //    from s1 in Parse.Char('/')
        //    from month in Parse.Number
        //    from s2 in Parse.Char('/')
        //    from year in Parse.Number
        //    select new DateTime(int.Parse(year), int.Parse(month), int.Parse(day));


        //MDSYS.SDO_GEOMETRY(2001,8311,MDSYS.SDO_POINT_TYPE(131.312355,-12.596545,NULL),NULL,NULL)
        public static Parser<Site_Data_Geometry> GEOMETRY_Parser =
           from sdo_geom_string in Parse.String("MDSYS.SDO_GEOMETRY").Text()//MDSYS.SDO_GEOMETRY

           from lparentheses1 in Parse.Char('(').Token()//(

           from firstNumber in Number//Parse.Number.Text().Token()//2001
           from comma1 in Comma//,

           from secondNumber in Number//Parse.Number.Text().Token()//8311
           from comma2 in Comma//,

           from sdo_point_string in Parse.String("MDSYS.SDO_POINT_TYPE").Text()//MDSYS.SDO_POINT_TYPE
           from lparentheses2 in Parse.Char('(').Token()//(

           from firstDecimal in SIGNED_DECIMAL_Parser//131.312355
           from comma3 in Comma//,

           from secondDecimal in SIGNED_DECIMAL_Parser//-12.596545
           from comma4 in Comma//,

           from thirdDecimal in SIGNED_DECIMAL_OrNULL_Parser//NULL
           from rparentheses1 in Parse.Char(')').Token()//)
           from comma5 in Comma//,

           from fourthDecimal in SIGNED_DECIMAL_OrNULL_Parser//NULL
           from comma6 in Comma//,

           from fifthDecimal in SIGNED_DECIMAL_OrNULL_Parser//NULL

           from rparentheses2 in Parse.Char(')').Token()

               //select sdo_geom_string + lparentheses1 + firstNumber + comma1 + secondNumber + comma2 + sdo_point_string + lparentheses2
               //         + firstDecimal + comma3 + secondDecimal + comma4 + thirdDecimal + rparentheses1 + comma5 + fourthDecimal + comma6 + fifthDecimal + rparentheses2;

           select new Site_Data_Geometry() {
               sdo_geom_string = sdo_geom_string,
               firstNumber = int.Parse(firstNumber),
               secondNumber = int.Parse(secondNumber),
               sdo_point_string = sdo_point_string,
               firstDecimal = decimal.Parse(firstDecimal),
               secondDecimal = decimal.Parse(secondDecimal),
               thirdDecimal = thirdDecimal,
               fourthDecimal = fourthDecimal,
               fifthDecimal = fifthDecimal
           };

        public static Parser<Site_Data_Header> Site_File_Header_Parser =
                from id in QuotedText
                from comma1 in Comma
                from survey_id in QuotedText
                from comma2 in Comma
                from site_no in QuotedText
                from comma3 in Comma
                from date_entered in QuotedText
                from comma4 in Comma

                from photo_filmnumber in QuotedText
                from comma5 in Comma
                from photo_year in QuotedText
                from comma6 in Comma
                from photo_run in QuotedText
                from comma7 in Comma

                from photo_framenumber in QuotedText
                from comma8 in Comma
                from photo_refeast in QuotedText
                from comma9 in Comma
                from photo_refnorth in QuotedText
                from comma10 in Comma
                from landuse in QuotedText
                from comma11 in Comma

                from geometry in QuotedText
                from comma111 in Comma

                from date_described in QuotedText
                from comma12 in Comma
                from landuse_lump_2007 in QuotedText
                from comma13 in Comma
                from gda94_latitude in QuotedText
                from comma14 in Comma
                from gda94_longitude in QuotedText
                from comma15 in Comma
                from analytical_site in QuotedText
                from comma16 in Comma
                from analytical_site_type in QuotedText
                from comma17 in Comma
                from considered_accuracy in QuotedText
                from comma18 in Comma
                from positional_method in QuotedText
                from comma19 in Comma
                from photo_reference in QuotedText

                from newLine in NEW_LINE_Parser.Optional()
                    /*(photo_filmnumber.IsDefined ? photo_filmnumber.Get() : string.Empty)*/
                select new Site_Data_Header(id, survey_id, site_no, date_entered, photo_filmnumber
                    , photo_year, photo_run, photo_framenumber, photo_refeast, photo_refnorth, landuse, geometry, date_described, landuse_lump_2007, gda94_latitude,
                    gda94_longitude, analytical_site, analytical_site_type, considered_accuracy, positional_method, photo_reference);

        public static Parser<Site_Data_Row> Site_Data_Row_Parser =
            from id in ID_Parser
            from comma1 in Comma
            from survey_id in SURVEY_ID_Parser
            from comma2 in Comma
            from site_no in SITE_NO_Parser
            from comma3 in Comma
            from date_entered in DATE_ENTERED_Parser
            from comma4 in Comma

            from photo_filmnumber in PHOTO_FILMNUMBER_Parser
            from comma5 in Comma
            from photo_year in PHOTO_YEAR_Parser
            from comma6 in Comma
            from photo_run in PHOTO_RUN_Parser
            from comma7 in Comma

            from photo_framenumber in PHOTO_FRAMENUMBER_Parser
            from comma8 in Comma
            from photo_refeast in PHOTO_REFEAST_Parser
            from comma9 in Comma
            from photo_refnorth in PHOTO_REFNORTH_Parser
            from comma10 in Comma
            from landuse in LANDUSE_Parser
            from comma11 in Comma

            from geometry in GEOMETRY_Parser
            from comma111 in Comma

            from date_described in DATE_DESCRIBED_Parser
            from comma12 in Comma
            from landuse_lump_2007 in LANDUSE_LUMP_2007_Parser
            from comma13 in Comma
            from gda94_latitude in GDA94_LATITUDE_Parser
            from comma14 in Comma
            from gda94_longitude in GDA94_LONGITUDE_Parser
            from comma15 in Comma
            from analytical_site in ANALYTICAL_SITE_Parser
            from comma16 in Comma
            from analytical_site_type in ANALYTICAL_SITE_TYPE_Parser
            from comma17 in Comma
            from considered_accuracy in CONSIDERED_ACCURACY_Parser
            from comma18 in Comma
            from positional_method in POSITIONAL_METHOD_Parser
            from comma19 in Comma
            from photo_reference in PHOTO_REFERENCE_Parser

            from newLine in NEW_LINE_Parser.Optional()
                /*(photo_filmnumber.IsDefined ? photo_filmnumber.Get() : string.Empty)*/
            select new Site_Data_Row(int.Parse(id), int.Parse(survey_id), site_no, date_entered, photo_filmnumber
                , photo_year, photo_run, photo_framenumber, photo_refeast, photo_refnorth, landuse, geometry, date_described, landuse_lump_2007, gda94_latitude,
                gda94_longitude, analytical_site, analytical_site_type, considered_accuracy, positional_method, photo_reference);

        internal static Parser<NT_Site_Data_File> NT_Site_Data_File_Parser =
            from header in Site_File_Header_Parser
            from data_Rows in Site_Data_Row_Parser.AtLeastOnce()
            select new NT_Site_Data_File(header, data_Rows);

        //order matters. static members are initialized top-to-bottom. So the basic building block that is referenced elsewhere has to be on top of where it is referenced.
        public static NT_Site_Data_File Parse_NT_Site_Data_File(string fileContents) {
            return NT_Site_Data_File_Parser.End().Parse(fileContents);
        }

    }
}
