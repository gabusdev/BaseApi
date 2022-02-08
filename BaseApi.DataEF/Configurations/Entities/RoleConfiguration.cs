using BaseApi.Core.Entities.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace BaseApi.DataEF.Configurations.Entities
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Name = Enum.GetName(RoleEnum.Administrator),
                    NormalizedName = Enum.GetName(RoleEnum.Administrator).ToUpper()
                },
                new IdentityRole
                {
                    Name = Enum.GetName(RoleEnum.User),
                    NormalizedName = Enum.GetName(RoleEnum.User).ToUpper()
                }
            );
        }
    }
}
