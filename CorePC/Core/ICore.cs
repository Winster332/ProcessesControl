using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessesControl.Core
{
	public interface ICore
	{
		/// <summary>
		/// Интерфейс менеджера процессов
		/// </summary>
		/// <returns></returns>
		IProcesses GetProcesses();
		/// <summary>
		/// Интерфейс менеджера ресурсов
		/// </summary>
		/// <returns></returns>
		IResourse GetResource();
		/// <summary>
		/// Интерфейс менеджера файлововй системы
		/// </summary>
		/// <returns></returns>
		IFiles GetFiles();
	}
}
