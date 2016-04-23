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
	/// Interaction logic for ItemRegulation.xaml
	/// </summary>
	public partial class ItemRegulation : UserControl
	{
		public String NameSignature
		{
			get
			{
				return tb_name.Text;
			}
			set
			{
				this.tb_name.Text = value;
			}
		}
		public Core.BaseCore.EventTypeSignature TypeEventSignature
		{
			get
			{
				Core.BaseCore.EventTypeSignature res = Core.BaseCore.EventTypeSignature.none;

				switch (cb_type.Text)
				{
					case "Ничего не делать": res = Core.BaseCore.EventTypeSignature.none; break;
					case "Завершить": res = Core.BaseCore.EventTypeSignature.kill; break;
					case "Завершить и оповестить": res = Core.BaseCore.EventTypeSignature.msg_and_kill; break;
					case "Оповестить": res = Core.BaseCore.EventTypeSignature.msg; break;
				}

				return res;
			}
			set
			{
				switch (value)
				{
					case Core.BaseCore.EventTypeSignature.kill: cb_type.Text = cb_type.Items[1].ToString(); break;
					case Core.BaseCore.EventTypeSignature.msg: cb_type.Text = cb_type.Items[3].ToString(); break;
					case Core.BaseCore.EventTypeSignature.none: cb_type.Text = cb_type.Items[0].ToString(); break;
					case Core.BaseCore.EventTypeSignature.msg_and_kill: cb_type.Text = cb_type.Items[2].ToString(); break;
				}
			}
		}

		public ItemRegulation()
		{
			InitializeComponent();

			cb_type.Items.Add("Ничего не делать");
			cb_type.Items.Add("Завершить");
			cb_type.Items.Add("Завершить и оповестить");
			cb_type.Items.Add("Оповестить");

			cb_type.Text = cb_type.Items[0].ToString();

			tb_name.Text = "Название";
		}
	}
}
