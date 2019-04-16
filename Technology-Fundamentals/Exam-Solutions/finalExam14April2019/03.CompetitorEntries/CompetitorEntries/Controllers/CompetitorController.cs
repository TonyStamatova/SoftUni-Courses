using CompetitorEntries.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CompetitorEntries.Controllers
{
    public class CompetitorController : Controller
    {
        private readonly CompetitorEntriesDbContext context;

        public CompetitorController(CompetitorEntriesDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            using (CompetitorEntriesDbContext db = new CompetitorEntriesDbContext())
            {
                var allCompetitors = db.Competitors.ToList();
                return this.View(allCompetitors);
            }            
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(Competitor competitor)
        {
            if (competitor == null)
            {
                return RedirectToAction("Index");
            }

            var newCompetitor = new Competitor
            {
                Name = competitor.Name,
                Age = competitor.Age,
                Category = competitor.Category,
                Team = competitor.Team
            };

            using (CompetitorEntriesDbContext db = new CompetitorEntriesDbContext())
            {                
                db.Competitors.Add(newCompetitor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }               
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            using (CompetitorEntriesDbContext db = new CompetitorEntriesDbContext())
            {
                var compToEdit = db.Competitors.FirstOrDefault(x => x.Id == id);

                if (compToEdit == null)
                {
                    return RedirectToAction("Index");
                }

                return this.View(compToEdit);
            }
               
        }

        [HttpPost]
        public IActionResult Edit(Competitor competitor)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            using (CompetitorEntriesDbContext db = new CompetitorEntriesDbContext())
            {
                var compToEdit = db.Competitors.FirstOrDefault(x => x.Id == competitor.Id);
                compToEdit.Name = competitor.Name;
                compToEdit.Team = competitor.Team;
                compToEdit.Age = competitor.Age;
                compToEdit.Category = competitor.Category;
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            using (CompetitorEntriesDbContext db = new CompetitorEntriesDbContext())
            {
                var compToDelete = db.Competitors.FirstOrDefault(x => x.Id == id);

                if (compToDelete == null)
                {
                    return RedirectToAction("Index");
                }

                return this.View(compToDelete);
            }
        }

        [HttpPost]
        public IActionResult Delete(Competitor competitor)
        {
            using (CompetitorEntriesDbContext db = new CompetitorEntriesDbContext())
            {
                var compToDelete = db.Competitors.FirstOrDefault(x => x.Id == competitor.Id);

                if (compToDelete == null)
                {
                    return RedirectToAction("Index");
                }

                db.Competitors.Remove(compToDelete);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}