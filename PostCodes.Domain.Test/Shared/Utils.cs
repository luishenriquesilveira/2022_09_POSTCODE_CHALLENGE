using AutoMapper;
using PostCodes.Domain.Configurations;
using PostCodes.Domain.Entities;
using PostCodes.Domain.Responses;

namespace PostCodes.Domain.Test.Shared
{
    static class Utils
    {
        private static readonly Random rdn = new Random();

        public static IMapper createMapperConfig()
        {
            var mockMaps = new MapperConfiguration(cfp =>
            {
                cfp.AddProfile(new AutoMapperConfiguration());
            });

            return mockMaps.CreateMapper();
        }

        public static string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            Random random = new Random();
            var randomString = new string(Enumerable.Repeat(chars, length)
                                                    .Select(s => s[random.Next(s.Length)]).ToArray());
            return randomString;
        }

        public static PostCode FactoryPostCode()
        {
            PostCode postcode = new PostCode();
            postcode.Id = rdn.Next(1, 10);
            postcode.Date = DateTime.Now;
            postcode.PostCodeNumber = GenerateRandomString(10);
            postcode.Outcode = GenerateRandomString(10);
            postcode.Incode = GenerateRandomString(10);
            postcode.Quality = rdn.Next(1, 10);
            postcode.Eastings = rdn.Next(1, 10);
            postcode.Northings = rdn.Next(1, 10);
            postcode.Country = GenerateRandomString(10);
            postcode.NhsHa = GenerateRandomString(10);
            postcode.AdminCounty = GenerateRandomString(10);
            postcode.AdminDistrict = GenerateRandomString(10);
            postcode.AdminWard = GenerateRandomString(10);
            postcode.Longitude = (float?)rdn.NextDouble();
            postcode.Latitude = (float?)rdn.NextDouble();
            postcode.ParliamentaryConstituency = GenerateRandomString(10);
            postcode.EuropeanElectoralRegion = GenerateRandomString(10);
            postcode.PrimaryCareTrust = GenerateRandomString(10);
            postcode.Region = GenerateRandomString(10);
            postcode.Parish = GenerateRandomString(10);
            postcode.Lsoa = GenerateRandomString(10);
            postcode.Msoa = GenerateRandomString(10);
            postcode.Ced = GenerateRandomString(10);
            postcode.Ccg = GenerateRandomString(10);
            postcode.Nuts = GenerateRandomString(10);
            postcode.CodeAdminDistrict = GenerateRandomString(10);
            postcode.CodeAdminCounty = GenerateRandomString(10);
            postcode.CodeAdminWard = GenerateRandomString(10);
            postcode.CodeParish = GenerateRandomString(10);
            postcode.CodeCcg = GenerateRandomString(10);
            postcode.CodeCcgId = GenerateRandomString(10);
            postcode.CodeNuts = GenerateRandomString(10);
            postcode.CodeLau2 = GenerateRandomString(10);
            postcode.CodeLsoa = GenerateRandomString(10);
            postcode.CodeMsoa = GenerateRandomString(10);
            postcode.DistanceToAirport = (float?)rdn.NextDouble();

            return postcode;
        }

        public static PostCodeResponse FactoryPostCodeResponse(bool success)
        {
            PostCodeResponse postcodeResponse = new PostCodeResponse();
            postcodeResponse.status = 200; 
            postcodeResponse.error = "";
            postcodeResponse.result = success ? FactoryResponseResult() : null;
            return postcodeResponse;
        }

        public static ResponseResult FactoryResponseResult()
        {
            ResponseResult responseResult = new ResponseResult();
            responseResult.postcode = GenerateRandomString(10);
            responseResult.outcode = GenerateRandomString(10);
            responseResult.incode = GenerateRandomString(10);
            responseResult.quality = rdn.Next(1, 10);
            responseResult.eastings = rdn.Next(1, 10);
            responseResult.northings = rdn.Next(1, 10);
            responseResult.country = GenerateRandomString(10);
            responseResult.nhs_ha = GenerateRandomString(10);
            responseResult.admin_county = GenerateRandomString(10);
            responseResult.admin_district = GenerateRandomString(10);
            responseResult.admin_ward = GenerateRandomString(10);
            responseResult.longitude = (float?)rdn.NextDouble();
            responseResult.latitude = (float?)rdn.NextDouble();
            responseResult.parliamentary_constituency = GenerateRandomString(10);
            responseResult.european_electoral_region = GenerateRandomString(10);
            responseResult.primary_care_trust = GenerateRandomString(10);
            responseResult.region = GenerateRandomString(10);
            responseResult.parish = GenerateRandomString(10);
            responseResult.lsoa = GenerateRandomString(10);
            responseResult.msoa = GenerateRandomString(10);
            responseResult.ced = GenerateRandomString(10);
            responseResult.ccg = GenerateRandomString(10);
            responseResult.nuts = GenerateRandomString(10);
            responseResult.codes = null;
            return responseResult;
        }
    }
}
