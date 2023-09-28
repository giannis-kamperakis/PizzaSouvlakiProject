using Pizza.ReadModels;
using Microsoft.AspNetCore.Mvc;

namespace allSouvlakia.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SouvlakiController : ControllerBase
    {
        private readonly ILogger<SouvlakiController> _logger;

        static private Pizza.ReadModels.Souvlaki[] allSouvlakia = new Pizza.ReadModels.Souvlaki[] {
                new (
                        Guid.NewGuid(),
                        "Souvlaki with xaloumi",
                        "1 Small Description",
                        "Souvlaki with xaloumi - Everything in a good bite of pizza should be balanced. " +
                            "The sauce shouldn't overpower the cheese and vice versa, the crust-to-sauce ratio should be even, " +
                            "and the choice of toppings should work fine together.",
                        new SouvlakiType(Guid.NewGuid(), "Vegetarian"),
                        6.5f
                    ),
                new (
                        Guid.NewGuid(),
                        "Souvlaki with every ingredient that you can imagine",
                        "2 Small Description",
                        "Souvlaki with every ingredient that you can imagine - Everything in a good bite of pizza should be balanced. " +
                        "The sauce shouldn't overpower the cheese and vice versa, the crust-to-sauce ratio should be even, " +
                        "and the choice of toppings should work fine together.",
                        new SouvlakiType(Guid.NewGuid(), "Non-Vegetarian"),
                        4.0f

                    ),
                new (
                        Guid.NewGuid(),
                        "Souvlaki with mushrooms",
                        "3 Small Description",
                        "Souvlaki with mushrooms - Everything in a good bite of pizza should be balanced. " +
                        "The sauce shouldn't overpower the cheese and vice versa, the crust-to-sauce ratio should be even, " +
                        "and the choice of toppings should work fine together.",
                        new SouvlakiType(Guid.NewGuid(), "Vegan"),
                        7.5f

                    )
            };

        public SouvlakiController(ILogger<SouvlakiController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(IEnumerable<Pizza.ReadModels.Souvlaki>), 200)]
        public IEnumerable<Pizza.ReadModels.Souvlaki> Search()
        => allSouvlakia;

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(Pizza.ReadModels.Souvlaki),200)]
        public ActionResult<Pizza.ReadModels.Souvlaki> Find(Guid id)
        {
            var oneSouvlaki = allSouvlakia.SingleOrDefault(f => f.Id == id);

            if (oneSouvlaki == null)
                return NotFound();

            return Ok(oneSouvlaki);
        }
         
    }
}