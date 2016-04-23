using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProcessesControl.Core.BaseCore
{
	public class ManagerFiles : IFiles
	{
		public const String PATH_DATA = @"Data\";
		public const String PATH_SETTINGS = PATH_DATA + @"Settings.xml";
		public const String PATH_CAST = PATH_DATA + @"Cast\";
		public const String PATH_CAST_FILE = PATH_DATA + @"Cast\CastProcesses.xml";
		public const String PATH_SIGNATURES = PATH_DATA + @"Signatures\";
		public const String PATH_SIGNATURES_FILE = PATH_SIGNATURES + "Signatures.xml";
		public const String PATH_LOCK_PROCESSES = PATH_DATA + @"Lock processes\";
		public const String PATH_UNLOCK_PROCESSES = PATH_DATA + @"Unlock processes\";
		public const String PATH_AUTORUN = PATH_DATA + @"Autorun\";
		public const String PATH_AUTORUN_FILE = PATH_DATA + @"Autorun\autorun_regedit.xml";
		private ICore core;

		public ManagerFiles(ICore core)
		{
			this.core = core;
		}

		public void CheckAll()
		{
			CheckAllFolder();
			CheckAllFiles();
		}

		public void CheckAllFiles()
		{
			if (!File.Exists(PATH_SETTINGS))
			{
				PCSettings setting = new PCSettings();
				setting.autorun = true;
				setting.auto_update = true;
				setting.current_version = "v_1";
				setting.interval = 20;
				setting.nf_unknow_processes = true;
				setting.nf_update = false;
				setting.sec_ynadex = false;
				setting.update_processes = true;
				setting.writing_logs_app = true;
				setting.writing_logs_processes = true;

				core.GetResource().SetSettings(setting);
			}
			if (!File.Exists(PATH_SIGNATURES_FILE))
			{
				List<INFO_SIGNATURE> info_s = new List<INFO_SIGNATURE>();

				core.GetResource().SetSignatures(info_s);
			}
			if (!File.Exists(PATH_CAST_FILE))
			{
				core.GetResource().GetManagerCast().SetListCast(new List<PCProcess>());
			}
			if (!File.Exists(PATH_AUTORUN_FILE))
			{
				core.GetResource().GetManagerAutorun().SetListRegedit(new List<ManagerAutorun.FileRegedit>());
			}
		}

		public void CheckAllFolder()
		{
			if (!Directory.Exists(PATH_DATA))
				Directory.CreateDirectory(PATH_DATA);
			if (!Directory.Exists(PATH_CAST))
				Directory.CreateDirectory(PATH_CAST);
			if (!Directory.Exists(PATH_LOCK_PROCESSES))
				Directory.CreateDirectory(PATH_LOCK_PROCESSES);
			if (!Directory.Exists(PATH_UNLOCK_PROCESSES))
				Directory.CreateDirectory(PATH_UNLOCK_PROCESSES);
			if (!Directory.Exists(PATH_SIGNATURES))
				Directory.CreateDirectory(PATH_SIGNATURES);
			if (!Directory.Exists(PATH_AUTORUN))
				Directory.CreateDirectory(PATH_AUTORUN);
		}
	}
}
