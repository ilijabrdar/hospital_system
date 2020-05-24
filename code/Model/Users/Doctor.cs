/***********************************************************************
 * Module:  Doctor.cs
 * Author:  Zorana
 * Purpose: Definition of the Class Users.Doctor
 ***********************************************************************/

using Model.Doctor;
using System;

namespace Model.Users
{
   public class Doctor : User
   {
      public System.Collections.ArrayList article; 
      private System.Collections.ArrayList businessDay;
        public override long GetId()
        {
            throw new NotImplementedException();
        }

        public override void SetId(long id)
        {
            throw new NotImplementedException();
        }

        private Specialty specialty;
      private DoctorGrade doctorGrade;
   
   }
}