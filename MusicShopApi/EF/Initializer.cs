using System;
using System.Collections.Generic;

namespace MusicShopApi
{
    public static class Initializer
    {
        public static void Seed(MusicalShopModel context)
        {
            if(context.Database.EnsureCreated())
            {
                var discount1 = context.Discounts.Add(new Discount { Name = "Discount1", DateFrom = DateTime.Now.AddDays(-14), DateTo =  DateTime.Now.AddDays(14), DiscountValue = 10 }).Entity;
                var discount2 = context.Discounts.Add(new Discount { Name = "Discount2", DateFrom = DateTime.Now.AddDays(-14), DateTo =  DateTime.Now.AddDays(14), DiscountValue = 10 }).Entity;
                var discount3 = context.Discounts.Add(new Discount { Name = "Discount3", DateFrom = DateTime.Now.AddDays(-14), DateTo =  DateTime.Now.AddDays(14), DiscountValue = 10 }).Entity;

                var pub1 = context.Publishers.Add(new Publisher { Name = "Publisher 1" }).Entity;
                var pub2 = context.Publishers.Add(new Publisher { Name = "Publisher 2" }).Entity;
                var pub3 = context.Publishers.Add(new Publisher { Name = "Publisher 3" }).Entity;
                var pub4 = context.Publishers.Add(new Publisher { Name = "Publisher 4" }).Entity;
                var pub5 = context.Publishers.Add(new Publisher { Name = "Publisher 5" }).Entity;

                var g1 = context.Genres.Add(new Genre { Name = "Genre 1" }).Entity;
                var g2 = context.Genres.Add(new Genre { Name = "Genre 2" }).Entity;
                var g3 = context.Genres.Add(new Genre { Name = "Genre 3" }).Entity;
                var g4 = context.Genres.Add(new Genre { Name = "Genre 4" }).Entity;
                var g5 = context.Genres.Add(new Genre { Name = "Genre 5" }).Entity;


                var gr1 = context.Groups.Add(new Group { Name = "Group 1" }).Entity;
                var gr2 = context.Groups.Add(new Group { Name = "Group 2" }).Entity;
                var gr3 = context.Groups.Add(new Group { Name = "Group 3" }).Entity;
                var gr4 = context.Groups.Add(new Group { Name = "Group 4" }).Entity;
                var gr5 = context.Groups.Add(new Group { Name = "Group 5" }).Entity;

                var c1 = context.Users.Add(new User { Name = "User 1", Login = "Userlogin1", Password = "Userpassword!1" }).Entity;
                var c2 = context.Users.Add(new User { Name = "User 2", Login = "Userlogin2", Password = "Userpassword!2" }).Entity;
                var c3 = context.Users.Add(new User { Name = "User 3", Login = "Userlogin3", Password = "Userpassword!3" }).Entity;

                var d1 = context.Discs.Add(new Disc { Discounts = new List<Discount> { discount1 }, Name = "Disc 1", Genre = g1, Publisher = pub2, Group = gr3, Price = 100, PublishDate = DateTime.Now.AddYears(-7), Count = 5 }).Entity;
                var d2 = context.Discs.Add(new Disc { Discounts = new List<Discount> { discount2 }, Name = "Disc 2", Genre = g2, Publisher = pub3, Group = gr4, Price = 130, PublishDate = DateTime.Now.AddYears(-6), Count = 5 }).Entity;
                var d3 = context.Discs.Add(new Disc { Discounts = new List<Discount> { discount3 }, Name = "Disc 3", Genre = g3, Publisher = pub4, Group = gr5, Price = 120, PublishDate = DateTime.Now.AddYears(-5), Count = 5 }).Entity;
                var d4 = context.Discs.Add(new Disc { Discounts = new List<Discount> { discount2, discount1 }, Name = "Disc 4", Genre = g4, Publisher = pub5, Group = gr1, Price = 110, PublishDate = DateTime.Now.AddYears(-4), Count = 5 }).Entity;
                var d5 = context.Discs.Add(new Disc { Discounts = new List<Discount> { discount3, discount1 }, Name = "Disc 5", Genre = g5, Publisher = pub1, Group = gr2, Price = 90, PublishDate = DateTime.Now.AddYears(-3), Count = 5 }).Entity;

                var s1 = context.Sales.Add(new Sale { User = c1, Price = 100, Discs = new List<Disc> { d1, d4, d2 } }).Entity;
                var s2 = context.Sales.Add(new Sale { User = c2, Price = 130, Discs = new List<Disc> { d2, d4 } }).Entity;
                var s3 = context.Sales.Add(new Sale { User = c3, Price = 120, Discs = new List<Disc> { d3, d4 } }).Entity;

                var t1 = context.Tracks.Add(new Track { Name = "Track 1", Disc = d1, Duration = TimeSpan.Parse("00:02:30") });
                var t2 = context.Tracks.Add(new Track { Name = "Track 2", Disc = d1, Duration = TimeSpan.Parse("00:02:20") });
                var t3 = context.Tracks.Add(new Track { Name = "Track 3", Disc = d1, Duration = TimeSpan.Parse("00:02:40") });
                var t4 = context.Tracks.Add(new Track { Name = "Track 4", Disc = d1, Duration = TimeSpan.Parse("00:02:50") });
                var t5 = context.Tracks.Add(new Track { Name = "Track 5", Disc = d1, Duration = TimeSpan.Parse("00:03:30") });

                var t6 = context.Tracks.Add(new Track { Name = "Track 6", Disc = d2, Duration = TimeSpan.Parse("00:03:30") });
                var t7 = context.Tracks.Add(new Track { Name = "Track 7", Disc = d2, Duration = TimeSpan.Parse("00:02:10") });
                var t8 = context.Tracks.Add(new Track { Name = "Track 8", Disc = d2, Duration = TimeSpan.Parse("00:02:20") });
                var t9 = context.Tracks.Add(new Track { Name = "Track 9", Disc = d2, Duration = TimeSpan.Parse("00:02:30") });
                var t10 = context.Tracks.Add(new Track { Name = "Track 10", Disc = d2, Duration = TimeSpan.Parse("00:04:30") });

                var t11 = context.Tracks.Add(new Track { Name = "Track 11", Disc = d3, Duration = TimeSpan.Parse("00:02:30") });
                var t12 = context.Tracks.Add(new Track { Name = "Track 12", Disc = d3, Duration = TimeSpan.Parse("00:02:50") });
                var t13 = context.Tracks.Add(new Track { Name = "Track 13", Disc = d3, Duration = TimeSpan.Parse("00:02:40") });
                var t14 = context.Tracks.Add(new Track { Name = "Track 14", Disc = d3, Duration = TimeSpan.Parse("00:03:30") });
                var t15 = context.Tracks.Add(new Track { Name = "Track 15", Disc = d3, Duration = TimeSpan.Parse("00:04:30") });

                var t16 = context.Tracks.Add(new Track { Name = "Track 16", Disc = d4, Duration = TimeSpan.Parse("00:04:30") });
                var t17 = context.Tracks.Add(new Track { Name = "Track 17", Disc = d4, Duration = TimeSpan.Parse("00:05:30") });
                var t18 = context.Tracks.Add(new Track { Name = "Track 18", Disc = d4, Duration = TimeSpan.Parse("00:03:30") });
                var t19 = context.Tracks.Add(new Track { Name = "Track 19", Disc = d4, Duration = TimeSpan.Parse("00:02:30") });
                var t20 = context.Tracks.Add(new Track { Name = "Track 20", Disc = d4, Duration = TimeSpan.Parse("00:02:10") });

                var t21 = context.Tracks.Add(new Track { Name = "Track 21", Disc = d5, Duration = TimeSpan.Parse("00:02:10") });
                var t22 = context.Tracks.Add(new Track { Name = "Track 22", Disc = d5, Duration = TimeSpan.Parse("00:02:20") });
                var t23 = context.Tracks.Add(new Track { Name = "Track 23", Disc = d5, Duration = TimeSpan.Parse("00:02:30") });
                var t24 = context.Tracks.Add(new Track { Name = "Track 24", Disc = d5, Duration = TimeSpan.Parse("00:02:40") });
                var t25 = context.Tracks.Add(new Track { Name = "Track 25", Disc = d5, Duration = TimeSpan.Parse("00:02:50") });
                
                context.SaveChanges();
            }
        }
    }

}