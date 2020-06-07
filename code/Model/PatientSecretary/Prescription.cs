using Repository;
using System;
using System.Collections.Generic;
using System.Windows.Documents;

namespace Model.PatientSecretary
{
   public class Prescription: IIdentifiable<long>
   {
      public long Id;
      public DateTime DateOfIssue;
      public DateTime ExpirationDate;
      public String Note;
      public List<Drug> Drug;
        public Prescription(long id, DateTime dateOfIssue, DateTime expirationDate, string note)
        {
            DateOfIssue = dateOfIssue;
            ExpirationDate = expirationDate;
            Note = note;
        }

        public Prescription(long id, DateTime dateOfIssue, DateTime expirationDate, string note, List<Drug> alternative)
        {
            DateOfIssue = dateOfIssue;
            ExpirationDate = expirationDate;
            Note = note;
            Id = id;
            this.Drug = alternative;
        }

        public Prescription(DateTime dateOfIssue, DateTime expirationDate, string note, List<Drug> drug)
        {
            DateOfIssue = dateOfIssue;
            ExpirationDate = expirationDate;
            Note = note;
            Drug = drug;
        }

        public Prescription(long id)
        {
            Id = id;
        }

        public long GetId()
        {
            return this.Id;
        }

        public void SetId(long id)
        {
            this.Id = id;
        }
    }
}