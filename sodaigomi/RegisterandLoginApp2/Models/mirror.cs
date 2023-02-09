using System.ComponentModel.DataAnnotations;
namespace RegisterandLoginApp2.Models
{
    public class mirror
    {
        public int ID { get; set; }
        public string Location { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime TimeLimit { get; set; }
        public string Contact { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public byte[]? Photo { get; set; }
    }
}
