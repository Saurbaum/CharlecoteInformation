using System.Reflection;
using System.Windows.Controls;

namespace CharlecoteInformation
{
	using System.Windows;

	/// <summary>
	/// Interaction logic for InfoWindow.xaml
	/// </summary>
	public partial class InfoWindow
	{
		private string homePage = "C:\\users\\music\\OneDrive\\Acer-charlecote\\index.htm";
		//private string homePage = "http://musicweb-international.com/charlecote/index.htm";

		public InfoWindow()
		{
			this.InitializeComponent();

			this.Browser.Navigated += (sender, args) =>
			{
				this.HideScriptErrors(this.Browser, true);
			};

			this.Browser.Navigate(this.homePage);
		}

		public void HideScriptErrors(WebBrowser wb, bool hide)
		{
			var fiComWebBrowser = typeof(WebBrowser).GetField("_axIWebBrowser2", BindingFlags.Instance | BindingFlags.NonPublic);

			if (fiComWebBrowser == null) return;

			var objComWebBrowser = fiComWebBrowser.GetValue(wb);

			objComWebBrowser?.GetType().InvokeMember("Silent", BindingFlags.SetProperty, null, objComWebBrowser, new object[] { hide });
		}

		private void Return_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void Back_Click(object sender, RoutedEventArgs e)
		{
			if (this.Browser.CanGoBack)
			{
				this.Browser.GoBack();
			}
		}

		private void Forward_Click(object sender, RoutedEventArgs e)
		{
			if (this.Browser.CanGoForward)
			{
				this.Browser.GoForward();
			}
		}

		private void Home_Click(object sender, RoutedEventArgs e)
		{
			this.Browser.Navigate(this.homePage);
		}
	}
}
