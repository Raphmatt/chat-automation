namespace WA_automator.AcceptanceTests.Steps;

[Binding]
public sealed class LogicSteps
{
    private readonly IBrowserController _browserController;

    public LogicSteps(ScenarioContext scenarioContext, IBrowserController browserController)
    {
        _browserController = browserController;
    }
}