using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleManagrment.ViewModel
{
    public class AddRecordViewModel
    {
        public string Vehicle_Name { get; set; }
        public int CategoryId { get; set; }
        public string Vehicle_Complaint { get; set; }
        public DateTime CreatedDate { get; set; }
        public double Repair_Cost { get; set; }
    }
}
