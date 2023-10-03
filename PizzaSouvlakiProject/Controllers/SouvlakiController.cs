using Pizza.ReadModels;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using PizzaSouvlakiProject.ReadModels;
using System.Reflection.PortableExecutable;
using System.Data;
using System.Linq;

namespace allSouvlakia.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SouvlakiController : ControllerBase
    {
        private readonly ILogger<SouvlakiController> _logger;
        
        string connectionString = "Data Source=(LocalDb)\\sqlite-customers; Initial Catalog=PizzaSouvlakiProject; Integrated Security=True";

        static private List<Souvlaki> allSouvlakia = new List<Souvlaki>();

        public SouvlakiController(ILogger<SouvlakiController> logger)
        {
            _logger = logger;

            if ( !(allSouvlakia.Count != 0) ) { 
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
                        FROM Souvlaki AS sou INNER JOIN FoodType as ty on sou.TypeId = ty.Id
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

                            allSouvlakia.Add(new Souvlaki(
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
        [ProducesResponseType(typeof(IEnumerable<Souvlaki>), 200)]
        public IEnumerable<Souvlaki> Search()
        => allSouvlakia;

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(Souvlaki),200)]
        public ActionResult<Souvlaki> Find(string id)
        {
            var oneSouvlaki = allSouvlakia.SingleOrDefault(f => f.Id == id);

            if (oneSouvlaki == null)
                return NotFound();

            return Ok(oneSouvlaki);
        }
         
    }
}