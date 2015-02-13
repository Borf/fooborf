using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace FooBorf
{
	[
	ToolStripItemDesignerAvailability
		(ToolStripItemDesignerAvailability.ToolStrip | ToolStripItemDesignerAvailability.StatusStrip)
	]

	public class ToolStripTraceBarItem : ToolStripControlHost
	{
		public TrackBar tb { get { return (TrackBar) this.Control;  } }
		public ToolStripTraceBarItem()
			: base(new TrackBar())
		{

		}
	}

}
