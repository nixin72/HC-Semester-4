using System;
using System.Collections.Generic;
using L08DB;
using System.Data;

namespace L08BLL {
    public class Genre {
        public Int32 GenreId { get; private set; }
        public String Name { get; set; }

        public Genre() {
            this.GenreId = 0;
            this.Name = "";
        }

        public Genre(Int32 _GenreId, String _Name) {
            this.GenreId = _GenreId;
            this.Name = _Name;
        }

        public List<Genre> ListGenres() {
            GenreDB arDB = new GenreDB();
            DataTable data = arDB.GetGenres();
            return GetAllGenres(data);
        }

        public List<Genre> GetAllGenres(DataTable data) {
            List<Genre> list = new List<Genre>();
            if (data != null) {
                foreach (DataRow r in data.Rows) {
                    try {
                        Genre ar = new Genre(
                            r[0] != DBNull.Value ? Convert.ToInt32(r[0]) : 0,
                            r[1] != DBNull.Value ? r[1].ToString() : ""
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
