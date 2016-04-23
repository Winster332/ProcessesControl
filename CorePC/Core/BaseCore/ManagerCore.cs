using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessesControl.Core.BaseCore
{
	public class ManagerCore : ICore
	{
		private IResourse resourse;
		private IFiles files;
		private IProcesses processes;

		public ManagerCore()
		{
			resourse = new BaseCore.ManagerResource(this);
			files = new BaseCore.ManagerFiles(this);
			processes = new BaseCore.ManagerProcesses(this);

			files.CheckAll();
			resourse.LoadingsSettings();
			resourse.GetManagerCast().LoadingListCast();
			resourse.GetManagerAutorun().LoadingListFiles();
		}

		public IFiles GetFiles()
		{
			return files;
		}

		public IProcesses GetProcesses()
		{
			return processes;
		}

		public IResourse GetResource()
		{
			return resourse;
		}
	}
}
