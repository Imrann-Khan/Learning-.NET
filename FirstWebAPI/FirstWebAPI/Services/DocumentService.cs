namespace FirstWebAPI.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IEmbeddingService? _model;
        public DocumentService(IEmbeddingService? model)
        {
            _model = model;
        }
        public void Process(string? filePath)
        {
            _model?.Load();
            Console.WriteLine($"Extracting text from {filePath}");
        }
    }
}
