using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace SportsCompetitionApp
{
  public class MainPresenter
  {
    private readonly IMainView view;
    private readonly AthleteRepository repository;
    private readonly Random random;

    public MainPresenter(IMainView mainView)
    {
      view = mainView;
      repository = new AthleteRepository();
      random = new Random();

      // Подписка на события представления
      view.GenerateDataClicked += OnGenerateDataClicked;
      view.LoadDataClicked += OnLoadDataClicked;
      view.FilterByYearClicked += OnFilterByYearClicked;
      view.FindBestAthleteClicked += OnFindBestAthleteClicked;
    }

    private void OnGenerateDataClicked(object sender, EventArgs e)
    {
      try
      {
        GenerateSampleData();
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "athletes.json");
        SaveDataToJson(filePath);
        view.FilePath = filePath;
        view.DisplayAllAthletes(repository.GetAllAthletes());
        view.ShowMessage($"Данные сгенерированы и сохранены в файл: {filePath}");
      }
      catch (Exception ex)
      {
        view.ShowMessage($"Ошибка при генерации данных: {ex.Message}");
      }
    }

    private void OnLoadDataClicked(object sender, EventArgs e)
    {
      try
      {
        if (string.IsNullOrEmpty(view.FilePath))
        {
          view.ShowMessage("Укажите путь к файлу");
          return;
        }

        LoadDataFromJson(view.FilePath);
        view.DisplayAllAthletes(repository.GetAllAthletes());
        view.ShowMessage($"Данные загружены из файла: {view.FilePath}");
      }
      catch (Exception ex)
      {
        view.ShowMessage($"Ошибка при загрузке данных: {ex.Message}");
      }
    }

    private void OnFilterByYearClicked(object sender, EventArgs e)
    {
      try
      {
        int year = view.FilterYear;
        if (year == 0)
        {
          view.ShowMessage("Введите корректный год рождения");
          return;
        }

        var filteredAthletes = repository.GetAthletesByBirthYear(year);
        view.DisplayFilteredAthletes(filteredAthletes);

        if (filteredAthletes.Count == 0)
        {
          view.ShowMessage($"Спортсмены, родившиеся в {year} году, не найдены");
        }
      }
      catch (Exception ex)
      {
        view.ShowMessage($"Ошибка при фильтрации: {ex.Message}");
      }
    }

    private void OnFindBestAthleteClicked(object sender, EventArgs e)
    {
      try
      {
        int year = view.FilterYear;
        if (year == 0)
        {
          view.ShowMessage("Введите корректный год рождения");
          return;
        }

        var bestAthlete = repository.GetBestAthleteByBirthYear(year);
        view.DisplayBestAthlete(bestAthlete);

        if (bestAthlete == null)
        {
          view.ShowMessage($"Спортсмены, родившиеся в {year} году, не найдены");
        }
      }
      catch (Exception ex)
      {
        view.ShowMessage($"Ошибка при поиске лучшего спортсмена: {ex.Message}");
      }
    }

    private void GenerateSampleData()
    {
      repository.Clear();

      string[] lastNames = { "Иванов", "Петров", "Сидоров", "Кузнецов", "Смирнов", "Попов", "Васильев", "Павлов" };
      int[] birthYears = { 1990, 1991, 1992, 1993, 1994, 1995 };

      foreach (var lastName in lastNames)
      {
        int birthYear = birthYears[random.Next(birthYears.Length)];
        double jumpResult = Math.Round(5.0 + random.NextDouble() * 3.0, 2); // Результат от 5.0 до 8.0 метров
        repository.AddAthlete(new Athlete(lastName, birthYear, jumpResult));
      }
    }

    private void SaveDataToJson(string filePath)
    {
      var options = new JsonSerializerOptions { WriteIndented = true };
      string json = JsonSerializer.Serialize(repository.GetAllAthletes(), options);
      File.WriteAllText(filePath, json);
    }

    private void LoadDataFromJson(string filePath)
    {
      if (!File.Exists(filePath))
      {
        throw new FileNotFoundException("Файл не найден");
      }

      string json = File.ReadAllText(filePath);
      var athletes = JsonSerializer.Deserialize<List<Athlete>>(json);

      repository.Clear();
      foreach (var athlete in athletes)
      {
        repository.AddAthlete(athlete);
      }
    }
  }
}