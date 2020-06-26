using Model.Director;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Controller.decorators
{
    public class AuthorityRoomTypeDecorator : IRoomTypeController
    {
        private IRoomTypeController RoomTypeController;
        private String Role;
        private Dictionary<String, List<String>> AuthorizedUsers;

        public AuthorityRoomTypeDecorator(IRoomTypeController roomTypeController, String role)
        {
            this.RoomTypeController = roomTypeController;
            this.Role = role;
            AuthorizedUsers = new Dictionary<string, List<string>>();
            AuthorizedUsers["CheckRoomTypeUnique"] = new List<string>() { "Director"};
            AuthorizedUsers["Delete"] = new List<string>() { "Director"};
            AuthorizedUsers["Edit"] = new List<string>() { "Director"};
            AuthorizedUsers["Get"] = new List<string>() { "Director"};
            AuthorizedUsers["GetAll"] = new List<string>() { "Director"};
            AuthorizedUsers["Save"] = new List<string>() { "Director"};
        }

        public bool CheckRoomTypeUnique(string type)
        {
            if (AuthorizedUsers["CheckRoomTypeUnique"].SingleOrDefault(any => any.Equals(Role)) != null)
                return RoomTypeController.CheckRoomTypeUnique(type);
            return false;
        }

        public void Delete(RoomType entity)
        {
            if (AuthorizedUsers["Delete"].SingleOrDefault(any => any.Equals(Role)) != null)
                RoomTypeController.Delete(entity);
        }

        public void Edit(RoomType entity)
        {
            if (AuthorizedUsers["Edit"].SingleOrDefault(any => any.Equals(Role)) != null)
                RoomTypeController.Edit(entity);
        }

        public RoomType Get(long id)
        {
            if (AuthorizedUsers["Get"].SingleOrDefault(any => any.Equals(Role)) != null)
                return RoomTypeController.Get(id);
            return null;
        }

        public IEnumerable<RoomType> GetAll()
        {
            if (AuthorizedUsers["GetAll"].SingleOrDefault(any => any.Equals(Role)) != null)
                return RoomTypeController.GetAll();
            return null;
        }

        public RoomType Save(RoomType entity)
        {
            if (AuthorizedUsers["Save"].SingleOrDefault(any => any.Equals(Role)) != null)
                return RoomTypeController.Save(entity);
            return null;
        }
    }
}
