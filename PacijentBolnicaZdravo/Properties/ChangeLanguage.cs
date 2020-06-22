using PacijentBolnicaZdravo.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace PacijentBolnicaZdravo.Properties
{


    public  class ChangeLanguage
    {
        

        public  void ChangeMainWindow(MainWindow currentWindow)
        {

            Console.WriteLine("Ovdesam");
            Console.WriteLine(currentWindow);
            currentWindow.SurgeriesHardCore.Text = MyProject.Language.Resources.SurgeryHardCore;
            currentWindow.Note.Text = MyProject.Language.Resources.NoteForExamination;
            currentWindow.Pitanje1.Text = MyProject.Language.Resources.Question1;
            currentWindow.Pitanje2.Text = MyProject.Language.Resources.Question2;
            currentWindow.Pitanje3.Text = MyProject.Language.Resources.Question3;
            currentWindow.Pitanje4.Text = MyProject.Language.Resources.Question4;
            currentWindow.Pitanje5.Text = MyProject.Language.Resources.Question5;
                currentWindow.DarkModeLabel.Text = MyProject.Language.Resources.DarkMode;
                currentWindow.LogOutButton.Content = MyProject.Language.Resources.LogOut;
                currentWindow.Articles.Header = MyProject.Language.Resources.TabArticles;
                currentWindow.TabExamination.Header = MyProject.Language.Resources.TabExemination;
                currentWindow.ChooseDoctor.Text = MyProject.Language.Resources.ChooseDoctor;
                currentWindow.ChooseDate.Text = MyProject.Language.Resources.ChooseDate;
                currentWindow.Schedule.Content = MyProject.Language.Resources.Schedule;
                currentWindow.TabCancel.Header = MyProject.Language.Resources.TabCancel;
                currentWindow.CancelCondition.Text = MyProject.Language.Resources.CancelCondition;
            currentWindow.ColumnDate.Header = MyProject.Language.Resources.Date;
            currentWindow.ColumnDoctor.Header = MyProject.Language.Resources.Doctor;
            currentWindow.ColumnOrdination.Header = MyProject.Language.Resources.Ordination;
            currentWindow.ColumnTime.Header = MyProject.Language.Resources.Time;
            currentWindow.ColumnDateForSchedule.Header = MyProject.Language.Resources.Date;
            currentWindow.ColumnDoctorForSchedule.Header = MyProject.Language.Resources.Doctor;
            currentWindow.ColumnOrdinationForSchedule.Header = MyProject.Language.Resources.Ordination;
            currentWindow.ColumnTimeForSchedule.Header = MyProject.Language.Resources.Time;
            currentWindow.Title = MyProject.Language.Resources.Title;
                currentWindow.Cancel.Content = MyProject.Language.Resources.Cancel;
                currentWindow.TabFile.Header = MyProject.Language.Resources.TabFile;
                currentWindow.CurrentTherapyLabel.Text = MyProject.Language.Resources.CurrentTherapy;
                currentWindow.TabAccount.Header = MyProject.Language.Resources.Tabaccount;
            currentWindow.TabChangeAccount.Header = MyProject.Language.Resources.TabChangeAccount;
                currentWindow.BasicInf.Text = MyProject.Language.Resources.BasicInf;
                currentWindow.NameLabel.Text = MyProject.Language.Resources.Name;
                currentWindow.SurnameLabel.Text = MyProject.Language.Resources.Surname;
                currentWindow.IDLabel.Text = MyProject.Language.Resources.ID;
                currentWindow.DateBirthLabel.Text = MyProject.Language.Resources.DateBirth;
                currentWindow.AdressLabel.Text = MyProject.Language.Resources.Adress;
                currentWindow.PhoneLabel.Text = MyProject.Language.Resources.NumberPhone;
            currentWindow.BasicInf2.Text = MyProject.Language.Resources.BasicInf;
            currentWindow.NameLabel2.Text = MyProject.Language.Resources.Name;
            currentWindow.SurnameLabel2.Text = MyProject.Language.Resources.Surname;
            currentWindow.IDLabel2.Text = MyProject.Language.Resources.ID;
            currentWindow.DateBirthLabel2.Text = MyProject.Language.Resources.DateBirth;
            currentWindow.AdressLabel2.Text = MyProject.Language.Resources.Adress;
            currentWindow.PhoneLabel2.Text = MyProject.Language.Resources.NumberPhone;
            currentWindow.UpdateData.Content = MyProject.Language.Resources.UpdateData;
            currentWindow.UsernameLabel2.Text = MyProject.Language.Resources.Username;
                currentWindow.ChoosePhotoButton.Content = MyProject.Language.Resources.Photo;
                currentWindow.PwLabel.Text = MyProject.Language.Resources.ChangePw;
                currentWindow.CurrentPw.Text = MyProject.Language.Resources.CurrentPw;
                currentWindow.NewPw.Text = MyProject.Language.Resources.NewPw;
                currentWindow.ConfirmPw.Text = MyProject.Language.Resources.ConfirmPw;
                currentWindow.UpdatePwButton.Content = MyProject.Language.Resources.UpdatePw;
                currentWindow.FeedbackHeader.Header = MyProject.Language.Resources.FeedBack;
                currentWindow.Opinion.Text = MyProject.Language.Resources.Opinion;
                currentWindow.OpinionName.Text = MyProject.Language.Resources.OpinionDesc;
                currentWindow.FeedBackButton.Content = MyProject.Language.Resources.Send;
                currentWindow.Examinations.Header = MyProject.Language.Resources.Examinations;
            currentWindow.Surgery.Header = MyProject.Language.Resources.Surgeries;
            currentWindow.Hospitalizations.Header = MyProject.Language.Resources.Hospitalizations;
            currentWindow.UsernameLabel.Text = MyProject.Language.Resources.Username;
            currentWindow.ExaminationHardCore.Text = MyProject.Language.Resources.ExaminationHardCore;
            currentWindow.Schedule.ToolTip = MyProject.Language.Resources.ToolTipSchedule;
            currentWindow.Cancel.ToolTip = MyProject.Language.Resources.ToolTipCancel;
            currentWindow.ToolTipSchedule.Content = MyProject.Language.Resources.ToolTipSearch;
            currentWindow.ToolTipCancel.Content = MyProject.Language.Resources.ToolTipCancel;

            currentWindow.GradeADoctor.Text = MyProject.Language.Resources.GradeADoctor;
            currentWindow.ChooseDoctorForGrade.Text = MyProject.Language.Resources.ChooseDoctor;
            currentWindow.GradeADoctorButton.Content = MyProject.Language.Resources.Send;
            currentWindow.ErrorSchedule.Text = MyProject.Language.Resources.ErrorSchedule;
            currentWindow.SuccessUpdateData.Text = MyProject.Language.Resources.SuccessUpdateData;
        }   

        public void ChangeLogInWindow(WindowLogIn currentWindow)
        {
            currentWindow.DarkModeLabel.Text = MyProject.Language.Resources.DarkMode;
            currentWindow.UsernameLabel.Text = MyProject.Language.Resources.Username;
            currentWindow.PasswordLabel.Text = MyProject.Language.Resources.Password;
            currentWindow.LogIn.Content = MyProject.Language.Resources.LogIn;
            currentWindow.QuestionReg.Text = MyProject.Language.Resources.LabelRegistration;
            currentWindow.RegisterButton.Content = MyProject.Language.Resources.Register;
            currentWindow.Title = MyProject.Language.Resources.TitleLogIn;

        }

        public void ChangeRegistrationWindow(Registration regWindow)
        {
            regWindow.Title = MyProject.Language.Resources.TitleRegistration;
            regWindow.BasicInf.Text = MyProject.Language.Resources.BasicInf;
            regWindow.NameLabel.Text = MyProject.Language.Resources.Name;
            regWindow.SurnameLabel.Text = MyProject.Language.Resources.Surname;
            regWindow.IDLabel.Text = MyProject.Language.Resources.ID;
            regWindow.DateBirthLabel.Text = MyProject.Language.Resources.DateBirth;
            regWindow.AdressLabel.Text = MyProject.Language.Resources.Adress;
            regWindow.PhoneLabel.Text = MyProject.Language.Resources.NumberPhone;
            regWindow.Register.Content = MyProject.Language.Resources.Register;
            regWindow.ChoosePhotoButton.Content = MyProject.Language.Resources.Photo;
            regWindow.NewPw.Text = MyProject.Language.Resources.NewPw;
            regWindow.ConfirmPw.Text = MyProject.Language.Resources.ConfirmPw;
            regWindow.CancelRegistration.Content = MyProject.Language.Resources.Cancel;

        }

    }
}



