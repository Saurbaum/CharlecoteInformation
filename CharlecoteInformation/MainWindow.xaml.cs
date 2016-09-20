namespace CharlecoteInformation
{
	using System.Windows;

	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow
	{
		public MainWindow()
		{
			this.InitializeComponent();
		}

		private void Exit_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void InfoButton_Click(object sender, RoutedEventArgs e)
		{
			var webWindow = new InfoWindow();

			webWindow.Show();
		}
	}
}
