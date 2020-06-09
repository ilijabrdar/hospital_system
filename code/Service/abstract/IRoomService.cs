using Model.Director;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Service
{
    public interface IRoomService : IService<Room, long>
    {

        Boolean AddEquipment(Equipment equipment, Room room);

        Boolean CheckRoomNameUnique(Room room);
        List<Room> GetVacantRooms();
        IEnumerable<Room> GetRoomsCointainingEquipment(Equipment equipment);

    }
}
