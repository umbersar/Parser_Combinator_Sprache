using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sprache_siteData_NT_Model {
    public class NT_Site_Data_File {
        readonly Site_Data_Header _dataHeader;
        readonly IEnumerable<Site_Data_Row> _dataRows;

        public NT_Site_Data_File(Site_Data_Header header,IEnumerable<Site_Data_Row> dataRows) {
            if (header == null) throw new ArgumentNullException("header");
            if (dataRows == null) throw new ArgumentNullException("dataRows");

            _dataHeader = header;
            _dataRows = dataRows.ToArray();
        }

        public IEnumerable<Site_Data_Row> DataRows { get { return _dataRows; } }

        public override string ToString() {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(_dataHeader.ToString());
            foreach (var row in this._dataRows) {
                stringBuilder.AppendLine(row.ToString());
            }

            return stringBuilder.ToString();
        }
    }
}
