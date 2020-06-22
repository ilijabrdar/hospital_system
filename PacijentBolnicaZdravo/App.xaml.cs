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
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace PacijentBolnicaZdravo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
          public static int j = 0;
        private readonly String _patient_File = "../../ResourcesFiles/patient.csv";
        private readonly String _patientFile_File = "../../ResourcesFiles/patientFile.csv";

        private readonly String _article_File = "../../../../code/Resources/Data/articles.csv";
        private readonly String _doctor_File = "../../../../code/Resources/Data/doctors.csv";
        private readonly String _speciality_File = "../../../../code/Resources/Data/speciality.csv";
        private readonly String _businessDay_File = "../../../../code/Resources/Data/businessdays.csv";
        private readonly String _room_File = "../../../../code/Resources/Data/rooms.csv";
        private readonly String _roomType_File = "../../../../code/Resources/Data/roomtypes.csv";
        private readonly String _equipment_File = "../../../../code/Resources/Data/equipment.csv";
        private readonly String _address_File = "../../../../code/Resources/Data/AddressFile.txt";
        private readonly String _state_File = "../../../../code/Resources/Data/StateFile.txt";
        private readonly String _town_File = "../../../../code/Resources/Data/TownFile.txt";

        public IUserController UserController { get; set; }
        public IArticleController ArticleController
        { get; private set; }
        public IDoctorController DoctorController { get; set; }
        public IBusinessDayController BusinessDayController { get; set; }

        public IExaminationController ExaminationController { get; set; }



        App()
        {
            var doctorGradeRepo = new DoctorGradeRepository(new CSVStream<DoctorGrade>("", new DoctorGradeCSVConverter(",", "|", "*")), new LongSequencer());
            var patientFileRepo = new PatientFileRepository(new CSVStream<PatientFile>(_patientFile_File, new PatientFileCSVConverter(",", "|")), new LongSequencer());
            var patientRepo = new PatientRepository(new CSVStream<Patient>(_patient_File, new PatientCSVConverter(",")), new LongSequencer(), patientFileRepo);
            var specialityRepo = new SpecialityRepository(new CSVStream<Speciality>(_speciality_File, new SpecialityCSVConverter(",")), new LongSequencer());
            var equipmentRepo = new EquipmentRepository(new CSVStream<Equipment>(_equipment_File, new EquipmentCSVConverter(",")), new LongSequencer());
            var roomTypeRepo = new RoomTypeRepository(new CSVStream<RoomType>(_roomType_File, new RoomTypeCSVConverter(",")), new LongSequencer());
            var roomRepo = new RoomRepository(new CSVStream<Room>(_room_File, new RoomCSVConverter(",")), new LongSequencer(), roomTypeRepo, equipmentRepo);
            var businessDayRepo = new BusinessDayRepository(new CSVStream<BusinessDay>(_businessDay_File, new BusinessDayCSVConverter()), new LongSequencer(), roomRepo);
            var doctorRepository = new DoctorRepository(new CSVStream<Doctor>(_doctor_File, new DoctorCSVConverter(",")), new LongSequencer(), businessDayRepo, specialityRepo, doctorGradeRepo);
            businessDayRepo.doctorRepo = doctorRepository;
            var articleRepo = new ArticleRepository(new CSVStream<Article>(_article_File, new ArticleCSVConverter(",")), new LongSequencer(), doctorRepository);
            var addressRepo = new AddressRepository(new CSVStream<Address>(_address_File, new AddressCSVConverter(",")), new LongSequencer());
            var townRepo = new TownRepository(new CSVStream<Town>(_town_File, new TownCSVConverter(",", "|")), new LongSequencer(), addressRepo);
            var stateRepo = new StateRepository(new CSVStream<State>(_state_File, new StateCSVConverter(",", "|")), new LongSequencer(), townRepo);

            var doctorGradeService = new DoctorGradeService(doctorGradeRepo);
            var articleService = new ArticleService(articleRepo);
            var patientFileService = new PatientFileService(patientFileRepo);
            var patientService = new PatientService(patientRepo, patientFileService);
            var userService = new UserService(patientService);
            var doctorService = new DoctorService(doctorRepository);
            var businessDayService = new BusinessDayService(businessDayRepo);
            //   var examinationService = new ExaminationService()
            var addressService = new AddressService(addressRepo);
            var townService = new TownService(townRepo);
            var stateService = new StateService(stateRepo);


            UserController = new UserController(userService);
            ArticleController = new ArticleController(articleService);
            DoctorController = new DoctorController(doctorService);
            BusinessDayController = new BusinessDayController(businessDayService);
       //   ExaminationController = new ExaminationController(examinationService);
           
        }


    }
}
