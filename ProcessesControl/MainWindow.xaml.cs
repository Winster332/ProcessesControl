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
		public Core.ICore core;
		private System.Timers.Timer timer_update;
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


			core = new Core.BaseCore.ManagerCore();

			page_autorun.Initialize(core);
			page_logs.Initialize(core);
			page_processes.Initialize(core);
			page_regulations.Initialize(core);
			page_settings.Initialize(core);

			menu.clickItemsMenu += Menu_clickItemsMenu;

			timer_update = new System.Timers.Timer();
			timer_update.Interval = core.GetResource().GetSettings().interval * 1000;
			timer_update.Elapsed += Timer_update_Elapsed;
			timer_update.Start();
		}
		#endregion
		#region update
		private void Timer_update_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			if (!core.GetResource().GetSettings().update_processes)
				timer_update.Stop();

			page_processes.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Background, new Action(delegate {
				page_processes.Update();
			}));

			bottom_panel.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Background, new Action(delegate {
				bottom_panel.SetAllValues(core.GetProcesses().GetProcesses().Length, core.GetProcesses().GetNewProcesses().Count, 0, 0);
			}));
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
					page_processes.Visibility = Visibility.Visible;
					page_regulations.Visibility = Visibility.Hidden;
					page_logs.Visibility = Visibility.Hidden;
					page_autorun.Visibility = Visibility.Hidden;
					page_settings.Visibility = Visibility.Hidden;
					break;
				case UI.ListBoxMenu.MenuCommand.regulation:
					page_processes.Visibility = Visibility.Hidden;
					page_regulations.Visibility = Visibility.Visible;
					page_logs.Visibility = Visibility.Hidden;
					page_autorun.Visibility = Visibility.Hidden;
					page_settings.Visibility = Visibility.Hidden;
					break;
				case UI.ListBoxMenu.MenuCommand.logs:
					page_processes.Visibility = Visibility.Hidden;
					page_regulations.Visibility = Visibility.Hidden;
					page_logs.Visibility = Visibility.Visible;
					page_autorun.Visibility = Visibility.Hidden;
					page_settings.Visibility = Visibility.Hidden;
					break;
				case UI.ListBoxMenu.MenuCommand.autorun:
					page_processes.Visibility = Visibility.Hidden;
					page_regulations.Visibility = Visibility.Hidden;
					page_logs.Visibility = Visibility.Hidden;
					page_settings.Visibility = Visibility.Hidden;
					page_autorun.Visibility = Visibility.Visible;
					break;
				case UI.ListBoxMenu.MenuCommand.settings:
					page_processes.Visibility = Visibility.Hidden;
					page_regulations.Visibility = Visibility.Hidden;
					page_logs.Visibility = Visibility.Hidden;
					page_autorun.Visibility = Visibility.Hidden;
					page_settings.Visibility = Visibility.Visible;
					break;
				case UI.ListBoxMenu.MenuCommand.exit:
					UI.MetroWindowClose mwc = new UI.MetroWindowClose(this);
					Canvas.SetLeft(mwc, this.Width / 2);
					Canvas.SetTop(mwc, this.Height / 2);
					mwc.ShowDialog();
					UI.MetroWindowClose.ResultCloseWindow result = mwc.GetResult();
					switch (result)
					{
						case UI.MetroWindowClose.ResultCloseWindow.cancle:  break;
						case UI.MetroWindowClose.ResultCloseWindow.close: SystemCommands.CloseWindow(this); break;
						case UI.MetroWindowClose.ResultCloseWindow.hidden: ToHide(); break;
					}
					break;
			}
		}
		#endregion
		#region ToHide
		private void ToHide()
		{
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
			page_autorun.Visibility = Visibility.Hidden;
			page_logs.Visibility = Visibility.Hidden;
			page_processes.Visibility = Visibility.Hidden;
			page_regulations.Visibility = Visibility.Hidden;
			page_settings.Visibility = Visibility.Hidden;
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
