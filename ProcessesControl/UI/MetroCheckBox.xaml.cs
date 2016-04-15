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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProcessesControl.UI
{
	/// <summary>
	/// Interaction logic for MetroCheckBox.xaml
	/// </summary>
	public partial class MetroCheckBox : UserControl
	{
		private Boolean IsCheck = false;

		public MetroCheckBox()
		{
			InitializeComponent();
			slider.Fill = new SolidColorBrush(Color.FromArgb(255, 220, 120, 120));
		}

		private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (!IsCheck)
			{
				slider.Margin = new Thickness(25, 0, 0, 0);
				slider.Fill = new SolidColorBrush(Color.FromArgb(255, 80, 220, 140));
			}
			else
			{
				slider.Margin = new Thickness(-25, 0, 0, 0);
				slider.Fill = new SolidColorBrush(Color.FromArgb(255, 220, 120, 120));
			}

			IsCheck = !IsCheck;
		}

		public bool GetChecked()
		{
			return IsCheck;
		}
	}
}
