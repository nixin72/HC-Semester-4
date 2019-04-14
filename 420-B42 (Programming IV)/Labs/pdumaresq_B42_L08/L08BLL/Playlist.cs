using System;
using System.Collections.Generic;
using System.Data;
using L08DB;

namespace L08BLL {
    public class Playlist {
        public Int32 PlayListId { get; private set; }
        public String Name { get; set; }

        public Playlist() {
            this.PlayListId = 0;
            this.Name = "";
        }

        public Playlist(Int32 _PlayListId, String _Name) {
            this.PlayListId = _PlayListId;
            this.Name = _Name;
        }

        public List<Playlist> ListPlaylists() {
            PlaylistDB plDB = new PlaylistDB();
            DataTable data = plDB.GetPlaylists();
            return GetAllGenres(data);
        }

        private List<Playlist> GetAllGenres(DataTable data) {
            List<Playlist> list = new List<Playlist>();
            if (data != null) {
                foreach (DataRow r in data.Rows) {
                    try {
                        Playlist ar = new Playlist(
                            r[0] != DBNull.Value ? Convert.ToInt32(r[0]) : 0,
                            r[1] != DBNull.Value ? r[1].ToString() : ""
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
