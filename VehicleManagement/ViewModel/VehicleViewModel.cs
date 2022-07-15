using System;

namespace VehicleManagrment.ViewModel
{
    public class VehicleViewModel
    {
        public int Id { get; set; }
        public string Vehicle_Name { get; set; }
        public string Vehicle_Category { get; set; }
        public string Vehicle_Complaint { get; set; }
        public DateTime CreatedDate { get; set; }
        public double Repair_Cost { get; set; }
    }
}
