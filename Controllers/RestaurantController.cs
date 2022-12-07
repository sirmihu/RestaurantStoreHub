using Microsoft.AspNetCore.Mvc;
using RestaurantStoreHub.Entities;
using RestaurantStoreHub.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantStoreHub.Services;
using System.ComponentModel.DataAnnotations;


namespace RestaurantStoreHub.Controllers
{
    [Route("api/restaurant")]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var isDeleted = _restaurantService.Delete(id);

            if(isDeleted)
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult CreateRestaurant([FromBody]CreateRestaurantDto dto)
        {
           if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);  
            }

            var id = _restaurantService.Create(dto);

            return Created($"/api/restaurant/{id}", null);
        }

        [HttpGet]
        public ActionResult<IEnumerable<RestaurantDto>> GetAll()
        {
            var restaurantsDtos = _restaurantService.GetAll();

            return Ok(restaurantsDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<RestaurantDto> Get([FromRoute] int id)
        {
            var restaurant = _restaurantService.GetById(id);

            if(restaurant == null)
            {
                return NotFound();
            }

            return Ok(restaurant);
        }
    }
}
