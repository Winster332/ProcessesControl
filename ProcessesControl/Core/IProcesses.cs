using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessesControl.Core
{
	public interface IProcesses
	{
		/// <summary>
		/// Возвращает все процессы
		/// </summary>
		/// <returns></returns>
		System.Diagnostics.Process[] GetProcesses();
		/// <summary>
		/// Возвращает слепок процессов
		/// </summary>
		/// <param name="id">ID слепка</param>
		/// <returns></returns>
		BaseCore.CastProcesses GetCastProcess(String id);
		/// <summary>
		/// Добавляет новый слепок
		/// </summary>
		/// <param name="cast">Слепок</param>
		void AddCastProcess(BaseCore.CastProcesses cast);
		/// <summary>
		/// Возвращает все слепки
		/// </summary>
		/// <returns></returns>
		List<BaseCore.CastProcesses> GetAllCast();
		/// <summary>
		/// Очищает кэш слепков
		/// </summary>
		void ClearAllCast();
		/// <summary>
		/// Удаляет слепок
		/// </summary>
		/// <param name="id">ID слепка</param>
		void RemoveCast(String id);
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
		List<System.Diagnostics.Process> GetNewProcesses();
	}
}
