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
		public PageRegulations()
		{
			InitializeComponent();
		}

		public void Initialize(ICore core)
		{
		}
	}
}
