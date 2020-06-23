using bolnica.Controller;
using bolnica.Service;
using Model.Doctor;
using Model.Users;
using System;
using System.Collections.Generic;

namespace Controller
{
    public class OperationController : IOperationController
    {
        private readonly IOperationService _operationService;

        public OperationController(IOperationService service)
        {
            _operationService = service;
        }

        public void Delete(Operation entity)
        {
            _operationService.Delete(entity);
        }

        public void Edit(Operation entity)
        {
            _operationService.Edit(entity);
        }

        public Operation Get(long id)
        {
            return _operationService.Get(id);
        }

        public IEnumerable<Operation> GetAll()
        {
            return _operationService.GetAll();
        }

        public List<Operation> GetOperationsByDoctor(Doctor doctor)
        {
            return _operationService.GetOperationsByDoctor(doctor);
        }

        public Operation Save(Operation entity)
        {
            return _operationService.Save(entity);
        }

    }
}