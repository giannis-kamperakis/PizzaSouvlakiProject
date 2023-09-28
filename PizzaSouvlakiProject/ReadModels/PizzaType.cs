namespace Pizza.ReadModels
{
    public class PizzaType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public PizzaType(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
