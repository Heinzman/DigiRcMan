namespace Elreg.FrameworkContracts
{
    public interface ITextWriterHandler
    {
        void CreateInstance(string fileNameWithPath);
        void WriteLine(string text);
        void Close();
        bool IsCreated { get; }
        void Flush();
    }
}
