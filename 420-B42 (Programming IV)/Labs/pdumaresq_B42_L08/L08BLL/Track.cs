using System;
using System.Collections.Generic;
using L08DB;
using System.Data;

namespace L08BLL {
    public class Track {
        public Int32 TrackId { get; private set; }
        public String Name { get; set; }
        public Int32 AlbumId { get; set; }
        public Int32 MediaTypeId { get; set; }
        public Int32 GenreId { get; set; }
        public String Composer { get; set; }
        public Int32 Milliseconds { get; set; }
        public Int32 Int32s { get; set; }
        public Double UnitPrice { get; set; }

        public Track() {
            this.TrackId = 0;
            this.Name = "";
            this.AlbumId = 0;
            this.MediaTypeId = 0;
            this.GenreId = 0;
            this.Composer = "";
            this.Milliseconds = 0;
            this.Int32s = 0;
            this.UnitPrice = 0;
        }

        public Track(Int32 _TrackId, String _Name, Int32 _MediaTypeId, 
                Int32 _Milliseconds, Double _UnitPrice) {
            this.TrackId = _TrackId;
            this.Name = _Name;
            this.AlbumId = 0;
            this.MediaTypeId = _MediaTypeId;
            this.GenreId = 0;
            this.Composer = "";
            this.Milliseconds = _Milliseconds;
            this.Int32s = 0;
            this.UnitPrice = _UnitPrice;
        }

        public Track(Int32 _TrackId, String _Name, Int32 _AlbumId, 
                Int32 _MediaTypeId, Int32 _GenreId, String _Composer, 
                Int32 _Milliseconds, Int32 _Int32s, Double _UnitPrice) {
            this.TrackId = _TrackId;
            this.Name = _Name;
            this.AlbumId = _AlbumId;
            this.MediaTypeId = _MediaTypeId;
            this.GenreId = _GenreId;
            this.Composer = _Composer;
            this.Milliseconds = _Milliseconds;
            this.Int32s = _Int32s;
            this.UnitPrice = _UnitPrice;
        }

        public List<Track> ListTracks() {
            TrackDB tDb = new TrackDB();
            DataTable data = tDb.GetPlayListTracks();
            return GetAllTracks(data);
        }

        public List<Track> GetAllTracks(DataTable data) {
            List<Track> list = new List<Track>();
            if (data != null) {
                foreach (DataRow r in data.Rows) {
                    try {
                        Track t = new Track(
                            r[0] != DBNull.Value ? Convert.ToInt32(r[0]) : 0,
                            r[0] != DBNull.Value ? r[1].ToString() : "",
                            r[0] != DBNull.Value ? Convert.ToInt32(r[2]) : 0,
                            r[0] != DBNull.Value ? Convert.ToInt32(r[3]) : 0,
                            r[0] != DBNull.Value ? Convert.ToInt32(r[4]) : 0,
                            r[0] != DBNull.Value ? r[5].ToString() : "",
                            r[0] != DBNull.Value ? Convert.ToInt32(r[6]) : 0,
                            r[0] != DBNull.Value ? Convert.ToInt32(r[7]) : 0,
                            r[0] != DBNull.Value ? Convert.ToInt32(r[8]) : 0
                        );
                        list.Add(t);
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
