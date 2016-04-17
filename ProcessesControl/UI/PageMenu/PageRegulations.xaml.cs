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
	/// Interaction logic for PageRegulations.xaml
	/// </summary>
	public partial class PageRegulations : UserControl, IPageBase
	{
		private Core.ICore core;

		public PageRegulations()
		{
			InitializeComponent();
		}

		public void Initialize(ICore core)
		{
			this.core = core;
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			String tag = ((Button)sender).Tag.ToString();

			switch (tag)
			{
				case "ADD":		Add();	break;
				case "CLEAR":		break;
			}
		}

		public void Add()
		{
			ItemRegulation ip = new ItemRegulation();
			ip.Width = 360;
			ip.Height = 30;
			stackPanel.Children.Add(ip);
		}
	}
}
