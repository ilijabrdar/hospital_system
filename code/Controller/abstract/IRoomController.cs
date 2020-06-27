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

        Boolean CheckRoomCodeUnique(String name);

        IEnumerable<Room> GetRoomsContainingEquipment(Equipment equipment);

        List<Room> GetRoomsForHospitalization();
        void CheckHospitalizationDurationInRoom();

    }
}
