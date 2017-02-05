namespace assignment_treeview
{
	using System.Windows;
	using ViewModels;


	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			var vm = new MainWindowViewModel();
			var v = new MainWindow { DataContext = vm };
			MainWindow = v;
			v.Show();

			base.OnStartup(e);
		}
	}
}
