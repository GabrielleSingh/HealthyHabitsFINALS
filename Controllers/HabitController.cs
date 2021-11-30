using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using HealthyHabits.Data;
using HealthyHabits.Models;

namespace HealthyHabits.Controllers
{
    public class HabitController : Controller
    {
        public readonly ApplicationDbContext _context;

        public HabitController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var list = _context.Habits.ToList();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Habit record)
        {
            var habit = new Habit();
            {
                habit.HabitName = record.HabitName;
                habit.HabitDesc = record.HabitDesc;
                habit.IncompHB = record.IncompHB;
                habit.BadgeID = record.BadgeID;
                habit.ID = record.ID;
                habit.Type = record.Type;
            }

            _context.Habits.Add(habit);
            _context.SaveChanges();

            return RedirectToAction("Index");


        }


        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return RedirectToAction("Index");
            }

            var habit = _context.Habits.Where(i => i.HabitID == id).SingleOrDefault();
            if( habit == null)
            {
                return RedirectToAction("Index");

            }

            return View(habit);
        }

        [HttpPost]
        public IActionResult Edit(int? id, Habit record)
        {
            var habit = _context.Habits.Where(i => i.HabitID == id).SingleOrDefault();
            habit.HabitName = record.HabitName;
            habit.HabitDesc = record.HabitDesc;
            habit.IncompHB = record.IncompHB;
            habit.BadgeID = record.BadgeID;
            habit.ID = record.ID;
            habit.Type = record.Type;


            _context.Habits.Update(habit);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }


        public IActionResult Delete(int? id)
        {
             if(id == null)
            {
                return RedirectToAction("Index");
            }

            var habit = _context.Habits.Where(i => i.HabitID == id).SingleOrDefault();
            if(habit == null)
            {
                return RedirectToAction("Index");
            }


            _context.Habits.Remove(habit);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
