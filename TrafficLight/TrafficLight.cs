using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semafori
{
    public class TrafficLight
    {
        public ITrafficLightState State { get; set; }

        public void Change()
        {
            State.Change(this);
        }
        public void ReportState()
        {
            State.ReportState();
        }
    }

    public class Red : ITrafficLightState
    {

        public void Change(TrafficLight light)
        {
            light.State = new Green();
        }

        public void ReportState()
        {
            Console.WriteLine("Red Light");

        }
    }
    public class Yellow : ITrafficLightState
    {

        public void Change(TrafficLight light)
        {
            light.State = new Red();
        }

        public void ReportState()
        {
            Console.WriteLine("Yellow Light");

        }
    }

    public class Green : ITrafficLightState
    {

        public void Change(TrafficLight light)
        {
            light.State = new Yellow();
        }

        public void ReportState()
        {
            Console.WriteLine("Green Light");

        }
    }
}
