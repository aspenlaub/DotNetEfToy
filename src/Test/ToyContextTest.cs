using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aspenlaub.Net.GitHub.CSharp.DotNetEfToy.Test;

[TestClass]
public class ToyContextTest {
    [TestMethod]
    public void CanWorkWithToyContext() {
        using var toyContext = new ToyContext(SynchronizationContext.Current);
        toyContext.Migrate();
        var dataCount = toyContext.Toys.Count();
        if (dataCount >= 10) {
            toyContext.Toys.RemoveRange(toyContext.Toys.Take(dataCount - 9));
        }

        var toyData = new Toy();
        toyContext.Add(toyData);
        toyContext.SaveChanges();
    }
}