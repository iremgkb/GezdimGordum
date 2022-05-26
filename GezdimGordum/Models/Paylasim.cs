using System.ComponentModel.DataAnnotations;

namespace GezdimGordum.Models
{
    public class Paylasim
    {
        public int Id { get; set; }
        
        [Required, MaxLength(255)]
        public string ResimYolu { get; set; }

        public string Aciklama { get; set; }

    }
}
