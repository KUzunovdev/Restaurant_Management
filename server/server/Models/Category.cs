namespace server.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public List<MenuItem> MenuItems { get; set; }
    }
}
