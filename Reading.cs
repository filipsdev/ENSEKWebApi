using System.ComponentModel.DataAnnotations;

namespace ENSEK
{
    public class Reading
    {
        [Key]
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string MeterReadingDateTime { get; set; }
        public int MeterReadValue { get; set; }
    }
}
