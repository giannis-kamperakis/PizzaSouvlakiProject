using PizzaSouvlakiProject.DataModel;
using PizzaSouvlakiProject.Interfaces.IPizza;
using PizzaSouvlakiProject.ReadModels;

namespace PizzaSouvlakiProject.Services
{
    public class PizzaServices : IPizzaGetEveryPizza
    {
        string dataSource = "";
        string initialCatalog = "";
        string integratedSecurity = "";

        public PizzaServices()
        {
            this.dataSource = "(LocalDb)\\PizzaSouvlakiDB";
            this.initialCatalog = "PizzaSouvlakiProject";
            this.integratedSecurity = "true";
        }
        public List<PizzaModel> GetEveryPizza()
        {
            string connectionString = $"Data Source = {this.dataSource}; Initial Catalog={this.initialCatalog}; Integrated Security={this.integratedSecurity}";
            string query = @"
                        SELECT 
                            sou.Id, 
                            sou.Name, 
                            sou.SmallDescription, 
                            sou.BigDescription,
                            sou.Price,
                            ty.Id,
                            ty.Name
                        FROM Pizza AS sou INNER JOIN FoodType as ty on sou.TypeId = ty.Id";
    
            return new PizzaDataModels().RetrieveDataForEveryPizza(connectionString, query);

        }
    }
}
