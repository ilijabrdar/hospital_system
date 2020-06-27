using Model.Director;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Controller.decorators
{
    public class AuthorityEquipmentDecorator : IEquipmentController
    {
        private IEquipmentController EquipmentController;
        private String Role;
        private Dictionary<String, List<String>> AuthorizedUsers;

        public AuthorityEquipmentDecorator(IEquipmentController equipmentController, String role)
        {
            this.EquipmentController = equipmentController;
            this.Role = role;
            AuthorizedUsers = new Dictionary<string, List<string>>();
            AuthorizedUsers["CheckEquipmentNameUnique"] = new List<string>() {"Director"};
            AuthorizedUsers["Delete"] = new List<string>() {"Director"};
            AuthorizedUsers["Edit"] = new List<string>() {"Director"};
            AuthorizedUsers["Get"] = new List<string>() {"Director"};
            AuthorizedUsers["GetAll"] = new List<string>() {"Director"};
            AuthorizedUsers["getConsumableEquipment"] = new List<string>() {"Director"};
            AuthorizedUsers["getInconsumableEquipment"] = new List<string>() {"Director"};
            AuthorizedUsers["Save"] = new List<string>() {"Director"};

        }

        public bool CheckEquipmentNameUnique(string name)
        {
            if (AuthorizedUsers["CheckEquipmentNameUnique"].SingleOrDefault(any => any.Equals(Role)) != null)
                return EquipmentController.CheckEquipmentNameUnique(name);
            return false;
        }

        public void Delete(Equipment entity)
        {
            if (AuthorizedUsers["Delete"].SingleOrDefault(any => any.Equals(Role)) != null)
                EquipmentController.Delete(entity);
        }

        public void Edit(Equipment entity)
        {
            if (AuthorizedUsers["Edit"].SingleOrDefault(any => any.Equals(Role)) != null)
                EquipmentController.Edit(entity);
        }

        public Equipment Get(long id)
        {
            if (AuthorizedUsers["Get"].SingleOrDefault(any => any.Equals(Role)) != null)
                return EquipmentController.Get(id);
            return null;
        }

        public IEnumerable<Equipment> GetAll()
        {
            if (AuthorizedUsers["GetAll"].SingleOrDefault(any => any.Equals(Role)) != null)
                return EquipmentController.GetAll();
            return null;
        }

        public IEnumerable<Equipment> getConsumableEquipment()
        {
            if (AuthorizedUsers["getConsumableEquipment"].SingleOrDefault(any => any.Equals(Role)) != null)
                return EquipmentController.getConsumableEquipment();
            return null;
        }

        public IEnumerable<Equipment> getInconsumableEquipment()
        {
            if (AuthorizedUsers["getInconsumableEquipment"].SingleOrDefault(any => any.Equals(Role)) != null)
                return EquipmentController.getInconsumableEquipment();
            return null;
        }

        public Equipment Save(Equipment entity)
        {
            if (AuthorizedUsers["Save"].SingleOrDefault(any => any.Equals(Role)) != null)
                return EquipmentController.Save(entity);
            return null;
        }
    }
}
