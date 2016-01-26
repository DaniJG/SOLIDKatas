﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.Katas.OCP
{
    public class PlatformAPI
    {
        public void StartRecording(int id, int channeId, DateTime startTime, DateTime stopTime)
        {
            Console.WriteLine("Start Recording - {0} - {1} - {2} - {3}", id, channeId, startTime, stopTime);
        }

        public void StopRecording(int id, DateTime stopTime)
        {
            Console.WriteLine("Stop Recording - {0} - {1}", id, stopTime);
        }

        public void DeleteRecording(int id)
        {
            Console.WriteLine("Delete Recording - {0}", id);
        }
    }
}
