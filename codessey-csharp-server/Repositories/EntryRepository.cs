using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using codessey_csharp_server.Models;
using System.Data;
using System.Data.SqlClient;
using codessey_csharp_server.Utils;

namespace codessey_csharp_server.Repositories
{
    public class EntryRepository : BaseRepository, IEntryRepository
    {
        public EntryRepository(IConfiguration configuration) : base(configuration) { }

        public List<Entry> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT
                            Id,
                            Title,
                            Content,
                            DateCreated,
                            Solved
                        FROM Entry
                    ";

                    var reader = cmd.ExecuteReader();

                    var entries = new List<Entry>();
                    while (reader.Read())
                    {
                        entries.Add(new Entry
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Title = reader.GetString(reader.GetOrdinal("Title")),
                            Content = reader.GetString(reader.GetOrdinal("Content")),
                            DateCreated = reader.GetDateTime(reader.GetOrdinal("DateCreated")),
                            Solved = reader.GetBoolean(reader.GetOrdinal("Solved"))
                        });
                    }
                    reader.Close();

                    return entries;
                }
            }
        }

        public Entry GetEntryById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT
                            e.Id AS EntryId,
                            e.Title,
                            e.Content,
                            p.FullName AS Author,
                            e.ProgrammerId,
                            e.DateCreated,
                            e.Solved,
                        FROM
                            Entry e
                        JOIN
                            Programmer p ON e.ProgrammerId = p.Id
                        LEFT JOIN
                            EntryCategory ec ON e.Id = ec.EntryId
                        LEFT JOIN
                            Category c ON ec.CategoryId = c.Id
                        WHERE
                            e.Id = @Id;
                    ";
                    cmd.Parameters.AddWithValue("@Id", id);

                    var reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        var entry = new Entry
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("EntryId")),
                            Title = reader.GetString(reader.GetOrdinal("Title")),
                            Content = reader.GetString(reader.GetOrdinal("Content")),
                            DateCreated = reader.GetDateTime(reader.GetOrdinal("DateCreated")),
                            Author = reader.GetString(reader.GetOrdinal("Author")),
                            Solved = reader.GetBoolean(reader.GetOrdinal("Solved")),
                        };
                        reader.Close();
                        return entry;
                    }

                    reader.Close();
                    return null;
                }
            }
        }

        public void AddEntry(Entry entry)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        INSERT INTO Entry (Title, Content, ProgrammerId, DateCreated, Solved)
                        VALUES (@Title, @Content, @ProgrammerId, @DateCreated, @Solved);
                        SELECT SCOPE_IDENTITY();
                    ";
                    cmd.Parameters.AddWithValue("@Title", entry.Title);
                    cmd.Parameters.AddWithValue("@Content", entry.Content);
                    cmd.Parameters.AddWithValue("@DateCreated", entry.DateCreated);
                    cmd.Parameters.AddWithValue("@Solved", entry.Solved);

                    entry.Id = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public void UpdateEntry(Entry entry)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        UPDATE Entry
                        SET Title = @Title,
                            Content = @Content,
                            ProgrammerId = @ProgrammerId,
                            DateCreated = @DateCreated,
                            Solved = @Solved
                        WHERE Id = @Id;
                    ";
                    cmd.Parameters.AddWithValue("@Title", entry.Title);
                    cmd.Parameters.AddWithValue("@Content", entry.Content);
                    cmd.Parameters.AddWithValue("@DateCreated", entry.DateCreated);
                    cmd.Parameters.AddWithValue("@Solved", entry.Solved);
                    cmd.Parameters.AddWithValue("@Id", entry.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }


    }
}
