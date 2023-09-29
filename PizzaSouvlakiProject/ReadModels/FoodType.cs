namespace PizzaSouvlakiProject.ReadModels
{
    public class FoodType
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public FoodType(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
