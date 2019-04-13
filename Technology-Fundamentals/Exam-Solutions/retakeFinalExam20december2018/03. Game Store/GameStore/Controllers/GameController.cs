using System;
using System.Collections.Generic;
using System.Linq;
using GameStore.Data;
using GameStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Controllers
{
    public class GameController : Controller
    {
        public IActionResult Index()
        {
            using (GameStoreDbContext db = new GameStoreDbContext())
            {
                List<Game> allGames = db.Games.ToList();
                return this.View(allGames);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(Game game)
        {
            Game newGame = new Game
            {
                Dlc = game.Dlc,
                Name = game.Name,
                Platform = game.Platform,
                Price = game.Price
            };

            using (GameStoreDbContext db = new GameStoreDbContext())
            {
                db.Games.Add(newGame);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            using (GameStoreDbContext db = new GameStoreDbContext())
            {
                Game gameToEdit = db.Games.FirstOrDefault(x => x.Id == id);

                if (gameToEdit == null)
                {
                    return RedirectToAction("Index");
                }

                return this.View(gameToEdit);
            }
        }

        [HttpPost]
        public IActionResult Edit(Game game)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            using (GameStoreDbContext db = new GameStoreDbContext())
            {
                Game gameToEdit = db.Games.FirstOrDefault(x => x.Id == game.Id);

                if (gameToEdit == null)
                {
                    return RedirectToAction("Index");
                }

                gameToEdit.Name = game.Name;
                gameToEdit.Platform = game.Platform;
                gameToEdit.Dlc = game.Dlc;
                gameToEdit.Price = game.Price;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            using (GameStoreDbContext db = new GameStoreDbContext())
            {
                Game gameToDelete = db.Games.FirstOrDefault(x => x.Id == id);

                if (gameToDelete == null)
                {
                    return RedirectToAction("Index");
                }

                return this.View(gameToDelete);
            }
        }

        [HttpPost]
        public IActionResult Delete(Game game)
        {
            using (GameStoreDbContext db = new GameStoreDbContext())
            {
                Game gameToDelete = db.Games.FirstOrDefault(x => x.Id == game.Id);

                if (gameToDelete == null)
                {
                    return RedirectToAction("Index");
                }

                db.Games.Remove(gameToDelete);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}