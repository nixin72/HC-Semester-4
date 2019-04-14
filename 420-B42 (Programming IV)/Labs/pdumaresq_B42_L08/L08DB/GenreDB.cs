using System.Data;

namespace L08DB {
    public class GenreDB {
        public DataTable GetGenres() {
            DataTable table;
            try {
                dsChinookTableAdapters.GENRETableAdapter adapt = new dsChinookTableAdapters.GENRETableAdapter();
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
