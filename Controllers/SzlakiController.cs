using App_web_Tatry.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App_web_Tatry.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SzlakiController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SzlakiController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Szlaki.Include(s => s.Zdjecia).ToListAsync());
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var szlak = await _context.Szlaki
                .Include(s => s.Zdjecia)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (szlak == null) return NotFound();

            return View(szlak);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Id,Nazwa,Opis,Dlugosc,CzasPrzejscia,PoziomTrudnosci,KolorSzlakow,Zdjecia")] Szlak szlak, List<IFormFile> plikiZdjec)
        {
            if (ModelState.IsValid)
            {
                _context.Add(szlak);
                await _context.SaveChangesAsync();

                if (plikiZdjec != null && plikiZdjec.Count > 0)
                {
                    string folderZapisu = Path.Combine(_webHostEnvironment.WebRootPath, "images");

                    if (!Directory.Exists(folderZapisu))
                    {
                        Directory.CreateDirectory(folderZapisu);
                    }

                    foreach (var plik in plikiZdjec)
                    {
                        if (plik.Length > 0)
                        {
                            string unikalnaNazwaPliku = Guid.NewGuid().ToString() + "_" + Path.GetFileName(plik.FileName);
                            string pelnaSciezkaPliku = Path.Combine(folderZapisu, unikalnaNazwaPliku);

                            using (var stream = new FileStream(pelnaSciezkaPliku, FileMode.Create))
                            {
                                await plik.CopyToAsync(stream);
                            }

                            var noweZdjecie = new Zdjecie
                            {
                                SciezkaPliku = "/images/" + unikalnaNazwaPliku,
                                SzlakId = szlak.Id
                            };

                            _context.Zdjecia.Add(noweZdjecie);
                        }
                    }
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
            }
            return View(szlak);
        }

        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var szlak = await _context.Szlaki.FindAsync(id);
            if (szlak == null)
            {
                return NotFound();
            }
            return View(szlak);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int? id, [Bind("Id,Nazwa,Opis,Dlugosc,CzasPrzejscia,PoziomTrudnosci,KolorSzlakow,Zdjecia")] Szlak szlak)
        {
            if (id != szlak.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(szlak);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SzlakExists(szlak.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(szlak);
        }

        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var szlak = await _context.Szlaki
                .FirstOrDefaultAsync(m => m.Id == id);
            if (szlak == null)
            {
                return NotFound();
            }

            return View(szlak);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var szlak = await _context.Szlaki.FindAsync(id);
            if (szlak != null)
            {
                _context.Szlaki.Remove(szlak);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SzlakExists(int? id)
        {
            return _context.Szlaki.Any(e => e.Id == id);
        }
    }
}


