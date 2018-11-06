namespace Heinzman.WpfControls.SelectionSync
{
    public interface IListItemConverter
    {
        object Convert(object masterListItem);
        object ConvertBack(object targetListItem);
    }
}