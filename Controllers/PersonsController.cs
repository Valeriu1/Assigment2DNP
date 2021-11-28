using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assigment3WebApiDatabase.Data;
using Assigment3WebApiDatabase.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assigment3WebApiDatabase.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonsController : ControllerBase
    {
        private IPersonsService PersonsService;

        public PersonsController(IPersonsService personsService)
        {
            PersonsService = personsService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Adult>>> GetPersons()
        {
            try
            {
                IList<Adult> adults = await PersonsService.GetPersonsAsync();
                return Ok(adults);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Adult>> GetPerson([FromRoute] int id)
        {
            try
            {
                Adult adult = await PersonsService.GetAsync(id);
                return Ok(adult);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
            
        }
        
        


        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> DeletePerson([FromRoute] int id)
        {
            try
            {
                await PersonsService.RemovePersonAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Adult>> AddPerson([FromBody] Adult adult)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Adult added = await PersonsService.AddPersonAsync(adult);
            return Created($"/{added.Id}", added); // return newly added to-do, to get the auto generated id

        }

        [HttpPatch]
        [Route("{id:int}")]
        public async Task<ActionResult<Adult>> UpdatePerson([FromBody] Adult adult)
        {
            try
            {
                Adult toUpdate = await PersonsService.UpdateAsync(adult);
                return Ok(toUpdate);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Adult>> UpdatePersonPut([FromBody] Adult adult)
        {
            try
            {
                Adult toUpdate = await PersonsService.UpdateAsync(adult);
                return Ok(toUpdate);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        

    }
}