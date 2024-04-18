using codessey_csharp_server.Models;

namespace codessey_csharp_server.Repositories
{
    public interface IEntryRepository
    {
        void AddEntry(Entry entry);
        List<Entry> GetAll();
        Entry GetEntryById(int id);
        void UpdateEntry(Entry entry);
    }
}