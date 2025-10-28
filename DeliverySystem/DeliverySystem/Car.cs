using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverySystem
{
    public class Car : Vehicle
    {
        protected int doors;          // кількість дверей 
        protected double fuelLevel;   // рівень палива (л)

        public Car(string brand, int year, double mileage, int doors)
            : this(brand, year, mileage, doors, 180.0)
        { }


        protected Car(string brand, int year, double mileage, int doors, double maxSpeed)
            : base(brand, year, mileage, maxSpeed)
        {
            this.doors = doors;
            this.fuelLevel = 50; 
        }


        public override string GetInfo()
        {
            return $"Car: {brand} ({year}), Doors: {doors}, Fuel: {fuelLevel}L";
        }

        public override void Move(double distance)
        {

            base.Move(distance);

            fuelLevel -= distance * 0.1;


            if (fuelLevel < 0)
            {
                fuelLevel = 0;
            }
        }
        public void Refuel(double liters)
        {
            fuelLevel += liters;
            if (fuelLevel > 50)
            {
                fuelLevel = 50;
            }
        }

    }
}
