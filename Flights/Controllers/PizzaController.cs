using Pizza.ReadModels;
using Microsoft.AspNetCore.Mvc;

namespace allPizzas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaController : ControllerBase
    {
        private readonly ILogger<PizzaController> _logger;

        static Random random = new Random();

        static private Pizza.ReadModels.Pizza[] allPizzas = new Pizza.ReadModels.Pizza[] {
                new (
                        Guid.NewGuid(),
                        "Special",
                        "1 Small Description",
                        "Special - Everything in a good bite of pizza should be balanced. " +
                            "The sauce shouldn't overpower the cheese and vice versa, the crust-to-sauce ratio should be even, " +
                            "and the choice of toppings should work fine together.",
                        new PizzaType(Guid.NewGuid(), "Vegetarian"),
                        12.5f
                    ),
                new (
                        Guid.NewGuid(),
                        "American BBQ",
                        "2 Small Description",
                        "American BBQ - Everything in a good bite of pizza should be balanced. " +
                        "The sauce shouldn't overpower the cheese and vice versa, the crust-to-sauce ratio should be even, " +
                        "and the choice of toppings should work fine together.",
                        new PizzaType(Guid.NewGuid(), "Non-Vegetarian"),
                        8.5f

                    ),
                new (
                        Guid.NewGuid(),
                        "Olives, Mushrooms and other stuff",
                        "3 Small Description",
                        "Olives, Mushrooms and other stuff - Everything in a good bite of pizza should be balanced. " +
                        "The sauce shouldn't overpower the cheese and vice versa, the crust-to-sauce ratio should be even, " +
                        "and the choice of toppings should work fine together.",
                        new PizzaType(Guid.NewGuid(), "Vegan"),
                        18.5f

                    )
            };

        public PizzaController(ILogger<PizzaController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(IEnumerable<Pizza.ReadModels.Pizza>), 200)]
        public IEnumerable<Pizza.ReadModels.Pizza> Search()
        => allPizzas;

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(Pizza.ReadModels.Pizza),200)]
        public ActionResult<Pizza.ReadModels.Pizza> Find(Guid id)
        {
            var flight = allPizzas.SingleOrDefault(f => f.Id == id);

            if (flight == null)
                return NotFound();

            return Ok(flight);
        }
         
    }
}