using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.DbConfig;

namespace Persistence.ModelConfig
{
    internal class EmployeeEntityConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder
                .ToTable("Employees", SchemaNames.HR)
                .HasIndex(entity => entity.FirstName)
                .HasDatabaseName("IX_Employees_FirstName");

            builder              
                .HasIndex(entity => entity.LastName)
                .HasDatabaseName("IX_Employees_LastName");
        }
    }
}
