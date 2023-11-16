namespace PizzaSouvlakiProject.ReadModels
{
    public class PizzaModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string SmallDescription { get; set; }
        public string BigDescription { get; set; }
        public FoodType Type { get; set; }
        public string Price { get; set; }

        public PizzaModel(string id, string name, string smallDescription, string bigDescription, string price, FoodType type)
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
