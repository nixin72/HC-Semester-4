using System;
using System.Data;

namespace L08DB {
    public class AlbumDB {
        public DataTable GetAlbums() {
            DataTable table;
            try {
                dsChinookTableAdapters.ALBUMTableAdapter adapt = new dsChinookTableAdapters.ALBUMTableAdapter();
                adapt.ClearBeforeFill = true;
                table = adapt.GetData();
            }
            catch {
                table = null;
            }
            return table;
        }

        public DataTable GetAlbumById(int _AlbumId) {
            DataTable table;
            try {
                dsChinookTableAdapters.ALBUMTableAdapter adapt = new dsChinookTableAdapters.ALBUMTableAdapter();
                adapt.ClearBeforeFill = true;
                table = adapt.GetDataByAlbumId(_AlbumId);
            }
            catch {
                table = null;
            }
            return table;
        }

        public decimal? GetPriceByAlbumName(String _Title) {
            decimal? retVal = -1;
            try {
                dsChinookTableAdapters.ALBUMTableAdapter adapt = new dsChinookTableAdapters.ALBUMTableAdapter();
                adapt.ClearBeforeFill = true;
                retVal = adapt.GetAlbumPrice(_Title);
            }
            catch {
                retVal = -1;
            }
            return retVal;
        }

        public decimal? GetPriceByArtistName(String _Name) {
            decimal? retVal = -1;
            try {
                dsChinookTableAdapters.ALBUMTableAdapter adapt = new dsChinookTableAdapters.ALBUMTableAdapter();
                adapt.ClearBeforeFill = true;
                retVal = adapt.GetAlbumPriceForArtist(_Name);
            }
            catch {
                retVal = -1;
            }
            return retVal;
        }

        public decimal? GetAlbumLength(String _Title) {
            decimal? retVal = -1;
            try {
                dsChinookTableAdapters.ALBUMTableAdapter adapt = new dsChinookTableAdapters.ALBUMTableAdapter();
                adapt.ClearBeforeFill = true;
                retVal = adapt.GetAlbumLength(_Title);
            }
            catch {
                retVal = -1;
            }
            return retVal;
        }

        public decimal? GetNumberOfTracks(String _Title) {
            decimal? retVal = -1;
            try {
                dsChinookTableAdapters.ALBUMTableAdapter adapt = new dsChinookTableAdapters.ALBUMTableAdapter();
                adapt.ClearBeforeFill = true;
                retVal = adapt.GetNumberOfTracks(_Title);
            }
            catch {
                retVal = -1;
            }
            return retVal;
        }
    }
}
