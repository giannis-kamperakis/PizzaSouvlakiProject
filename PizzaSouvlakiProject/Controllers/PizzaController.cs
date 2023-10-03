using Microsoft.AspNetCore.Mvc;
using Pizza.ReadModels;
using PizzaSouvlakiProject.ReadModels;
using System.Data.SqlClient;

namespace allPizzas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaController : ControllerBase
    {
        private readonly ILogger<PizzaController> _logger;

        string connectionString = "Data Source=(LocalDb)\\sqlite-customers; Initial Catalog=PizzaSouvlakiProject; Integrated Security=True";

        static private List<Pizza.ReadModels.Pizza> allPizza = new List<Pizza.ReadModels.Pizza>();

        public PizzaController(ILogger<PizzaController> logger)
        {
            _logger = logger;

            if (!(allPizza.Count != 0))
            {
                string query = "";

                query = @"
                          SELECT 
                            sou.Id, 
                            sou.Name, 
                            sou.SmallDescription, 
                            sou.BigDescription,
                            sou.Price,
                            ty.Id,
                            ty.Name
                        FROM Pizza AS sou INNER JOIN FoodType as ty on sou.TypeId = ty.Id
                    ";


                using (SqlConnection connection = new SqlConnection(
                           connectionString))
                {
                    SqlCommand command = new SqlCommand(
                        query, connection);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        string id = "";
                        string name = "";
                        string smallDescription = "";
                        string bigDescription = "";
                        string price = "";
                        string typeId = "";
                        string typeName = "";

                        while (reader.Read())
                        {
                            id = reader.GetValue(0).ToString();
                            name = reader.GetValue(1).ToString();
                            smallDescription = reader.GetValue(2).ToString();
                            bigDescription = reader.GetValue(3).ToString();
                            price = reader.GetValue(4).ToString();
                            typeId = reader.GetValue(5).ToString();
                            typeName = reader.GetValue(6).ToString();

                            allPizza.Add(new Pizza.ReadModels.Pizza(
                                        id,
                                        name,
                                        smallDescription,
                                        bigDescription,
                                        price,
                                        new FoodType(typeId, typeName)
                                    )
                            );
                        }

                        reader.Close();
                    }
                    connection.Close();
                }
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