namespace SGCorp.Models
{
    public class Document
    {
        public int DocumentId { get; set; }
        //public Category CategoryType { get; set; }
        public string DocumentName {get; set; }
        public string CategoryName { get; set; }
        public string DocumentFilePath { get; set; }
    }
}