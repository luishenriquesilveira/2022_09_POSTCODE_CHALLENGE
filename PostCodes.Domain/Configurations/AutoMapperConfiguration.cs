using AutoMapper;
using PostCodes.Domain.Entities;
using PostCodes.Domain.Responses;

namespace PostCodes.Domain.Configurations
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<CommonResponse<PostCodeResponse>, CommonResponse<PostCode>>();

            CreateMap<PostCodeResponse, PostCode>()
                .ForMember(pc => pc.PostCodeNumber, o => o.MapFrom(r => r.result.postcode))
                .ForMember(pc => pc.Outcode, o => o.MapFrom(r => r.result.outcode))
                .ForMember(pc => pc.Incode, o => o.MapFrom(r => r.result.incode))
                .ForMember(pc => pc.Quality, o => o.MapFrom(r => r.result.quality))
                .ForMember(pc => pc.Eastings, o => o.MapFrom(r => r.result.eastings))
                .ForMember(pc => pc.Northings, o => o.MapFrom(r => r.result.northings))
                .ForMember(pc => pc.Country, o => o.MapFrom(r => r.result.country))
                .ForMember(pc => pc.NhsHa, o => o.MapFrom(r => r.result.nhs_ha))
                .ForMember(pc => pc.AdminCounty, o => o.MapFrom(r => r.result.admin_county))
                .ForMember(pc => pc.AdminDistrict, o => o.MapFrom(r => r.result.admin_district))
                .ForMember(pc => pc.AdminWard, o => o.MapFrom(r => r.result.admin_ward))
                .ForMember(pc => pc.Longitude, o => o.MapFrom(r => r.result.longitude))
                .ForMember(pc => pc.Latitude, o => o.MapFrom(r => r.result.latitude))
                .ForMember(pc => pc.ParliamentaryConstituency, o => o.MapFrom(r => r.result.parliamentary_constituency))
                .ForMember(pc => pc.EuropeanElectoralRegion, o => o.MapFrom(r => r.result.european_electoral_region))
                .ForMember(pc => pc.PrimaryCareTrust, o => o.MapFrom(r => r.result.primary_care_trust))
                .ForMember(pc => pc.Region, o => o.MapFrom(r => r.result.region))
                .ForMember(pc => pc.Parish, o => o.MapFrom(r => r.result.parish))
                .ForMember(pc => pc.Lsoa, o => o.MapFrom(r => r.result.lsoa))
                .ForMember(pc => pc.Msoa, o => o.MapFrom(r => r.result.msoa))
                .ForMember(pc => pc.Ced, o => o.MapFrom(r => r.result.ced))
                .ForMember(pc => pc.Ccg, o => o.MapFrom(r => r.result.ccg))
                .ForMember(pc => pc.Nuts, o => o.MapFrom(r => r.result.nuts))
                .ForMember(pc => pc.CodeAdminDistrict, o => o.MapFrom(r => r.result.codes.admin_district))
                .ForMember(pc => pc.CodeAdminCounty, o => o.MapFrom(r => r.result.codes.admin_county))
                .ForMember(pc => pc.CodeAdminWard, o => o.MapFrom(r => r.result.codes.admin_ward))
                .ForMember(pc => pc.CodeParish, o => o.MapFrom(r => r.result.codes.parish))
                .ForMember(pc => pc.CodeCcg, o => o.MapFrom(r => r.result.codes.ccg))
                .ForMember(pc => pc.CodeCcgId, o => o.MapFrom(r => r.result.codes.ccg_id))
                .ForMember(pc => pc.CodeNuts, o => o.MapFrom(r => r.result.codes.nuts))
                .ForMember(pc => pc.CodeLau2, o => o.MapFrom(r => r.result.codes.lau2))
                .ForMember(pc => pc.CodeLsoa, o => o.MapFrom(r => r.result.codes.lsoa))
                .ForMember(pc => pc.CodeMsoa, o => o.MapFrom(r => r.result.codes.msoa));
        }
    }
}
