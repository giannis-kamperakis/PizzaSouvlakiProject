namespace Pizza.ReadModels
{
    public class Souvlaki
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string SmallDescription { get; set; }
        public string BigDescription { get; set; }
        public SouvlakiType Type { get; set; }
        public float Price { get; set; }

        public Souvlaki(Guid id, string name, string smallDescription, string bigDescription, SouvlakiType type, float price)
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
