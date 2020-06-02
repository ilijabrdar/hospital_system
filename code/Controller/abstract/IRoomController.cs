using Controller;
using Model.Director;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Controller
{
    public interface IRoomController : IController<Room, long>
    {
        IEnumerable<Room> GetVacantRooms();
        Boolean AddEquipment(Equipment equipment, Room room);

        Boolean ChangeRoomType(Room room, RoomType roomType);
    }
}
