using System;
using Elreg.BusinessObjects.DerivedEventArgs;

namespace Elreg.BusinessObjects.Interfaces
{
    public interface ICountDownModel
    {
        event EventHandler<CountDownEventArgs> CountDownChanged;
    }
}
