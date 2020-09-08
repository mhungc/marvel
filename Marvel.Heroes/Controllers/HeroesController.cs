using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marvel.Heroes.DAL;
using Marvel.Heroes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Marvel.Heroes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        private IHeroesProvider _heroesProvider;
        public HeroesController(IHeroesProvider heroesProvider)
        {
            _heroesProvider = heroesProvider;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            var result = await _heroesProvider.GetAsync(id);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }

        [HttpGet("")]
        public async Task<IEnumerable<Hero>> GetAsync()
        {
            return await _heroesProvider.GetAsync();
        }
    }
}
