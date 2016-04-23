using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessesControl.Core.BaseCore
{
	public enum StateProcesse { New, Old, Unlock, Lock, System }

	public class PCProcess
	{
		public String name;
		public String path;
		public StateProcesse State;
	}
}
