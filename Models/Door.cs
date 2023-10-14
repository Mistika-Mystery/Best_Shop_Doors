namespace Best_Shop_Doors.Models
{
    public class Door
    {
        public int ID { get; set; }
        public string? Name { get; set; }

        public ushort Price { get; set; }
        public int TipID { get; set; }

        public int MaterialID { get; set; }
        public int ColorID { get; set; }
        public int ProizvoditelID { get; set; }
        public string? Foto { get; set; }
        public string? Opisanie { get; set; }
        public virtual Tip? Tip { get; set; }
        public Material? Material { get; set; }
        public Color? Color { get; set; }
        public Proizvoditel? Proizvoditel { get; set; }


    }
}
