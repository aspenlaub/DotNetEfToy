using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aspenlaub.Net.GitHub.CSharp.DotNetEfToy.Test;

[TestClass]
public class NotATest {
    [TestMethod]
    public async Task NotATestMethod() {
        var notAnInstance = new NotAClass();
        var container = await notAnInstance.Container();
        Assert.IsNotNull(container);
    }
}