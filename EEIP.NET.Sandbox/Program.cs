using System.Reflection;

namespace EEIP.NET.Sandbox;
internal class Program
{
    private static void Main(string[] args)
    {
        // Find all classes implementing IRunner and call the static Main() methods
        // Credit to the answer here: https://stackoverflow.com/a/699871
        // None of the files defining those classes should be committed to version control, so anyone can write quick tests without cluttering version control
        var instances = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => t.GetInterfaces().Contains(typeof(IRunner)))
            .Where(t => t.GetConstructor(Type.EmptyTypes) != null)
            .Select(t => Activator.CreateInstance(t) as IRunner);

        foreach (var instance in instances)
        {
            if (instance?.ShouldRun ?? false)
            {
                instance?.Main(args);
            }
        }
    }
}
