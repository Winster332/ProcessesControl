using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessesControl.Core
{
	public interface IResourse
	{
		/// <summary>
		/// Возвращает настройки
		/// </summary>
		/// <returns></returns>
		PCSettings GetSettings();
		/// <summary>
		/// Создает настройки
		/// </summary>
		/// <param name="settings">Сам объект настроек</param>
		void SetSettings(PCSettings settings);
		/// <summary>
		/// Загружает настройки в память
		/// </summary>
		void LoadingsSettings();
		/// <summary>
		/// Возвращает менеджер слепков
		/// </summary>
		/// <returns></returns>
		BaseCore.ManagerCast GetManagerCast();
		/// <summary>
		/// Создает коллекцию сигнатур
		/// </summary>
		/// <param name="signature"></param>
		void SetSignatures(List<BaseCore.INFO_SIGNATURE> signature);
		/// <summary>
		/// Возвращает коллекцию сигнатур
		/// </summary>
		/// <returns></returns>
		List<BaseCore.INFO_SIGNATURE> GetSignatures();
		/// <summary>
		/// Добавляет сигнатуру в коллекцию
		/// </summary>
		/// <param name="signature">Объект сигнатуры</param>
		void AddSignature(BaseCore.INFO_SIGNATURE signature);
		/// <summary>
		/// Удаляет сигнатуру из коллекции
		/// </summary>
		/// <param name="name">Имя удаляемой сигнатуры</param>
		/// <param name="type">Тип удаляемой сигнатуры</param>
		void RemoveSignature(String name, BaseCore.EventTypeSignature type);
		/// <summary>
		/// Возвращает менеджер автозапуска программ
		/// </summary>
		/// <returns></returns>
		BaseCore.ManagerAutorun GetManagerAutorun();
	}
}
