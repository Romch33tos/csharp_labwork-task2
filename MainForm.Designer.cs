namespace SportsCompetitionApp
{
  partial class MainForm
  {
    private System.ComponentModel.IContainer components = null;

    protected System.Windows.Forms.DataGridView dataGridViewAthletes;
    protected System.Windows.Forms.Button buttonGenerate;
    protected System.Windows.Forms.Button buttonLoad;
    protected System.Windows.Forms.Button buttonFilter;
    protected System.Windows.Forms.Button buttonFindBest;
    protected System.Windows.Forms.TextBox textBoxFilePath;
    protected System.Windows.Forms.TextBox textBoxYear;
    protected System.Windows.Forms.Label labelBestAthlete;
    private System.Windows.Forms.Label labelFile;
    private System.Windows.Forms.Label labelYear;

    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      labelFile = new Label();
      textBoxFilePath = new TextBox();
      labelYear = new Label();
      textBoxYear = new TextBox();
      buttonGenerate = new Button();
      buttonLoad = new Button();
      buttonFilter = new Button();
      buttonFindBest = new Button();
      labelBestAthlete = new Label();
      dataGridViewAthletes = new DataGridView();
      ((System.ComponentModel.ISupportInitialize)dataGridViewAthletes).BeginInit();
      SuspendLayout();
      // 
      // labelFile
      // 
      labelFile.AutoSize = true;
      labelFile.Location = new Point(20, 20);
      labelFile.Name = "labelFile";
      labelFile.Size = new Size(39, 15);
      labelFile.TabIndex = 0;
      labelFile.Text = "Файл:";
      // 
      // textBoxFilePath
      // 
      textBoxFilePath.Location = new Point(65, 17);
      textBoxFilePath.Name = "textBoxFilePath";
      textBoxFilePath.Size = new Size(355, 23);
      textBoxFilePath.TabIndex = 1;
      // 
      // labelYear
      // 
      labelYear.AutoSize = true;
      labelYear.Location = new Point(20, 50);
      labelYear.Name = "labelYear";
      labelYear.Size = new Size(87, 15);
      labelYear.TabIndex = 2;
      labelYear.Text = "Год рождения:";
      // 
      // textBoxYear
      // 
      textBoxYear.Location = new Point(113, 48);
      textBoxYear.Name = "textBoxYear";
      textBoxYear.Size = new Size(42, 23);
      textBoxYear.TabIndex = 3;
      // 
      // buttonGenerate
      // 
      buttonGenerate.Location = new Point(448, 16);
      buttonGenerate.Name = "buttonGenerate";
      buttonGenerate.Size = new Size(150, 23);
      buttonGenerate.TabIndex = 4;
      buttonGenerate.Text = "Сгенерировать данные";
      buttonGenerate.UseVisualStyleBackColor = true;
      // 
      // buttonLoad
      // 
      buttonLoad.Location = new Point(448, 50);
      buttonLoad.Name = "buttonLoad";
      buttonLoad.Size = new Size(150, 23);
      buttonLoad.TabIndex = 5;
      buttonLoad.Text = "Загрузить данные";
      buttonLoad.UseVisualStyleBackColor = true;
      // 
      // buttonFilter
      // 
      buttonFilter.Location = new Point(161, 47);
      buttonFilter.Name = "buttonFilter";
      buttonFilter.Size = new Size(133, 23);
      buttonFilter.TabIndex = 6;
      buttonFilter.Text = "Фильтровать по году";
      buttonFilter.UseVisualStyleBackColor = true;
      // 
      // buttonFindBest
      // 
      buttonFindBest.Location = new Point(300, 46);
      buttonFindBest.Name = "buttonFindBest";
      buttonFindBest.Size = new Size(120, 23);
      buttonFindBest.TabIndex = 7;
      buttonFindBest.Text = "Найти лучшего";
      buttonFindBest.UseVisualStyleBackColor = true;
      // 
      // labelBestAthlete
      // 
      labelBestAthlete.AutoSize = true;
      labelBestAthlete.Location = new Point(20, 80);
      labelBestAthlete.Name = "labelBestAthlete";
      labelBestAthlete.Size = new Size(122, 15);
      labelBestAthlete.TabIndex = 8;
      labelBestAthlete.Text = "Лучший спортсмен: ";
      // 
      // dataGridViewAthletes
      // 
      dataGridViewAthletes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      dataGridViewAthletes.Location = new Point(20, 110);
      dataGridViewAthletes.Name = "dataGridViewAthletes";
      dataGridViewAthletes.ReadOnly = true;
      dataGridViewAthletes.Size = new Size(583, 199);
      dataGridViewAthletes.TabIndex = 9;
      // 
      // MainForm
      // 
      ClientSize = new Size(610, 321);
      Controls.Add(dataGridViewAthletes);
      Controls.Add(labelBestAthlete);
      Controls.Add(buttonFindBest);
      Controls.Add(buttonFilter);
      Controls.Add(buttonLoad);
      Controls.Add(buttonGenerate);
      Controls.Add(textBoxYear);
      Controls.Add(labelYear);
      Controls.Add(textBoxFilePath);
      Controls.Add(labelFile);
      Name = "MainForm";
      Text = "Соревнования по прыжкам";
      ((System.ComponentModel.ISupportInitialize)dataGridViewAthletes).EndInit();
      ResumeLayout(false);
      PerformLayout();
    }
  }
}