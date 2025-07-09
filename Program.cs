using PlaceholderTextBox;
using OfficeOpenXml;
using System.Text.Json;

namespace iridiJSONParser4XilicaApp
{
    internal static class Program
    {
        
        public class AllDevices
        {
            public List<Device> Devices { get; set; }
            public AllDevices(Device d)
            {
                Devices = new List<Device>();
                Devices.Add(d);
            }

        }
        public class Device
        {
            public int Type { get; set; }
            public string Name { get; set; }
            public string Protocol { get; set; }
            public int Merge { get; set; }

            public Connection Connection { get; set; }

            public List<CommandOrFeedback> Commands { get; set; }
            public List<CommandOrFeedback> Feedbacks { get; set; }

            public Device(int t, string n, string p, int m, Connection c, List<CommandOrFeedback> com, List<CommandOrFeedback> feed)
            {
                Type = t;
                Name = n;
                Protocol = p;
                Merge = m;
                Connection = c;
                Commands = com;
                Feedbacks = feed;
            }
        }

        public class Connection
        {
            public string Host { get; set; }
            public int Port { get; set; }

            public Connection(string h, int p)
            {
                Host = h;
                Port = p;
            }

            public Connection()
            {
                Host = "192.168.0.1";
                Port = 123;
            }

        }

        public class CommandOrFeedback
        {
            public int Direction { get; set; }
            public string Name { get; set; }

            public CommandOrFeedback(int d, string str)
            {
                Direction = d;
                Name = str;
            }
        }

        //создает массив объектов с полями Name из входного массива, возвращает полученный массив или null
        public static List<CommandOrFeedback> StringArrayToObjectsArray(List<string> array, int direction)
        {
            if (array.Count > 0)
            {
                List<CommandOrFeedback> objectsList = new List<CommandOrFeedback> { };
                foreach (string s in array)
                {
                    objectsList.Add(new CommandOrFeedback(direction, s));
                }
                //Console.WriteLine("Object Array Length:" + objectsList.Count);
                return objectsList;
            }
            return null;

        }

        public static List<string> ReadExcelFile(string filePath)
        {
            FileInfo file = new FileInfo(filePath);

            using (ExcelPackage package = new ExcelPackage(file))
            {
                int sheetsCount = package.Workbook.Worksheets.Count;
                //Console.WriteLine("Количество листов = " + sheetsCount);
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0]; // Получаем первый лист
                int rowCount = worksheet.Dimension.Rows; // кол-во строк
                int colCount = 7; // кол-во столбцов
                List<string> list = new List<string>();
                for (int row = 8; row <= rowCount; row++)
                {
                    object cellValue = worksheet.Cells[row, colCount].Value;
                    list.Add(cellValue.ToString());
                }
                return list;
            }
        }

        public static bool IsValidFileNameWithoutExtension(string fileName)
        {
            // 1. Проверка на пустоту или пробелы
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentException("Имя файла не может быть пустым или содержать только пробелы");
            }

            // 2. Проверка недопустимых символов
            char[] invalidChars = Path.GetInvalidFileNameChars();
            if (fileName.Any(c => invalidChars.Contains(c)))
            {
                throw new ArgumentException(
                    $"Имя файла содержит недопустимые символы: {string.Join(", ", invalidChars)}");
            }

            // 3. Проверка зарезервированных имён Windows
            string[] reservedNames = {
                "CON", "PRN", "AUX", "NUL",
                "COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9",
                "LPT1", "LPT2", "LPT3", "LPT4", "LPT5", "LPT6", "LPT7", "LPT8", "LPT9" };

            if (reservedNames.Contains(fileName.ToUpper()))
            {
                throw new ArgumentException("Это зарезервированное имя файла в Windows");
            }

            // 4. Проверка длины (максимум 255 символов для имени)
            if (fileName.Length > 255)
            {
                throw new ArgumentException("Имя файла слишком длинное (максимум 255 символов)");
            }

            // 5. Проверка начальных/конечных символов
            if (fileName.StartsWith(" ") || fileName.EndsWith(" "))
            {
                throw new ArgumentException("Имя файла не должно начинаться или заканчиваться пробелом");
            }

            // 6. Проверка точек (не может быть "." или ".." или заканчиваться на ".")
            if (fileName == "." || fileName == ".." || fileName.EndsWith("."))
            {
                throw new ArgumentException("Недопустимое использование точек в имени файла");
            }

            return true;
        }

        public static JsonSerializerOptions options = new JsonSerializerOptions
        {
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            WriteIndented = true // Для красивого форматирования (опционально)
        };
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            ExcelPackage.License.SetNonCommercialPersonal("Stepan");
            ApplicationConfiguration.Initialize();
            Application.Run(new XilicaCommandsParser());
        }
    
    }
}