using DomainSuperhero.Interfaces;
using DomainSuperhero.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace SuperheroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperheroController : ControllerBase
    {
        private readonly ISuperheroRepository _superRepository;

        public SuperheroController(ISuperheroRepository superRepository)
        {
            _superRepository = superRepository;
        }

        /// <summary>
        /// Gets all heroes
        /// </summary>
        /// <returns>returns all heroes</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _superRepository.GetAllSuperherores();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetOne(int id)
        {
            try
            {
                var result = await _superRepository.GetOneSuperhero(id);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Creates an Superhero.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST api/Employee
        ///     {        
        ///       "superheroID": 0,
        ///       "name": "Andrew",
        ///       "superheroName": "Amazing-SpiderMan",
        ///       "city": "Queens"
        ///     }
        /// </remarks>
        /// <param name="hero"></param>      
        [HttpPost]
        public async Task<IActionResult> InsertSuperhero(SuperheroModel hero)
        {
            try
            {
                var result = await _superRepository.InsertSuperhero(hero);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Updates the specified hero chosen by you
        /// </summary>
        /// <param name="hero"></param>
        /// <returns>return the hero you have updated</returns>
        [HttpPut]
        public async Task<IActionResult> UpdateSuperhero(SuperheroModel hero)
        {
            try
            {
                var result = await _superRepository.UpdateSuperhero(hero);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// deletes the hero
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Hero is deleted</returns>
        [HttpDelete("id")]      
        public async Task<IActionResult> DeleteSuperhero(int id)
        {
            try
            {
                var result = await _superRepository.DeleteSuperhero(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // to kill port npx kill-port 4200
    }
}
