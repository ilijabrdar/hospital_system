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
    /// <summary>
    /// Interaction logic for AllergyWin.xaml
    /// </summary>
    public partial class AllergyWin : Window
    {
        private Doctor doctor;
        private Patient patient;
        public AllergyWin(Doctor _doctor, Patient _patient)
        {
            this.doctor = _doctor;
            this.patient = _patient;
            InitializeComponent();
            setAllergyCombo();
        }
        private void setAllergyCombo()
        {
            foreach (Allergy allergy in patient.patientFile.Allergy)
            {
                alergijaBrisi.Items.Add(allergy.Name);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var app = Application.Current as App;

            if (alergijaBrisi.SelectedItem != null)
            {
                Allergy allergy = new Allergy(alergijaBrisi.SelectedItem.ToString());
                foreach(Allergy al in patient.patientFile.Allergy.ToList())
                {
                    if(al.Name== allergy.Name)
                    {
                        patient.patientFile.Allergy.Remove(al);
                    }
                }
            }
            if (alergijaDodaj.Text != " ")
            {
                
                patient.patientFile.Allergy.Add(new Allergy(alergijaDodaj.Text));
            }

            app.PatientFileController.Edit(patient.patientFile);
            this.Close();
        }
    }
}
