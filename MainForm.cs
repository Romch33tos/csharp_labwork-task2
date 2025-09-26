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
    event EventHandler BrowseFileClicked;

    string FilePath { get; set; }
    int FilterYear { get; set; }

    void DisplayAllAthletes(List<Athlete> athletes);
    void DisplayFilteredAthletes(List<Athlete> athletes);
    void DisplayBestAthlete(Athlete athlete);
    void ShowMessage(string message);
    void DisableGenerateButton();
    void EnableFilterButtons(bool enable);
    string ShowSaveFileDialog();
    string ShowOpenFileDialog();
  }

  public partial class MainForm : Form, IMainView
  {
    public event EventHandler GenerateDataClicked;
    public event EventHandler LoadDataClicked;
    public event EventHandler FilterByYearClicked;
    public event EventHandler FindBestAthleteClicked;
    public event EventHandler BrowseFileClicked;

    private const int MIN_YEAR = 1970;
    private const int MAX_YEAR = 2006;

    public MainForm()
    {
      InitializeComponent();
      SetupDataGridView();
      SubscribeEvents();
      SetupYearNumericUpDown();
      EnableFilterButtons(false);
    }

    private void SetupDataGridView()
    {
      dataGridViewAthletes.Columns.Add("LastName", "Фамилия");
      dataGridViewAthletes.Columns.Add("BirthYear", "Год рождения");
      dataGridViewAthletes.Columns.Add("JumpResult", "Результат (м)");
      dataGridViewAthletes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
    }

    private void SetupYearNumericUpDown()
    {
      numericUpDownYear.Minimum = MIN_YEAR;
      numericUpDownYear.Maximum = MAX_YEAR;
      numericUpDownYear.Value = MIN_YEAR;

      numericUpDownYear.ReadOnly = true; 
    }

    private void SubscribeEvents()
    {
      buttonGenerate.Click += (s, e) => GenerateDataClicked?.Invoke(this, EventArgs.Empty);
      buttonLoad.Click += (s, e) => LoadDataClicked?.Invoke(this, EventArgs.Empty);
      buttonFilter.Click += (s, e) => FilterByYearClicked?.Invoke(this, EventArgs.Empty);
      buttonFindBest.Click += (s, e) => FindBestAthleteClicked?.Invoke(this, EventArgs.Empty);
      buttonBrowse.Click += (s, e) => BrowseFileClicked?.Invoke(this, EventArgs.Empty);
    }

    public string FilePath
    {
      get => textBoxFilePath.Text;
      set => textBoxFilePath.Text = value;
    }

    public int FilterYear
    {
      get
      {
        return (int)numericUpDownYear.Value;
      }
      set
      {
        if (value >= MIN_YEAR && value <= MAX_YEAR)
        {
          numericUpDownYear.Value = value;
        }
      }
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

    public void DisableGenerateButton()
    {
      buttonGenerate.Enabled = false;
    }

    public void EnableFilterButtons(bool enable)
    {
      buttonFilter.Enabled = enable;
      buttonFindBest.Enabled = enable;
      numericUpDownYear.Enabled = enable;

      if (!enable)
      {
        numericUpDownYear.Value = MIN_YEAR;
      }
    }

    public string ShowSaveFileDialog()
    {
      if (saveFileDialog.ShowDialog() == DialogResult.OK)
      {
        return saveFileDialog.FileName;
      }
      return null;
    }

    public string ShowOpenFileDialog()
    {
      if (openFileDialog.ShowDialog() == DialogResult.OK)
      {
        return openFileDialog.FileName;
      }
      return null;
    }

    private void buttonFilter_Click(object sender, EventArgs e)
    {

    }
  }
}
