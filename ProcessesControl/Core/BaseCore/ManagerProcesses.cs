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

		public ManagerProcesses(ICore core)
		{
			this.core = core;
		}

		public void AddCastProcess(CastProcesses cast)
		{
			throw new NotImplementedException();
		}

		public void ClearAllCast()
		{
			throw new NotImplementedException();
		}

		public void ClearFrozenProcesses()
		{
			throw new NotImplementedException();
		}

		public List<CastProcesses> GetAllCast()
		{
			throw new NotImplementedException();
		}

		public CastProcesses GetCastProcess(string id)
		{
			throw new NotImplementedException();
		}

		public List<PCProcess> GetFrozenProcesses()
		{
			throw new NotImplementedException();
		}

		public CastProcesses GetNewProcesses()
		{
			throw new NotImplementedException();
		}

		public Process[] GetProcesses()
		{
			return Process.GetProcesses();
		}

		public void LockProcess(Process process)
		{
			throw new NotImplementedException();
		}

		public void RemoveCast(string id)
		{
			throw new NotImplementedException();
		}

		public void UnlockProcess(Process process)
		{
			throw new NotImplementedException();
		}
	}
}
