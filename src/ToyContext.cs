using Aspenlaub.Net.GitHub.CSharp.Pegh.Components;
using Aspenlaub.Net.GitHub.CSharp.Pegh.Entities;
using Aspenlaub.Net.GitHub.CSharp.Pegh.Interfaces;
using Aspenlaub.Net.GitHub.CSharp.Vishizhukel.Data;
using Aspenlaub.Net.GitHub.CSharp.Vishizhukel.Entities.Data;
using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Aspenlaub.Net.GitHub.CSharp.DotNetEfToy;

public class ToyContext : ContextBase {
    private const string Namespace = "Aspenlaub.Net.GitHub.CSharp.DotNetEfToy";

    public DbSet<Toy> Toys { get; set; }

    // ReSharper disable once UnusedMember.Global
    public ToyContext() : this(SynchronizationContext.Current) {
    }

    public ToyContext(SynchronizationContext? uiSynchronizationContext) : base(EnvironmentType.UnitTest, uiSynchronizationContext, Namespace, new ConnectionStringInfos(), GetDataSources()) {
    }

    private static DataSources GetDataSources() {
        var container = new ContainerBuilder().UsePegh("Vishizhukel", new DummyCsArgumentPrompter()).Build();
        var secretRepository = container.Resolve<ISecretRepository>();
        var secretDataSources = new SecretDataSources();
        var errorsAndInfos = new ErrorsAndInfos();
        var dataSources = secretRepository.GetAsync(secretDataSources, errorsAndInfos).Result;
        if (errorsAndInfos.AnyErrors()) {
            throw new Exception(string.Join("\r\n", errorsAndInfos.Errors));
        }
        return dataSources;
    }
}