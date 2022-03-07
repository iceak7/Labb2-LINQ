using Labb2_LINQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Labb2_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {

            ////Inte klar ännu
            
            using LabbDBContext context = new LabbDBContext();

            //Lärare som undervisar i matte
            var lärareMatte = (from lärare in context.Lärare
                               join lärareKurs in context.LärareKurs on lärare.LärareId equals lärareKurs.Lärare.LärareId
                               join ÄmneKurs in context.ÄmneKurs on lärareKurs.Kurs.KursId equals ÄmneKurs.Kurs.KursId
                               join Ämne in context.Ämnen on ÄmneKurs.Ämne.ÄmneId equals Ämne.ÄmneId
                               where Ämne.Namn == "Matte"
                               select new { Ämne = Ämne.Namn, lärare.Förnamn, lärare.Efternamn }
                               );
            Console.WriteLine("Lärare som undervisar i matte:");
            foreach (var item in lärareMatte)
            {
                Console.WriteLine(item.Förnamn + " " + item.Efternamn );
            }


            //var lärarePerElev = (from elev in context.Elever
            //                     join elevKurs in context.ElevKurs on elev.ElevId equals elevKurs.Elev.ElevId
            //                     join lärareKurs in context.LärareKurs on elevKurs.Kurs.KursId equals lärareKurs.Kurs.KursId
            //                     join lärare in context.Lärare on lärareKurs.Lärare.LärareId equals lärare.LärareId
            //                     into LärareGroup
            //                     select new { elev, LärareGroup });

            //foreach (var item in lärarePerElev)
            //{
            //    Console.WriteLine(item.elev.Förnamn + " " + item.elev.Efternamn);
            //    foreach (var lärare in item.LärareGroup)
            //    {
            //        Console.WriteLine(lärare.Förnamn + " " + lärare.Efternamn);
            //    }
            //}


            //Elever med sina lärare
            var lärarePerElev = (from elev in context.Elever
                                 join elevKurs in context.ElevKurs on elev.ElevId equals elevKurs.Elev.ElevId
                                 join lärareKurs in context.LärareKurs on elevKurs.Kurs.KursId equals lärareKurs.Kurs.KursId
                                 join lärare in context.Lärare on lärareKurs.Lärare.LärareId equals lärare.LärareId
                                 select new { elev, lärare });

            Dictionary<string, List<string>> elevLärare = new Dictionary<string,List<string>>();
            foreach (var item in lärarePerElev)
            {
               if(elevLärare.ContainsKey(item.elev.Förnamn + " " + item.elev.Efternamn))
                {
                    elevLärare[item.elev.Förnamn + " " + item.elev.Efternamn].Add(item.lärare.Förnamn + " " + item.lärare.Efternamn);
                }
                else
                {
                    elevLärare.Add(item.elev.Förnamn + " " + item.elev.Efternamn, new List<string> { item.lärare.Förnamn + " " + item.lärare.Efternamn });
                }
            }

            Console.WriteLine("\nLärare för varje elev");
            foreach (var item in elevLärare)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("\nElev: " + item.Key);
                Console.ForegroundColor = ConsoleColor.White;
                foreach (var lärare in item.Value)
                {
                    Console.WriteLine(lärare);
                }
            }


            //Contains Programmering 1?
            Console.WriteLine("\nFinns progammering 1 som ämne?");
            var containsProgrammering1 = context.Ämnen.Select(x => x.Namn).Contains("Programmering 1");
            if (containsProgrammering1)
            {
                Console.WriteLine("Ja");
            }
            else
            {
                Console.WriteLine("Nej");
            }


            //Ändra programmering 2 till OOP
            Console.WriteLine("\n");
            var ä1 = context.Ämnen.FirstOrDefault(x=>x.Namn== "Programmering 2");
            if (ä1 != null)
            {
                ä1.Namn = "OOP";
                context.Update(ä1);
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Ä1 var null");
            }
            Console.WriteLine("\nAlla ämnen:");
            foreach (var item in context.Ämnen)
            {
                Console.WriteLine(item.Namn);
            }


            //Ändra alla med Anas som lärare till Reidar som lärare
            var lärareAnas = context.Lärare.First(l => l.Förnamn == "Anas");
            var lärareReidar = context.Lärare.First(l => l.Förnamn == "Reidar");

            var kurserMedAnas = context.LärareKurs.Where(x => x.Lärare == lärareAnas);

            foreach (var item in kurserMedAnas)
            {
                item.Lärare = lärareReidar;
                context.Update(item);
            }
            context.SaveChanges();

            Console.WriteLine("\nLärare som har kurser");
            foreach (var item in context.LärareKurs)
            {
                Console.WriteLine(item.Lärare.Förnamn);
            }



            //Elev e1 = new Elev()
            //{
            //    Förnamn = "Lars",
            //    Efternamn = "Larsson",
            //    Ålder = 19,
            //    Klass = "TE16B"
            //};
            //Elev e2 = new Elev()
            //{
            //    Förnamn = "Maja",
            //    Efternamn = "Hansson",
            //    Ålder = 19,
            //    Klass = "TE16B"
            //};
            //Elev e3 = new Elev()
            //{
            //    Förnamn = "Karl",
            //    Efternamn = "Johansson",
            //    Ålder = 20,
            //    Klass = "NA17B"
            //};
            //Elev e4 = new Elev()
            //{
            //    Förnamn = "Kajsa",
            //    Efternamn = "Persson",
            //    Ålder = 20,
            //    Klass = "NA17B"
            //};
            //context.AddRange(new Elev[4] { e1, e2, e3, e4 });

            //Lärare l1 = new Lärare()
            //{
            //    Förnamn = "Anas",
            //    Efternamn = "Qlok",
            //};
            //Lärare l2 = new Lärare()
            //{
            //    Förnamn = "Robert",
            //    Efternamn = "Olsson",
            //};
            //Lärare l3 = new Lärare()
            //{
            //    Förnamn = "Anna",
            //    Efternamn = "Larsson",
            //};
            //Lärare l4 = new Lärare()
            //{
            //    Förnamn = "Reidar",
            //    Efternamn = "Qlok",
            //};
            //context.AddRange(new Lärare[4] { l1, l2, l3, l4 });


            //Ämne ä1 = new Ämne()
            //{
            //    Namn = "Programmering 1"
            //};
            //Ämne ä2 = new Ämne()
            //{
            //    Namn = "Programmering 2"
            //};
            //Ämne ä3 = new Ämne()
            //{
            //    Namn = "Matte"
            //};
            //Ämne ä4 = new Ämne()
            //{
            //    Namn = "Svenska"
            //};
            //Ämne ä5 = new Ämne()
            //{
            //    Namn = "Samhällskunskap"
            //};
            //context.AddRange(new Ämne[5] { ä1, ä2, ä3, ä4, ä5 });

            //Kurs k1 = new Kurs()
            //{
            //    KursNamn = "Årskurs 2",
            //    StartDatum=new DateTime(2020, 9, 10),
            //    SlutDatum=new DateTime(2021,6, 10 )              
            //};
            //Kurs k2 = new Kurs()
            //{
            //    KursNamn = "Årskurs 3",
            //    StartDatum = new DateTime(2020, 9, 10),
            //    SlutDatum = new DateTime(2021, 6, 10)
            //};
            //Kurs k3 = new Kurs()
            //{
            //    KursNamn = "SUT 21",
            //    StartDatum = new DateTime(2021, 9, 10),
            //    SlutDatum = new DateTime(2022, 6, 10)
            //};
            //context.AddRange(new Kurs[3] { k1, k2, k3 });

            //ElevKurs ek1 = new ElevKurs()
            //{
            //    Elev = e1,
            //    Kurs = k1
            //};
            //ElevKurs ek2 = new ElevKurs()
            //{
            //    Elev = e2,
            //    Kurs = k1
            //};
            //ElevKurs ek3 = new ElevKurs()
            //{
            //    Elev = e1,
            //    Kurs = k3
            //};
            //ElevKurs ek4 = new ElevKurs()
            //{
            //    Elev = e3,
            //    Kurs = k2
            //};
            //ElevKurs ek5 = new ElevKurs()
            //{
            //    Elev = e4,
            //    Kurs = k2
            //};
            //context.AddRange(new ElevKurs[5] { ek1, ek2, ek3, ek4, ek5 });

            //ÄmneKurs äk1 = new ÄmneKurs()
            //{
            //    Kurs=k1,
            //    Ämne=ä3
            //};
            //ÄmneKurs äk2 = new ÄmneKurs()
            //{
            //    Kurs = k1,
            //    Ämne = ä4
            //};
            //ÄmneKurs äk3 = new ÄmneKurs()
            //{
            //    Kurs = k2,
            //    Ämne = ä1
            //};
            //ÄmneKurs äk4 = new ÄmneKurs()
            //{
            //    Kurs = k2,
            //    Ämne = ä5
            //};
            //ÄmneKurs äk5 = new ÄmneKurs()
            //{
            //    Kurs = k2,
            //    Ämne = ä2
            //};
            //context.AddRange(new ÄmneKurs[5] { äk1, äk2, äk3, äk4, äk5});

            //LärareKurs lk = new LärareKurs()
            //{
            //    Kurs = k3,
            //    Lärare = l1
            //};
            //LärareKurs lk2 = new LärareKurs()
            //{
            //    Kurs = k2,
            //    Lärare = l2
            //};
            //LärareKurs lk3 = new LärareKurs()
            //{
            //    Kurs = k1,
            //    Lärare = l3
            //};
            //context.AddRange(new LärareKurs[3] { lk, lk2, lk3 });
            //context.SaveChanges();
        }
    }
}
