namespace Best_Shop_Doors.Models
{
    public class Material
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public List<Door>? DoorsMaterial { get; set; }
    }
}
