namespace codessey_csharp_server.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int ProgrammerId { get; set; }
        public string Author { get; set; }
        public DateTime CreatedAt {  get; set; }
        public DateTime CompletedAt {  get; set; }
        public bool Done {  get; set; }
}
}
