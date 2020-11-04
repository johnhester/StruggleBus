using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StruggleBus.Models;
using StruggleBus.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StruggleBus.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _contactRepo;
        public ContactController(IContactRepository contactRepository)
        {
            _contactRepo = contactRepository;
        }
        // GET: api/<ContactController>
        [HttpGet("{userId}")]
        public IActionResult Get(int userId)
        {
            var contacts = _contactRepo.GetByUserId(userId);

            if (contacts == null)
            {
                return NotFound();
            }

            return Ok(contacts);
        }

        // GET api/<ContactController>/5
        [HttpGet("{userId}/{contactId}")]
        public IActionResult Get(int userId, int contactId)
        {
            var contact = _contactRepo.GetById(contactId);

            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
        }

        // POST api/<ContactController>
        [HttpPost]
        public IActionResult Post(Contact contact)
        {
            try
            {
                _contactRepo.Add(contact);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception:", ex);

                return NotFound();
            }

            return CreatedAtAction("Get", new { userId = contact.UserId }, contact);
        }

        // PUT api/<ContactController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Contact contact)
        {
            if (id != contact.Id)
            {
                return BadRequest();
            }

            _contactRepo.Edit(contact);
            

            return NoContent();
        }

        // DELETE api/<ContactController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _contactRepo.Delete(id);

            return NoContent();
        }
    }
}
