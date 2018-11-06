using System.Windows.Forms;

namespace Elreg.WindowsFormsView
{
    public interface IMaintainDriversView : ISimpleView
    {
        TextBox TxtHymnFilename { get; }
        TextBox TxtWavName { get; }
        ISoundOptionView CtlLap { get; }
        TextBox TxtName { get; }
        CheckBox ChkActivated { get; }
        BindingNavigator BindingNavigatorDrivers { get; }
        DataGridView GrdDrivers { get; }
        GroupBox GrpDrivers { get; }
        GroupBox GrpDetails { get; }
        DataGridViewColumn GridColumnName { get; }
        Label LblName { get; }
        Label LblWavName { get; }
        Button BtnCreateWav { get; }
        Button BtnOk { get; }
        Button BtnCancel { get; }
        Label LblHymn { get; }
    }
}