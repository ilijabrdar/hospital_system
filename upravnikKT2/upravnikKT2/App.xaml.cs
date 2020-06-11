using bolnica.Controller;
using bolnica.Repository;
using bolnica.Repository.CSV.Converter;
using bolnica.Service;
using Controller;
using Model.Director;
using Model.Doctor;
using Model.PatientSecretary;
using Model.Users;
using Repository;
using Service;
using System;
using System.Windows;

namespace upravnikKT2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string ROOMTYPE_FILE = "../../Resources/Data/roomtypes.csv";
        private const string INGREDIENTS_FILE = "../../Resources/Data/ingredients.csv";
        private const string ROOMS_FILE = "../../Resources/Data/rooms.csv";
        private const string EQUIPMENT_FILE = "../../Resources/Data/equipment.csv";
        private const string RENOVATIONS_FILE = "../../Resources/Data/renovations.csv";
        private const string DRUGS_FILE = "../../Resources/Data/drugs.csv";
        private const string DOCTORS_FILE = "../../Resources/Data/doctors.csv";
        private const string SPECIALITY_FILE = "../../Resources/Data/speciality.csv";
        private const string ADDRESS_FILE = "../../Resources/Data/AddressFile.txt";
        private const string TOWN_FILE = "../../Resources/Data/TownFile.txt";
        private const string STATE_FILE = "../../Resources/Data/StateFile.txt";

        private const string CSV_DELIMITER = ",";
        private const String CSV_ARRAY_DELIMITER = "|";

        public IRoomTypeController RoomTypeController { get; private set; }
        public IIngredientController IngredientController { get; private set; }
        public IRoomController RoomController { get; private set; }

        public IEquipmentController EquipmentController { get; private set; }

        public IRenovationController RenovationController { get; private set; }

        public IDrugController DrugController { get; private set; }

        public IDoctorController DoctorController { get; private set; }

        public ISpecialityController SpecialityController { get; private set; }

        public IStateController StateController { get; private set; }

        public App()
        {
            var roomTypeRepository = new RoomTypeRepository(
                new CSVStream<RoomType>(ROOMTYPE_FILE, new RoomTypeCSVConverter(CSV_DELIMITER)),
                new LongSequencer());

            var roomTypeService = new RoomTypeService(roomTypeRepository);

            RoomTypeController = new RoomTypeController(roomTypeService);


            var ingredientRepository = new IngredientRepository(
                new CSVStream<Ingredient>(INGREDIENTS_FILE, new IngredientsCSVConverter(CSV_DELIMITER)),
                new LongSequencer());

            var ingredientService = new IngredientService(ingredientRepository);

            IngredientController = new IngredientController(ingredientService);


            var equipmentRepository = new EquipmentRepository(
               new CSVStream<Equipment>(EQUIPMENT_FILE, new EquipmentCSVConverter(CSV_DELIMITER)),
               new LongSequencer());

            var equipmentService = new EquipmentService(equipmentRepository);

            EquipmentController = new EquipmentController(equipmentService);

            var roomRepository = new RoomRepository(
               new CSVStream<Room>(ROOMS_FILE, new RoomCSVConverter(CSV_DELIMITER)),
               new LongSequencer(), roomTypeRepository,equipmentRepository);

            var roomService = new RoomService(roomRepository);

            RoomController = new RoomController(roomService);


            var renovationRepository = new RenovationRepository(new CSVStream<Renovation>(RENOVATIONS_FILE, new RenovationCSVConverter(CSV_DELIMITER)), new LongSequencer(),roomRepository);
            var renovationService = new RenovationService(renovationRepository);
            RenovationController = new RenovationController(renovationService);

            var drugRepository = new DrugRepository(new CSVStream<Drug>(DRUGS_FILE, new DrugCSVConverter(CSV_DELIMITER)), new LongSequencer(), ingredientRepository);
            var drugService = new DrugService(drugRepository);
            DrugController = new DrugController(drugService);

            var specialityRepository = new SpecialityRepository(new CSVStream<Speciality>(SPECIALITY_FILE, new SpecialityCSVConverter(CSV_DELIMITER)), new LongSequencer());
            var specialityService = new SpecialityService(specialityRepository);
            SpecialityController = new SpecialityController(specialityService);

            var doctorRepository = new DoctorRepository(new CSVStream<Doctor>(DOCTORS_FILE, new DoctorCSVConverter(CSV_DELIMITER)), new LongSequencer(),null,null,specialityRepository,null);
            var doctorService = new DoctorService(doctorRepository,null);
            DoctorController = new DoctorController(doctorService);

            AddressRepository addressRepository = new AddressRepository(new CSVStream<Address>(ADDRESS_FILE, new AddressCSVConverter(CSV_DELIMITER)), new LongSequencer());
            TownRepository townRepository = new TownRepository(new CSVStream<Town>(TOWN_FILE, new TownCSVConverter(CSV_DELIMITER, CSV_ARRAY_DELIMITER)), new LongSequencer(), addressRepository);
            StateRepository stateRepository = new StateRepository(new CSVStream<State>(STATE_FILE, new StateCSVConverter(CSV_DELIMITER, CSV_ARRAY_DELIMITER)), new LongSequencer(), townRepository);

            StateService stateService = new StateService(stateRepository);
            StateController = new StateController(stateService);
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            string text = System.IO.File.ReadAllText(@"C:\Users\david\Desktop\cc\hospital_system\upravnikKT2\upravnikKT2\Resources\Data\config.txt");

            if (text.Equals("false"))
                StartupUri = new Uri("MainWindow.xaml", UriKind.Relative);
            else
                StartupUri = new Uri("DashboardWindow.xaml", UriKind.Relative);

        }
    }
}
