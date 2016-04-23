using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessesControl.Core
{
	public interface IFiles
	{
		/// <summary>
		/// Проверяет и все репозитории приложения, в случае их отсутствия: создает новые
		/// </summary>
		void CheckAllFolder();
		/// <summary>
		/// Проверяет и файлы приложения, в случае их отсутствия: создает новые
		/// </summary>
		void CheckAllFiles();
		/// <summary>
		/// Проверка окружения
		/// </summary>
		void CheckAll();
	}
}
