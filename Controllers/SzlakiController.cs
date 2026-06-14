
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using App_web_Tatry.Entities;

public class SzlakiController : Controller
{
    private readonly ApplicationDbContext _context;

    public SzlakiController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: SZLAKS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Szlaki.ToListAsync());
    }

    // GET: SZLAKS/Details/5
    public async Task<IActionResult> Details(int? id)
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

    // GET: SZLAKS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: SZLAKS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Nazwa,Opis,Dlugosc,CzasPrzejscia,PoziomTrudnosci,KolorSzlakow,Zdjecia")] Szlak szlak)
    {
        if (ModelState.IsValid)
        {
            _context.Add(szlak);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(szlak);
    }

    // GET: SZLAKS/Edit/5
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

    // POST: SZLAKS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
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

    // GET: SZLAKS/Delete/5
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

    // POST: SZLAKS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
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
