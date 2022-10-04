using PostCodes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PostCodes.Infrastructure.Mappings
{
    public class PostCodeMapping : IEntityTypeConfiguration<PostCode>
    {
        public void Configure(EntityTypeBuilder<PostCode> builder)
        {
            builder.ToTable("post_code");
            
            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Date)
                .HasColumnName("date")
                .IsRequired();

            builder.Property(x => x.PostCodeNumber)
                .HasColumnName("post_code_number")
                .IsRequired();

            builder.Property(x => x.Outcode)
                .HasColumnName("outcode")
                .IsRequired();

            builder.Property(x => x.Incode)
                .HasColumnName("incode")
                .IsRequired();

            builder.Property(x => x.Quality)
                .HasColumnName("quality")
                .IsRequired();

            builder.Property(x => x.Eastings)
                .HasColumnName("eastings");

            builder.Property(x => x.Northings)
                .HasColumnName("northings");

            builder.Property(x => x.Country)
                .HasColumnName("country");

            builder.Property(x => x.NhsHa)
                .HasColumnName("nhs_ha");

            builder.Property(x => x.AdminCounty)
                .HasColumnName("admin_county");

            builder.Property(x => x.AdminDistrict)
                .HasColumnName("admin_district");

            builder.Property(x => x.AdminWard)
                .HasColumnName("admin_ward");

            builder.Property(x => x.Longitude)
                .HasColumnName("longitude");

            builder.Property(x => x.Latitude)
                .HasColumnName("latitude");

            builder.Property(x => x.ParliamentaryConstituency)
                .HasColumnName("parliamentary_constituency");

            builder.Property(x => x.EuropeanElectoralRegion)
                .HasColumnName("european_electoral_region");

            builder.Property(x => x.PrimaryCareTrust)
                .HasColumnName("primary_care_trust");

            builder.Property(x => x.Region)
                .HasColumnName("region");

            builder.Property(x => x.Parish)
                .HasColumnName("parish");

            builder.Property(x => x.Lsoa)
                .HasColumnName("lsoa");

            builder.Property(x => x.Msoa)
                .HasColumnName("msoa");

            builder.Property(x => x.Ced)
                .HasColumnName("ced");

            builder.Property(x => x.Ccg)
                .HasColumnName("ccg");

            builder.Property(x => x.Nuts)
                .HasColumnName("nuts");

            builder.Property(x => x.CodeAdminDistrict)
                .HasColumnName("code_admin_district");

            builder.Property(x => x.CodeAdminCounty)
                .HasColumnName("code_admin_county");

            builder.Property(x => x.CodeAdminWard)
                .HasColumnName("code_admin_ward");

            builder.Property(x => x.CodeParish)
                .HasColumnName("code_parish");

            builder.Property(x => x.CodeCcg)
                .HasColumnName("code_ccg");

            builder.Property(x => x.CodeCcgId)
                .HasColumnName("code_ccg_id");

            builder.Property(x => x.CodeNuts)
                .HasColumnName("code_nuts");

            builder.Property(x => x.CodeLau2)
                .HasColumnName("code_lau2");

            builder.Property(x => x.CodeLsoa)
                .HasColumnName("code_lsoa");

            builder.Property(x => x.CodeMsoa)
                .HasColumnName("code_msoa");

            builder.Property(x => x.DistanceToAirport)
                .HasColumnName("distance_to_airport");

            builder.Ignore(t => t.DistanceToAirportKm);
            builder.Ignore(t => t.DistanceToAirportMi);
        }
    }
}
