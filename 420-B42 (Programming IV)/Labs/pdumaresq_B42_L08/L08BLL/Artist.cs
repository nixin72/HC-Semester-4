using System;
using System.Collections.Generic;
using L08DB;
using System.Data;

namespace L08BLL {
    public class Artist {
        public Int32 ArtistId { get; private set; }
        public String Name { get; set; }

        private List<Album> _albums = new List<Album>();
        public List<Album> Albums {
            get { return _albums; }
            set { _albums = value; }
        }

        public Artist() {
            this.ArtistId = 0;
            this.Name = "";
        }

        public Artist(Int32 _ArtistId, String _Name) {
            this.ArtistId = _ArtistId;
            this.Name = _Name;
        }

        public List<Artist> ListArtists() {
            PlaylistDB plDB = new PlaylistDB();
            DataTable data = plDB.GetPlaylists();
            return ListArtists(data);
        }

        private List<Artist> ListArtists(DataTable data) {
            List<Artist> list = new List<Artist>();
            if (data != null) {
                foreach (DataRow r in data.Rows) {
                    try {
                        Artist ar = new Artist(
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
