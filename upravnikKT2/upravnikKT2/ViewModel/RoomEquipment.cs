using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace upravnikKT2.ViewModel
{
    public class RoomEquipment
    {
        public string RoomCode { get; set; }

        public string EquipmentName { get; set; }

        public int Equipment_Amount { get; set; }

        public long Id { get; set; }

        public RoomEquipment(long id, string roomCode, int equipment_Amount, string EquipmentName)
        {
            RoomCode = roomCode;
            Equipment_Amount = equipment_Amount;
            Id = id;
            this.EquipmentName = EquipmentName;
        }

        public RoomEquipment(string equipmentName, int equipment_Amount)
        {
            EquipmentName = equipmentName;
            Equipment_Amount = equipment_Amount;
        }
    }
}
