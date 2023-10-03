using allSouvlakia.Controllers;
using Microsoft.AspNetCore.Mvc;
using Pizza.ReadModels;
using PizzaSouvlakiProject.ReadModels;
using System.Data.SqlClient;

namespace PizzaSouvlakiProject.Controllers
{
    public class ContactUsSuggestionsController : Controller
    {
        private readonly ILogger<ContactUsSuggestionsController> _logger;

        string connectionString = "Data Source=(LocalDb)\\sqlite-customers; Initial Catalog=PizzaSouvlakiProject; Integrated Security=True";

        static private List<FoodType> allFoodTypes = new List<FoodType>();

        public ContactUsSuggestionsController(ILogger<ContactUsSuggestionsController> logger)
        {
            _logger = logger;

            if (!(allFoodTypes.Count != 0))
            {
                string query = @"SELECT * FROM FoodType";

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

                        while (reader.Read())
                        {
                            id = reader.GetValue(0).ToString();
                            name = reader.GetValue(1).ToString();

                            allFoodTypes.Add(new FoodType(
                                        id,
                                        name
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
        public IEnumerable<FoodType> GetFoodTypes()
        => allFoodTypes;
    }
}
