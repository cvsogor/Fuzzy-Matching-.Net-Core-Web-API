using FuzzySharp;
using Savills.Data;
using Savills.DB;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Savills.Service
{
    public class SavillsService : ISavillsService
    {
        public void S1(S1 value) 
        {
            using (var context = new SavillsDbContext())
            {
                var row = context.S1.FirstOrDefault(e => e.Id == value.Id);
                if (row != null)
                    row.Update(value);
                else
                    context.S1.Add(value);

                Match match = null;
                var addressS1 = string.Format("{0} {1}", value.Address1, value.Address2).Trim();
                // is it unique?
                if (value.Id != null)
                    match = context.Matches.FirstOrDefault(e => e.S1Id == value.Id);
                // is it unique?
                if (match == null && value.Lat != null && value.Lon != null)
                    match = context.Matches.FirstOrDefault(e => e.Lat == value.Lat && e.Lon == value.Lon);
                if (match == null && !string.IsNullOrWhiteSpace(addressS1))
                    match = context.Matches.FirstOrDefault(e => e.S1Address == addressS1 || e.S2Address == addressS1);
                if (match == null)
                {
                    List<Match> matches = new List<Match>();
                    if (value.Address1 != null)
                    {
                        var ms = context.Matches.Where(e => e.Address1 == value.Address1);
                        if (ms.Count() == 0)
                            ms = context.Matches.Where(e => e.S2Address.Contains(value.Address1));
                        matches.AddRange(ms);
                    }
                    if (value.Address2 != null)
                    {
                        var ms = context.Matches.Where(e => e.Address2 == value.Address2);
                        if (ms.Count() == 0)
                            ms = context.Matches.Where(e => e.S2Address.Contains(value.Address2));
                        matches.AddRange(ms);
                    }
                    if (matches.Count() > 0)
                    {
                        match = matches.OrderByDescending(m => Math.Max(Fuzz.Ratio(m.S2Address, addressS1), Fuzz.Ratio(m.S1Address, addressS1))).First();
                    }
                }
                if (match == null)
                {
                    match = new Match();
                    context.Matches.Add(match);
                }
                match.Update(value);

                context.SaveChanges();
            }
        }
        public void S2(S2 value) 
        {
            //if (!ValidateData(value))
            //    return;

            using (var context = new SavillsDbContext())
            {
                var row = context.S2.FirstOrDefault(e => e.Id == value.Id);
                if (row != null)
                    row.Update(value);
                else
                    context.S2.Add(value);

                Match match = null;
                var addressS2 = string.Format("{0} {1} {2}", value.Name, value.Address, value.Postcode).Trim();

                // is it unique?
                if (value.Id != null)
                    match = context.Matches.FirstOrDefault(e => e.S2Id == value.Id);
                // is it unique?
                if (match == null && value.Lat != null && value.Lon != null)
                    match = context.Matches.FirstOrDefault(e => e.Lat == value.Lat && e.Lon == value.Lon);
                if (match == null && !string.IsNullOrWhiteSpace(addressS2))
                    match = context.Matches.FirstOrDefault(e => e.S2Address == addressS2 || e.S1Address == addressS2);
                
                if (match == null)
                {
                    List<Match> matches = new List<Match>();
                    if (value.Name != null)
                    {
                        var ms = context.Matches.Where(e => e.Name == value.Name);
                        if (ms.Count() == 0)
                            ms = context.Matches.Where(e => e.S1Address.Contains(value.Name));
                        matches.AddRange(ms);
                    }
                    if (value.Address != null)
                    {
                        var ms = context.Matches.Where(e => e.Address == value.Address);
                        if (ms.Count() == 0)
                            ms = context.Matches.Where(e => e.S1Address.Contains(value.Address));
                        matches.AddRange(ms);
                    }
                    if (value.Postcode != null)
                    {
                        var ms = context.Matches.Where(e => e.Postcode == value.Postcode);
                        if (ms.Count() == 0)
                            ms = context.Matches.Where(e => e.S1Address.Contains(value.Postcode));
                        matches.AddRange(ms);
                    }
                    if (matches.Count() > 0 && !string.IsNullOrWhiteSpace(addressS2))
                    {
                        match = matches.OrderByDescending(m => Math.Max(Fuzz.Ratio(m.S2Address != null ? m.S2Address : "" , addressS2), Fuzz.Ratio(m.S1Address != null ? m.S1Address : "", addressS2))).First();
                    }

                    //PostCode NOT Unique 
                    //TODO: fuzzy matching on SQL side?
                    //TODO: optimization
                    //TODO: move logic to the stored procedure

                }
                if (match == null)
                {
                    match = new Match();
                    context.Matches.Add(match);
                }
                match.Update(value);

                context.SaveChanges();
            }
        }
    }
}
