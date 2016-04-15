using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessesControl.Core.BaseCore
{
	public class ManagerFiles : IFiles
	{
		private ICore core;

		public ManagerFiles(ICore core)
		{
			this.core = core;
		}

		public void CheckAll()
		{
			throw new NotImplementedException();
		}

		public void CheckAllFiles()
		{
			throw new NotImplementedException();
		}

		public void CheckAllFolder()
		{
			throw new NotImplementedException();
		}
	}
}
