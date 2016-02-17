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
                    this.ExecuteStartAction(action as StartRecordingAction);                    
                }
                else if (action is StopRecordingAction)
                {
                    this.ExecuteStopAction(action as StopRecordingAction);
                }
                else
                {
                    throw new InvalidOperationException(
                        string.Format("Cannot execute action of type {0}", action.GetType().Name));
                }
            }
        }

        private void ExecuteStartAction(StartRecordingAction action)
        {
            this.platform.StartRecording(
                        action.RecordingId,
                        action.ChannelId,
                        action.StartTime,
                        action.StopTime);
        }

        private void ExecuteStopAction(StopRecordingAction action)
        {
            this.platform.StopRecording(action.RecordingId, action.StopTime);
        }
    }
}
