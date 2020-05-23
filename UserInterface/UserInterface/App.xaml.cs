using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Repository;
using bolnica.Repository;
using Model.Users;

namespace UserInterface
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const String CSV_DELIMITER = ",";
        private const String SECRETARY_FILE = "";
        public App()
        {
            //SecretaryRepository secretaryRepository = new SecretaryRepository(SECRETARY_FILE, new CSVStream<Secretary>, new );
        }
    }
}
