/***********************************************************************
 * Module:  AnamnesisService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.AnamnesisService
 ***********************************************************************/

using bolnica.Controller;
using bolnica.Service;
using Model.PatientSecretary;
using System;

namespace Controller
{
   public class AnamnesisController : IAnamnesisController
   {
        private readonly IAnemnesisService _service;
        public Anemnesis createAnemnesis(Anemnesis anamnesis, Examination examination)
        {
            throw new NotImplementedException();
        }

     

    }
}