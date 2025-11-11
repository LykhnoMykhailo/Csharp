using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSystem
{
    public class CoffeeMachine : Device, IEnergyConsumer
    {
        public string DeviceName
        {
            get { return Name; }
        }

        public int PowerConsumption
        {
            get { return 1000; }
        }

        public override void TurnOn()
        {
            if (!IsOn)
            {
                IsOn = true;
                Console.WriteLine($"{Name} почала готувати каву.");
            }
        }

        public override void TurnOff()
        {
            if (IsOn)
            {
                IsOn = false;
                Console.WriteLine($"{Name} завершила роботу.");
            }
        }

        public double GetEnergyUsage(int hours)
        {
            if (!IsOn) return 0;
            return (double)PowerConsumption * hours / 1000.0;
        }
    }
}
