namespace Iterator.Models
{
    class Item
    {
        private string name;
        public Item(string name)
        {
            this.name = name;
        }
        public string Name
        {
            get { return name; }
        }
    }
}
