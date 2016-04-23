using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace ProcessesControl.Core.BaseCore
{
	public class ManagerCast
	{
		private ICore core;
		private List<PCProcess> old_cast;

		public ManagerCast(ICore core)
		{
			this.core = core;

			old_cast = new List<PCProcess>();
		}

		public void SetListCast(List<PCProcess> process)
		{
			XmlSerializer ser = new XmlSerializer(typeof(List<PCProcess>));

			using (Stream stream = new FileStream(BaseCore.ManagerFiles.PATH_CAST_FILE, FileMode.Create))
			{
				ser.Serialize(stream, old_cast);
			}
			this.old_cast = process;
		}

		public void LoadingListCast()
		{
			XmlSerializer ser = new XmlSerializer(typeof(List<PCProcess>));

			using (Stream stream = new FileStream(BaseCore.ManagerFiles.PATH_CAST_FILE, FileMode.Open))
			{
				this.old_cast = (List<PCProcess>)ser.Deserialize(stream);
			}
		}

		public List<PCProcess> GetListCast()
		{
			return old_cast;
		}

		public void AddProcess(PCProcess process)
		{
			old_cast.Add(process);
			SetListCast(old_cast);
		}

		public void RemoveProcess(PCProcess process)
		{
			old_cast.Remove(process);
			SetListCast(old_cast);
		}
	}
}
