namespace Aspenlaub.Net.GitHub.CSharp.DotNetEfToy;

public class ToyContextFactory {
    public static async Task<ToyContext> CreateAsync() {
        var dataSources = await ToyContext.GetDataSourcesAsync();
        return new ToyContext(dataSources);
    }
}