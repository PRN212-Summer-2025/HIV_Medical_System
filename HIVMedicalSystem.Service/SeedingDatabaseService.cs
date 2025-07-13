using HIVMedicalSystem.Repository.Abstraction;
using HIVMedicalSystem.Service.Abstraction;

namespace HIVMedicalSystem.Service;

public class SeedingDatabaseService: ISeedingDatabaseService
{
    private readonly ISeedingDatabaseRepository _seedingDatabaseRepository;

    public SeedingDatabaseService(ISeedingDatabaseRepository seedingDatabaseRepository)
    {
        _seedingDatabaseRepository = seedingDatabaseRepository;
    }
    
    public async Task Seeding()
    {
        await _seedingDatabaseRepository.SeedingDatabase();
    }
}