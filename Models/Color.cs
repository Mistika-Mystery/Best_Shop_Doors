namespace Best_Shop_Doors.Models
{
    public class Color
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public List<Door>? DoorsColor { get; set; }
    }
}
