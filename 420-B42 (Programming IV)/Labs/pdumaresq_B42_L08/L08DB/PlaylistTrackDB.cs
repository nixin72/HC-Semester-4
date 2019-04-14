using System.Data;

namespace L08DB {
    public class PlaylistTrackDB {
        public DataTable GetPlayListTracks() {
            DataTable table;
            try {
                dsChinookTableAdapters.PLAYLISTTRACKTableAdapter adapt = new dsChinookTableAdapters.PLAYLISTTRACKTableAdapter();
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
