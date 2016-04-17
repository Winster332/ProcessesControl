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
	/// Interaction logic for MetroTextBox.xaml
	/// </summary>
	public partial class MetroTextBox : UserControl
	{
		#region varaibels
		public String Text
		{
			get
			{
				return textBox.Text;
			}
			set
			{
				textBox.Text = value;
			}
		}
		#endregion
		public MetroTextBox()
		{
			InitializeComponent();
		}
		#region Button click clear
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			ClearText();
			textBox.Focus();
		}
		#endregion
		#region Clear text
		public void ClearText()
		{
			textBox.Text = "";
		}
		#endregion
	}
}
