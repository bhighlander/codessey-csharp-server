namespace codessey_csharp_server.Models
{
    public class Entry
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime DateCreated {  get; set; }
        public bool Solved {  get; set; }
        public virtual ICollection<EntryCategory> EntryCategories { get; set; }
    }
}
