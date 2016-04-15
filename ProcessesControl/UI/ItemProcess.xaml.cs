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
	/// Interaction logic for ItemProcess.xaml
	/// </summary>
	public partial class ItemProcess : UserControl
	{
		private Boolean show = false;
		public ItemProcess()
		{
			InitializeComponent();
		}

		public void SetNameProcess(String name)
		{
			label_name_process.Content = name;
		}

		// Show
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if (!show)
			{
				this.Height = 100;
			}
			else
			{
				this.Height = 30;
			}

			show = !show;
		}
	}
}
