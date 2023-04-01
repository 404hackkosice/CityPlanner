namespace CityPlanner.Internal.Services.Hosted;

public class PopulateDbHostedService : AbstractHostedService<PopulateDbHostedService>
{
    public PopulateDbHostedService(IServiceScopeFactory serviceScopeFactory) :
        base(serviceScopeFactory, TimeSpan.FromSeconds(Constants.Limits.MINIMUM_SECOND_HOSTED_SERVICE_DELAY), TimeSpan.FromHours(1))
    {

    }

    protected override async void OnRun()
    {
    }
}