using Microsoft.EntityFrameworkCore;
using StudentsAchievmentsTracker.Entities;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace StudentsAchievmentsTracker.Data;

public class StudentsAchievmentsTrackerDbContext : AbpDbContext<StudentsAchievmentsTrackerDbContext>
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Achievment> Achievments { get; set; }
    public StudentsAchievmentsTrackerDbContext(DbContextOptions<StudentsAchievmentsTrackerDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureIdentityServer();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own entities here */

        builder.Entity<Achievment>(b => {
            b.HasOne<Student>(a => a.Student)
            .WithMany(s => s.Achievments)
            .HasForeignKey(a => a.StudentId);
        });
    }
}
