using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using codessey_csharp_server.Repositories;
using codessey_csharp_server.Models;

namespace codessey_csharp_server.Controllers


{
    [Route("/[controller]")]
    [ApiController]
    public class EntryController : ControllerBase
    {

        private readonly IEntryRepository _entryRepository;

        public EntryController(IEntryRepository entryRepository)
        {
            _entryRepository = entryRepository;
        }

        // GET: EntryController
        [HttpGet]
        public IActionResult Get()
        {
            var entries = _entryRepository.GetAll();
            return Ok(entries);
        }

        // GET: EntryController/Details/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var entry = _entryRepository.GetEntryById(id);
            if (entry == null)
            {
                return NotFound();
            }
            return Ok(entry);
        }

        // POST: EntryController/Create
        [HttpPost]
        public IActionResult Post([FromBody] Entry entry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _entryRepository.AddEntry(entry);
            return CreatedAtAction(nameof(GetEntryById), new { id = entry.Id }, entry);
        }

        private object GetEntryById()
        {
            throw new NotImplementedException();
        }

        // GET: EntryController/Edit/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Entry entry)
        {
            if (id != entry.Id)
            {
                return BadRequest();
            }

            _entryRepository.UpdateEntry(entry);
            return NoContent();
        }

        // GET: EntryController/Delete/5

    }
}
