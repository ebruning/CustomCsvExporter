using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Kofax.Eclipse.Base;
   
namespace CustomCsvExporter
{
    public class CustomCsvExporter : IPageIndexGenerator, IBatchIndexGenerator
    {
        public void SerializeSettings(Stream output)
        {
            
        }

        public void DeserializeSettings(Stream input)
        {
            
        }

        public void Setup(IDictionary<string, string> releaseData)
        {
            
        }

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

        void IBatchIndexGenerator.SerializeSample(IDictionary<string, string> releaseData, Stream output)
        {
            //SerializeSample(releaseData, output);
        }

        public object StartIndex(IBatch batch, IDictionary<string, string> releaseData, string outputFileName)
        {
            return null;
        }

        public void AppendIndex(IDocument document, string outputFileName)
        {
            
        }

        public void EndIndex(object handle, ReleaseResult result, string outputFileName)
        {
           
        }

        public ReleaseMode WorkingMode
        {
            get { return ReleaseMode.SinglePage; }
            set {}
        }

        void IPageIndexGenerator.SerializeSample(IDictionary<string, string> releaseData, Stream output)
        {
            //SerializeSample(releaseData, output);
        }

        public void CreateIndex(IPage page, IDictionary<string, string> releaseData, string outputFileName)
        {
            
        }
    }
}
