// 代码生成时间: 2025-10-02 03:43:24
 * Error handling and documentation are also included for clarity and maintainability.
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace MedicalEquipmentApp
{
    // Define a class to represent a medical equipment item.
    public class MedicalEquipment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public DateTime ManufactureDate { get; set; }

        public MedicalEquipment(int id, string name, string model, string serialNumber, DateTime manufactureDate)
        {
            Id = id;
            Name = name;
            Model = model;
            SerialNumber = serialNumber;
            ManufactureDate = manufactureDate;
        }
    }

    // Define the MedicalEquipmentManager class to manage medical equipment items.
    public class MedicalEquipmentManager
    {
        private List<MedicalEquipment> equipmentList;

        public MedicalEquipmentManager()
        {
            equipmentList = new List<MedicalEquipment>();
        }

        // Add a new medical equipment to the list.
        public void AddEquipment(MedicalEquipment equipment)
        {
            if (equipment == null)
            {
                throw new ArgumentNullException(nameof(equipment), "Equipment cannot be null.");
            }

            equipmentList.Add(equipment);
        }

        // Remove a medical equipment from the list by its ID.
        public bool RemoveEquipment(int equipmentId)
        {
            var equipmentToRemove = equipmentList.FirstOrDefault(e => e.Id == equipmentId);
            if (equipmentToRemove == null)
            {
                return false; // Equipment not found.
            }
            else
            {
                equipmentList.Remove(equipmentToRemove);
                return true;
            }
        }

        // Get all medical equipment in the list.
        public List<MedicalEquipment> GetAllEquipment()
        {
            return equipmentList;
        }
    }

    // Main class with Program entry point.
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                // Initialize the medical equipment manager.
                var manager = new MedicalEquipmentManager();

                // Add some equipment to manage.
                var equipment1 = new MedicalEquipment(1, "Defibrillator", "ACME DF-100", "SN12345", DateTime.Now);
                manager.AddEquipment(equipment1);

                // Attempt to remove an equipment that does not exist.
                if (!manager.RemoveEquipment(999))
                {
                    Console.WriteLine("Attempted to remove non-existing equipment.");
                }

                // List all equipment.
                var equipment = manager.GetAllEquipment();
                foreach (var item in equipment)
                {
                    Console.WriteLine($"ID: {item.Id}, Name: {item.Name}, Model: {item.Model}, Serial: {item.SerialNumber}, Manufacture Date: {item.ManufactureDate}");
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the execution.
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}