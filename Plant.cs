using System;

namespace PartyThyme
{
  public class Plant
  {
    public int Id { get; set; }
    public string Species { get; set; }
    public string LocatedPlanted { get; set; }
    public DateTime PlantedDate { get; set; }
    public DateTime LastWateredDate { get; set; }
    public double LightNeeded { get; set; }
    public double WaterNeeded { get; set; }

  }
}

//  Id - primary key
//  Species - The type of plant
//  LocatedPlanted - where is the plant plated
//  PlantedDate - When was the plant planted
//  LastWateredDate - When was the last time a plant was water
//  LightNeeded - How much sunlight is needed
//  WaterNeeded - how much water is needed