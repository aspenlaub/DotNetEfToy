using Aspenlaub.Net.GitHub.CSharp.Pegh.Components;
using Aspenlaub.Net.GitHub.CSharp.Vishizhukel;
using Autofac;

namespace Aspenlaub.Net.GitHub.CSharp.DotNetEfToy;

public class NotAClass {
    public async Task<IContainer> Container() {
        return (await new ContainerBuilder().UseVishizhukelAndPeghAsync("DotNetEfToy", new DummyCsArgumentPrompter())).Build();
    }
}