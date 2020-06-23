﻿using Model.PatientSecretary;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Repository
{
    public interface ITherapyRepository : IRepository<Therapy,long>, IEagerRepository<Therapy , long>
    {
    }
}
