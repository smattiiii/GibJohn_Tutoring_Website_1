using System.ComponentModel.DataAnnotations;

namespace GibJohn_Tutoring_Website_1.Models
{
    public class ClickData
    {
        [Key]
        public int Id { get; set; }

        public string Label { get; set; }

        public int Count { get; set; }
    }
}
