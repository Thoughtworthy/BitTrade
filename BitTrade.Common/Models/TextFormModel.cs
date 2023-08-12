using System.ComponentModel.DataAnnotations;

namespace BitTrade.Common.Models
{
    public class TextFormModel
    {
        public int ID { get; set; }
        [Required]
        public string Text { get; set; }
    }
}
