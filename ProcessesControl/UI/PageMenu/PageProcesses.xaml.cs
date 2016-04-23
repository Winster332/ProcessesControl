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
		#endregion
		#region PageProcesses
		public PageProcesses()
		{
			InitializeComponent();

			this.IsVisibleChanged += PageProcesses_IsVisibleChanged;
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
			}
			else if (Visibility == Visibility.Hidden)
			{
			}
		}
		#endregion
		#region Initialize
		public void Initialize(ICore core)
		{
			this.core = core;
		}
		#endregion
		#region Add
		public void Add(System.Diagnostics.Process process)
		{
			ItemProcess ip = new ItemProcess();
			ip.Width = 360;
			ip.SetNameProcess(process.ProcessName);
			ip.Height = 30;
			ip.SetMemory(((process.VirtualMemorySize / 1024) / 1000).ToString());
		// Нужно доставать иконку из процесса
		//	ip.SetImage(@"C:\Users\User\Desktop\Screen\post-1120952-1428568681.png"); 
			stackPanel.Children.Add(ip);
		}
		#endregion
		#region Update
		public void Update()
		{
			System.Diagnostics.Process[] procrsses = core.GetProcesses().GetProcesses();
			core.GetProcesses().UpdateNewProcesses();

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
