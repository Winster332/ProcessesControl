using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessesControl.Core.BaseCore
{
	public enum EventTypeSignature { none, kill, msg, msg_and_kill }

	[Serializable]
	public class INFO_SIGNATURE
	{
		public String name;
		public EventTypeSignature TypeSignature;
	}
}
