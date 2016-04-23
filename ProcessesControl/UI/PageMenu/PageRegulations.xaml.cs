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
		public List<ItemRegulation> items_regulation;

		public PageRegulations()
		{
			InitializeComponent();
			
			items_regulation = new List<ItemRegulation>();
		}

		public void Initialize(ICore core)
		{
			this.core = core;

			this.IsVisibleChanged += PageRegulations_IsVisibleChanged;
		}

		private void PageRegulations_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			if (this.Visibility == Visibility.Visible)
			{
				stackPanel.Children.Clear();
				List<Core.BaseCore.INFO_SIGNATURE> info_s = core.GetResource().GetSignatures();

				for (int i = 0; i < info_s.Count; i++)
				{
					Add(info_s[i].name, info_s[i].TypeSignature);
				}
			}
			else if (this.Visibility == Visibility.Hidden)
			{
				List<Core.BaseCore.INFO_SIGNATURE> list_signature = new List<Core.BaseCore.INFO_SIGNATURE>();

				for (int i = 0; i < stackPanel.Children.Count; i++)
				{
					ItemRegulation item = (ItemRegulation)stackPanel.Children[i];
					Core.BaseCore.INFO_SIGNATURE signature = new Core.BaseCore.INFO_SIGNATURE();
					signature.name = item.NameSignature;
					signature.TypeSignature = item.TypeEventSignature;
					list_signature.Add(signature);
				}

				core.GetResource().SetSignatures(list_signature);
			}
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			String tag = ((Button)sender).Tag.ToString();

			switch (tag)
			{
				case "ADD":		Add();	break;
				case "CLEAR":	Clear();break;
			}
		}

		public void Clear()
		{
			core.GetResource().SetSignatures(new List<Core.BaseCore.INFO_SIGNATURE>());
			stackPanel.Children.Clear();
		}

		public void Add()
		{
			items_regulation.Add(new ItemRegulation());
			items_regulation[items_regulation.Count - 1].Width = 360;
			items_regulation[items_regulation.Count - 1].Height = 30;
			stackPanel.Children.Add(items_regulation[items_regulation.Count - 1]);
		}

		public void Add(String name, Core.BaseCore.EventTypeSignature type)
		{
			items_regulation.Add(new ItemRegulation());
			items_regulation[items_regulation.Count - 1].Width = 360;
			items_regulation[items_regulation.Count - 1].Height = 30;
			items_regulation[items_regulation.Count - 1].NameSignature = name;
			items_regulation[items_regulation.Count - 1].TypeEventSignature = type;
			stackPanel.Children.Add(items_regulation[items_regulation.Count - 1]);
		}
	}
}
