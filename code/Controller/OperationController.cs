/***********************************************************************
 * Module:  OperationService.cs
 * Author:  david
 * Purpose: Definition of the Class Service.OperationService
 ***********************************************************************/

using bolnica.Controller;
using bolnica.Service;
using Model.Doctor;
using System;

namespace Controller
{
    public class OperationController : IOperationController
    {
        private IOperationService _service;

        public OperationController(IOperationService service)
        {
            _service = service;
        }

        public Operation CreateOperation(Operation operation)
        {
            throw new NotImplementedException();
        }

        public bool DeleteOperation(Operation operation)
        {
            throw new NotImplementedException();
        }
    }
}