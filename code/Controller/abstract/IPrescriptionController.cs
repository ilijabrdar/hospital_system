using Model.PatientSecretary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Controller
{
    public interface IPrescriptionController
    {
        Prescription CreatePrescription(Prescription prescription, Examination examination);
    }
}
