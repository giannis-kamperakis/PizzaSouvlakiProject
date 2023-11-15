using Microsoft.AspNetCore.Mvc;

namespace allPizzas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaController : ControllerBase
    {
        private readonly ILogger<PizzaController> _logger;

        static private List<Pizza.ReadModels.Pizza> allPizza;

        public PizzaController(ILogger<PizzaController> logger)
        {
            _logger = logger;

            if (!(allPizza.Count != 0))
            {
                                
            }
        }

        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(IEnumerable<Pizza.ReadModels.Pizza>), 200)]
        public IEnumerable<Pizza.ReadModels.Pizza> Search()
        => allPizza;

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(Pizza.ReadModels.Pizza),200)]
        public ActionResult<Pizza.ReadModels.Pizza> Find(string id)
        {
            var flight = allPizza.SingleOrDefault(f => f.Id == id);

            if (flight == null)
                return NotFound();

            return Ok(flight);
        }
         
    }
}