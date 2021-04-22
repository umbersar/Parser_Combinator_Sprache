using Microsoft.VisualStudio.TestTools.UnitTesting;
using sprache_siteData_NT_Grammar;
using Sprache;
using System.IO;
using sprache_siteData_NT_Model;
using System.Collections.Generic;
using System.Linq;

namespace sprache_siteData_NT_Tests {
    [TestClass]
    public class ParsingTests {
        [TestMethod]
        public void QuotedTextTest() {
            string testStr = "\"Hello, world!\"";
            string retVal;

            retVal = NT_Site_Data_File_Grammar.QuotedText.End().Parse(testStr);
            Assert.AreEqual("Hello, world!", retVal);


            //can't match with empty string as well and throws exception
            Assert.ThrowsException<Sprache.ParseException>(() => NT_Site_Data_File_Grammar.QuotedText.End().Parse(""));

            //match with empty string as well but 
            retVal = NT_Site_Data_File_Grammar.QuotedText_WithEmptyStrings.End().Parse("");
            Assert.AreEqual("", retVal);
            retVal = NT_Site_Data_File_Grammar.QuotedText_WithEmptyStrings.End().Parse(testStr);
            Assert.AreEqual("Hello, world!", retVal);
            //the following throws an: System.ArgumentNullException: Value cannot be null. (Parameter 'input')
            //that tells us the that the Parset cannot accept null.  
            Assert.ThrowsException<System.ArgumentNullException>(() => NT_Site_Data_File_Grammar.QuotedText_WithEmptyStrings.End().Parse(null));


            //i wrote this thinking to handle null scenarios. But we cannot pass null to Parser as it does not work with null. 
            IOption<string> retVal_optional = NT_Site_Data_File_Grammar.QuotedText_WithEmptyStrings_Nullable.End().Parse(testStr);
            Assert.AreEqual("Hello, world!", retVal);

            //Since the input to parser has to be a string, we cannot differentitate between embedded string and nothing'ness. Ex: lets take 3 columns with the values as follows
            // "1,\"\",3" cannot be differentiated from  "1,,3"
            //the second column value is parsed as empty string either way.
        }

        [TestMethod]
        public void Site_No_Test() {
            var retVal = NT_Site_Data_File_Grammar.DATE_ENTERED_Parser.End().Parse("13/OCT/11");
            Assert.AreEqual(retVal, "13/OCT/11");
        }

        [TestMethod]
        public void Site_Data_Row_Parser_Test() {
            string testStr = "554972,554888,\"5\",13/OCT/11,\"CAG4008\",\"1963\",\"24\",\"5137\",,,\"\",MDSYS.SDO_GEOMETRY(2001,8311,MDSYS.SDO_POINT_TYPE(131.312355,-12.596545,NULL),NULL,NULL),30/MAY/75,\"6.5\",,,\"Non - Analytical Site\",\"\",\"Accuracy estimated to be within a radius of 30 - 100 metres\",\"Pre GPS(Marked on survey working map)\",\"Darwin - Adelaide River\"";


            var retVal = NT_Site_Data_File_Grammar.Site_Data_Row_Parser.End().Parse(testStr);
            Assert.AreEqual(554972, retVal.ID);
            Assert.AreEqual(554888, retVal.SURVEY_ID);
            Assert.AreEqual("5", retVal.SITE_NO);
            Assert.AreEqual("13/OCT/11", retVal.DATE_ENTERED);
            Assert.AreEqual("CAG4008", retVal.PHOTO_FILMNUMBER);
            Assert.AreEqual("1963", retVal.PHOTO_YEAR);
            Assert.AreEqual("24", retVal.PHOTO_RUN);
            Assert.AreEqual("5137", retVal.PHOTO_FRAMENUMBER);
            Assert.AreEqual("", retVal.PHOTO_REFEAST);
            Assert.AreEqual("", retVal.PHOTO_REFNORTH);
            Assert.AreEqual("", retVal.LANDUSE);

            Assert.AreEqual("MDSYS.SDO_GEOMETRY(2001+8311+MDSYS.SDO_POINT_TYPE(131.312355+-12.596545+NULL)+NULL+NULL)", retVal.GEOMETRY.ToString());

            Assert.AreEqual("30/MAY/75", retVal.DATE_DESCRIBED);
            Assert.AreEqual("6.5", retVal.LANDUSE_LUMP_2007);
            Assert.AreEqual("", retVal.GDA94_LATITUDE);
            Assert.AreEqual("", retVal.GDA94_LONGITUDE);
            Assert.AreEqual("Non - Analytical Site", retVal.ANALYTICAL_SITE);
            Assert.AreEqual("", retVal.ANALYTICAL_SITE_TYPE);
            Assert.AreEqual("Accuracy estimated to be within a radius of 30 - 100 metres", retVal.CONSIDERED_ACCURACY);
            Assert.AreEqual("Pre GPS(Marked on survey working map)", retVal.POSITIONAL_METHOD);
            Assert.AreEqual("Darwin - Adelaide River", retVal.PHOTO_REFERENCE);


            //test newline at the end of row..when a file is read, each row ends with newline char.
            testStr = "554972,554888,\"5\",13/OCT/11,\"CAG4008\",\"1963\",\"24\",\"5137\",,,\"\",MDSYS.SDO_GEOMETRY(2001,8311,MDSYS.SDO_POINT_TYPE(131.312355,-12.596545,NULL),NULL,NULL),30/MAY/75,\"6.5\",,,\"Non - Analytical Site\",\"\",\"Accuracy estimated to be within a radius of 30 - 100 metres\",\"Pre GPS(Marked on survey working map)\",\"Darwin - Adelaide River\"\r\n";
            retVal = NT_Site_Data_File_Grammar.Site_Data_Row_Parser.End().Parse(testStr);
            Assert.AreEqual(554972, retVal.ID);
            Assert.AreEqual(554888, retVal.SURVEY_ID);
            Assert.AreEqual("5", retVal.SITE_NO);
            Assert.AreEqual("13/OCT/11", retVal.DATE_ENTERED);
            Assert.AreEqual("CAG4008", retVal.PHOTO_FILMNUMBER);
            Assert.AreEqual("1963", retVal.PHOTO_YEAR);
            Assert.AreEqual("24", retVal.PHOTO_RUN);
            Assert.AreEqual("5137", retVal.PHOTO_FRAMENUMBER);
            Assert.AreEqual("", retVal.PHOTO_REFEAST);
            Assert.AreEqual("", retVal.PHOTO_REFNORTH);
            Assert.AreEqual("", retVal.LANDUSE);

            Assert.AreEqual("MDSYS.SDO_GEOMETRY(2001+8311+MDSYS.SDO_POINT_TYPE(131.312355+-12.596545+NULL)+NULL+NULL)", retVal.GEOMETRY.ToString());

            Assert.AreEqual("30/MAY/75", retVal.DATE_DESCRIBED);
            Assert.AreEqual("6.5", retVal.LANDUSE_LUMP_2007);
            Assert.AreEqual("", retVal.GDA94_LATITUDE);
            Assert.AreEqual("", retVal.GDA94_LONGITUDE);
            Assert.AreEqual("Non - Analytical Site", retVal.ANALYTICAL_SITE);
            Assert.AreEqual("", retVal.ANALYTICAL_SITE_TYPE);
            Assert.AreEqual("Accuracy estimated to be within a radius of 30 - 100 metres", retVal.CONSIDERED_ACCURACY);
            Assert.AreEqual("Pre GPS(Marked on survey working map)", retVal.POSITIONAL_METHOD);

            testStr = "188587,185010,\"62\",17/JUL/02,\"\",\"1980\",\"52\",\"6603\",102,115,\"\",MDSYS.SDO_GEOMETRY(2001,8311,MDSYS.SDO_POINT_TYPE(131.3980166668,-13.6860416667,NULL),NULL,NULL),10/JUN/81,\"2.1\",-13.686,131.398,\"Non-Analytical Site\",\"\",\"Accuracy estimated to be within a radius of 30-100 metres\",\"Pre GPS (Marked on an aerial photograph)\",\"Douglas - Tipperary\"";
            retVal = NT_Site_Data_File_Grammar.Site_Data_Row_Parser.End().Parse(testStr);
            Assert.AreEqual(retVal.GDA94_LONGITUDE, "131.398");
            Assert.AreEqual(retVal.GDA94_LATITUDE, "-13.686");
        }

        [TestMethod]
        public void NT_Site_Data_File_Parser_Test() {
            //var f = File.ReadAllText(".\\simple.csv");
            var f = File.ReadAllText(".\\SITE.csv");//does not work because readin header is not supported yet
            //var f = File.ReadAllText(".\\SITE_Full_without_Header.csv");
            //var f = File.ReadAllText(".\\SITE_small.csv");
            string testStr = f;

            var retVal = NT_Site_Data_File_Grammar.Parse_NT_Site_Data_File(testStr);
            List<Site_Data_Row> rows = retVal.DataRows.ToList();

            Assert.AreEqual(554972, rows[0].ID);
            Assert.AreEqual(554888, rows[0].SURVEY_ID);
            Assert.AreEqual("5", rows[0].SITE_NO);

            Assert.AreEqual(555012, rows[1].ID);
            Assert.AreEqual(554888, rows[1].SURVEY_ID);
            Assert.AreEqual("45", rows[1].SITE_NO);
        }


        [TestMethod]
        public void NT_Site_Data_File_Header_Test() {
            string testStr = "\"ID\",\"SURVEY_ID\",\"SITE_NO\",\"DATE_ENTERED\",\"PHOTO_FILMNUMBER\",\"PHOTO_YEAR\",\"PHOTO_RUN\",\"PHOTO_FRAMENUMBER\",\"PHOTO_REFEAST\",\"PHOTO_REFNORTH\",\"LANDUSE\",\"GEOMETRY\",\"DATE_DESCRIBED\",\"LANDUSE_LUMP_2007\",\"GDA94_LATITUDE\",\"GDA94_LONGITUDE\",\"ANALYTICAL_SITE\",\"ANALYTICAL_SITE_TYPE\",\"CONSIDERED_ACCURACY\",\"POSITIONAL_METHOD\",\"PHOTO_REFERENCE\"";

            var retVal = NT_Site_Data_File_Grammar.Site_File_Header_Parser.End().Parse(testStr);

            Assert.AreEqual("ID", retVal.ID_Col_Header);
            Assert.AreEqual("PHOTO_REFERENCE", retVal.PHOTO_REFERENCE_Col_Header);
        }

        [TestMethod]
        public void NT_Site_Data_File_Parser_writer_Test() {
            //var f = File.ReadAllText(".\\SITE_Full_without_Header.csv");
            var f = File.ReadAllText(".\\SITE.csv");
            string testStr = f;

            var retVal = NT_Site_Data_File_Grammar.Parse_NT_Site_Data_File(testStr);
            List<Site_Data_Row> rows = retVal.DataRows.ToList();
            Assert.AreEqual(554972, rows[0].ID);
            Assert.AreEqual(554888, rows[0].SURVEY_ID);
            Assert.AreEqual("5", rows[0].SITE_NO);

            File.WriteAllText(".\\Serialized_Ste_file.csv", retVal.ToString());
        }


        [TestMethod]
        public void Decimal_Parsing_Test() {
            var a = Parse.Decimal.Text().Token().Parse("111.546");
            Assert.AreEqual(a, "111.546");

            string v = NT_Site_Data_File_Grammar.SIGNED_DECIMAL_Parser.Parse("-111.546");
            Assert.AreEqual(v, "-111.546");

            string decimal_optional = NT_Site_Data_File_Grammar.SIGNED_DECIMAL_OrNULL_Parser.Parse("NULL");
            Assert.AreEqual(decimal_optional, "NULL");
        }

        [TestMethod]
        public void GeometryTest() {

            string geometry = "MDSYS.SDO_GEOMETRY(2001,8311,MDSYS.SDO_POINT_TYPE(131.312355,-12.596545,NULL),NULL,NULL)";
            var retVal = NT_Site_Data_File_Grammar.GEOMETRY_Parser.End().Parse(geometry);
            Assert.AreEqual("MDSYS.SDO_GEOMETRY(2001+8311+MDSYS.SDO_POINT_TYPE(131.312355+-12.596545+NULL)+NULL+NULL)", retVal.ToString());
        }

        [TestMethod]
        public void QuotedText_With_Quotes_Included_Test() {
            Parser<string> QuotedText =
                (from lquot in Parse.Char('"')
                 from content in Parse.AnyChar.Many().Text()
                 //from content in Parse.CharExcept('"').Many().Text()
                 from rquot in Parse.Char('"')
                 select string.Format("\"{0}\"", content)).Token();

            string geometry = "\"SDO_GEOMETRY\"";

            var retVal = QuotedText.End().Parse(geometry);
            Assert.AreEqual(geometry, retVal);
        }

    }
}
