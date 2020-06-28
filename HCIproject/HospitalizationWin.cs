using Model.Director;
using Model.Doctor;
using Model.PatientSecretary;
using Model.Users;
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
using System.Windows.Shapes;

namespace HCIproject
{

    public partial class HospitalizationWin : Window
    {
        private Doctor user;
        public String dijagnoza;
        private long patientId;
       
        public HospitalizationWin(Doctor _user, long _patientId, String _dijagnoza)
        {
            this.user = _user;
            this.dijagnoza = _dijagnoza;
            this.patientId = _patientId;


            InitializeComponent();
            setPatientInfo();
            dijagnozaTxt.Text = dijagnoza;
            setRoomCombo();
        }

        private void setPatientInfo()
        {
            var app = Application.Current as App;
            Patient patient = app.PatientDecorator.Get(patientId);
            String imePrez = patient.FirstName + " " + patient.LastName;
            imePacijenta.Content = imePrez;

            int godine = DateTime.Now.Year - patient.DateOfBirth.Year;
            godinePacijenta.Content = godine.ToString();

            foreach (Allergy allergy in patient.patientFile.Allergy)
            {
                alergijePacijenta.Content += allergy.Name;
            }
        }

        private void setRoomCombo()
        {
            var app = Application.Current as App;
            foreach(var room in app.RoomDecorator.GetRoomsForHospitalization())
            {
                roomCMB.Items.Add(room.RoomCode+"-"+room.RoomType.Name);
            }

        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        { //potvrdi
            var app = Application.Current as App;

            if (StartDate.SelectedDate > EndDate.SelectedDate || StartDate.SelectedDate < DateTime.Now || roomCMB.SelectedItem == null)
            {
                if (roomCMB.SelectedItem == null)
                {
                    string messageBoxText1 = "Morate izabrati odeljenje kako biste izvrsili hospitalizaciju!";
                    string caption1 = "Hospitalizacija";
                    MessageBoxButton button1 = MessageBoxButton.OK;
                    MessageBoxImage icon1 = MessageBoxImage.Information;
                    MessageBoxResult result1 = MessageBox.Show(messageBoxText1, caption1, button1, icon1);
                }
                else
                {
                    string messageBoxText = "Nevalidan unos datuma. Datum početka operacije mora biti u budućnosti, pre završetka iste.";
                    string caption = "Hospitalizacija";
                    MessageBoxButton button = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Information;
                    MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);

                }
            }else
            {
                if (roomCMB.SelectedItem == null) return;

                String idTip = roomCMB.SelectedItem.ToString();
                String[] tokens = idTip.Split("-".ToCharArray());
                string id = tokens[0];
                Room room= new Room();

                foreach(Room r in app.RoomDecorator.GetAll())
                {
                    if (r.RoomCode == id)
                    {
                        room = r;
                    }
                }
                room.CurrentNumberOfPatients++;
                app.RoomDecorator.Edit(room);
                Patient patient = app.PatientDecorator.Get(patientId);
                if (StartDate.SelectedDate == null || EndDate.SelectedDate == null) return;
                Period period = new Period(StartDate.SelectedDate, EndDate.SelectedDate);
                Hospitalization hospitalization = new Hospitalization(patient, user, period, room);
            //    app.HospitalizationDecorator.Save(hospitalization);

                app.PatientFileDecorator.AddHospitalization(hospitalization, patient.patientFile);
                string messageBoxText = "Uspesno ste izvrsili hospitalizaciju pacijenta!";
                string caption = "Hospitalizacija";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);

                this.Close();
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        { //otkazi
            this.Close();
        }

        private void StackPanel_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            scrol.Height = this.ActualHeight - 150;
        }


    }
}
