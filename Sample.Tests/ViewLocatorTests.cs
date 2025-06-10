using Sample;

namespace Sample.Tests;

public class ViewLocatorTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ViewLocator_Returns_MainView()
    {
        var locator = new ViewLocator();
        var result = locator.Build(new MainViewModel());
        Assert.IsInstanceOf<MainView>(result);
    }
}
