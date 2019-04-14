using System.Data;

namespace L08DB {
    public class TrackDB {
        public DataTable GetPlayListTracks() {
            DataTable table;
            try {
                dsChinookTableAdapters.TRACKTableAdapter adapt = new dsChinookTableAdapters.TRACKTableAdapter();
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
