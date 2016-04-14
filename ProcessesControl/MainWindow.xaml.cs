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

namespace ProcessesControl
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		#region variables

		#endregion
		#region MainWindow
		public MainWindow()
		{
			InitializeComponent();

			#region add command
			this.CommandBindings.Add(new CommandBinding(SystemCommands.CloseWindowCommand, this.OnCloseWindow));
			this.CommandBindings.Add(new CommandBinding(SystemCommands.MaximizeWindowCommand, this.OnMaximizeWindow, this.OnCanResizeWindow));
			this.CommandBindings.Add(new CommandBinding(SystemCommands.MinimizeWindowCommand, this.OnMinimizeWindow, this.OnCanMinimizeWindow));
			this.CommandBindings.Add(new CommandBinding(SystemCommands.RestoreWindowCommand, this.OnRestoreWindow, this.OnCanResizeWindow));
			#endregion

			menu.clickItemsMenu += Menu_clickItemsMenu;
		}
		#endregion
		#region Menu click in page
		private void Menu_clickItemsMenu(UI.ListBoxMenu.MenuCommand cmd)
		{
			IndentTo(cmd);
		}
		#endregion
		#region IndentTo
		private void IndentTo(UI.ListBoxMenu.MenuCommand page)
		{
			switch (page)
			{
				case UI.ListBoxMenu.MenuCommand.processes:
					processes.Visibility = Visibility.Visible;
					regulations.Visibility = Visibility.Hidden;
					logs.Visibility = Visibility.Hidden;
					autorun.Visibility = Visibility.Hidden;
					settings.Visibility = Visibility.Hidden;
					break;
				case UI.ListBoxMenu.MenuCommand.regulation:
					processes.Visibility = Visibility.Hidden;
					regulations.Visibility = Visibility.Visible;
					logs.Visibility = Visibility.Hidden;
					autorun.Visibility = Visibility.Hidden;
					settings.Visibility = Visibility.Hidden;
					break;
				case UI.ListBoxMenu.MenuCommand.logs:
					processes.Visibility = Visibility.Hidden;
					regulations.Visibility = Visibility.Hidden;
					logs.Visibility = Visibility.Visible;
					autorun.Visibility = Visibility.Hidden;
					settings.Visibility = Visibility.Hidden;
					break;
				case UI.ListBoxMenu.MenuCommand.autorun:
					processes.Visibility = Visibility.Hidden;
					regulations.Visibility = Visibility.Hidden;
					logs.Visibility = Visibility.Hidden;
					settings.Visibility = Visibility.Hidden;
					autorun.Visibility = Visibility.Visible;
					break;
				case UI.ListBoxMenu.MenuCommand.settings:
					processes.Visibility = Visibility.Hidden;
					regulations.Visibility = Visibility.Hidden;
					logs.Visibility = Visibility.Hidden;
					autorun.Visibility = Visibility.Hidden;
					settings.Visibility = Visibility.Visible;
					break;
				case UI.ListBoxMenu.MenuCommand.exit: SystemCommands.CloseWindow(this); break;
			}
		}
		#endregion
		#region Commands
		private void OnCanResizeWindow(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = this.ResizeMode == ResizeMode.CanResize || this.ResizeMode == ResizeMode.CanResizeWithGrip;
		}

		private void OnCanMinimizeWindow(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = this.ResizeMode != ResizeMode.NoResize;
		}

		private void OnCloseWindow(object target, ExecutedRoutedEventArgs e)
		{
			SystemCommands.CloseWindow(this);
		}

		private void OnMaximizeWindow(object target, ExecutedRoutedEventArgs e)
		{
			if (this.WindowState == System.Windows.WindowState.Normal)
			{
				SystemCommands.MaximizeWindow(this);
			}
			else if (this.WindowState == System.Windows.WindowState.Maximized)
			{
				SystemCommands.RestoreWindow(this);
			}
		}

		private void OnMinimizeWindow(object target, ExecutedRoutedEventArgs e)
		{
			SystemCommands.MinimizeWindow(this);
		}

		private void OnRestoreWindow(object target, ExecutedRoutedEventArgs e)
		{
			SystemCommands.RestoreWindow(this);
		}
		#endregion
	}
}
