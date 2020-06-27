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


        IEnumerable<Room> GetRoomsCointainingEquipment(Equipment equipment);

        void DeleteRoomsByRoomType(RoomType roomType);

        void DeleteEquipmentFromRooms(Equipment equipment);

        bool CheckRoomCodeUnique(String roomCode);

        List<Room> GetRoomsForHospitalization();

        void CheckHospitalizationDurationInRoom();

    }
}
