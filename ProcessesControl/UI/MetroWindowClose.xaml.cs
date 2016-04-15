using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProcessesControl.UI
{
	/// <summary>
	/// Interaction logic for MetroWindowClose.xaml
	/// </summary>
	public partial class MetroWindowClose : Window
	{
		public enum ResultCloseWindow { close, hidden, cancle}
		private ResultCloseWindow result;
		private Window window;

		public MetroWindowClose(Window window)
		{
			InitializeComponent();

			this.window = window;
		}

		public ResultCloseWindow GetResult()
		{
			return result;
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			String tag = ((Button)sender).Tag.ToString();

			switch (tag)
			{
				case "CLOSE":
					result = ResultCloseWindow.close;
					this.Close();
					break;
				case "SEC":
					result = ResultCloseWindow.hidden;
					this.Close();
					break;
				case "CANCLE":
					result = ResultCloseWindow.cancle;
					this.Close();
					break;
			}
		}
	}
}
