/***********************************************************************
 * Module:  Examination.cs
 * Author:  david
 * Purpose: Definition of the Class PatientSecretary.Examination
 ***********************************************************************/

using Repository;
using System;
using Model.Users;
using bolnica.Service;

namespace Model.PatientSecretary
{
   public class Examination : IIdentifiable<long>
   {
        public long Id;
        public Patient Patient;
        public Model.Users.Doctor Doctor;
        public Period Period;
        public Diagnosis Diagnosis;
        public Prescription Prescription;
        public Anemnesis Anemnesis;
        public Therapy Therapy;
        public Refferal Refferal;

        public Examination(long id, Patient patient, Users.Doctor doctor, Period period)
        {
            Id = id;
            Doctor = doctor;
            Patient = patient;
            Period = period;
        }
        public Examination(long id, Patient patient, Users.Doctor doctor, Period period, Diagnosis diagnosis, Prescription prescription, Anemnesis anemnesis, Therapy therapy, Refferal refferal)
        {
            Id = id;
            Doctor = doctor;
            Patient = patient;
            Period = period;
            Diagnosis = diagnosis;
            Prescription = prescription;
            Anemnesis = anemnesis;
            Therapy = therapy;
            Refferal = refferal;
        }

        public Examination(long id)
        {
            Id = id;
        }

        public long GetId()
        {
            throw new NotImplementedException();
        }

        public void SetId(long id)
        {
            throw new NotImplementedException();
        }






        ///// <pdGenerated>default getter</pdGenerated>
        //public System.Collections.ArrayList GetPrescription()
        //{
        //   if (prescription == null)
        //      prescription = new System.Collections.ArrayList();
        //   return prescription;
        //}

        ///// <pdGenerated>default setter</pdGenerated>
        //public void SetPrescription(System.Collections.ArrayList newPrescription)
        //{
        //   RemoveAllPrescription();
        //   foreach (Prescription oPrescription in newPrescription)
        //      AddPrescription(oPrescription);
        //}

        ///// <pdGenerated>default Add</pdGenerated>
        //public void AddPrescription(Prescription newPrescription)
        //{
        //   if (newPrescription == null)
        //      return;
        //   if (this.prescription == null)
        //      this.prescription = new System.Collections.ArrayList();
        //   if (!this.prescription.Contains(newPrescription))
        //      this.prescription.Add(newPrescription);
        //}

        ///// <pdGenerated>default Remove</pdGenerated>
        //public void RemovePrescription(Prescription oldPrescription)
        //{
        //   if (oldPrescription == null)
        //      return;
        //   if (this.prescription != null)
        //      if (this.prescription.Contains(oldPrescription))
        //         this.prescription.Remove(oldPrescription);
        //}

        ///// <pdGenerated>default removeAll</pdGenerated>
        //public void RemoveAllPrescription()
        //{
        //   if (prescription != null)
        //      prescription.Clear();
        //}
        //private System.Collections.ArrayList referral;

        ///// <pdGenerated>default getter</pdGenerated>
        //public System.Collections.ArrayList GetReferral()
        //{
        //   if (referral == null)
        //      referral = new System.Collections.ArrayList();
        //   return referral;
        //}

        ///// <pdGenerated>default setter</pdGenerated>
        //public void SetReferral(System.Collections.ArrayList newReferral)
        //{
        //   RemoveAllReferral();
        //   foreach (Model.Doctor.Referral oReferral in newReferral)
        //      AddReferral(oReferral);
        //}

        ///// <pdGenerated>default Add</pdGenerated>
        //public void AddReferral(Model.Doctor.Referral newReferral)
        //{
        //   if (newReferral == null)
        //      return;
        //   if (this.referral == null)
        //      this.referral = new System.Collections.ArrayList();
        //   if (!this.referral.Contains(newReferral))
        //      this.referral.Add(newReferral);
        //}

        ///// <pdGenerated>default Remove</pdGenerated>
        //public void RemoveReferral(Model.Doctor.Referral oldReferral)
        //{
        //   if (oldReferral == null)
        //      return;
        //   if (this.referral != null)
        //      if (this.referral.Contains(oldReferral))
        //         this.referral.Remove(oldReferral);
        //}

        ///// <pdGenerated>default removeAll</pdGenerated>
        //public void RemoveAllReferral()
        //{
        //   if (referral != null)
        //      referral.Clear();
        //}



    }
}