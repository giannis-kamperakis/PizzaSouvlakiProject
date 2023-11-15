using PizzaSouvlakiProject.ReadModels;
using System.Data.SqlClient;

namespace PizzaSouvlakiProject.DataModel
{
    public class DataModel
    {
        public List<Pizza.ReadModels.Pizza> GetEveryPizza() {
            string connectionString = "Data Source=(LocalDb)\\PizzaSouvlakiDB; Initial Catalog=PizzaSouvlakiProject; Integrated Security=True";
            List<Pizza.ReadModels.Pizza> allPizza = new List<Pizza.ReadModels.Pizza>();
            string query = @"
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
            
            return allPizza;
        }
    }
}
