using System.IO;
using Elreg.FrameworkContracts;

namespace Elreg.CatelLogging
{
    public class TextWriterHandler : ITextWriterHandler
    {
        private TextWriter _textWriter;

        public void CreateInstance(string fileNameWithPath)
        {
            IsCreated = true;
            _textWriter = new StreamWriter(fileNameWithPath);
        }

        public void WriteLine(string text)
        {
            _textWriter.WriteLine(text);
        }

        public void Close()
        {
            _textWriter.Close();
        }

        public bool IsCreated { get; private set; }

        public void Flush()
        {
            _textWriter.Flush();
        }
    }
}
