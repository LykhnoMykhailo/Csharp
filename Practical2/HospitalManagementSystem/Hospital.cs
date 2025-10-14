using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem
{
    public class Hospital
    {
        public List<Doctor> Doctors;
        public List<Patient> Patients;
        public List<HospitalRoom> Rooms;
        public List<MedicalRecord> Records;

        public Hospital()
        {
            Doctors = new List<Doctor>();
            Patients = new List<Patient>();
            Rooms = new List<HospitalRoom>();
            Records = new List<MedicalRecord>();
        }

        public void AddDoctor(Doctor doctor)
        {
            Doctors.Add(doctor);
            Console.WriteLine($"Лікар {doctor.Name} ({doctor.Specialization}) доданий до системи");
        }

        public void RegisterPatient(Patient patient)
        {
            Patients.Add(patient);
            Console.WriteLine($"Пацієнт {patient.Name}, {patient.Age} років, зареєстрований");
        }

        public void CreateRoom(HospitalRoom room)
        {
            Rooms.Add(room);
            Console.WriteLine($"Палата №{room.RoomNumber} створена (місткість: {room.Capacity})");
        }

        public void HospitalizePatient(int patientId, int roomNumber)
        {
            int room_check = 0;
            int patient_check = 0;
                foreach (var patient in Patients)
                {
                if (patient.Id == patientId)
                {
                    patient_check ++;
                        foreach (var room in Rooms)
                        {
                    
                            if (room.RoomNumber == roomNumber)
                            {
                            room_check++ ;
                            room.AddPatient(patient);
                            return;
                        }

                    }
                }
            }

            if (patient_check == 0) 
                {
                    Console.WriteLine($"Пацієнт з ID {patientId} не знайдений!");
                    return;
                }
                if (room_check == 0)
                {
                    Console.WriteLine($"Палата №{roomNumber} не знайдена!");
                    return;
                }
           


        }

        public void AddMedicalRecord(MedicalRecord record)
        {
            Records.Add(record);
            Console.WriteLine($"Медичний запис створено: {record.Patient.Name} -> {record.Doctor.Name}");
        }

        public List<MedicalRecord> GetPatientHistory(int patientId)
        {
            var result = Records.FindAll(record => record.Patient.Id == patientId);
            return result;
        }

        public string GetStatistics()
        {
            int totalDoctors = Doctors.Count;
            int totalPatients = Patients.Count;
            int totalRooms = Rooms.Count;
            int totalPatientsInRooms = Rooms.Sum(record => record.Patients.Count);
            int totalRecords = Records.Count;

            return "=== СТАТИСТИКА ЛІКАРНІ ===\n" +
                $"Кількість лікарів: {Doctors.Count}\n" +
                $"Кількість зареєстрованих пацієнтів: {Patients.Count}\n" +
                $"Кількість палат: {Rooms.Count}\n" +
                $"Кількість пацієнтів у палатах: {totalPatientsInRooms}\n" +
                $"Кількість медичних записів: {Records.Count}";
        }
    }
}
