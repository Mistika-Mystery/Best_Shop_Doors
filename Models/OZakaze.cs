namespace Best_Shop_Doors.Models
{
    public class OZakaze
    {
        public int ID { get; set; }
        public int ZakazID { get; set; }
        public int DoorID { get; set; }
        public int Kolich { get; set; }

        public Zakaz? Zakaz { get; set; }
        public Door? Door { get; set; }
    }
}
