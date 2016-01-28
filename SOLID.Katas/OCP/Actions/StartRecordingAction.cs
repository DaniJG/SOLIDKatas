using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.Katas.OCP.Actions
{
    public class StartRecordingAction : RecordingAction
    {
        public int ChannelId { get; set; }
        public DateTime StartTime { get; set; }

        public DateTime StopTime { get; set; }
    }
}
