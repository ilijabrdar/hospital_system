using bolnica.Repository;
using Model.Doctor;
using Model.PatientSecretary;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Repository
{
    public class PatientFileRepository : CSVRepository<PatientFile, long>, IPatientFileRepository
    {
        public IHospitalizationRepository _hospitalizationRepository;
        public IOperationRepository _operationRepository;
        public IExaminationPreviousRepository _examinationPreviousRepository;

        public PatientFileRepository(ICSVStream<PatientFile> stream, ISequencer<long> sequencer)
               : base(stream, sequencer)
        {
        }

        public IEnumerable<PatientFile> GetAllEager()
        {
            List<PatientFile> retVal = new List<PatientFile>();
            foreach(PatientFile patientFile in GetAll().ToList())
            {
                retVal.Add(GetEager(patientFile.GetId()));
            }
            return retVal;
        }

        public PatientFile GetEager(long id)
        {
            PatientFile patientFile = Get(id);
            List<Hospitalization> hospitalizatonCollection = new List<Hospitalization>();
            if (patientFile.Hospitalization != null)
            {
                foreach (Hospitalization hospitalization in patientFile.Hospitalization)
                {
                    hospitalizatonCollection.Add(_hospitalizationRepository.GetEager(hospitalization.GetId()));
                }
            }
            patientFile.Hospitalization = hospitalizatonCollection;
            List<Operation> operationCollection = new List<Operation>();
            if (patientFile.Operation != null)
            {
                foreach (Operation operation in patientFile.Operation)
                {
                    operationCollection.Add(_operationRepository.GetEager(operation.GetId()));
                }
            }
            patientFile.Operation = operationCollection;
            List<Examination> examinationCollection = new List<Examination>();
            if (patientFile.Examination != null)
            {
                foreach (Examination examination in patientFile.Examination)
                {
                    examinationCollection.Add(_examinationPreviousRepository.GetEager(examination.GetId()));
                }
            }
            patientFile.Examination = examinationCollection;
            return patientFile;
        }
    }
}