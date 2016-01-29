using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SOLID.Katas.OCP;
using SOLID.Katas.OCP.Actions;
using Moq;
using System.Collections.Generic;

namespace SOLID.Katas.Test.OCP
{
    [TestClass]
    public class ActionExecutorIntegrationTest
    {
        private ActionExecutor actionExecutor;
        private Mock<IPlatformAPI> platformMock;

        [TestInitialize]
        public void Initialize()
        {
            this.platformMock = new Mock<IPlatformAPI>();
            PlatformAPI.SetPlatformAPI(this.platformMock.Object);
            this.actionExecutor = new ActionExecutor();
        }

        [TestMethod]
        public void ARecordingCanBeCreated()
        {
            var action = new StartRecordingAction { 
                RecordingId = 5, 
                ChannelId = 32, 
                StartTime = DateTime.Now, 
                StopTime = DateTime.Now.AddHours(1)
            };
            this.actionExecutor.ExecuteActions(new List<RecordingAction> { action });

            this.platformMock.Verify(p => p.StartRecording(
                action.RecordingId,
                action.ChannelId,
                action.StartTime,
                action.StopTime));
        }

        [TestMethod]
        public void ARecordingCanBeCreated_AndStoppedEarlier()
        {
            var startAction = new StartRecordingAction
            {
                RecordingId = 75,
                ChannelId = 32,
                StartTime = DateTime.Now,
                StopTime = DateTime.Now.AddHours(1)
            };
            var stopAction = new StopRecordingAction
            {
                RecordingId = 75,
                StopTime = DateTime.Now.AddMinutes(30)
            };
            this.actionExecutor.ExecuteActions(new List<RecordingAction> { startAction, stopAction });

            this.platformMock.Verify(p => p.StartRecording(
                startAction.RecordingId,
                startAction.ChannelId,
                startAction.StartTime,
                startAction.StopTime));
            this.platformMock.Verify(p => p.StopRecording(stopAction.RecordingId, stopAction.StopTime));
        }

        [TestMethod]
        public void ARecordingCanBeCreated_AndDeleted()
        {
            var startAction = new StartRecordingAction
            {
                RecordingId = 1,
                ChannelId = 32,
                StartTime = DateTime.Now,
                StopTime = DateTime.Now.AddHours(1)
            };
            var deleteAction = new DeleteRecordingAction
            {
                RecordingId = 1
            };
            this.actionExecutor.ExecuteActions(new List<RecordingAction> { startAction, deleteAction });

            this.platformMock.Verify(p => p.StartRecording(
                startAction.RecordingId,
                startAction.ChannelId,
                startAction.StartTime,
                startAction.StopTime));
            this.platformMock.Verify(p => p.DeleteRecording(deleteAction.RecordingId));
        }
    }
}
