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
		private List<Process> current_processes;
		private List<Process> prev_processes;
		private List<Process> new_processes;

		public ManagerProcesses(ICore core)
		{
			this.core = core;

			current_processes = new List<Process>();
			prev_processes = new List<Process>();
			new_processes = new List<Process>();
		}
		
		public void ClearFrozenProcesses()
		{
		}

		public List<PCProcess> GetFrozenProcesses()
		{
			throw new NotImplementedException();
		}

		public List<Process> UpdateNewProcesses()
		{
			current_processes.Clear();
			Process[] cp = Process.GetProcesses();

			if (prev_processes.Count > 0)
			{
				for (int i = 0; i < cp.Length; i++)
				{
					Boolean check_process = false;
					current_processes.Add(cp[i]);

					for (int j = 0; j < prev_processes.Count; j++)
						if (cp[i].ProcessName == prev_processes[j].ProcessName)
						{
							check_process = true;
							continue;
						}

					if (!check_process)
					{
						foreach (Process proc in new_processes)
							if (proc.ProcessName == cp[i].ProcessName)
								check_process = true;

						if (!check_process)
							new_processes.Add(cp[i]);
					}
				}
			}
			else { GetProcesses(); }

			prev_processes.Clear();
			for (int i = 0; i < current_processes.Count; i++)
				prev_processes.Add(current_processes[i]);

			return new_processes;
		}

		public Process[] GetProcesses()
		{
			current_processes.Clear();
			Process[] pr = Process.GetProcesses();
			foreach (Process p in pr)
				current_processes.Add(p);

			return pr;
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
