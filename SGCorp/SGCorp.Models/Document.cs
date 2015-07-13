namespace SGCorp.Models
{
    public class Document
    {
        public int DocumentId { get; set; }
        public Category CategoryType { get; set; }
        public string CategoryName { get { return CategoryType.ToString(); } }
        public string DocumentFilePath { get; set; }
    }
}