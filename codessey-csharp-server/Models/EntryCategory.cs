namespace codessey_csharp_server.Models
{
    public class EntryCategory
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int EntryId { get; set; }
        public Entry Entry { get; set; }
    }
}
