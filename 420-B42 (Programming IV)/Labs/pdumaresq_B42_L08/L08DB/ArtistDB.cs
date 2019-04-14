using System.Data;

namespace L08DB {
    public class ArtistDB {
        public DataTable GetArtists() {
            DataTable table;
            try {
                dsChinookTableAdapters.ARTISTTableAdapter adapt = new dsChinookTableAdapters.ARTISTTableAdapter();
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
