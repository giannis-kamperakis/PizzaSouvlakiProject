namespace Pizza.ReadModels
{
    public class SouvlakiType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public SouvlakiType(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
