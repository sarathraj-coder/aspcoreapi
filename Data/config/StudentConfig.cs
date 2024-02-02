using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace school.Data.Config
{
    public class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Student");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).UseIdentityColumn();
            builder.Property(s => s.Name).IsRequired();
            builder.Property(s => s.Address).HasMaxLength(500);
            builder.Property(s => s.Address).IsRequired();
            builder.Property(s => s.Address).HasMaxLength(500);
            builder.Property(s => s.Email).IsRequired();
            builder.Property(s => s.Email).HasMaxLength(256);
             builder.Property(s => s.Dob).IsRequired();
            
        }
    }
}
