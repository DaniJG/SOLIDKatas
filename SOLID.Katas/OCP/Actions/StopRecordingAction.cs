using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.Katas.OCP.Actions
{
    class StopRecordingAction : RecordingAction
    {
        public DateTime StopTime { get; set; }
    }
}
