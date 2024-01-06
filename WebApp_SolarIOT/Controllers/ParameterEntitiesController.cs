using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp_SolarIOT.Data;
using WebApp_SolarIOT.Models;

namespace WebApp_SolarIOT.Controllers
{
    public class ParameterEntitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ParameterEntitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ParameterEntities
        public async Task<IActionResult> Index()
        {
              return _context.parameters != null ? 
                          View(await _context.parameters.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.parameters'  is null.");
        }

        // GET: ParameterEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.parameters == null)
            {
                return NotFound();
            }

            var parameterEntities = await _context.parameters
                .FirstOrDefaultAsync(m => m.EventID == id);
            if (parameterEntities == null)
            {
                return NotFound();
            }

            return View(parameterEntities);
        }

        // GET: ParameterEntities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ParameterEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventID,latitude,longitude,accuracy,solar_volt,solar_amp,light_intensity,temperature,battery_volt,battery_amp,EventProcessedUtcTime")] ParameterEntities parameterEntities)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parameterEntities);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(parameterEntities);
        }

        // GET: ParameterEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.parameters == null)
            {
                return NotFound();
            }

            var parameterEntities = await _context.parameters.FindAsync(id);
            if (parameterEntities == null)
            {
                return NotFound();
            }
            return View(parameterEntities);
        }

        // POST: ParameterEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventID,latitude,longitude,accuracy,solar_volt,solar_amp,light_intensity,temperature,battery_volt,battery_amp,EventProcessedUtcTime")] ParameterEntities parameterEntities)
        {
            if (id != parameterEntities.EventID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parameterEntities);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParameterEntitiesExists(parameterEntities.EventID))
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
            return View(parameterEntities);
        }

        // GET: ParameterEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.parameters == null)
            {
                return NotFound();
            }

            var parameterEntities = await _context.parameters
                .FirstOrDefaultAsync(m => m.EventID == id);
            if (parameterEntities == null)
            {
                return NotFound();
            }

            return View(parameterEntities);
        }

        // POST: ParameterEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.parameters == null)
            {
                return Problem("Entity set 'ApplicationDbContext.parameters'  is null.");
            }
            var parameterEntities = await _context.parameters.FindAsync(id);
            if (parameterEntities != null)
            {
                _context.parameters.Remove(parameterEntities);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParameterEntitiesExists(int id)
        {
          return (_context.parameters?.Any(e => e.EventID == id)).GetValueOrDefault();
        }
    }
}
