using Microsoft.AspNetCore.Mvc;
using PizzaSouvlakiProject.ReadModels;
using PizzaSouvlakiProject.Services;

namespace allPizzas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaController : ControllerBase
    {
        private readonly ILogger<PizzaController> _logger;

        static private List<PizzaModel> allPizza = new List<PizzaModel>();

        public PizzaController(ILogger<PizzaController> logger)
        {
            _logger = logger;

            if (!(allPizza.Count != 0))
            {
                allPizza = new PizzaServices().GetEveryPizza();
            }
        }

        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(IEnumerable<PizzaModel>), 200)]
        public IEnumerable<PizzaModel> Search()
        => allPizza;

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(PizzaModel),200)]
        public ActionResult<PizzaModel> Find(string id)
        {
            var flight = allPizza.SingleOrDefault(f => f.Id == id);

            if (flight == null)
                return NotFound();

            return Ok(flight);
        }
         
    }
}