namespace Best_Shop_Doors.Models
{
    public class Tip
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public List<Door>? DoorsTip { get; set; }
    }
}
