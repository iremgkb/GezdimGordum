using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace GezdimGordum.Attributes
{
    public class GecerliResimAttribute : ValidationAttribute
    {
        /// <summary>
        /// Kilobyte cinsinden yüklenebilecek maksimum dosya boyutu. Default: 1024
        /// </summary>
        public int MaksimumDosyaBoyutu { get; set; } = 1024;

        public override bool IsValid(object value)
        {
            IFormFile formFile = value as IFormFile;

            if (formFile == null)
                return true;

            if (!formFile.ContentType.StartsWith("image/"))
            {
                ErrorMessage = "Geçersiz resim dosyası.";
                return false;
            }
            else if (formFile.Length > MaksimumDosyaBoyutu * 1024)
            {
                ErrorMessage = $"Maksimum dosya boyutu: {MaksimumDosyaBoyutu}kb.";
                return false;
            }
            return true;
        }
    }
}
