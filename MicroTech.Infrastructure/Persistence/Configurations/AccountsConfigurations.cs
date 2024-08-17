using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MicroTech.Data.Entities;
using static Dapper.SqlMapper;

namespace MicroTech.Infrastructure.Persistence.Configurations
{
    public class AccountsConfigurations : IEntityTypeConfiguration<Accounts>
    {
        public void Configure(EntityTypeBuilder<Accounts> builder)
        {
            builder.HasKey(e => e.AccNumber);

            builder.Property(e => e.AccNumber)
                .HasMaxLength(10)
                .HasColumnName("Acc_Number");
            builder.Property(e => e.AccParent)
                .HasMaxLength(10)
                .HasColumnName("ACC_Parent");
            builder.Property(e => e.Balance).HasColumnType("decimal(20, 9)");

            builder.HasOne(d => d.AccParentNavigation).WithMany(p => p.InverseAccParentNavigation)
                .HasForeignKey(d => d.AccParent)
                .HasConstraintName("FK_Accounts_Accounts");
        }
    }
}
