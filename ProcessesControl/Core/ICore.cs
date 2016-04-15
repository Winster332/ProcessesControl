using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessesControl.Core
{
	public interface ICore
	{
		IProcesses GetProcesses();
		IResourse GetResource();
		IFiles GetFiles();
	}
}
