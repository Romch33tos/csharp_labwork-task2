using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace SportsCompetitionApp
{
  public interface IMainView
  {
    event EventHandler GenerateDataClicked;
    event EventHandler LoadDataClicked;
    event EventHandler FilterByYearClicked;
    event EventHandler FindBestAthleteClicked;

    string FilePath { get; set; }
    int FilterYear { get; set; }

    void DisplayAllAthletes(List<Athlete> athletes);
    void DisplayFilteredAthletes(List<Athlete> athletes);
    void DisplayBestAthlete(Athlete athlete);
    void ShowMessage(string message);
  }

  public partial class MainForm : Form, IMainView
  {
    public event EventHandler GenerateDataClicked;
    public event EventHandler LoadDataClicked;
    public event EventHandler FilterByYearClicked;
    public event EventHandler FindBestAthleteClicked;

    public MainForm()
    {
      InitializeComponent();
      SetupDataGridView();
      SubscribeEvents();
    }

    private void SetupDataGridView()
    {
      dataGridViewAthletes.Columns.Add("LastName", "Фамилия");
      dataGridViewAthletes.Columns.Add("BirthYear", "Год рождения");
      dataGridViewAthletes.Columns.Add("JumpResult", "Результат (м)");
      dataGridViewAthletes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
    }

    private void SubscribeEvents()
    {
      buttonGenerate.Click += (s, e) => GenerateDataClicked?.Invoke(this, EventArgs.Empty);
      buttonLoad.Click += (s, e) => LoadDataClicked?.Invoke(this, EventArgs.Empty);
      buttonFilter.Click += (s, e) => FilterByYearClicked?.Invoke(this, EventArgs.Empty);
      buttonFindBest.Click += (s, e) => FindBestAthleteClicked?.Invoke(this, EventArgs.Empty);
    }

    public string FilePath
    {
      get => textBoxFilePath.Text;
      set => textBoxFilePath.Text = value;
    }

    public int FilterYear
    {
      get => int.TryParse(textBoxYear.Text, out int year) ? year : 0;
      set => textBoxYear.Text = value.ToString();
    }

    public void DisplayAllAthletes(List<Athlete> athletes)
    {
      dataGridViewAthletes.Rows.Clear();
      foreach (var athlete in athletes)
      {
        dataGridViewAthletes.Rows.Add(athlete.LastName, athlete.BirthYear, athlete.JumpResult);
      }
    }

    public void DisplayFilteredAthletes(List<Athlete> athletes)
    {
      DisplayAllAthletes(athletes);
    }

    public void DisplayBestAthlete(Athlete athlete)
    {
      labelBestAthlete.Text = athlete != null
        ? $"Лучший спортсмен: {athlete.LastName} ({athlete.BirthYear}) - {athlete.JumpResult}м"
        : "Лучший спортсмен не найден";
    }

    public void ShowMessage(string message)
    {
      MessageBox.Show(message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
  }
}