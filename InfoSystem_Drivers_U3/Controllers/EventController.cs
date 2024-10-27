﻿using InfoSystem_Drivers_U3.Data;
using InfoSystem_Drivers_U3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InfoSystem_Drivers_U3.Controllers
{
    [Authorize(Roles = "Admin, Employee")]
    public class EventController : Controller
    {
        private readonly AppDbContext _context;

        public EventController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Event/Index – Lista alla händelser för en specifik förare
        public async Task<IActionResult> Index(int driverId, DateTime? startDate, DateTime? endDate)
        {
            var driver = await _context.Drivers
                .Include(d => d.Events)
                .FirstOrDefaultAsync(d => d.DriverID == driverId);

            if (driver == null)
            {
                return NotFound();
            }

            // Filtrera händelser baserat på start- och slutdatum
            var events = driver.Events.AsQueryable();
            if (startDate.HasValue)
            {
                events = events.Where(e => e.NoteDate >= startDate.Value);
            }
            if (endDate.HasValue)
            {
                events = events.Where(e => e.NoteDate <= endDate.Value);
            }

            // Sätt värden till ViewBag så de kan användas i vyn
            ViewBag.StartDate = startDate?.ToString("yyyy-MM-dd");
            ViewBag.EndDate = endDate?.ToString("yyyy-MM-dd");

            ViewBag.DriverName = driver.DriverName;
            ViewBag.DriverId = driver.DriverID;
            return View(events.ToList());
        }

        // GET: Event/Create – Visa formulär för att skapa ny händelse
        public IActionResult Create(int driverId)
        {
            ViewBag.DriverId = driverId;
            return View();
        }

        // POST: Event/Create – Lägg till ny händelse för specifik förare
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int driverId, Event newEvent)
        {
            if (ModelState.IsValid)
            {
                newEvent.DriverID = driverId;
                _context.Add(newEvent);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", new { driverId = driverId });
            }

            ViewBag.DriverId = driverId;
            return View(newEvent);
        }

        // GET: Event/Edit/5 – Visa formulär för att redigera händelse
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventToEdit = await _context.Events.FindAsync(id);
            if (eventToEdit == null)
            {
                return NotFound();
            }

            ViewBag.DriverId = eventToEdit.DriverID;
            return View(eventToEdit);
        }

        // POST: Event/Edit/5 – Uppdatera händelse i databasen
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Event eventToUpdate)
        {
            if (id != eventToUpdate.EventID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventToUpdate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Events.Any(e => e.EventID == id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", new { driverId = eventToUpdate.DriverID });
            }

            ViewBag.DriverId = eventToUpdate.DriverID;
            return View(eventToUpdate);
        }

        // GET: Event/Delete/5 – Visa bekräftelse för att ta bort händelse
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventToDelete = await _context.Events
                .Include(e => e.Driver)
                .FirstOrDefaultAsync(m => m.EventID == id);
            if (eventToDelete == null)
            {
                return NotFound();
            }

            return View(eventToDelete);
        }

        // POST: Event/Delete/5 – Ta bort händelse från databasen
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventToDelete = await _context.Events.FindAsync(id);
            var driverId = eventToDelete.DriverID;
            _context.Events.Remove(eventToDelete);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", new { driverId = driverId });
        }

        [Authorize(Roles = "Admin, Employee")]
        public async Task<IActionResult> GetNotifications(string driverName, string employeeName, DateTime? startDate, DateTime? endDate)
        {
            // Ändra timespan till 7 dagar (1 vecka)
            TimeSpan timeSpan = TimeSpan.FromDays(7);
            DateTime cutoffTime = DateTime.Now.Subtract(timeSpan);

            var events = _context.Events
                .Include(e => e.Driver)
                .Where(e => e.NoteDate >= cutoffTime);

            if (!string.IsNullOrEmpty(driverName))
            {
                events = events.Where(e => e.Driver.DriverName.Contains(driverName));
            }

            if (!string.IsNullOrEmpty(employeeName))
            {
                events = events.Where(e => e.Driver.ResponsibleEmployee.Contains(employeeName));
            }

            if (startDate.HasValue)
            {
                events = events.Where(e => e.NoteDate >= startDate.Value);
            }

            if (endDate.HasValue)
            {
                events = events.Where(e => e.NoteDate <= endDate.Value);
            }

            return View(await events.ToListAsync());
        }

    }
}