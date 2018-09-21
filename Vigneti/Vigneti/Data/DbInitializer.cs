using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vigneti.Models;

namespace Vigneti.Data
{

    // Rimpimento tabelle database con i dati forniti 
    public class DbInitializer
    {
        public static void Initialize(VineyardContext context)
        {
            context.Database.EnsureCreated();

            if (context.Vineyards.Any())
            {
                return;
            }


            // Tabella viticoltori 
            var vinegrowers = new VineGrower[]
            {
                new VineGrower{FullName = "Marco Zucchini"},
                new VineGrower{FullName = "Alex Costea"},
                new VineGrower{FullName = "Kristian Hristov"},
                new VineGrower{FullName = "Florin Mocanu"},
                new VineGrower{FullName = "Salin Kumar"},
                new VineGrower{FullName = "Danielle Cutilli"},
                new VineGrower{FullName = "Artenis Molla"},
                new VineGrower{FullName = "Riccardo Sibio"},
                new VineGrower{FullName = "Alex Toghe"},
                new VineGrower{FullName = "Max Pancini"},
                new VineGrower{FullName = "Morgan"}
            };

            // Aggiunta dei valori da "vinegrowers" nella rispettiva tabella
            foreach (var v in vinegrowers)
            {
                context.VineGrowers.Add(v);
            }
            context.SaveChanges();


            // Tabella vini
            var wines = new Wine[]
            {
                new Wine{Type = TypeW.Barricato},
                new Wine{Type = TypeW.Bianco},
                new Wine{Type = TypeW.Passito},
                new Wine{Type = TypeW.Rosato},
                new Wine{Type = TypeW.Arancione},
                new Wine{Type = TypeW.Novello},
                new Wine{Type = TypeW.Rosso},
                new Wine{Type = TypeW.Spumante}
            };

            foreach (var w in wines)
            {
                context.Wines.Add(w);
            }
            context.SaveChanges();


            // Tabella vigneti
            var vineyards = new Vineyard[]
            {
                new Vineyard{Dimension = 80, Humidity = 13 , VineGrowerID = 1, WineID = 1},
                new Vineyard{Dimension = 80, Humidity = 13 , VineGrowerID = 2, WineID = 2},
                new Vineyard{Dimension = 80, Humidity = 13 , VineGrowerID = 5, WineID = 3},
                new Vineyard{Dimension = 80, Humidity = 13 , VineGrowerID = 1, WineID = 4},
                new Vineyard{Dimension = 80, Humidity = 13 , VineGrowerID = 5, WineID = 5},
                new Vineyard{Dimension = 80, Humidity = 13 , VineGrowerID = 5, WineID = 6},
                new Vineyard{Dimension = 180, Humidity = 23 , VineGrowerID = 1, WineID = 7},
                new Vineyard{Dimension = 80, Humidity = 13 , VineGrowerID = 8, WineID = 8},
                new Vineyard{Dimension = 80, Humidity = 13 , VineGrowerID = 9, WineID = 1},
                new Vineyard{Dimension = 80, Humidity = 13 , VineGrowerID = 11, WineID = 2},
                new Vineyard{Dimension = 80, Humidity = 13 , VineGrowerID = 11, WineID = 3}

            };
            foreach (var y in vineyards)
            {
                context.Vineyards.Add(y);
            }
            context.SaveChanges();
        }
    }
}
