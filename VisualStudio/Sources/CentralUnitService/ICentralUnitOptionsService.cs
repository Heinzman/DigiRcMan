using Elreg.CentralUnitService.Settings;

namespace Elreg.CentralUnitService
{
    public interface ICentralUnitOptionsService
    {
        Options Options { get; set; }
        void Save();
    }
}
