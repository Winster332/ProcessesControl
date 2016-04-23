using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessesControl.Core
{
	public class PCSettings
	{
		public Boolean autorun; // Автозапуск app
		public Boolean update_processes; // Обновляется ли список процессов автоматически
		public int interval; // Интервал обновлений процессов
		public Boolean nf_update; // Оповещать о новом обновлении
		public Boolean auto_update; // Автообновление app
		public Boolean nf_unknow_processes; // Оповещать о неизвестном процессе
		public Boolean sec_ynadex; // 
		public Boolean writing_logs_app; // Вести логи приложения
		public Boolean writing_logs_processes; // Вести логи процессов
		public String current_version; // Текущая версия app
	}
}
