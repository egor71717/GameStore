using GameStore.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace GameStore.EntityFramework
{
    class DbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            #region games
            //add games here
            var games = new Dictionary<String, Game>();
            //games.Add("test game", new Game()
            //{

            //});
            #endregion

            #region comments
            //add comments
            var comments = new Dictionary<String, Comment>();
            //comments.Add("test comment", new Comment()
            //{

            //});
            #endregion

            context.Games.AddRange(games.Values);
            context.Comments.AddRange(comments.Values);
            context.SaveChanges();
        }
    }
}