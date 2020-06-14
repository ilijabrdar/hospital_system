using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using MyProject.Language;
using System.Globalization;
using System.Configuration;
using System.Reflection;
using PacijentBolnicaZdravo.Properties;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics;
using System.Windows.Markup;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Threading;
using MahApps.Metro.Controls;
using MahApps.Metro;
using Model.Dto;
using Model.Users;
using Model.PatientSecretary;
using Model.Director;
using ControlzEx.Standard;
using System.Windows.Threading;
using System.Windows.Media.Animation;
using System.Windows.Forms;
using Model.Doctor;
using System.Collections;

namespace PacijentBolnicaZdravo
{

    public partial class MainWindow : MetroWindow, INotifyPropertyChanged
    {

        public ChangeLanguage cl = new ChangeLanguage();
        public static CultureInfo culture = new CultureInfo("sr");
        public List<ExaminationDTO> scheduledExaminations { get; set; }
        public List<ExaminationDTO> upcomingExaminations { get; set; }
        public List<Doctor> listOfDoctors { get; set; }
        public List<Article> ListOfArticles { get; set; }
        public List<Examination> examinations { get; set; }
        public Patient _patient { get; set; }
        public static int Theme = 0;

        public MainWindow(Patient patient, List<Article> articles)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            _patient = patient;
            ListOfArticles = articles;
            
            scheduledExaminations = getScheduledExaminations();
            Doctor dr = new Doctor(1, "Pera", "Perić", "213123123123", "sadsds@sadsa.com", "2312312312", new DateTime(), null, "DDD", "ddd", null, null);
            Doctor dr1 = new Doctor(1, "Jovan", "Jovanović", "213123123123", "sadsds@sadsa.com", "2312312312", new DateTime(), null, "DDD", "ddd", null, null);
            listOfDoctors = new List<Doctor>();
            listOfDoctors.Add(dr);
            listOfDoctors.Add(dr1);
            upcomingExaminations = new List<ExaminationDTO>();
            examinations = uploadExaminations();

            InitializeComponent();
            setArticle();
            setExaminations();
            FillAccountData(_patient);

            PasswordValidation2.password2 = _patient.Password;
           
            DoctorsForFeedback.DisplayMemberPath = "FullName";
            DoctorsForExaminations.DisplayMemberPath = "FullName";
           
            this.DataContext = this;
            

            if (Thread.CurrentThread.CurrentCulture.Equals(new CultureInfo("sr")))
                Language.SelectedItem = Language.Items[0];
            else
                Language.SelectedItem = Language.Items[1];

            if (Theme == 1)
            {
                ThemeManager.ChangeAppStyle(this,
                                   ThemeManager.GetAccent("Teal"),
                                   ThemeManager.GetAppTheme("BaseDark"));
                DarkMode.Value = DarkMode.Maximum;
            }else
            {
                ThemeManager.ChangeAppStyle(this,
                                   ThemeManager.GetAccent("Blue"),
                                   ThemeManager.GetAppTheme("BaseLight"));
                DarkMode.Value = DarkMode.Minimum;
            }

        }

        public List<Examination> uploadExaminations()
        {
            List<Examination> retVal = new List<Examination>();
            Examination examination1 = new Examination(1);
            examination1.Doctor =  new Doctor(1, "Pera", "Perić", "213123123123", "sadsds@sadsa.com", "2312312312", new DateTime(), null, "DDD", "ddd", null, null);
            examination1.Period = new Period(new DateTime(2020, 06, 12,12,40,0));
            examination1.Therapy = new Therapy(0, null, 0, "Mazati tanak sloj kreme preko upaljenog dela.", null);
            List<Drug> drugs = new List<Drug>();
            Drug dr1 = new Drug("Klindamicin krema",0,true,null,null);
            drugs.Add(dr1);
            List<Prescription> pr = new List<Prescription>();
            pr.Add(new Prescription(new Period(new DateTime(2020, 06, 12), new DateTime(2020, 06, 17)), "Mazati tanak sloj kreme preko upaljenog dela!", drugs));
            examination1.Prescription = pr;
            examination1.Refferal = null;
            examination1.User = this._patient;
            examination1.Anemnesis = new Anemnesis("Svrab i crvenilo oko oka, često jaki bolovi i konstantne suze. Pacijent se takodje zali na bolove u glavi i kako kaže da mu sve dolazi od oka.");
            examination1.Diagnosis = new Diagnosis(0, "Konjuktavitis praćen teškom upalom.");
            Examination examination2 = new Examination(2);
            examination2.Doctor = new Doctor(1, "Pera", "Perić", "213123123123", "sadsds@sadsa.com", "2312312312", new DateTime(), null, "DDD", "ddd", null, null);
            examination2.Period = new Period(new DateTime(2020, 06, 15, 09, 20, 0));
            List<Drug> drugs1 = new List<Drug>();
            Drug dr2 = new Drug("Kardiopirin", 0, true, null, null);
            drugs1.Add(dr2);
            List<Prescription> pr1 = new List<Prescription>();
            pr1.Add(new Prescription(new Period(new DateTime(2020, 06, 12), new DateTime(2020, 06, 17)), "Mazati tanak sloj kreme preko upaljenog dela!", drugs1));
            examination2.Prescription = pr1;
            examination2.Refferal = new Referral(2,new Period(new DateTime(2020, 06, 25, 09, 40, 0)), new Doctor(1, "Đorđe", "Cvijić", "213123123123", "sadsds@sadsa.com", "2312312312", new DateTime(), null, "DDD", "ddd", null, null));
            examination2.User = this._patient;
            examination2.Anemnesis = new Anemnesis("Pacijent se žali na brzo zamaranje i ubrzan rad srca, tvrdi da mu je " +
                                                                            "teško da se " +
                                                      "puno kreće i da često mora da sedne da odmori. Takodje govori da " +
                                                        "često oseti preskakanja srca i da nakon toga ne može da se smiri.");
            examination2.Diagnosis = new Diagnosis(0, "Srčana aritmija");
            examination2.Therapy = new Therapy(0, null, 0, "Lek uzimati svaki drugi dan 3 puta dnevno", null);
            retVal.Add(examination1);
            retVal.Add(examination2);
            return retVal;
        }

        private void setExaminations()
        {
            foreach(var examination in examinations)
            {
                Border b = new Border();
                b.BorderThickness = new Thickness(2);
                b.CornerRadius = new CornerRadius(3);
                b.BorderBrush = Brushes.LightBlue;
                b.Margin = new Thickness(10, 10, 10, 10);

                StackPanel stackPanelExamination = new StackPanel();
                TextBlock doctor = new TextBlock();
                TextBlock period = new TextBlock();
                TextBlock prescription = new TextBlock();
                TextBlock refferal = new TextBlock();
                TextBlock Anamnesis = new TextBlock();
                TextBlock Diagnosis = new TextBlock();
                TextBlock therapy = new TextBlock();

                doctor.FontSize = 15;
                doctor.Inlines.Add(new Run("Doktor:  ") { FontWeight = FontWeights.Bold });
                doctor.Inlines.Add( examination.Doctor.FullName);
                doctor.Margin = new Thickness(10, 10, 10, 10);
                stackPanelExamination.Children.Add(doctor);
                //
                period.Inlines.Add(new Run("Datum:  ") { FontWeight = FontWeights.Bold });
                period.FontSize = 15;
                period.Inlines.Add( examination.Period.StartDate.ToString());
                period.Margin = new Thickness(10, 10, 10, 10);
                stackPanelExamination.Children.Add(period);

                //
                Anamnesis.FontSize = 15;
                Anamnesis.Inlines.Add(new Run("Anamnesis:  ") { FontWeight = FontWeights.Bold });
                Anamnesis.TextWrapping = TextWrapping.Wrap;
                Anamnesis.Margin = new Thickness(10, 10, 10, 10);
                Anamnesis.Inlines.Add( examination.Anemnesis.Text);
                stackPanelExamination.Children.Add(Anamnesis);

                //
                Diagnosis.FontSize = 15;
                Diagnosis.TextWrapping = TextWrapping.Wrap;
                Diagnosis.Inlines.Add(new Run("Diagnoza:  ") { FontWeight = FontWeights.Bold });
                Diagnosis.Margin = new Thickness(10, 10, 10, 10);
                Diagnosis.Inlines.Add( examination.Diagnosis.Name);
                stackPanelExamination.Children.Add(Diagnosis);

                //

                prescription.FontSize = 15;
                prescription.TextWrapping = TextWrapping.Wrap;
                prescription.Margin = new Thickness(10, 10, 10, 10);
                prescription.Inlines.Add(new Run("Recept: ") { FontWeight = FontWeights.Bold });
                foreach(Prescription pr in examination.Prescription)
                {
                    foreach (Drug dr in pr.Drug)
                        prescription.Inlines.Add( dr.Name);
                }
                stackPanelExamination.Children.Add(prescription);

                therapy.FontSize = 15;
                therapy.TextWrapping = TextWrapping.Wrap;
                therapy.Margin = new Thickness(10, 10, 10, 10);
                therapy.Inlines.Add(new Run("Terapija:  ") { FontWeight = FontWeights.Bold });
                therapy.Inlines.Add(examination.Therapy.Note);
                stackPanelExamination.Children.Add(therapy);
                if (examination.Refferal != null)
                {
                    refferal.FontSize = 15;
                    refferal.Margin = new Thickness(10, 10, 10, 10);
                    refferal.Inlines.Add(new Run("Uput:  ") { FontWeight = FontWeights.Bold });
                    refferal.Inlines.Add("pacijent se upućuje na dateljniji pregled kod lekara " + examination.Refferal.Doctor.FullName + " datuma " + examination.Refferal.Period.StartDate.ToString());
                    stackPanelExamination.Children.Add(refferal);
                }

                    b.Child = stackPanelExamination;

                Exeminations.Children.Add(b);
            }
        }

        private void setArticle()
        {
            foreach (var article in ListOfArticles)
            {
                Border b = new Border();
                b.BorderThickness = new Thickness(2);
                b.CornerRadius = new CornerRadius(3);
                b.BorderBrush = Brushes.LightBlue;
                b.Margin = new Thickness(10, 10, 10, 10);

                StackPanel stackPanelArticle = new StackPanel();
                TextBlock newTopic = new TextBlock();
                TextBlock newText = new TextBlock();
                TextBlock writer = new TextBlock();

                newTopic.TextWrapping = TextWrapping.Wrap;
                newTopic.FontSize = 15;
                newTopic.FontWeight = FontWeights.Bold;
                newTopic.MaxWidth = 700;
                //newTopic.HorizontalAlignment = HorizontalAlignment.Center;
                newText.TextWrapping = TextWrapping.Wrap;
                newText.FontSize = 13;
                newText.MaxWidth = 700;
                writer.FontSize = 12;
               // writer.HorizontalAlignment = HorizontalAlignment.Right;


                newTopic.Text = article.Topic;
                writer.Text = article.Doctor.FirstName + " " + article.Doctor.LastName;
                newText.Text = article.Text;

                stackPanelArticle.Children.Add(newTopic);
                stackPanelArticle.Children.Add(newText);
                stackPanelArticle.Children.Add(writer);

                b.Child = stackPanelArticle;

                ArticlesPanel.Children.Add(b);
            }
        }
        private void FillAccountData(Patient patient)
        {
            Username2.Text = _patient.Username;
            Name2.Text = _patient.FirstName;
            Surname2.Text = _patient.LastName;
            ID2.Text = _patient.Jmbg;
            Adress2.Text = "Adresa ne radi"; //TODO: _patient.Address.ToString();
            DateBirthTextBlock.Text = _patient.DateOfBirth.Date.ToString();
            Email2.Text = _patient.Email;
            PhoneNumber2.Text = _patient.Phone;
            UsernameConst.Text = _patient.Username;
        }



        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private List<ExaminationDTO> getScheduledExaminations()
        {
            List<ExaminationDTO> retVal = new List<ExaminationDTO>();
            Doctor dr = new Doctor(1, "Pera", "Perić", "213123123123", "sadsds@sadsa.com", "2312312312", new DateTime(), null, "DDD", "ddd", null, null);
            Period period = new Period(new DateTime(2020, 7, 7, 12, 20, 0), new DateTime(2020, 7, 7, 12, 40, 0));
            Console.WriteLine(period.StartDate.Date);
            Room room = new Room("213", null, null);
            ExaminationDTO examination = new ExaminationDTO();
            examination.Doctor = dr;
            examination.Period = period;
            examination.Room = room;
            examination.Patient = null;
            retVal.Add(examination);
            ExaminationDTO examination1 = new ExaminationDTO();
            Doctor dr1 = new Doctor(1, "Jovan", "Jovanović", "213123123123", "sadsds@sadsa.com", "2312312312", new DateTime(), null, "DDD", "ddd", null, null);
            Period period1 = new Period(new DateTime(2020, 10, 7, 9, 20, 0), new DateTime(2020, 10, 7, 12, 40, 0));
            Room room1 = new Room("101", null, null);
            examination1.Room = room1;
            examination1.Period = period1;
            examination1.Doctor = dr1;
            retVal.Add(examination1);
            return retVal;
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void LogOut(object sender, RoutedEventArgs e)
        {
            DeleteExamination delete;
            DialogResult result;
            if (System.Threading.Thread.CurrentThread.CurrentCulture.Equals(new CultureInfo("sr")))
            {
                delete = new DeleteExamination("Da li ste sigurni da želite da se odjavite?", "Da", "Ne", "Odjava", MainWindow.Theme);
                result = delete.ShowDialog();
            
            if (result == System.Windows.Forms.DialogResult.OK)
                {
                    App.j = 0;
                    WindowLogIn wl = new WindowLogIn();
                    wl.Show();
                    this.Close();
                }
            } else
            {
                delete = new DeleteExamination("Are you sure you want to log out?", "Yes", "No", "Log out", MainWindow.Theme);
                result = delete.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    App.j = 0;
                    WindowLogIn wl = new WindowLogIn();
                    wl.Show();
                    this.Close();
                }
            }
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if((int) DarkMode.Value == 1)
            {
                ThemeManager.ChangeAppStyle(this,
                                    ThemeManager.GetAccent("Teal"),//teal Steel
                                    ThemeManager.GetAppTheme("BaseDark"));
                Theme = 1;
            }
            else
            {
                ThemeManager.ChangeAppStyle(this,
                                    ThemeManager.GetAccent("Blue"),
                                    ThemeManager.GetAppTheme("BaseLight"));
                Theme = 0;
            }
        }

        private void Language_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selected = (int)Language.SelectedIndex;

            if (App.j != 0)
            {

                if (selected == 1)
                {
                    System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
                    System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-GB");
                    MainWindow.culture = new CultureInfo("en-GB");
                    cl.ChangeMainWindow(this);
                }
                else
                {
                    System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("sr");
                    System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo("sr");
                    MainWindow.culture = new CultureInfo("sr");
                    cl.ChangeMainWindow(this);

                }
            }
           
            Console.WriteLine("Vrednost od j je :" + App.j);

            App.j++;
        }

     

        private void Zakazi(object sender, RoutedEventArgs e)
        {
            var selectedItem = scheduleExaminationsGrid.SelectedItem;
           
            if(selectedItem == null)
            {
                return;
            }
            if(scheduledExaminations.Count == 3)
            {
                Storyboard sb = Resources["sbHideAnimation"] as Storyboard;
                sb.Begin(ErrorSchedule);
                return;
            }

            DeleteExamination delete;
            ExaminationDTO deleteExam = (ExaminationDTO)selectedItem;
            if (Thread.CurrentThread.CurrentCulture.Equals(new CultureInfo("sr")))
            {
                delete = new DeleteExamination("Zakažite termin kod lekara  " +
                                                                         deleteExam.Doctor.FirstName + " " + deleteExam.Doctor.LastName + "?", "Da", "Ne", "Zakaži pregled", MainWindow.Theme);

            }
            else
            {
                delete = new DeleteExamination("Schedule examination at the doctor  " +
                                                                        deleteExam.Doctor.FirstName + " " + deleteExam.Doctor.LastName + "?", "Yes", "No", "Schedule examination", MainWindow.Theme);

            }
            DialogResult result = delete.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                upcomingExaminations.Remove((ExaminationDTO)selectedItem);
                scheduledExaminations.Add((ExaminationDTO)selectedItem);
                scheduledExaminationsGrid.Items.Refresh();
                scheduleExaminationsGrid.Items.Refresh();
            }

        }

        private void Otkazi(object sender, RoutedEventArgs e)
        {
            var selectedItem = scheduledExaminationsGrid.SelectedItem;
            if (selectedItem == null)
            {
                return;
            }

            DeleteExamination delete;
            ExaminationDTO deleteExam = (ExaminationDTO)selectedItem;
            if (Thread.CurrentThread.CurrentCulture.Equals(new CultureInfo("sr")))
            {
               delete = new DeleteExamination("Da li ste sigurni da zelite da otkažete pregled kod lekara " +
                                                                        deleteExam.Doctor.FirstName + " " + deleteExam.Doctor.LastName + "?", "Da", "Ne", "Obriši pregled", MainWindow.Theme);

            }
            else
            {
                delete = new DeleteExamination("Are you sure you want to cancel the examination at the doctor  " +
                                                                        deleteExam.Doctor.FirstName + " " + deleteExam.Doctor.LastName + "?", "Yes", "No", "Delete examination", MainWindow.Theme);

            }
            DialogResult result = delete.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                scheduledExaminations.Remove((ExaminationDTO)selectedItem);
                scheduledExaminationsGrid.Items.Refresh();

            }
        }

        private void ChoosePhoto(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateInfo(object sender, RoutedEventArgs e)
        {
            int prom = 0;
            
            
            if (!Name.Text.ToString().Equals(""))
            {
                prom++;
                _patient.FirstName = Name.Text.ToString();
            }
            if (!Surname.Text.ToString().Equals(""))
            {
                prom++;
                _patient.LastName = Surname.Text.ToString();
            }
            if (!ID.Text.ToString().Equals(""))
            {
                prom++;
                _patient.Jmbg = ID.Text.ToString();
            }
            if (!Adress.Text.ToString().Equals(""))
            {
                prom++;
                _patient.Address = null; //TODO : ne zaboravi
            }
            if (!PhoneNumber.Text.ToString().Equals(""))
            {
                prom++;
                _patient.Phone = PhoneNumber.Text.ToString();
            }
            if (!Email.Text.ToString().Equals(""))
            {
                prom++;
                _patient.Email = Email.Text.ToString();
                
            }
            if (!DateBirthPicker.Text.ToString().Equals("") && DateBirthPicker.SelectedDate != DateTime.Today)
            {
                prom++;
                _patient.DateOfBirth = DateTime.Parse(DateBirthPicker.Text);
            }

            if (prom != 0)
            {
                //userService.Edit(_patient);
                FillAccountData(_patient);
                Storyboard sb = Resources["sbHideAnimation"] as Storyboard;
                sb.Begin(SuccessUpdateData);
//SuccessUpdateData.Visibility = Visibility.Visible;
                //TODO : Ispisi poruku za uspesan tok
            }
      

        }

        private void Password(object sender, RoutedEventArgs e)
        {
            PasswordValidation2.password2 = _patient.Password;
            CurrentPassword.GetBindingExpression(System.Windows.Controls.TextBox.TextProperty).UpdateSource();
        }


        private void PasswordCheck(object sender, RoutedEventArgs e)
        {

            CheckPassword.GetBindingExpression(System.Windows.Controls.TextBox.TextProperty).UpdateSource();

        }

        private void UpdatePw(object sender, RoutedEventArgs e)
        {
            if(CurrentPassword.Text != "" && NewPassword.Text != "")
            {
                _patient.Password = NewPassword.Text;
                Storyboard sb = Resources["sbHideAnimation"] as Storyboard;
                sb.Begin(SuccessUpdatePw);
            }
        }

        private void Search(object sender, RoutedEventArgs e)
        {
            if(ArticlesPanel.Children.Count < 5) {
                Border b = new Border();

                b.BorderThickness = new Thickness(1);
                b.BorderBrush = Brushes.Black;
                b.Height = 200;
                b.CornerRadius = new CornerRadius(3);

                b.Margin = new Thickness(5);
                ArticlesPanel.Children.Add(b);
            } else
            {
                ArticlesPanel.Children.Clear();
            }
            
        }

        private void CurrentTherapy(object sender, RoutedEventArgs e)
        {
            try
            {
                Process process = new System.Diagnostics.Process();
                String file = "C:\\Users\\jovan\\Desktop\\Faks\\HCI\\SrpskiIzvestaj.pdf";
                process.StartInfo.FileName = file;
                process.Start();
                process.WaitForExit();
            }
            catch
            {
                System.Windows.MessageBox.Show("Could not open the file.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Feedback(object sender, RoutedEventArgs e)
        {
            
            if(FeedBack.Text.Length != 0)
            {

                FeedBack.Clear();
                if (Thread.CurrentThread.CurrentCulture.Equals(new CultureInfo("sr")))
                {
                    FeedbackText.Text = "Hvala Vam što ste podelili sa nama Vaše mišljenje! " ;
                }
                else
                {
                    FeedbackText.Text = "Thank you for sharing with us your opinion! ";

                }
                Storyboard sb = Resources["sbHideAnimation"] as Storyboard;
                sb.Begin(FeedbackText);
            }

        }

        private void CalendarDateChanged(object sender, RoutedEventArgs e)
        {
            upcomingExaminations.Clear();
            Doctor dr = new Doctor(1, "Pera", "Perić", "213123123123", "sadsds@sadsa.com", "2312312312", new DateTime(), null, "DDD", "ddd", null, null);
            Doctor dr1 = new Doctor(1, "Jovan", "Jovanović", "213123123123", "sadsds@sadsa.com", "2312312312", new DateTime(), null, "DDD", "ddd", null, null);
            Room room1 = new Room("101", null,null);
            Room room3 = new Room("113", null,null);
            Room room4 = new Room("103", null,null);
            Room room6 = new Room("100", null,null);
            Room room7 = new Room("201", null,null);
            Period period1 = new Period(new DateTime(2020, 6, 20, 9, 20, 0));
            Period period2 = new Period(new DateTime(2020, 6, 20, 9, 40, 0));
            Period period3 = new Period(new DateTime(2020, 6, 20, 10, 20, 0));
            Period period4 = new Period(new DateTime(2020, 6, 20, 10, 0, 0));
            Period period5 = new Period(new DateTime(2020, 6, 19, 14, 20, 0));
            Period period6 = new Period(new DateTime(2020, 7, 19, 15, 20, 0));
            Period period7 = new Period(new DateTime(2020, 7, 19, 16, 40, 0));
            Period period8 = new Period(new DateTime(2020, 7, 19, 17, 20, 0));
            Period period9 = new Period(new DateTime(2020, 7, 19, 18, 0, 0));
            ExaminationDTO exam1 = new ExaminationDTO(dr, room1, period1);
            ExaminationDTO exam2 = new ExaminationDTO(dr, room1, period2);
            ExaminationDTO exam3 = new ExaminationDTO(dr, room3, period3);
            ExaminationDTO exam4 = new ExaminationDTO(dr, room1, period4);
            ExaminationDTO exam5 = new ExaminationDTO(dr1, room4, period5);
            ExaminationDTO exam6 = new ExaminationDTO(dr1, room4, period6);
            ExaminationDTO exam7 = new ExaminationDTO(dr1, room6, period7);
            ExaminationDTO exam8 = new ExaminationDTO(dr1, room7, period8);

            Doctor doctorica = (Doctor) DoctorsForExaminations.SelectedItem;
            if (doctorica != null && doctorica.FirstName.Equals("Pera"))
            {
                upcomingExaminations.Add(exam1);
                upcomingExaminations.Add(exam2);
                upcomingExaminations.Add(exam3);
                upcomingExaminations.Add(exam4);
            }
            else if(doctorica != null)
            {
                upcomingExaminations.Add(exam5);
                upcomingExaminations.Add(exam6);
                upcomingExaminations.Add(exam7);
                upcomingExaminations.Add(exam8);
            }
            scheduleExaminationsGrid.Items.Refresh();


        }


        private void GradeADoctorButton_Click(object sender, RoutedEventArgs e)
        {
            double grade = 0;
            grade += Slider1.Value;
            grade += Slider2.Value;
            grade += Slider3.Value;
            grade += Slider4.Value;
            grade += Slider5.Value;
            grade /= 5;
            var doctor = (Doctor)DoctorsForFeedback.SelectedItem;
            if (doctor == null)
            {
                FeedbackDOctor.Foreground = Brushes.Red;
                if (Thread.CurrentThread.CurrentCulture.Equals(new CultureInfo("sr")))
                {

                    FeedbackDOctor.Text = "Morate izabrati lekara!";
                }
                else
                {
                    FeedbackDOctor.Text = "You have to pik doctor!";

                }
                Storyboard ssb = Resources["sbHideAnimation"] as Storyboard;
                ssb.Begin(FeedbackDOctor);
                return;
            }

            FeedbackDOctor.Foreground = Brushes.Green;
            if (Thread.CurrentThread.CurrentCulture.Equals(new CultureInfo("sr")))
                {
                    FeedbackDOctor.Text = "Uspešno ste ocenili lekara!";
                }
            else
                {
                    FeedbackDOctor.Text = "You have successfully graded the doctor!";

                }
            Storyboard sb = Resources["sbHideAnimation"] as Storyboard;
            sb.Begin(FeedbackDOctor);
        }






        private String _ime;
        public String Ime
        {
            get
            {
                return _ime;
            }
            set
            {
                if (value != _ime)
                {
                    _ime = value;
                    OnPropertyChanged("Ime");
                }
            }
        }
        private String _password;
        public String Password1
        {
            get
            {
                return _password;
            }
            set
            {
                if (value != _password)
                {
                    _password = value;
                    OnPropertyChanged("Password");
                }
            }
        }
        private String _password2;
        public String Password2
        {
            get
            {
                return _password2;
            }
            set
            {
                if (value != _password2)
                {
                    _password2 = value;
                    OnPropertyChanged("Password");
                }
            }
        }
        private String _password3;
        public String Password3
        {
            get
            {
                return _password3;
            }
            set
            {
                if (value != _password3)
                {
                    _password3 = value;
                    OnPropertyChanged("Password");
                }
            }
        }



        private DateTime _dateTime = DateTime.Today;
        public DateTime DATETIME
        {
            get
            {
                return _dateTime;
            }
            set
            {
                if (value != _dateTime)
                {
                    _dateTime = value;
                    OnPropertyChanged("DATETIME");
                }
            }
        }


        private String _prezime;
        public String Prezime
        {
            get
            {
                return _prezime;
            }
            set
            {
                if (value != _prezime)
                {
                    _prezime = value;
                    OnPropertyChanged("Prezime");
                }
            }
        }
        private String _jmbg;
        public String JMBG
        {
            get
            {
                return _jmbg;
            }
            set
            {
                if (value != _jmbg)
                {
                    _jmbg = value;
                    OnPropertyChanged("JMBG");
                }
            }
        }

        private String _username;
        public String USERNAME
        {
            get
            {
                return _username;
            }
            set
            {
                if (value != _username)
                {
                    _username = value;
                    OnPropertyChanged("USERNAME");
                }
            }
        }
        private String _email;
        public String EMAIL
        {
            get
            {
                return _email;
            }
            set
            {
                if (value != _email)
                {
                    _email = value;
                    OnPropertyChanged("EMAIL");
                }
            }
        }
        private String _adress;
        public String ADRESS
        {
            get
            {
                return _adress;
            }
            set
            {
                if (value != _adress)
                {
                    _adress = value;
                    OnPropertyChanged("ADRESS");
                }
            }
        }

        private String _phone;
        public String Phone
        {
            get
            {
                return _phone;
            }
            set
            {
                if (value != _phone)
                {
                    _phone = value;
                    OnPropertyChanged("Phone");
                }
            }
        }

    }
}
