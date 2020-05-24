/***********************************************************************
 * Module:  PatientFileService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.PatientFileService
 ***********************************************************************/

using bolnica.Repository;
using Model.PatientSecretary;
using System;

namespace Repository
{
    public class PatientFileRepository : CSVRepository<PatientFile, long>, IPatientFileRepository
    {
        private String FilePath;


        public PatientFileRepository(ICSVStream<PatientFile> stream, ISequencer<long> sequencer)
               : base(stream, sequencer)
        {

        }
    }
}