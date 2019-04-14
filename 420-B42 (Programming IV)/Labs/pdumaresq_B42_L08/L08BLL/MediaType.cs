using System;
using System.Collections.Generic;
using System.Data;
using L08DB;

namespace L08BLL {
    public class MediaType {
        public Int32 MediaTypeId { get; private set; }
        public String Name { get; set; }

        public MediaType() {
            this.MediaTypeId = 0;
            this.Name = "";
        }

        public MediaType(Int32 _MediaTypeId, String _Name) {
            this.MediaTypeId = _MediaTypeId;
            this.Name = _Name;
        }

        public List<MediaType> ListMediaTypes() {
            PlaylistDB plDB = new PlaylistDB();
            DataTable data = plDB.GetPlaylists();
            return ListMediaTypes(data);
        }

        private List<MediaType> ListMediaTypes(DataTable data) {
            List<MediaType> list = new List<MediaType>();
            if (data != null) {
                foreach (DataRow r in data.Rows) {
                    try {
                        MediaType ar = new MediaType(
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
