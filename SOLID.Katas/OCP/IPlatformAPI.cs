using System;
namespace SOLID.Katas.OCP
{
    public interface IPlatformAPI
    {
        void DeleteRecording(int id);
        void StartRecording(int id, int channeId, DateTime startTime, DateTime stopTime);
        void StopRecording(int id, DateTime stopTime);
    }
}
