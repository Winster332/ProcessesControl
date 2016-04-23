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

namespace ProcessesControl.UI
{
	/// <summary>
	/// Interaction logic for ItemAutorun.xaml
	/// </summary>
	public partial class ItemAutorun : UserControl
	{
		private Boolean local_visible = false;

		public ItemAutorun()
		{
			InitializeComponent();
		}

		public void SetName(String name)
		{
			this.label_name.Content = name;
			this.label_sub_name.Content = "Название: " + name;
		}

		public void SetValue(String value)
		{
			this.label_sub_value.ToolTip = value;

			if (value.Length > 45)
				value = value.Substring(0, 45) + "...";
			this.label_sub_value.Content = "Значение: " + value;
		}

		public void SetKeyType(String type)
		{
			label_type.Content = "Тип: " + type;
		}

		private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (!local_visible)
			{
				this.Height = 110;
			}
			else
			{
				this.Height = 30;
			}

			local_visible = !local_visible;
		}
	}
}
