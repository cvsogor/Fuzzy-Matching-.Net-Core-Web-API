using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Savills.Data
{
    public class S1
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int? Id { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public double? Lat { get; set; }
        public double? Lon { get; set; }
        public int? Floorcount { get; set; }

        public void Update(S1 value)
        {
            if (!string.IsNullOrWhiteSpace(value.Address1)) Address1 = value.Address1;
            if (!string.IsNullOrWhiteSpace(value.Address2)) Address2 = value.Address2;
            if (value.Lat != null) Lat = value.Lat;
            if (value.Lon != null) Lon = value.Lon;
            if (value.Floorcount != null) Floorcount = value.Floorcount;
        }
    }
}
