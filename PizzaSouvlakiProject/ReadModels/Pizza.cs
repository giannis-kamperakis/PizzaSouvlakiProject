namespace Pizza.ReadModels
{
    public class Pizza
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string SmallDescription { get; set; }
        public string BigDescription { get; set; }
        public PizzaType Type { get; set; }
        public float Price { get; set; }

        public Pizza(Guid id, string name, string smallDescription, string bigDescription, PizzaType type, float price)
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
