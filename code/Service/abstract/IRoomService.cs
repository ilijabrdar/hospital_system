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
        Boolean ChangeRoomType(Room room, RoomType roomType);

        Boolean AddEquipment(Equipment equipment, Model.Director.Room room);

        Model.Director.Room[] GetVacantRooms();
        IEnumerable<Room> getRoomsCointainingEquipment(Equipment equipment);

    }
}
