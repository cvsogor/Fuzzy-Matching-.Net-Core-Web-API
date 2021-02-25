using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Savills.Data
{
    public class S2
    {
        //[JsonProperty("Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Postcode { get; set; }
        [NotMapped]
        public double[] Coordinates { get; set; } //= new double[2]; //[0.0803, 51.5145]
        public double? Lat 
        {
            get 
            {
                if (Coordinates != null && Coordinates.Length != 2) 
                {
                    Coordinates = null;
                }
                return Coordinates?[0]; 
            } 
            set 
            {
                if (value.HasValue) 
                {
                    if (Coordinates == null || (Coordinates != null && Coordinates.Length != 2)) 
                    {
                        Coordinates = new double[2];
                    }
                    Coordinates[0] = value.Value;
                }
            } 
        }
        public double? Lon 
        {
            get
            {
                if (Coordinates != null && Coordinates.Length != 2)
                {
                    Coordinates = null;
                }
                return Coordinates?[1];
            }
            set
            {
                if (value.HasValue)
                {
                    if (Coordinates == null || (Coordinates != null && Coordinates.Length != 2))
                    {
                        Coordinates = new double[2];
                    }
                    Coordinates[1] = value.Value;
                }
            }
        }
        public int? Floorarea { get; set; }

        public void Update(S2 value)
        {
            if (!string.IsNullOrWhiteSpace(value.Name)) Name = value.Name;
            if (!string.IsNullOrWhiteSpace(value.Address)) Address = value.Address;
            if (!string.IsNullOrWhiteSpace(value.Postcode)) Postcode = value.Postcode;

            if (value.Lat != null) Lat = value.Lat;
            if (value.Lon != null) Lon = value.Lon;
            if (value.Floorarea != null) Floorarea = value.Floorarea;
        }
    }
}
