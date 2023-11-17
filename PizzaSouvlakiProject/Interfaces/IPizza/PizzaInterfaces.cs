using PizzaSouvlakiProject.ReadModels;

namespace PizzaSouvlakiProject.Interfaces.IPizza
{
    ///<summary>
    //Interface for the Pizza services
    ///</summary>
    public interface IPizzaGetEveryPizza
    {
        List<PizzaModel> GetEveryPizza();
    }
}
