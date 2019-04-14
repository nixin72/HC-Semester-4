using System.Data;

namespace L08DB {
    public class PlaylistDB {
        public DataTable GetPlaylists() {
            DataTable table;
            try {
                dsChinookTableAdapters.PLAYLISTTableAdapter adapt = new dsChinookTableAdapters.PLAYLISTTableAdapter();
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
