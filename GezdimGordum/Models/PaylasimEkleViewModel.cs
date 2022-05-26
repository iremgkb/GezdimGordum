// https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads?view=aspnetcore-5.0
using GezdimGordum.Attributes;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace GezdimGordum.Models
{
    public class PaylasimEkleViewModel
    {

        public string Aciklama { get; set; }

        [Required]
        [GecerliResim(MaksimumDosyaBoyutu = 1000)]
        public IFormFile Resim { get; set; }
    }
}
