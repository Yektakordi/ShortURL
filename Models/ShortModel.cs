using System.ComponentModel.DataAnnotations;

namespace UrlShort.Models
{
    public class ShortModel
    {
        public int Id { get; set; }
        
        [Required]
        public string MainUrl { get; set; }
    }
}
