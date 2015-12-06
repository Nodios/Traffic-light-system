using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Semafori
{
    public interface ITrafficLightState
    {
        void Change(TrafficLight light);
        void ReportState();
    }
}
