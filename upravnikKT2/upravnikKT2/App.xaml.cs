using bolnica.Repository;
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
        private const string CSV_DELIMITER = ",";

        public IController<RoomType, long> RoomTypeController { get; private set; }
        public IController<Ingredient, long> IngredientController { get; private set; }

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

        }
    }
}
