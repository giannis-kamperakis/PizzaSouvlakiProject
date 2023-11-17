using Pizza.ReadModels;
using PizzaSouvlakiProject.ReadModels;

namespace PizzaSouvlakiProject.Interfaces.ISouvlaki
{
    public class SouvlakiInterfaces
    {
        ///<summary>
        //Interface for the Souvlaki services
        ///</summary>
        public interface ISouvlakiGetEverySouvlaki
        {
            List<SouvlakiModel> GetEverySouvlaki();
        }
    }
}
