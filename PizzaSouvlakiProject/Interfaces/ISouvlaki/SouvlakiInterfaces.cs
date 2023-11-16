using Pizza.ReadModels;
using PizzaSouvlakiProject.ReadModels;

namespace PizzaSouvlakiProject.Interfaces.ISouvlaki
{
    public class SouvlakiInterfaces
    {
        public interface ISouvlakiGetEverySouvlaki
        {
            List<SouvlakiModel> GetEverySouvlaki();
        }
    }
}
