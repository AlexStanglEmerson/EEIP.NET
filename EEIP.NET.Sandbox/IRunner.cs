namespace EEIP.NET.Sandbox;
public interface IRunner
{
    public bool ShouldRun { get; }
    public void Main(string[] args);
}
