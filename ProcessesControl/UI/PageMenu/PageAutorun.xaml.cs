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
using Microsoft.Win32;

namespace ProcessesControl.UI.PageMenu
{
	/// <summary>
	/// Interaction logic for PageAutorun.xaml
	/// </summary>
	public partial class PageAutorun : UserControl, IPageBase
	{
		private Core.ICore core;

		public PageAutorun()
		{
			InitializeComponent();

			this.IsVisibleChanged += PageAutorun_IsVisibleChanged;
		}

		private void PageAutorun_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			if (this.Visibility == Visibility.Visible)
			{
				stackPanel.Children.Clear();
				CheckAutorun();
			}
		}

		public void Initialize(ICore core)
		{
			this.core = core;
		}
		
		public void Add(String name)
		{
			ItemProcess ip = new ItemProcess();
			ip.Width = 360;
			ip.SetNameProcess(name);
			ip.Height = 30;
			stackPanel.Children.Add(ip);
		}

		public void CheckAutorun()
		{
			RegistryKey reg = Registry.CurrentUser;
			reg = reg.OpenSubKey("Software");
			reg = reg.OpenSubKey("Microsoft");
			reg = reg.OpenSubKey("Windows");
			reg = reg.OpenSubKey("CurrentVersion");
			reg = reg.OpenSubKey("Run", true);
			String[] names = reg.GetValueNames();

			for (int i = 0; i < names.Length; i++)
				Add(names[i]);
		}
	}
}
