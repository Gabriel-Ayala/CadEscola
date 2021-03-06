using CadEscola.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CadEscola.Controllers
{
    public class ResponsaveisController : Controller
    {
        private readonly Context _context;

        public ResponsaveisController(Context context)
        {
            _context = context;
        }

        // GET: Responsavels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Responsaveis.ToListAsync());
        }

        // GET: Responsavels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var responsavel = await _context.Responsaveis
                .FirstOrDefaultAsync(m => m.ResponsavelId == id);
            if (responsavel == null)
            {
                return NotFound();
            }

            return View(responsavel);
        }

        // GET: Responsavels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Responsavels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ResponsavelId,Nome,DataNascimento,CPF")] Responsavel responsavel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(responsavel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(responsavel);
        }

        // GET: Responsavels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var responsavel = await _context.Responsaveis.FindAsync(id);
            if (responsavel == null)
            {
                return NotFound();
            }
            return View(responsavel);
        }

        // POST: Responsavels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ResponsavelId,Nome,DataNascimento,CPF")] Responsavel responsavel)
        {
            if (id != responsavel.ResponsavelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(responsavel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResponsavelExists(responsavel.ResponsavelId))
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
            return View(responsavel);
        }

        // GET: Responsavels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var responsavel = await _context.Responsaveis
                .FirstOrDefaultAsync(m => m.ResponsavelId == id);
            if (responsavel == null)
            {
                return NotFound();
            }

            return View(responsavel);
        }

        // POST: Responsavels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var responsavel = await _context.Responsaveis.FindAsync(id);
            _context.Responsaveis.Remove(responsavel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResponsavelExists(int id)
        {
            return _context.Responsaveis.Any(e => e.ResponsavelId == id);
        }
    }
}
