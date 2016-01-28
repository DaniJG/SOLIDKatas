using SOLID.Katas.OCP.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.Katas.OCP
{
    public class ActionExecutor
    {
        private IPlatformAPI platform;

        public ActionExecutor()
        {
            this.platform = PlatformAPI.GetPlatformAPI();
        }

        public void ExecuteActions(IEnumerable<RecordingAction> actions)
        {
            foreach(var action in actions)
            {
                if (action is StartRecordingAction)
                {
                    var startAction = action as StartRecordingAction;
                    this.platform.StartRecording(
                        startAction.RecordingId, 
                        startAction.ChannelId, 
                        startAction.StartTime, 
                        startAction.StopTime);
                }
                else if (action is StopRecordingAction)
                {
                    var stopAction = action as StopRecordingAction;
                    this.platform.StopRecording(stopAction.RecordingId, stopAction.StopTime);
                }
                else
                {
                    throw new InvalidOperationException(
                        string.Format("Cannot execute action of type {0}", action.GetType().Name));
                }
            }
        }
    }
}
