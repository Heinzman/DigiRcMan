namespace Elreg.Controls.ProgressColumns
{
    public sealed class DataGridViewHorizProgressColumn : DataGridViewProgressColumn
    {
        public DataGridViewHorizProgressColumn()
        {
            CellTemplate = new DataGridViewHorizProgressCell();
        }

    }
}
