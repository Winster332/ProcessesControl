﻿using System;
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
	/// Interaction logic for BottomPanel.xaml
	/// </summary>
	public partial class BottomPanel : UserControl
	{
		public BottomPanel()
		{
			InitializeComponent();
		}

		public void SetAllValues(int Processes, int lock_count, int cpu, int ram)
		{
		}
	}
}
