using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.PatientSecretary;
using bolnica.Controller;

namespace bolnica.Controller
{
    public interface ITherapyController : ISaveController<Therapy>, IGetterController<Therapy, long>
    {

    }
}
