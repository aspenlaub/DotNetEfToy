using Aspenlaub.Net.GitHub.CSharp.Pegh.Components;
using Aspenlaub.Net.GitHub.CSharp.Pegh.Entities;
using Aspenlaub.Net.GitHub.CSharp.Pegh.Interfaces;
using Aspenlaub.Net.GitHub.CSharp.Skladasu.Entities;
using Aspenlaub.Net.GitHub.CSharp.Vishizhukel.Data;
using Aspenlaub.Net.GitHub.CSharp.Vishizhukel.Entities.Data;
using Autofac;
using Microsoft.EntityFrameworkCore;

namespace Aspenlaub.Net.GitHub.CSharp.DotNetEfToy;

public class ToyContext : ContextBase {
    private const string Namespace = "Aspenlaub.Net.GitHub.CSharp.DotNetEfToy";

    public DbSet<Toy> Toys { get; set; }

    // ReSharper disable once UnusedMember.Global
    public ToyContext() : this(DefaultDataSources()) {
    }

    public ToyContext(DataSources dataSources)
        : this(SynchronizationContext.Current, dataSources) {
    }

    public ToyContext(SynchronizationContext? uiSynchronizationContext, DataSources dataSources)
        : base(EnvironmentType.UnitTest, uiSynchronizationContext,
               Namespace, new ConnectionStringInfos(), dataSources) {
        if (Toys == null) {
            throw new Exception(nameof(Toys));
        }
    }

    public static async Task<DataSources> GetDataSourcesAsync() {
        IContainer container = new ContainerBuilder().UsePegh("Vishizhukel").Build();
        ISecretRepository secretRepository = container.Resolve<ISecretRepository>();
        var secretDataSources = new SecretDataSources();
        var errorsAndInfos = new ErrorsAndInfos();
        DataSources? dataSources = await secretRepository.GetAsync(secretDataSources, errorsAndInfos);
        if (errorsAndInfos.AnyErrors()) {
            throw new Exception(string.Join("\r\n", errorsAndInfos.Errors));
        }
        return dataSources;
    }

    private static DataSources DefaultDataSources() {
        return new DataSources {
            new() { MachineId = Environment.MachineName, TheDataSource = $"{Environment.MachineName}\\SQLEXPRESS" }
        };
    }
}