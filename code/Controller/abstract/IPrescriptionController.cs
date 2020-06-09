using Controller;
using Model.PatientSecretary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Controller
{
    public interface IPrescriptionController : IController<Prescription,long>
    {
    }
}
