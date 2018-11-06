using Elreg.BusinessObjects;
using Elreg.BusinessObjects.Interfaces;

namespace Elreg.VirtualControllerService
{
    public class VirtualController : IVirtualController
    {
        public ControllerLevel CurrentLevel { get; set; }
        public bool IsButtonPressed { get; set; }
    }
}
