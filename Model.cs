using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace SportsCompetitionApp
{
  public class Athlete
  {
    [JsonPropertyName("lastName")]
    public string LastName { get; set; }

    [JsonPropertyName("birthYear")]
    public int BirthYear { get; set; }

    [JsonPropertyName("jumpResult")]
    public double JumpResult { get; set; }

    public Athlete() { }

    public Athlete(string lastName, int birthYear, double jumpResult)
    {
      LastName = lastName;
      BirthYear = birthYear;
      JumpResult = jumpResult;
    }

    public override string ToString()
    {
      return $"{LastName} ({BirthYear}): {JumpResult}m";
    }
  }

  public class AthleteRepository
  {
    private List<Athlete> athletes;

    public AthleteRepository()
    {
      athletes = new List<Athlete>();
    }

    public void AddAthlete(Athlete athlete)
    {
      athletes.Add(athlete);
    }

    public List<Athlete> GetAllAthletes()
    {
      return athletes;
    }

    public List<Athlete> GetAthletesByBirthYear(int birthYear)
    {
      return athletes.Where(a => a.BirthYear == birthYear).ToList();
    }

    public Athlete GetBestAthleteByBirthYear(int birthYear)
    {
      var athletesByYear = GetAthletesByBirthYear(birthYear);
      return athletesByYear.OrderByDescending(a => a.JumpResult).FirstOrDefault();
    }

    public void Clear()
    {
      athletes.Clear();
    }
  }
}