using HIVMedicalSystem.Domain.Abstractions.Repositories.Seedings;
using HIVMedicalSystem.Repository.Abstraction;

namespace HIVMedicalSystem.Repository;

public class SeedingDatabaseRepository: ISeedingDatabaseRepository
{
    public async Task SeedingDatabase()
    {
        await DataSeeding.Instance.MigrateDatabaseAsync();
        await DataSeeding.Instance.RoleSeedingAsync();
        await DataSeeding.Instance.UserSeedingAsync();
        await DataSeeding.Instance.DegreeTypeSeedingAsync();
        await DataSeeding.Instance.DegreeSeedingAsync();
    }
}