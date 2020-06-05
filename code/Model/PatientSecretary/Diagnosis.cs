/***********************************************************************
 * Module:  Dijagnoza.cs
 * Author:  Tamara Kovacevic
 * Purpose: Definition of the Class Pacijent.Dijagnoza
 ***********************************************************************/

using Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Documents;

namespace Model.PatientSecretary
{
   public class Diagnosis : IIdentifiable<long>
   {
        public long Id;
        public string code;
        private List<Symptom> symptom;

        public Diagnosis(long id)
        {
            Id = id;
        }

        public Diagnosis(long id, string code, List<Symptom> symptom)
        {
            Id = id;
            this.code = code;
            this.symptom = symptom;
        }

        public long GetId()
        {
            throw new NotImplementedException();
        }

        public void SetId(long id)
        {
            throw new NotImplementedException();
        }



    }
}