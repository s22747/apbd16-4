using Tutorial6.Models;

namespace Tutorial6;

public static class Database
{
    public static List<Test> Tests = new List<Test>()
    {
        new Test() { Id = 1, Name = "Test1" },
        new Test() { Id = 2, Name = "Test2" },
        new Test() { Id = 3, Name = "Test3" }
    };
    
    public static List<Animal> Animals = new()
    {
        new Animal { Id = 1, Name = "Asia", Category = "Kot", Weight = 5, FurColor = "Szary" },
        new Animal { Id = 2, Name = "Diabel", Category = "Pies", Weight = 41, FurColor = "Pomaranczowy" },
        new Animal { Id = 3, Name = "Piotrek", Category = "Krokodyl", Weight = 210, FurColor = "Zielony" }
        
    };
    public static List<Visit> Visits = new()
    {
        new Visit { Id = 1, AnimalId = 1, VisitDate = new DateTime(2025, 05, 07), Description = "Kroplowka oraz pobyt w szpitalu", Price = 350 },
        new Visit { Id = 2, AnimalId = 2, VisitDate = new DateTime(2025, 04, 18), Description = "Kontrola po operacji", Price = 200 },
        new Visit { Id = 3, AnimalId = 1, VisitDate = new DateTime(2025, 03, 10), Description = "Badanie kontrolne", Price = 90 }
    };
    
}