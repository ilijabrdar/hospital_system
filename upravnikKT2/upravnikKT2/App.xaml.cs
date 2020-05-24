using bolnica.Controller;
using bolnica.Repository;
using bolnica.Repository.CSV.Converter;
using Controller;
using Model.Director;
using Model.PatientSecretary;
using Repository;
using Service;
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
        private const string CSV_DELIMITER = ",";

        public IRoomTypeController RoomTypeController { get; private set; }
        public IIngredientController IngredientController { get; private set; }
        public IRoomController RoomController { get; private set; }

        public IEquipmentController EquipmentController { get; private set; }

        public IRenovationController RenovationController { get; private set; }

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


            var roomRepository = new RoomRepository(
               new CSVStream<Room>(ROOMS_FILE, new RoomCSVConverter(CSV_DELIMITER)),
               new LongSequencer());

            var roomService = new RoomService(roomRepository);

            RoomController = new RoomController(roomService);


            var equipmentRepository = new EquipmentRepository(
               new CSVStream<Equipment>(EQUIPMENT_FILE, new EquipmentCSVConverter(CSV_DELIMITER)),
               new LongSequencer());

            var equipmentService = new EquipmentService(equipmentRepository);

            EquipmentController = new EquipmentController(equipmentService);


            var renovationRepository = new RenovationRepository(new CSVStream<Renovation>(RENOVATIONS_FILE, new RenovationCSVConverter(CSV_DELIMITER)), new LongSequencer());
            var renovationService = new RenovationService(renovationRepository);
            RenovationController = new RenovationController(renovationService);

        }
    }
}
