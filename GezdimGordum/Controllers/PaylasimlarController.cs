using GezdimGordum.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;


// https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.hosting.iwebhostenvironment.webrootpath?view=aspnetcore-5.0
namespace GezdimGordum.Controllers
{
    public class PaylasimlarController : Controller
    {
        private readonly UygulamaDbContext _db;
        private readonly IWebHostEnvironment _env;

        public PaylasimlarController(UygulamaDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        // GET: Paylasimlar/Yeni
        public IActionResult Yeni()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Yeni(PaylasimEkleViewModel vm)
        {
            if (ModelState.IsValid)
            {
                string uzanti = Path.GetExtension(vm.Resim.FileName);
                string dosyaAd = Guid.NewGuid() + uzanti;
                string kaydetmeYolu = Path.Combine(_env.WebRootPath, "img", dosyaAd);

                using (var stream = System.IO.File.Create(kaydetmeYolu))
                {
                    vm.Resim.CopyTo(stream);
                }

                _db.Paylasimlar.Add(new Paylasim()
                {
                    Aciklama = vm.Aciklama,
                    ResimYolu = dosyaAd
                });
                _db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Sil(int id)
        {
            var paylasim = _db.Paylasimlar.Find(id);

            if (paylasim == null) return NotFound();

            string silmeYolu = Path.Combine(_env.WebRootPath, "img", paylasim.ResimYolu);

            if (System.IO.File.Exists(silmeYolu))
                System.IO.File.Delete(silmeYolu);

            _db.Paylasimlar.Remove(paylasim);
            _db.SaveChanges();

            return Ok();
        }
    }
}
