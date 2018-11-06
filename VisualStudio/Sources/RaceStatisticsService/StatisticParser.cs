using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Elreg.RaceStatisticsService
{
    public class StatisticParser
    {
        private readonly string _fileName;
        private string _copiedFileName;
        private string _xml;
        private Statistics _statistics;

        public StatisticParser(string fileName)
        {
            _fileName = fileName;
        }

        public Statistics DoWork()
        {
            CopyFile();
            using (StreamReader streamReader = new StreamReader(_copiedFileName))
            {
                _xml = streamReader.ReadToEnd();
                streamReader.Close();

                AddStartTagToText();
                ParserXml();
            }
            RemoveCopiedFile();
            return _statistics;
        }

        private void RemoveCopiedFile()
        {
            File.Delete(_copiedFileName);
        }

        private void CopyFile()
        {
            _copiedFileName = _fileName + ".temp_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
            File.Copy(_fileName, _copiedFileName, true);
        }

        private void AddStartTagToText()
        {
            _xml = "<Statistics><StatisticRecords>" + _xml + "</StatisticRecords></Statistics>";
        }

        private void ParserXml()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Statistics));
            MemoryStream memoryStream = new MemoryStream(ConvStringToUtf8ByteArray(_xml));
            _statistics = xmlSerializer.Deserialize(memoryStream) as Statistics;
        }

        private Byte[] ConvStringToUtf8ByteArray(String pXmlString)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            Byte[] byteArray = encoding.GetBytes(pXmlString);
            return byteArray;
        } 


    }
}
