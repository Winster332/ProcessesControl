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
using ProcessesControl.Core;

namespace ProcessesControl.UI.PageMenu
{
	/// <summary>
	/// Interaction logic for PageProcesses.xaml
	/// </summary>
	public partial class PageProcesses : UserControl, IPageBase
	{
		#region variables
		private Core.ICore core;
		private int sleep_worker = 1000;
		private System.ComponentModel.BackgroundWorker worker;
		private Boolean running_worker = true;
		#endregion
		#region PageProcesses
		public PageProcesses()
		{
			InitializeComponent();

			this.IsVisibleChanged += PageProcesses_IsVisibleChanged;

			worker = new System.ComponentModel.BackgroundWorker();
			worker.DoWork += Worker_DoWork;
			worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
		}
		#endregion
		#region Visible changed
		private void PageProcesses_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			if (Visibility == Visibility.Visible)
			{
				System.Diagnostics.Process[] procrsses = core.GetProcesses().GetProcesses();
				stackPanel.Children.Clear();

				for (int i = 0; i < procrsses.Length; i++)
					Add(procrsses[i]);

				sleep_worker = core.GetResource().GetSettings().interval * 1000;

				if (core.GetResource().GetSettings().update_processes)
				{
					running_worker = true;
				}
				else running_worker = false;
			}
			else if (Visibility == Visibility.Hidden)
			{
			}
		}
		#endregion
		#region Background worker async
		private void Worker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
		{
			this.Update();

			if (running_worker)
				worker.RunWorkerAsync();
		}

		private void Worker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
		{
			System.Threading.Thread.Sleep(sleep_worker);
		}
		#endregion
		#region Initialize
		public void Initialize(ICore core)
		{
			this.core = core;

			worker.RunWorkerAsync();
		}
		#endregion
		#region Add
		public void Add(System.Diagnostics.Process process)
		{
			ItemProcess ip = new ItemProcess();
			ip.Width = 360;
			ip.SetNameProcess(process.ProcessName);
			ip.Height = 30;
			stackPanel.Children.Add(ip);
		}
		#endregion
		#region Update
		private void Update()
		{
			System.Diagnostics.Process[] procrsses = core.GetProcesses().GetProcesses();
			core.GetProcesses().GetNewProcesses();

			stackPanel.Children.Clear();

			if (this.Visibility == Visibility.Visible)
			{
				for (int i = 0; i < procrsses.Length; i++)
					Add(procrsses[i]);
			}
		}
		#endregion
		#region Button click Update
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			System.Diagnostics.Process[] procrsses = core.GetProcesses().GetProcesses();
			stackPanel.Children.Clear();

			for (int i = 0; i < procrsses.Length; i++)
				Add(procrsses[i]);
		}
		#endregion
		#region Create cast
		private void Button_Click_1(object sender, RoutedEventArgs e)
		{

		}
		#endregion
	}
}
