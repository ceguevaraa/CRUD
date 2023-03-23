using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Phonebook.Requests;
using Phonebook.Services;

namespace Phonebook.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        private IContactService _contactService;
        private IMapper _mapper;

        public ContactController(
    IContactService contactService,
    IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _contactService.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _contactService.GetById(id);
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Create(CreateRequest model)
        {
            _contactService.Create(model);
            return Ok(new { message = "Contact created" });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateRequest model)
        {
            _contactService.Update(id, model);
            return Ok(new { message = "Contact updated" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _contactService.Delete(id);
            return Ok(new { message = "Contact deleted" });
        }
    }
}
