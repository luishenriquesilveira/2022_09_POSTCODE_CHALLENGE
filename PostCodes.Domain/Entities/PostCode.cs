using System.Text.Json.Serialization;

namespace PostCodes.Domain.Entities
{
    public class PostCode
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public string PostCodeNumber { get; set; }
        public string Outcode { get; set; }
        public string Incode { get; set; }
        public int Quality { get; set; }
        public int? Eastings { get; set; }
        public int? Northings { get; set; }
        public string Country { get; set; }
        public string? NhsHa { get; set; }
        public string? AdminCounty { get; set; }
        public string? AdminDistrict { get; set; }
        public string? AdminWard { get; set; }
        public float? Longitude { get; set; }
        public float? Latitude { get; set; }
        public string? ParliamentaryConstituency { get; set; }
        public string? EuropeanElectoralRegion { get; set; }
        public string? PrimaryCareTrust { get; set; }
        public string? Region { get; set; }
        public string? Parish { get; set; }
        public string? Lsoa { get; set; }
        public string? Msoa { get; set; }
        public string? Ced { get; set; }
        public string? Ccg { get; set; }
        public string? Nuts { get; set; }
        public string? CodeAdminDistrict { get; set; }
        public string? CodeAdminCounty { get; set; }
        public string? CodeAdminWard { get; set; }
        public string? CodeParish { get; set; }
        public string? CodeCcg { get; set; }
        public string? CodeCcgId { get; set; }
        public string? CodeNuts { get; set; }
        public string? CodeLau2 { get; set; }
        public string? CodeLsoa { get; set; }
        public string? CodeMsoa { get; set; }
        public double? DistanceToAirport { get; set; }
        public double? DistanceToAirportKm
        {
            get
            {
                if (!this.DistanceToAirport.HasValue)
                    return null;

                return Math.Round((double)(this.DistanceToAirport / 1000), 4);
            }
        }
        public double? DistanceToAirportMi 
        {
            get
            {
                if (!this.DistanceToAirport.HasValue)
                    return null;

                return Math.Round((double)(this.DistanceToAirport * 0.00062137), 4);
            }
        }

        public void SetDate()
        {
            Date = DateTime.Now;
        }
    }
}
