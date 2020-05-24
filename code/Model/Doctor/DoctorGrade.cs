/***********************************************************************
 * Module:  DoctorGrade.cs
 * Author:  Asus
 * Purpose: Definition of the Class Doctor.DoctorGrade
 ***********************************************************************/

using Repository;
using System;

namespace Model.Doctor
{
   public class DoctorGrade : IIdentifiable<long>
    {
      private String Review;
      private int TotalGraded;
        public long Id;

        public DoctorGrade(long id)
        {
            this.Id = id;
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