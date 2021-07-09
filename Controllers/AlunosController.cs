using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CadEscola.Models;

namespace CadEscola.Controllers
{
    public class AlunosController : Controller
    {
        private readonly Context _Context;

        public AlunosController(Context context)
        {
            _Context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _Context.Alunos.ToListAsync());
        }
    }
}
