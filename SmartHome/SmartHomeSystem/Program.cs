using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using SmartHomeSystem;


public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        SmartHomeController controller = new SmartHomeController();


        Light light = new Light { Name = "Лампа у вітальні" };
        AirConditioner ac = new AirConditioner { Name = "Кондиціонер у спальні" };
        CoffeeMachine coffeeMachine = new CoffeeMachine { Name = "Кавомашина на кухні" };
        MotionSensor sensor = new MotionSensor { Name = "Датчик руху у коридорі" };

        controller.AddDevice(light);
        controller.AddDevice(ac);
        controller.AddDevice(coffeeMachine);
        controller.AddDevice(sensor);
        controller.AddEnergyDevice(light);
        controller.AddEnergyDevice(ac);
        controller.AddEnergyDevice(coffeeMachine);


        controller.TurnAllOn();
        Console.WriteLine();


        light.PrintStatus();
        ac.PrintStatus();
        coffeeMachine.PrintStatus();
        sensor.PrintStatus();


        controller.ShowEnergyReport(5);


        controller.TurnAllOff();
    }
}