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

		public ManagerResource(ICore core)
		{
			this.core = core;
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
	}
}
