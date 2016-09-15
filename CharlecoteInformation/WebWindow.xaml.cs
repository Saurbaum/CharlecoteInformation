using System.Reflection;
using System.Windows.Controls;
using System.Windows.Input;

namespace CharlecoteInformation
{
	using System;
	using System.Windows;

	/// <summary>
	/// Interaction logic for WebWindow.xaml
	/// </summary>
	public partial class WebWindow
	{
		private string homePage = "http://www.google.com";
		public WebWindow()
		{
			InitializeComponent();

			this.Browser.Navigated += (sender, args) =>
			{
				this.HideScriptErrors(this.Browser, true);
				this.Address.Text = args.Uri.ToString();
				this.Back.IsEnabled = this.Browser.CanGoBack;
				this.Forward.IsEnabled = this.Browser.CanGoForward;
			};

			this.Browser.Navigate(homePage);
		}

		public void HideScriptErrors(WebBrowser wb, bool Hide)
		{
			var fiComWebBrowser = typeof(WebBrowser).GetField("_axIWebBrowser2", BindingFlags.Instance | BindingFlags.NonPublic);

			if (fiComWebBrowser == null) return;

			var objComWebBrowser = fiComWebBrowser.GetValue(wb);

			objComWebBrowser?.GetType().InvokeMember("Silent", BindingFlags.SetProperty, null, objComWebBrowser, new object[] { Hide });
		}

		private void Go_Click(object sender, RoutedEventArgs e)
		{
			var targetUrl = this.Address.Text;
			if (!targetUrl.StartsWith("http"))
			{
				targetUrl = new UriBuilder("http", this.Address.Text).ToString();
			}

			this.Browser.Navigate(targetUrl);
		}

		private void Return_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void Back_OnClick(object sender, RoutedEventArgs e)
		{
			this.Browser.GoBack();
		}

		private void Forward_OnClick(object sender, RoutedEventArgs e)
		{
			this.Browser.GoForward();
		}

		private void Home_OnClick(object sender, RoutedEventArgs e)
		{
			this.Browser.Navigate(homePage);
		}

		private void Refresh_OnClick(object sender, RoutedEventArgs e)
		{
			this.Browser.Refresh();
		}

		private void Address_OnKeyUp(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Enter || e.Key == Key.Return)
			{
				this.Go_Click(null, null);
			}
		}

		private void Address_OnGotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
		{
			this.Address.SelectionStart = 0;
			this.Address.SelectionLength = this.Address.Text.Length;
		}
	}
}
