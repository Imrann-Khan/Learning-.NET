using System;
using System.Reflection;

namespace FirstWebAPI
{
    public class DocumentAnalyzer
    {
        public string modelName { get; set; } = "YoloV11-Extractor";
        private void Analyze(string filePath)
        {
            Console.WriteLine($"Analyzing file: {filePath} using model: {modelName}");
        }
        public void LogInternalMetrics(string x)
        {
            Console.WriteLine($"Logging internal metrics for model: {modelName}");
        }
    }
}
