using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessesControl.UI.PageMenu
{
	public interface IPageBase
	{
		/// <summary>
		/// Инициализирует страницу
		/// </summary>
		/// <param name="core">Интерфейс ядра приложения</param>
		void Initialize(Core.ICore core);
	}
}
