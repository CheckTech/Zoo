using Rhino;
using Rhino.Commands;

namespace SampleCsZooTest
{
  /// <summary>
  /// SampleCsZooTestCommand command
  /// </summary>
  [System.Runtime.InteropServices.Guid("a3f790bf-1e8a-405e-97bb-f3009d978a1e")]
  public class SampleCsZooTestCommand : Command
  {
    /// <summary>
    /// Constructor
    /// </summary>
    public SampleCsZooTestCommand()
    {
      // Rhino only creates one instance of each command class defined in a
      // plug-in, so it is safe to store a reference in a static property.
      Instance = this;
    }

    /// <summary>
    /// Gets the one and only instance of this command.
    /// </summary>
    public static SampleCsZooTestCommand Instance
    {
      get;
      private set;
    }

    /// <summary>
    /// Gets the command name as it appears on the Rhino command line.
    /// </returns>
    public override string EnglishName
    {
      get { return "SampleCsZooTest"; }
    }

    /// <summary>
    /// Called by Rhino to run this command.
    /// </summary>
    protected override Result RunCommand(RhinoDoc doc, RunMode mode)
    {
      RhinoApp.WriteLine("The {0} command is under construction", EnglishName);
      return Result.Success;
    }
  }
}
