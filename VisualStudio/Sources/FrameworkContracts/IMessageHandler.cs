using System;

namespace Elreg.FrameworkContracts
{
    public interface IMessageHandler
    {
        void ShowErrorMessage(Exception ex, string caption, string description);
    }
}
