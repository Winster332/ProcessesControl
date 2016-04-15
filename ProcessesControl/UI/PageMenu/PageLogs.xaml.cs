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
		public PageLogs()
		{
			InitializeComponent();
		}

		public void Initialize(ICore core)
		{
		}
	}
}
