using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.IO;
using System.Xml.Serialization;

namespace ProcessesControl.Core.BaseCore
{
	public class ManagerAutorun
	{
		private ICore core;
		private List<FileRegedit> old_regedit;

		public ManagerAutorun(ICore core)
		{
			this.core = core;

			old_regedit = new List<FileRegedit>();
		}

		public List<FileRegedit> LoadingListFiles()
		{
			XmlSerializer ser = new XmlSerializer(typeof(List<FileRegedit>));

			using (Stream stream = new FileStream(BaseCore.ManagerFiles.PATH_AUTORUN_FILE, FileMode.Open))
			{
				old_regedit = (List<FileRegedit>)ser.Deserialize(stream);
			}

			return old_regedit;
		}

		public void SetListRegedit(List<FileRegedit> regedit)
		{
			XmlSerializer ser = new XmlSerializer(typeof(List<FileRegedit>));

			using (Stream stream = new FileStream(BaseCore.ManagerFiles.PATH_AUTORUN_FILE, FileMode.Create))
			{
				ser.Serialize(stream, regedit);
			}
		}

		public List<FileRegedit> CheckFileAutorun()
		{
			List<FileRegedit> currentFiles = GetCurrentAutorun();
			List<FileRegedit> savingFiles = LoadingListFiles();
			List<FileRegedit> newFiles = new List<FileRegedit>();

			for (int i = 0; i < currentFiles.Count; i++)
			{
				Boolean isChecked = false;

				for (int j = 0; j < savingFiles.Count; j++)
				{
					if (savingFiles[j].name == currentFiles[i].name && savingFiles[j].path == currentFiles[i].path)
					{
						isChecked = true;
					}
				}

				if (!isChecked)
				{
					newFiles.Add(currentFiles[i]);
				}
			}

			return newFiles;
		}

		public List<FileRegedit> GetRegeditFiles()
		{
			return old_regedit;
		}

		public List<FileRegedit> GetCurrentAutorun()
		{
			List<FileRegedit> now = new List<FileRegedit>();
			RegistryKey reg = Registry.CurrentUser;
			reg = reg.OpenSubKey("Software");
			reg = reg.OpenSubKey("Microsoft");
			reg = reg.OpenSubKey("Windows");
			reg = reg.OpenSubKey("CurrentVersion");
			reg = reg.OpenSubKey("Run", true);
			String[] names = reg.GetValueNames();

			for (int i = 0; i < names.Length; i++)
			{
				FileRegedit fr = new FileRegedit();
				fr.IsNew = true;
				fr.name = names[i];
				fr.path = reg.GetValue(names[i]).ToString();
				now.Add(fr);
			}

			return now;
		}

		public class FileRegedit
		{
			public String name;
			public String path;
			public Boolean IsNew;
		}
	}
}
