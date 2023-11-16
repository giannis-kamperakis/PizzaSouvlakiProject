using Pizza.ReadModels;
using PizzaSouvlakiProject.ReadModels;
using System.Data.SqlClient;

namespace PizzaSouvlakiProject.DataModel
{
    public class SouvlakiDataModels
    {
        public List<SouvlakiModel> RetrieveDataForEverySouvlaki(string connectionString, string query)
        {

            List<SouvlakiModel> allPizza = new List<SouvlakiModel>();

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

                        allPizza.Add(new SouvlakiModel(
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
