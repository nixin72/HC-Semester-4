using System;
using System.Collections.Generic;
using L08DB;
using System.Data;

namespace L08BLL {
    public class PlaylistTrack {
        public Int32 PlayListId { get; private set; }
        public Int32 TrackId { get; }

        public PlaylistTrack() {
            this.PlayListId = 0;
            this.TrackId = 0;
        }

        public PlaylistTrack(Int32 _PlayListId, Int32 _TrackId) {
            this.PlayListId = _PlayListId;
            this.TrackId = _TrackId;
        }

        public List<PlaylistTrack> ListArtists() {
            PlaylistTrackDB plDB = new PlaylistTrackDB();
            DataTable data = plDB.GetPlayListTracks();
            return ListArtists(data);
        }

        private List<PlaylistTrack> ListArtists(DataTable data) {
            List<PlaylistTrack> list = new List<PlaylistTrack>();
            if (data != null) {
                foreach (DataRow r in data.Rows) {
                    try {
                        PlaylistTrack ar = new PlaylistTrack(
                            r[0] != DBNull.Value ? Convert.ToInt32(r[0]) : 0,
                            r[1] != DBNull.Value ? Convert.ToInt32(r[1]) : 0
                        );
                        list.Add(ar);
                    }
                    catch { }
                }
            }
            else {
                list = null;
            }
            return list;
        }
    }
}
