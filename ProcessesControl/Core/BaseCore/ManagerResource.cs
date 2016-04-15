using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessesControl.Core.BaseCore
{
	public class ManagerResource : IResourse
	{
		private ICore core;

		public ManagerResource(ICore core)
		{
			this.core = core;
		}
	}
}
