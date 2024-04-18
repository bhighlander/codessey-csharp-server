namespace codessey_csharp_server.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public int ProgrammerId { get; set; }
        public string Author { get; set; }
        public virtual ICollection<EntryCategory> EntryCategories { get; set; }
    }
}
