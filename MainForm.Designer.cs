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
    protected System.Windows.Forms.Label labelBestAthlete;
    private System.Windows.Forms.Label labelFile;
    private System.Windows.Forms.Label labelYear;
    private System.Windows.Forms.Button buttonBrowse;
    private System.Windows.Forms.OpenFileDialog openFileDialog;
    private System.Windows.Forms.SaveFileDialog saveFileDialog;
    private System.Windows.Forms.ErrorProvider errorProvider;
    protected System.Windows.Forms.NumericUpDown numericUpDownYear;

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
      components = new System.ComponentModel.Container();
      labelFile = new Label();
      textBoxFilePath = new TextBox();
      labelYear = new Label();
      buttonGenerate = new Button();
      buttonLoad = new Button();
      buttonFilter = new Button();
      buttonFindBest = new Button();
      labelBestAthlete = new Label();
      dataGridViewAthletes = new DataGridView();
      buttonBrowse = new Button();
      openFileDialog = new OpenFileDialog();
      saveFileDialog = new SaveFileDialog();
      numericUpDownYear = new NumericUpDown();
      errorProvider = new ErrorProvider(components);
      ((System.ComponentModel.ISupportInitialize)dataGridViewAthletes).BeginInit();
      ((System.ComponentModel.ISupportInitialize)numericUpDownYear).BeginInit();
      ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
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
      textBoxFilePath.ReadOnly = true;
      textBoxFilePath.Size = new Size(350, 23);
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
      // buttonGenerate
      // 
      buttonGenerate.Location = new Point(496, 21);
      buttonGenerate.Name = "buttonGenerate";
      buttonGenerate.Size = new Size(150, 23);
      buttonGenerate.TabIndex = 4;
      buttonGenerate.Text = "Сгенерировать данные";
      buttonGenerate.UseVisualStyleBackColor = true;
      // 
      // buttonLoad
      // 
      buttonLoad.Location = new Point(496, 50);
      buttonLoad.Name = "buttonLoad";
      buttonLoad.Size = new Size(150, 23);
      buttonLoad.TabIndex = 5;
      buttonLoad.Text = "Загрузить данные";
      buttonLoad.UseVisualStyleBackColor = true;
      // 
      // buttonFilter
      // 
      buttonFilter.Location = new Point(219, 50);
      buttonFilter.Name = "buttonFilter";
      buttonFilter.Size = new Size(120, 23);
      buttonFilter.TabIndex = 6;
      buttonFilter.Text = "Фильтровать";
      buttonFilter.UseVisualStyleBackColor = true;
      buttonFilter.Click += buttonFilter_Click;
      // 
      // buttonFindBest
      // 
      buttonFindBest.Location = new Point(345, 50);
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
      dataGridViewAthletes.Location = new Point(20, 108);
      dataGridViewAthletes.Name = "dataGridViewAthletes";
      dataGridViewAthletes.ReadOnly = true;
      dataGridViewAthletes.Size = new Size(626, 219);
      dataGridViewAthletes.TabIndex = 9;
      // 
      // buttonBrowse
      // 
      buttonBrowse.Location = new Point(421, 17);
      buttonBrowse.Name = "buttonBrowse";
      buttonBrowse.Size = new Size(40, 25);
      buttonBrowse.TabIndex = 10;
      buttonBrowse.Text = "...";
      buttonBrowse.UseVisualStyleBackColor = true;
      // 
      // openFileDialog
      // 
      openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
      openFileDialog.Title = "Выберите файл для загрузки";
      // 
      // saveFileDialog
      // 
      saveFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
      saveFileDialog.Title = "Выберите файл для сохранения";
      // 
      // numericUpDownYear
      // 
      numericUpDownYear.Location = new Point(113, 49);
      numericUpDownYear.Maximum = new decimal(new int[] { 2025, 0, 0, 0 });
      numericUpDownYear.Minimum = new decimal(new int[] { 1970, 0, 0, 0 });
      numericUpDownYear.Name = "numericUpDownYear";
      numericUpDownYear.Size = new Size(100, 23);
      numericUpDownYear.TabIndex = 11;
      numericUpDownYear.Value = new decimal(new int[] { 1970, 0, 0, 0 });
      // 
      // errorProvider
      // 
      errorProvider.ContainerControl = this;
      // 
      // MainForm
      // 
      ClientSize = new Size(663, 339);
      Controls.Add(numericUpDownYear);
      Controls.Add(buttonBrowse);
      Controls.Add(dataGridViewAthletes);
      Controls.Add(labelBestAthlete);
      Controls.Add(buttonFindBest);
      Controls.Add(buttonFilter);
      Controls.Add(buttonLoad);
      Controls.Add(buttonGenerate);
      Controls.Add(labelYear);
      Controls.Add(textBoxFilePath);
      Controls.Add(labelFile);
      Name = "MainForm";
      Text = "Соревнования по прыжкам";
      ((System.ComponentModel.ISupportInitialize)dataGridViewAthletes).EndInit();
      ((System.ComponentModel.ISupportInitialize)numericUpDownYear).EndInit();
      ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
      ResumeLayout(false);
      PerformLayout();
    }
  }
}
