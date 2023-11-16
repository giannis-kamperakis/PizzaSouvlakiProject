using Pizza.ReadModels;
using PizzaSouvlakiProject.DataModel;
using static PizzaSouvlakiProject.Interfaces.ISouvlaki.SouvlakiInterfaces;

namespace PizzaSouvlakiProject.Services
{
    public class SouvlakiServices : ISouvlakiGetEverySouvlaki
    {
        string dataSource = "";
        string initialCatalog = "";
        string integratedSecurity = "";

        public SouvlakiServices()
        {
            this.dataSource = "(LocalDb)\\PizzaSouvlakiDB";
            this.initialCatalog = "PizzaSouvlakiProject";
            this.integratedSecurity = "true";
        }
        public List<SouvlakiModel> GetEverySouvlaki()
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

            return new SouvlakiDataModels().RetrieveDataForEverySouvlaki(connectionString, query);

        }
    }
}
