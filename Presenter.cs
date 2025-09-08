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
    private bool dataLoaded = false;

    private const int MIN_YEAR = 1970;
    private const int MAX_YEAR = 2006;

    public MainPresenter(IMainView mainView)
    {
      view = mainView;
      repository = new AthleteRepository();
      random = new Random();

      view.GenerateDataClicked += OnGenerateDataClicked;
      view.LoadDataClicked += OnLoadDataClicked;
      view.FilterByYearClicked += OnFilterByYearClicked;
      view.FindBestAthleteClicked += OnFindBestAthleteClicked;
      view.BrowseFileClicked += OnBrowseFileClicked;
    }

    private void OnBrowseFileClicked(object sender, EventArgs e)
    {
      try
      {
        string filePath = view.ShowOpenFileDialog();
        if (!string.IsNullOrEmpty(filePath))
        {
          view.FilePath = filePath;
        }
      }
      catch (Exception ex)
      {
        view.ShowMessage($"Ошибка при выборе файла: {ex.Message}");
      }
    }

    private void OnGenerateDataClicked(object sender, EventArgs e)
    {
      try
      {
        if (dataLoaded)
        {
          view.ShowMessage("Данные уже были сгенерированы или загружены");
          return;
        }

        string filePath = view.ShowSaveFileDialog();
        if (string.IsNullOrEmpty(filePath))
        {
          return;
        }

        GenerateSampleData();
        SaveDataToJson(filePath);
        view.FilePath = filePath;
        view.DisplayAllAthletes(repository.GetAllAthletes());
        view.DisableGenerateButton();
        view.EnableFilterButtons(true);
        dataLoaded = true;
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
        if (dataLoaded)
        {
          view.ShowMessage("Данные уже были загружены или сгенерированы");
          return;
        }

        if (string.IsNullOrEmpty(view.FilePath))
        {
          view.ShowMessage("Укажите путь к файлу");
          return;
        }

        LoadDataFromJson(view.FilePath);
        view.DisplayAllAthletes(repository.GetAllAthletes());
        view.EnableFilterButtons(true); 
        dataLoaded = true;
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
        if (!dataLoaded)
        {
          view.ShowMessage("Сначала загрузите или сгенерируйте данные");
          return;
        }

        int year = view.FilterYear;
        if (year < MIN_YEAR || year > MAX_YEAR)
        {
          view.ShowMessage($"Год должен быть в диапазоне {MIN_YEAR}-{MAX_YEAR}");
          return;
        }

        var filteredAthletes = repository.GetAthletesByBirthYear(year);

        if (filteredAthletes.Count == 0)
        {   
          view.ShowMessage($"Спортсмены, родившиеся в {year} году, не найдены");
          view.DisplayAllAthletes(repository.GetAllAthletes());
        }
        else
        {
          view.DisplayFilteredAthletes(filteredAthletes);
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
        if (!dataLoaded)
        {
          view.ShowMessage("Сначала загрузите или сгенерируйте данные");
          return;
        }

        int year = view.FilterYear;
        if (year < MIN_YEAR || year > MAX_YEAR)
        {
          view.ShowMessage($"Год должен быть в диапазоне {MIN_YEAR}-{MAX_YEAR}");
          return;
        }

        var bestAthlete = repository.GetBestAthleteByBirthYear(year);
        view.DisplayBestAthlete(bestAthlete);

        if (bestAthlete == null)
        {
          view.ShowMessage($"Спортсмены, родившиеся в {year} году, не найдены");
          view.DisplayAllAthletes(repository.GetAllAthletes());
        }
        else
        {
          var athletesByYear = repository.GetAthletesByBirthYear(year);
          view.DisplayFilteredAthletes(athletesByYear);
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

      foreach (var lastName in lastNames)
      {
        int birthYear = random.Next(MIN_YEAR, MAX_YEAR + 1);
        double jumpResult = Math.Round(5.0 + random.NextDouble() * 3.0, 2);
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
