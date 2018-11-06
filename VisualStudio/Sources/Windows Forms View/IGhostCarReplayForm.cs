using Elreg.BusinessObjects;

namespace Elreg.WindowsFormsView
{
    public interface IGhostCarReplayForm : ISimpleView
    {
        Ghost Ghost { get; set; }
    }
}
