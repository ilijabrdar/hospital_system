/***********************************************************************
 * Module:  TherapyService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.TherapyService
 ***********************************************************************/

using bolnica.Service;
using Model.PatientSecretary;
using System;

namespace Service
{
    public class TherapyService : ITherapyService
    {
        public Therapy CreateCurrentTherapy(PatientFile patientFile)
        {
            throw new NotImplementedException();
        }

        public Therapy CreateTherapy(Therapy therapy, Examination examination)
        {
            throw new NotImplementedException();
        }
    }
}