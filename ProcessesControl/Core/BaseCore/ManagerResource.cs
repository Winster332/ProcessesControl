using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace ProcessesControl.Core.BaseCore
{
	public class ManagerResource : IResourse
	{
		private ICore core;
		public PCSettings settings;
		private ManagerCast mCast;
		private ManagerAutorun mAutorun;

		public ManagerResource(ICore core)
		{
			this.core = core;

			mCast = new ManagerCast(core);
			mAutorun = new ManagerAutorun(core);
		}

		public PCSettings GetSettings()
		{
			return settings;
		}

		public void SetSettings(PCSettings settings)
		{
			this.settings = settings;
			XmlSerializer ser = new XmlSerializer(typeof(PCSettings));

			using (Stream stream = new FileStream(BaseCore.ManagerFiles.PATH_SETTINGS, FileMode.Create))
			{
				ser.Serialize(stream, settings);
			}
		}

		public void LoadingsSettings()
		{
			XmlSerializer ser = new XmlSerializer(typeof(PCSettings));

			using (Stream stream = new FileStream(BaseCore.ManagerFiles.PATH_SETTINGS, FileMode.Open))
			{
				this.settings = (PCSettings)ser.Deserialize(stream);
			}
		}

		public ManagerCast GetManagerCast()
		{
			return mCast;
		}

		public void SetSignatures(List<INFO_SIGNATURE> signature)
		{
			XmlSerializer ser = new XmlSerializer(typeof(List<INFO_SIGNATURE>));

			using (Stream stream = new FileStream(BaseCore.ManagerFiles.PATH_SIGNATURES_FILE, FileMode.Create))
			{
				ser.Serialize(stream, signature);
			}
		}

		public List<INFO_SIGNATURE> GetSignatures()
		{
			XmlSerializer ser = new XmlSerializer(typeof(List<INFO_SIGNATURE>));
			List<INFO_SIGNATURE> info_s = new List<INFO_SIGNATURE>();

			using (Stream stream = new FileStream(BaseCore.ManagerFiles.PATH_SIGNATURES_FILE, FileMode.Open))
			{
				info_s = (List<INFO_SIGNATURE>)ser.Deserialize(stream);
			}

			return info_s;
		}

		public void AddSignature(INFO_SIGNATURE signature)
		{
			List<INFO_SIGNATURE> info_s = GetSignatures();
			info_s.Add(signature);
			SetSignatures(info_s);
		}

		public void RemoveSignature(string name, EventTypeSignature type)
		{
			List<INFO_SIGNATURE> info_s = GetSignatures();

			for (int i = 0; i < info_s.Count; i++)
				if (info_s[i].name == name && info_s[i].TypeSignature == type)
				{
					info_s.RemoveAt(i);
					break;
				}

			SetSignatures(info_s);
		}

		public ManagerAutorun GetManagerAutorun()
		{
			return mAutorun;
		}
	}
}
