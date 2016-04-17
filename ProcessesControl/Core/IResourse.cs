using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessesControl.Core
{
	public interface IResourse
	{
		PCSettings GetSettings();
		void SetSettings(PCSettings settings);
		void LoadingsSettings();
		BaseCore.ManagerCast GetManagerCast();
	}
}
