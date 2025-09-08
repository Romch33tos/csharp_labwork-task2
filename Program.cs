using System;
using System.Windows.Forms;

namespace SportsCompetitionApp
{
  internal static class Program
  {
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      var mainForm = new MainForm();
      var presenter = new MainPresenter(mainForm);

      Application.Run(mainForm);
    }
  }
}