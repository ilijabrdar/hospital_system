using Model.PatientSecretary;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public interface ISymptomRepository : IRepository<Symptom, long>
    {
    }
}
