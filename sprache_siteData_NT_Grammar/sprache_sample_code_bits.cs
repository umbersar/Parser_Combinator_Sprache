using Sprache;
using System;
using System.Collections.Generic;
using System.Text;

namespace sprache_siteData_NT_Grammar {
    class sprache_sample_code_bits {
        #region  sample 1
        //public static Parser<string> Array =
        //    from open in OpenBrackets.Named("open bracket")
        //    from items in Literal.Or(Identifier).Or(Array).DelimitedBy(Comma).Optional()
        //    from close in CloseBrackets.Named("close bracket")
        //    select open + (items.IsDefined ? string.Join(", ", items.Get()) : " ") + close;

        //select open + (items.IsDefined? string.Join(", ", items.Get()) : " ") + close;
        //select open + string.Join(", ", items.GetOrElse(new string[0])) + close;
        #endregion

        #region  sample 2. Shows how to return different objects based on condition matched..
        //public static readonly Parser<DateTime> DateTimeParser =
        //    from day in Parse.Number
        //    from s1 in Parse.Char('/')
        //    from month in Parse.Number
        //    from s2 in Parse.Char('/')
        //    from year in Parse.Number
        //    select new DateTime(int.Parse(year), int.Parse(month), int.Parse(day));

        //public static readonly Parser<DataFilterEntity> CustomParser =
        //    from a1 in Parse.String("custom").Token()
        //    from fromDateTime in DateTimeParser.Token()
        //    from toDateTime in DateTimeParser.Token()
        //    select new DataFilterEntity(fromDateTime.ToShortDateString() + " -> " + toDateTime.ToShortDateString());

        //public static readonly Parser<DataFilterEntity> TimeFilter =
        //    Parse.String("today").Return(DataFilterEntity.Today)
        //        .Or(Parse.String("yesterday").Return(DataFilterEntity.Yesterday)
        //        .Or(Parse.String("last week").Return(DataFilterEntity.LastWeek)
        //        .Or(Parse.String("last month").Return(DataFilterEntity.LastMonth)
        //        .Or(Parse.String("none").Return(DataFilterEntity.None))
        //        .Or(CustomParser))));

        //public void TestIt() {
        //    var result = TimeFilter.Parse("custom 21/3/2013 10/4/2013");
        //    Console.Out.WriteLine("result.Value = {0}", result.Value);
        //}
        #endregion




    }
}
