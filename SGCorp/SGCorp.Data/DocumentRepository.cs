using System.Collections.Generic;
using System.IO;
using System.Linq;
using SGCorp.Models;

namespace SGCorp.Data
{
    public class DocumentRepository
    {
        List<Document> _documents = new List<Document>();
        public List<Document> GetAll(string filePath)
        {
            if (File.Exists(filePath))
            {
                var reader = File.ReadAllLines(filePath);

                for (var i = 1; i < reader.Length; i++)
                {
                    var columns = reader[i].Split('`');

                    var doc = new Document()
                    {
                        DocumentId = int.Parse(columns[0]),
                        DocumentName = columns[1],
                        CategoryName = columns[2],
                        DocumentFilePath = columns[3]
                    };
                    _documents.Add(doc);
                }
            }
            return _documents;
        }

        public void Add(Document doc, string filePath)
        {
            List<Document> docs = GetAll(filePath);
            if (docs.Any())
                doc.DocumentId = docs.Max(d => d.DocumentId) + 1;
            else
                doc.DocumentId = 1;

            docs.Add(doc);

            OverwriteFile(docs, filePath);
        }

        public void Delete(Document doc, string filePath)
        {
            //_resumes = GetAll(fileName);
            //_resumes.Remove(resume);
            OverwriteFile(_documents, filePath);
        }

        private void OverwriteFile(List<Document> docsUpdate, string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            using (var writer = File.CreateText(filePath))
            {
                writer.WriteLine("DocumentId`DocumentName`CategoryName`DocumentFilePath");

                foreach (var d in docsUpdate)
                {
                    writer.WriteLine("{0}`{1}`{2}`{3}", d.DocumentId,d.DocumentName,d.CategoryName,d.DocumentFilePath);
                }
            }
        }
    }
}