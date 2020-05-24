using Model.PatientSecretary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Service
{
    public interface IPrescriptionService 
    {
        Prescription CreatePrescription(Prescription prescription, Examination examination);
    }
}
