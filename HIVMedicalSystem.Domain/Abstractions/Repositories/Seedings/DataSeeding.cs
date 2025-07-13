using HIVMedicalSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HIVMedicalSystem.Domain.Abstractions.Repositories.Seedings;

public class DataSeeding
{
    public async Task MigrateDatabaseAsync()
    {
        try
        {
            using var context = new AppDbContext();
            await context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.InnerException);
        }
    }

    public async Task RoleSeedingAsync()
    {
        try
        {
            using var context = new AppDbContext();
            var roles = await context.Roles.ToListAsync();
            if (roles.Any()) return;
            var rolesCreated = new List<Role>()
            {
                new Role()
                {
                    RoleName = "Staff",
                    IsDeleted = false,
                },
                new Role()
                {
                    RoleName = "Admin",
                    IsDeleted = false
                },
                new Role()
                {
                    RoleName = "Customer",
                    IsDeleted = false
                },
                new Role()
                {
                    RoleName = "Doctor",
                    IsDeleted = false
                }
            };
            await context.Roles.AddRangeAsync(rolesCreated);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.InnerException);
        }
    }
    
    
}