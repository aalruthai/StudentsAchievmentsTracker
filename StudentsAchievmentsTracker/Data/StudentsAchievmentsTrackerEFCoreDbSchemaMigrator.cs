using Microsoft.EntityFrameworkCore;
using Volo.Abp.DependencyInjection;

namespace StudentsAchievmentsTracker.Data;

public class StudentsAchievmentsTrackerEFCoreDbSchemaMigrator : ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public StudentsAchievmentsTrackerEFCoreDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the StudentsAchievmentsTrackerDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<StudentsAchievmentsTrackerDbContext>()
            .Database
            .MigrateAsync();
    }
}
