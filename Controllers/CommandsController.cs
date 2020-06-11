using System.Collections.Generic;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepository repository;
        private readonly IMapper mapper;

        public CommandsController(ICommanderRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        // GET api/commands
        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commandItems = repository.GetAppCommands();
            return Ok(mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
        }

        // GET api/commands/id
        [HttpGet("{id}", Name = nameof(GetCommandById))]
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
            var commandItem = repository.GetCommandById(id);
            if (commandItem == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<CommandReadDto>(commandItem));
        }

        // POST api/commands
        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand([FromBody] CommandCreateDto ccd)
        {
            var commandModel = mapper.Map<Command>(ccd);
            repository.CreateCommand(commandModel);
            repository.SaveChanges();

            var commandReadDto = mapper.Map<CommandReadDto>(commandModel);

            return CreatedAtRoute(nameof(GetCommandById), new { Id = commandReadDto.Id }, commandReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, [FromBody] CommandUpdateDto cud)
        {
            var commandModelFromRepo = repository.GetCommandById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            mapper.Map(cud, commandModelFromRepo);

            repository.UpdateCommand(commandModelFromRepo);

            repository.SaveChanges();

            return NoContent();
        }

        // PATCH api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDto> patchDoc)
        {
            var commandModelFromRepo = repository.GetCommandById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            var commandToPatch = mapper.Map<CommandUpdateDto>(commandModelFromRepo);
            patchDoc.ApplyTo(commandToPatch, ModelState);

            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem();
            }

            mapper.Map(commandToPatch, commandModelFromRepo);

            repository.UpdateCommand(commandModelFromRepo);

            repository.SaveChanges();

            return NoContent();
        }

        // DELETE api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var commandModelFromRepo = repository.GetCommandById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            repository.DeleteCommand(commandModelFromRepo);
            repository.SaveChanges();

            return NoContent();
        }
    }
}