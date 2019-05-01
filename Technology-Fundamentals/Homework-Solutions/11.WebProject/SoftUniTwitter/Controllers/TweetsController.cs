﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoftUniTwitter.Data;
using SoftUniTwitter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SoftUniTwitter.Controllers
{
    [Authorize]
    public class TweetsController : Controller
    {
        ApplicationDbContext db;

        public TweetsController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult SaveToDatabase(string text)
        {
            var tweet = new Tweet
            {
                Text = text,
                CreatedOn = DateTime.UtcNow,
                UserId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value
            };

            db.Tweets.Add(tweet);
            db.SaveChanges();

            return Redirect("/");
        }

        public IActionResult ByHashtag(string id)
        {
            var model = db.Tweets
                .Where(x => x.Text.Contains("#" + id))
                .OrderByDescending(x => x.CreatedOn)
                .Select(x =>
                    new TweetViewModel
                        {
                            CreatedOn = x.CreatedOn,
                            Text = x.Text,
                            Username = x.User.UserName
                        })
                .ToList();
            return View(model);
        }
    }
}
