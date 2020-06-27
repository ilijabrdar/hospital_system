using Model.Director;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Controller.decorators
{
    public class AuthorityRoomDecorator : IRoomController
    {
        private IRoomController RoomController;
        private String Role;
        private Dictionary<String, List<String>> AuthorizedUsers;

        public AuthorityRoomDecorator(IRoomController roomController, String role)
        {
            this.RoomController = roomController;
            this.Role = role;
            AuthorizedUsers = new Dictionary<string, List<string>>();
            AuthorizedUsers["AddEquipment"] = new List<string>() { "Director" };
            AuthorizedUsers["CheckHospitalizationDurationInRoom"] = new List<string>() { "Director", "Doctor" };
            AuthorizedUsers["CheckRoomCodeUnique"] = new List<string>() { "Director" };
            AuthorizedUsers["Delete"] = new List<string>() { "Director" };
            AuthorizedUsers["Edit"] = new List<string>() { "Director" };
            AuthorizedUsers["GetRoomsContainingEquipment"] = new List<string>() { "Director" };
            AuthorizedUsers["GetRoomsForHospitalization"] = new List<string>() { "Doctor" };
            AuthorizedUsers["Save"] = new List<string>() { "Director" };
            AuthorizedUsers["Get"] = new List<string>() { "Director", "Doctor", "Secretary" };
            AuthorizedUsers["GetAll"] = new List<string>() { "Director", "Doctor", "Secretary" };

        }

        public void CheckHospitalizationDurationInRoom()
        {
            if (AuthorizedUsers["CheckHospitalizationDurationInRoom"].SingleOrDefault(any => any.Equals(Role)) != null)
                RoomController.CheckHospitalizationDurationInRoom();
        }

        public bool CheckRoomCodeUnique(string name)
        {
            if (AuthorizedUsers["CheckRoomCodeUnique"].SingleOrDefault(any => any.Equals(Role)) != null)
                return RoomController.CheckRoomCodeUnique(name);
            return false;
        }

        public void Delete(Room entity)
        {
            if (AuthorizedUsers["Delete"].SingleOrDefault(any => any.Equals(Role)) != null)
                RoomController.Delete(entity);
        }

        public void Edit(Room entity)
        {
            if (AuthorizedUsers["Edit"].SingleOrDefault(any => any.Equals(Role)) != null)
                RoomController.Edit(entity);
        }

        public Room Get(long id)
        {
            if (AuthorizedUsers["Get"].SingleOrDefault(any => any.Equals(Role)) != null)
                return RoomController.Get(id);
            return null;
        }

        public IEnumerable<Room> GetAll()
        {
            if (AuthorizedUsers["GetAll"].SingleOrDefault(any => any.Equals(Role)) != null)
                return RoomController.GetAll();
            return null;
        }

        public IEnumerable<Room> GetRoomsContainingEquipment(Equipment equipment)
        {
            if (AuthorizedUsers["GetRoomsContainingEquipment"].SingleOrDefault(any => any.Equals(Role)) != null)
                return RoomController.GetRoomsContainingEquipment(equipment);
            return null;
        }

        public List<Room> GetRoomsForHospitalization()
        {
            if (AuthorizedUsers["GetRoomsForHospitalization"].SingleOrDefault(any => any.Equals(Role)) != null)
                return RoomController.GetRoomsForHospitalization();
            return null;
        }

        public Room Save(Room entity)
        {
            if (AuthorizedUsers["Save"].SingleOrDefault(any => any.Equals(Role)) != null)
                return RoomController.Save(entity);
            return null;
        }
    }
}
