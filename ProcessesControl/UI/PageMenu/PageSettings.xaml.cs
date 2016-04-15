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
	/// Interaction logic for PageSettings.xaml
	/// </summary>
	public partial class PageSettings : UserControl, IPageBase
	{
		private Core.ICore core;
		private Core.PCSettings settings;

		public PageSettings()
		{
			InitializeComponent();

			for (int i = 5; i <= 120; i += 5)
				comboBox_interval.Items.Add(i);

			this.IsVisibleChanged += PageSettings_IsVisibleChanged;
		}

		private void PageSettings_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			if (this.Visibility == Visibility.Visible)
			{
				core.GetResource().LoadingsSettings();
				this.settings = core.GetResource().GetSettings();
				ApplyInterfaceSettings();
			}
			else if (this.Visibility == Visibility.Hidden)
			{
				this.settings.autorun = cb_autorun.GetChecked();
				this.settings.auto_update = cb_auto_update.GetChecked();
				this.settings.interval = int.Parse(comboBox_interval.Text);
				this.settings.nf_unknow_processes = cb_nf_new_process.GetChecked();
				this.settings.nf_update = cb_nf_msg_update.GetChecked();
				this.settings.sec_ynadex = cb_sec_yandex.GetChecked();
				this.settings.update_processes = cb_update_processe.GetChecked();
				this.settings.writing_logs_app = cb_write_logs_app.GetChecked();
				this.settings.writing_logs_processes = cb_write_logs_processes.GetChecked();

				core.GetResource().SetSettings(this.settings);
			}
		}

		public void Initialize(ICore core)
		{
			this.core = core;
		}

		public void ApplyInterfaceSettings()
		{
			cb_autorun.SetCheck(settings.autorun);
			cb_auto_update.SetCheck(settings.auto_update);
			cb_nf_msg_update.SetCheck(settings.nf_update);
			cb_nf_new_process.SetCheck(settings.nf_unknow_processes);
			cb_sec_yandex.SetCheck(settings.sec_ynadex);
			cb_update_processe.SetCheck(settings.update_processes);
			cb_write_logs_app.SetCheck(settings.writing_logs_app);
			cb_write_logs_processes.SetCheck(settings.writing_logs_processes);
			comboBox_interval.Text = settings.interval.ToString();
		}

		// Default settings
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			PCSettings setting = new PCSettings();
			setting.autorun = true;
			setting.auto_update = true;
			setting.current_version = "v_1";
			setting.interval = 20;
			setting.nf_unknow_processes = true;
			setting.nf_update = false;
			setting.sec_ynadex = false;
			setting.update_processes = true;
			setting.writing_logs_app = true;
			setting.writing_logs_processes = true;

			core.GetResource().SetSettings(setting);
			this.settings = setting;
			ApplyInterfaceSettings();
		}
	}
}
