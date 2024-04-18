namespace codessey_csharp_server.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublicationDate { get; set; }
        public int ProgrammerId { get; set; }
        public string Author { get; set; }
}
}
