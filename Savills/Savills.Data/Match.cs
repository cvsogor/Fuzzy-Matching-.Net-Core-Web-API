using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Savills.Data
{
    public class Match
    {
        public int Id { get; set; }
        public double? Lat { get; set; }
        public double? Lon { get; set; }

        public string S2Address { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public string Postcode { get; set; }


        public string S1Address { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }


        public int? S1Id { get; set; }
        public int? Floorcount { get; set; }

        public int? S2Id { get; set; }

        public int? Floorarea { get; set; }

        public void Update(S2 value)
        {
            if (!string.IsNullOrWhiteSpace(value.Name)) Name = value.Name;
            if (!string.IsNullOrWhiteSpace(value.Address)) Address = value.Address;
            if (!string.IsNullOrWhiteSpace(value.Postcode)) Postcode = value.Postcode;

            if (value.Lat != null) Lat = value.Lat;
            if (value.Lon != null) Lon = value.Lon;
            if (value.Floorarea != null) Floorarea = value.Floorarea;

            if (value.Id != null) S2Id = value.Id;
            S2Address = string.Format("{0} {1} {2}", Name, Address, Postcode).Trim();
        }
        public void Update(S1 value)
        {
            if (!string.IsNullOrWhiteSpace(value.Address1)) Address1 = value.Address1;
            if (!string.IsNullOrWhiteSpace(value.Address2)) Address2 = value.Address2;
            if (value.Lat != null) Lat = value.Lat;
            if (value.Lon != null) Lon = value.Lon;
            if (value.Floorcount != null) Floorcount = value.Floorcount;

            if (value.Id != null) S1Id = value.Id;
            S1Address = string.Format("{0} {1}", Address1, Address2).Trim();
        }

    }
}
