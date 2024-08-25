using System.Reflection;

namespace Product.Host.Extensions;

public static class AutoMapperExtension
{
    public static void AddCustomAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(GetAssemblies());
    }

    private static IEnumerable<Assembly> GetAssemblies()
    {
        var assemblies = new List<Assembly>();
        var assemblyNames = Assembly.GetExecutingAssembly().GetReferencedAssemblies().Where(x => x.FullName?.Contains("Services.Cart.Service") ?? false);
        foreach (var name in assemblyNames)
        {
            Assembly assembly = Assembly.Load(name);
            assemblies.Add(assembly);
        }
        return assemblies;
    }
}
