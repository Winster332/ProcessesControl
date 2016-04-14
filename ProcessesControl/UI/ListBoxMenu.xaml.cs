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
	/// Interaction logic for ListBoxMenu.xaml
	/// </summary>
	public partial class ListBoxMenu : UserControl
	{
		public enum MenuCommand { processes, settings, autorun, exit, regulation, logs }
		public delegate void ClickItemMenu(MenuCommand cmd);
		public event ClickItemMenu clickItemsMenu;

		public ListBoxMenu()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			String tag = ((Button)sender).Tag.ToString();
			MenuCommand cmd = MenuCommand.processes;

			switch (tag)
			{
				case "processes": cmd = MenuCommand.processes; break;
				case "regulation": cmd = MenuCommand.regulation; break;
				case "logs": cmd = MenuCommand.logs; break;
				case "autorun": cmd = MenuCommand.autorun; break;
				case "settings": cmd = MenuCommand.settings; break;
				case "exit": cmd = MenuCommand.exit; break;
			}

			if (clickItemsMenu != null)
				clickItemsMenu(cmd);
		}
	}
}
