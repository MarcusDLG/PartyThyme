using System;
using System.Linq;

namespace PartyThyme
{
  class Program
  {
    static void Main(string[] args)
    {
      var db = new PlantContext();
      Console.WriteLine("Welcome to Garden Tracker!");
      bool isRunning = true;
      while (isRunning)
      {
        Console.WriteLine("What would you like to do: (VIEW), (PLANT), (REMOVE), (WATER), (QUIT)? ");
        var userInput = Console.ReadLine().ToLower();
        if (userInput != "view" && userInput != "plant" && userInput != "remove" && userInput != "water" && userInput != "quit")
        {
          Console.WriteLine("That is not a valid input, please choose again from: (VIEW), (PLANT), (REMOVE), (WATER), (QUIT)");
          userInput = Console.ReadLine().ToLower();
        }
        if (userInput == "view")
        {
          Console.WriteLine("Would you like to view (ALL), by (LOCATION), or not (WATERED)?");
          userInput = Console.ReadLine().ToLower();
          if (userInput != "all" && userInput != "location" && userInput != "watered")
          {
            Console.WriteLine("That is not a valid input, please choose again from: (ALL), by (LOCATION), or not (WATERED)?");
            userInput = Console.ReadLine().ToLower();
          }
          if (userInput == "all")
          {
            Console.Clear();

            var displayAll = db.Plants.OrderBy(plant => plant.LocatedPlanted);
            foreach (var plant in displayAll)
            {
              Console.WriteLine($"{plant.Species} is located at {plant.LocatedPlanted}.");
            }
            //for each loop
          }
          if (userInput == "location")
          {
            Console.Clear();
            Console.WriteLine("You have plants in the following locations:");
            var displayLocation = db.Plants.OrderBy(plant => plant.LocatedPlanted).Distinct();
            foreach (var l in displayLocation)
            {
              Console.WriteLine($"{l.LocatedPlanted}");
            }
            // ask user which zone they would like to look at?
            Console.WriteLine("Which location would you like to view?");
            // var locationToLook = console readline
            var locationInput = Console.ReadLine().ToLower();
            // plant => plant.LocatedPlanted == locationInput
            var displayPlantsByLocation = db.Plants.Where(plant => plant.LocatedPlanted == locationInput);

            // foreach loop printing each plant in that location
            Console.Clear();
            foreach (var locatedPlant in displayPlantsByLocation)
            {
              Console.WriteLine($"{locatedPlant.Species}");
            }
          }
          if (userInput == "watered")
          {
            isRunning = false;
          }
        }
        if (userInput == "plant")
        {
          Console.Clear();
          var newPlant = new Plant();
          Console.WriteLine("What would you like to plant?");
          newPlant.Species = Console.ReadLine().ToLower();
          Console.WriteLine($"Where did you plant {newPlant.Species}?");
          newPlant.LocatedPlanted = Console.ReadLine().ToLower();
          Console.WriteLine($"How much light in hours does the {newPlant.Species} need?");
          newPlant.LightNeeded = double.Parse(Console.ReadLine());
          Console.WriteLine($"How much water in gallons does {newPlant.Species} need a week?");
          newPlant.WaterNeeded = double.Parse(Console.ReadLine().ToLower());
          newPlant.PlantedDate = DateTime.Now;
          newPlant.LastWateredDate = DateTime.Now;


          db.Add(newPlant);
          db.SaveChanges();
        }
        if (userInput == "remove")
        {
          var displayRemove = db.Plants.OrderBy(plant => plant.Id);
          foreach (var plant in displayRemove)
          {
            Console.Clear();
            Console.WriteLine("Which plant would you like to remove?");
            Console.WriteLine($"{plant.Id}: {plant.Species} located in the {plant.LocatedPlanted}");
          }

          Console.WriteLine("What plant would you like to remove? Please enter the plant id from the list above!");
          var userRemove = int.Parse(Console.ReadLine());
          var plantToRemove = db.Plants.FirstOrDefault(plant => plant.Id == userRemove);
          if (plantToRemove == null)
          {
            Console.WriteLine("That is not a valid option, please select a valid id number.");
            userRemove = int.Parse(Console.ReadLine());
          }
          if (plantToRemove != null)
          {
            db.Plants.Remove(plantToRemove);
            db.SaveChanges();
          }
        }
        if (userInput == "water")
        {
          //display plants by last watered first(id, name, location, and last watered)
          Console.WriteLine("What plant would you like to water? Please enter the plant id from the list above!");
          var userWater = int.Parse(Console.ReadLine());
          var plantToWater = db.Plants.FirstOrDefault(plant => plant.Id == userWater);
          if (plantToWater == null)
          {
            Console.WriteLine("That is not a valid option, please select a valid id number.");
            //display plants by last watered first(id, name, location, and last watered)
            userWater = int.Parse(Console.ReadLine());
          }
          if (plantToWater != null)
          {
            // modify by id, updating last watered to current datetime
            db.SaveChanges();
          }
        }
        else if (userInput == "quit")
        {
          isRunning = false;
        }
      }
    }
  }
}
