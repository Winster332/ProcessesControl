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
			stackPanel.Children.Add(ip);
		}
		#endregion
		#region Update
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
