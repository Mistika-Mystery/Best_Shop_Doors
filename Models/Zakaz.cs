using System.ComponentModel.DataAnnotations;

namespace Best_Shop_Doors.Models
{
    public class Zakaz
    {
        public int ID { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public int UserID { get; set; }
        public AppUser? AppUser { get; set; }
    }
}
