namespace PizzaSouvlakiProject.ReadModels
{
    public class ContactUsSuggestions
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string MenuToBe { get; set; }
        public string SmallDescription { get; set; }
        public string BigDescription { get; set; }

        public ContactUsSuggestions(string id, string name, string menutobe, string smallDescription, string bigDescription)
        {
            Id = id;
            Name = name;
            MenuToBe = menutobe;
            SmallDescription = smallDescription;
            BigDescription = bigDescription;
        }
    }
}
