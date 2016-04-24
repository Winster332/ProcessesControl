using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessesControl.Core.BaseCore
{
	public class ManagerProcesses : IProcesses
	{
		private ICore core;
		private List<Process> new_processes;

		public ManagerProcesses(ICore core)
		{
			this.core = core;
			
			new_processes = new List<Process>();
		}
		
		public void ClearFrozenProcesses()
		{
		}

		public List<PCProcess> GetFrozenProcesses()
		{
			throw new NotImplementedException();
		}

		public List<PCProcess> UpdateNewProcesses(Process[] cp)
		{
			List<PCProcess> list_signatures = core.GetResource().GetManagerCast().GetListCast();
			List<PCProcess> list_processes = new List<PCProcess>();

			for (int i = 0; i < cp.Length; i++)
			{
				Boolean check_process = false;
				PCProcess process = new PCProcess();
				process.name = cp[i].ProcessName;
				process.State = StateProcesse.Old;

				for (int j = 0; j < list_signatures.Count; j++)
				{
					if (cp[i].ProcessName == list_signatures[j].name)
					{
						process.State = StateProcesse.Old;
						check_process = true;
					}
				}

				if (!check_process)
				{
					process.State = StateProcesse.New;
				}

				list_processes.Add(process);
			}

			return list_processes;
		}

		public Tuple<Process[], List<PCProcess>> GetProcesses()
		{
			Process[] pr = Process.GetProcesses();
			List<PCProcess> proc = UpdateNewProcesses(pr);

			return new Tuple<Process[], List<PCProcess>>(pr, proc);
		}

		public void LockProcess(Process process)
		{
		}

		public void UnlockProcess(Process process)
		{
		}

		public List<Process> GetNewProcesses()
		{
			return new_processes;
		}
	}
}
