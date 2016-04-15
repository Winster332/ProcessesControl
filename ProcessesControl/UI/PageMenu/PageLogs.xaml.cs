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
	/// Interaction logic for PageLogs.xaml
	/// </summary>
	public partial class PageLogs : UserControl, IPageBase
	{
		private Core.ICore core;
		public PageLogs()
		{
			InitializeComponent();

			this.IsVisibleChanged += PageLogs_IsVisibleChanged;
		}

		private void PageLogs_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			if (this.Visibility == Visibility.Visible)
			{
				this.stackPanel.Children.Clear();

				List<System.Diagnostics.Process> list_new_processes = core.GetProcesses().GetNewProcesses();

				for (int i = 0; i < list_new_processes.Count; i++)
					Add(list_new_processes[i]);

			}
		}
		
		public void Add(System.Diagnostics.Process process)
		{
			ItemProcess ip = new ItemProcess();
			ip.Width = 360;
			ip.SetNameProcess(process.ProcessName);
			ip.Height = 30;
			stackPanel.Children.Add(ip);
		}

		public void Initialize(ICore core)
		{
			this.core = core;
		}
	}
}
