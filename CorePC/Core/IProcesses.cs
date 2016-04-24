using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ProcessesControl.Core
{
	public interface IProcesses
	{
		/// <summary>
		/// Возвращает все процессы
		/// </summary>
		/// <returns></returns>
		Tuple<Process[], List<BaseCore.PCProcess>> GetProcesses();
		/// <summary>
		/// Возвращает коллекцию заблокированных процессов
		/// </summary>
		/// <returns></returns>
		List<BaseCore.PCProcess> GetFrozenProcesses();
		/// <summary>
		/// Очищает список заблокированных процессов
		/// </summary>
		void ClearFrozenProcesses();
		/// <summary>
		/// Блокирует процесс
		/// </summary>
		/// <param name="process"></param>
		void LockProcess(System.Diagnostics.Process process);
		/// <summary>
		/// Разблокирывает процесс
		/// </summary>
		/// <param name="process">Сам процесс</param>
		void UnlockProcess(System.Diagnostics.Process process);
		/// <summary>
		/// Возвращает слепок новых процессов
		/// </summary>
		/// <returns></returns>
		List<BaseCore.PCProcess> UpdateNewProcesses(System.Diagnostics.Process[] processes);

		List<System.Diagnostics.Process> GetNewProcesses();
	}
}
