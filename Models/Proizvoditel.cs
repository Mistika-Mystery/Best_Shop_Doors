namespace Best_Shop_Doors.Models
{
    public class Proizvoditel
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public List<Door>? DoorsProizvod { get; set; }
    }
}
