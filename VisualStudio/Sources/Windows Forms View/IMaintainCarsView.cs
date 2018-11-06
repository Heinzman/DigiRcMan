using System.Windows.Forms;

namespace Elreg.WindowsFormsView
{
    public interface IMaintainCarsView : ISimpleView
    {
        TextBox TxtName { get; }
        TextBox TxtPicture { get; }
        PictureBox PictureBox { get; }
        DataGridView GrdCars { get; }
        BindingNavigator BindingNavigatorCars { get; }
        GroupBox GrpCars { get; }
        GroupBox GrpDetails { get; }
        DataGridViewColumn GridColumnName { get; }
        Label LblName { get; }
        Label LblPicture { get; }
        Button BtnAccept { get; }
        Button BtnOk { get; }
        Button BtnCancel{ get; }
    }
}