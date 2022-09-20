using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace StudentsAchievmentsTracker;

[Dependency(ReplaceServices = true)]
public class StudentsAchievmentsTrackerBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "StudentsAchievmentsTracker";
}
