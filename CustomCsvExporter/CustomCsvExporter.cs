using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Kofax.Eclipse.Base;
   
namespace CustomCsvExporter
{
    public class CustomCsvExporter : IPageIndexGenerator, IBatchIndexGenerator
    {
        public void SerializeSettings(Stream output){}

        public void DeserializeSettings(Stream input){}

        public void Setup(IDictionary<string, string> releaseData){}

        public Guid Id
        {
            get { return new Guid("{6B5D9632-7E47-4818-8684-67720B20554B}"); }
        }

        public string Name
        {
            get { return "Custom CSV Exporter"; }
        }

        public string Description
        {
            get { return "Exports indexes for each document"; }
        }

        public string DefaultExtension
        {
            get { return "CSV"; }
        }

        public bool IsCustomizable
        {
            get { return false; }
        }

        public bool IsSupported(ReleaseMode mode)
        {
            return true;
        }

        void IBatchIndexGenerator.SerializeSample(IDictionary<string, string> releaseData, Stream output){}

        public object StartIndex(IBatch batch, IDictionary<string, string> releaseData, string outputFileName)
        {
            using (FileStream fs = new FileStream(outputFileName, FileMode.CreateNew, FileAccess.Write, FileShare.None))
            using (StreamWriter writer = new StreamWriter(fs, Encoding.ASCII))
            {
                string indexNames = string.Empty;

                for (int count = 0; count < batch.IndexFieldCount; count++ )
                {
                    indexNames += string.Format("{0},", batch.GetIndexField(count).Label);
                }
                indexNames = indexNames.TrimEnd(',');
 
                writer.WriteLine(string.Format("{0},{1}", indexNames, "FileName"));
                writer.Flush();
                writer.Close();
            }

            return null;
        }

        public void AppendIndex(IDocument document, string outputFileName)
        {
            using (FileStream fs = new FileStream(outputFileName, FileMode.Append, FileAccess.Write, FileShare.None))
            using (StreamWriter writer = new StreamWriter(fs, Encoding.ASCII))
            {
                string indexData = string.Empty;

                for (int count = 0; count < document.IndexDataCount; count++)
                {
                    indexData += string.Format("{0},", document.GetIndexDataValue(count));
                }
                indexData = indexData.TrimEnd(',');

                for (int count = 1; count < document.PageCount; count++ )
                    writer.WriteLine(string.Format("{0},{1}", indexData, document.GetPage(count).OutputFileName));

                writer.Flush();
                writer.Close();
            }
        }

        public void EndIndex(object handle, ReleaseResult result, string outputFileName){}

        public ReleaseMode WorkingMode
        {
            get { return ReleaseMode.SinglePage; }
            set {}
        }

        void IPageIndexGenerator.SerializeSample(IDictionary<string, string> releaseData, Stream output){}

        public void CreateIndex(IPage page, IDictionary<string, string> releaseData, string outputFileName){}
    }
}
