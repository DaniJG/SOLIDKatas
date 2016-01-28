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
        public void ExecuteActions_CanExecuteSingleAction()
        {
            var action = new StartRecordingAction { 
                RecordingId = 1, 
                ChannelId = 32, 
                StartTime = DateTime.Now, 
                StopTime = DateTime.Now.AddHours(1)
            };
            this.actionExecutor.ExecuteActions(new List<RecordingAction> { action });

            this.platformMock.Verify(p => p.StartRecording(
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<DateTime>(),
                It.IsAny<DateTime>()));
        }

        [TestMethod]
        public void ExecuteActions_CanExecuteMultipleActions()
        {
            var startAction = new StartRecordingAction
            {
                RecordingId = 1,
                ChannelId = 32,
                StartTime = DateTime.Now,
                StopTime = DateTime.Now.AddHours(1)
            };
            var stopAction = new StopRecordingAction
            {
                RecordingId = 3,
                StopTime = DateTime.Now
            };
            var deleteAction = new DeleteRecordingAction
            {
                RecordingId = 34
            };
            this.actionExecutor.ExecuteActions(new List<RecordingAction> { startAction, stopAction, deleteAction });

            this.platformMock.Verify(p => p.StartRecording(
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<DateTime>(),
                It.IsAny<DateTime>()));
            this.platformMock.Verify(p => p.StopRecording(It.IsAny<int>(), It.IsAny<DateTime>()));
            this.platformMock.Verify(p => p.DeleteRecording(It.IsAny<int>()));
        }
    }
}
