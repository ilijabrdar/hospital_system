/***********************************************************************
 * Module:  ExaminationService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.ExaminationService
 ***********************************************************************/

using System;

namespace Service
{
   public class ExaminationService : IService
   {
      public Examination StartScheduledExamination(Examination examination)
      {
         // TODO: implement
         return null;
      }
      
      public Examination FinishExamination(Examination examination)
      {
         // TODO: implement
         return null;
      }
      
      public Examination[] GetScheduledUserExaminations(User user)
      {
         // TODO: implement
         return null;
      }
      
      public Examination[] GetExaminationsByUser(User user)
      {
         // TODO: implement
         return null;
      }
   
      private PrescriptionService prescriptionService;
      private TherapyService therapyService;
      private AnamnesisService anamnesisService;
      private ReferralService referralService;
      private DiagnosisService diagnosisService;
      private Repository.IExaminationUpcomingRepository _upcomingRepository;
      private Repository.IExaminationPreviousRepository _previousRepository;
   
   }
}