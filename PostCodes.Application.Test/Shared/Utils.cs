
using AutoMapper;
using Microsoft.AspNetCore.Http;
using PostCodes.Domain.Configurations;
using PostCodes.Domain.Entities;

namespace PostCodes.Application.Test.Shared
{
    static class Utils
    {
        private static readonly Random rdn = new Random();

        public static HttpContext mockContext(string method)
        {
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Method = method;
            return httpContext;
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
    }
}
