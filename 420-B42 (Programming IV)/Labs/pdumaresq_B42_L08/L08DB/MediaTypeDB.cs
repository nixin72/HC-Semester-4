using System.Data;

namespace L08DB {
    public class MediaTypeDB {
        public DataTable GetMediaTypes() {
            DataTable table;
            try {
                dsChinookTableAdapters.MEDIATYPETableAdapter adapt = new dsChinookTableAdapters.MEDIATYPETableAdapter();
                adapt.ClearBeforeFill = true;
                table = adapt.GetData();
            }
            catch {
                table = null;
            }
            return table;
        }
    }
}
