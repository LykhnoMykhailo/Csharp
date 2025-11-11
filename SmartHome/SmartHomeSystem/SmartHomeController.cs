using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSystem
{
    public class SmartHomeController
    {
        private readonly List<ISwitchable> _allDevices = new List<ISwitchable>();
        private readonly List<IEnergyConsumer> _energyDevices = new List<IEnergyConsumer>();

        public void AddDevice(ISwitchable device)
        {
            _allDevices.Add(device);
        }

        public void AddEnergyDevice(IEnergyConsumer device)
        {
            if (!_energyDevices.Contains(device))
            {
                _energyDevices.Add(device);
            }
        }

        public void TurnAllOn()
        {
            foreach (var device in _allDevices)
            {
                device.TurnOn();
            }
        }

        public void TurnAllOff()
        {
            foreach (var device in _allDevices)
            {
                device.TurnOff();
            }
        }

        public void ShowEnergyReport(int hours)
        {
            Console.WriteLine($"\nЗвіт про споживання енергії за {hours} год:");

            double totalConsumption = 0;

            foreach (var device in _energyDevices)
            {
                double usage = device.GetEnergyUsage(hours);
                totalConsumption += usage;

                Console.WriteLine($"{device.DeviceName}: {usage:F2} кВт·год (потужність: {device.PowerConsumption} Вт)");
            }

            double cost = totalConsumption * 4.0;

            Console.WriteLine($"Загальне споживання: {totalConsumption:F2} кВт·год");
            Console.WriteLine($"Вартість (~4 грн/кВт·год): {cost:F2} грн");
        }

        public void PrintAllStatus()
        {
            Console.WriteLine();
            foreach (var switchableDevice in _allDevices)
            {
                if (switchableDevice is Device device)
                {
                    device.PrintStatus();
                }
            }
        }
    }
}
