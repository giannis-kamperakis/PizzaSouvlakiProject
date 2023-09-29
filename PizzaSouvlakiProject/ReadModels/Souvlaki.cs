using PizzaSouvlakiProject.ReadModels;

namespace Pizza.ReadModels
{
    public class Souvlaki
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string SmallDescription { get; set; }
        public string BigDescription { get; set; }
        public FoodType Type { get; set; }
        public string Price { get; set; }

        public Souvlaki(string id, string name, string smallDescription, string bigDescription, string price, FoodType type)
        {
            Id = id;
            Name = name;
            SmallDescription = smallDescription;
            BigDescription = bigDescription;
            Type = type;
            Price = price;
        }
    }


}
