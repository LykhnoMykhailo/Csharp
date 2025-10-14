using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem
{
    public class HospitalDemo
    {
        public void Run()
        {
            Console.WriteLine("=== СИСТЕМА УПРАВЛІННЯ ЛІКАРНЕЮ ===");

            Hospital hospital = new Hospital();
            // Додавання лікарів
            hospital.AddDoctor(new Doctor(1, "Олена Ковальчук", "Кардіолог"));
            hospital.AddDoctor(new Doctor(2, "Андрій Лохинович", "Хірург-ортопед"));
            hospital.AddDoctor(new Doctor(3, "Ірина Петренко", "Педіатр"));
            // Реєстрація пацієнтів
            hospital.RegisterPatient(new Patient(1, "Василь Кравченко", 65));
            hospital.RegisterPatient(new Patient(2, "Світлана Мороз", 34));
            hospital.RegisterPatient(new Patient(3, "Дем'ян Многогрішний", 4));
            // Створення палат
            hospital.CreateRoom(new HospitalRoom(101, 2));
            hospital.CreateRoom(new HospitalRoom(102, 1));
            // Госпіталізація
            hospital.HospitalizePatient(1, 101);
            hospital.HospitalizePatient(2, 101);
            hospital.HospitalizePatient(3, 102);
            // Медичні записи
            hospital.AddMedicalRecord(new MedicalRecord(hospital.Patients[0], hospital.Doctors[0], DateTime.Now, "ГРВІ"));
            hospital.AddMedicalRecord(new MedicalRecord(hospital.Patients[1], hospital.Doctors[1], DateTime.Now, "Апендектомія"));


            Console.WriteLine("\n--- ІСТОРІЯ ПАЦІЄНТА ---");
            var history = hospital.GetPatientHistory(2);
            foreach (var record in history)
            {
                Console.WriteLine($"  Дата: {record.Date.ToShortDateString()}");
                Console.WriteLine($"  Лікар: {record.Doctor.Name}");
                Console.WriteLine($"  Опис: {record.Description}");
            }

            Console.WriteLine(hospital.GetStatistics());
        }
    }
}
