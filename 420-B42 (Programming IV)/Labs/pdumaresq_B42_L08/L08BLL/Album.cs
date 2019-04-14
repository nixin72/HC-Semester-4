using System;
using System.Collections.Generic;
using L08DB;
using System.Data;

namespace L08BLL {
    public class Album {
        public Int32 AlbumId { get; private set; }
        public String Title { get; set; }
        public Int32 ArtistId { get; set; }

        private List<Track> _tracks = new List<Track>();
        public List<Track> Tracks {
            get { return _tracks; }
            set { _tracks = value; }
        }

        public Album() {
            this.AlbumId = 0;
            this.Title = "";
            this.ArtistId = 0;
        }

        public Album(Int32 _AlbumId, String _Title, Int32 _ArtistId) {
            this.AlbumId = _AlbumId;
            this.Title = _Title;
            this.ArtistId = _ArtistId;
        }  
        
        public Double GetPrice() {
            Double price = 0;
            foreach (Track t in Tracks) 
                price += t.UnitPrice;
            price *= 1.10;

            return price;
        } 

        public Double GetPriceByArtist(String _Name) {
            AlbumDB db = new AlbumDB();
            return Convert.ToInt16(db.GetPriceByArtistName(_Name)) * 1.10;
        }

        public Double GetAlbumLength() {
            AlbumDB db = new AlbumDB();
            return Convert.ToInt16(db.GetAlbumLength(Title)) / 1000;
        }

        public Double GetNumberTracks() {
            AlbumDB db = new AlbumDB();
            return Convert.ToInt16(db.GetNumberOfTracks(Title)) / 1000;
        }

        public Double GetAvergeLength() {
            return GetAlbumLength() / GetNumberTracks();
        }
        
        public List<Album> ListArtists() {
            ArtistDB arDB = new ArtistDB();
            DataTable data = arDB.GetArtists();
            return GetAllArtists(data);
        }
        
        public List<Album> GetAllArtists(DataTable data) {
            List<Album> list = new List<Album>();
            if (data != null) {
                foreach (DataRow r in data.Rows) {
                    try {
                        Album ar = new Album(
                            r[0] != DBNull.Value ? Convert.ToInt32(r[0]) : 0, 
                            r[1] != DBNull.Value ? r[1].ToString() : "",
                            r[2] != DBNull.Value ? Convert.ToInt32(r[2]) : 0
                        );
                        list.Add(ar);
                    } catch { }
                }
            }
            else {
                list = null;
            }
            return list;
        } 
    }
}
