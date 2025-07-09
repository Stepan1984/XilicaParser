using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static iridiJSONParser4XilicaApp.Program;

namespace iridiJSONParser4XilicaApp
{
    public partial class XilicaCommandsParser : Form
    {
        public XilicaCommandsParser()
        {
            InitializeComponent();
        }

        private void filePathButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Title = "Выберите файл";
                openFileDialog.Filter = "(*.xlsx)|*.xlsx";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Получите путь к выбранному файлу
                        string selectedFile = openFileDialog.FileName;
                        inputFilePathTextBox.Text = selectedFile;
                        if (outputFilePathTextBox.Text == "")
                        {
                            outputFilePathTextBox.Text = selectedFile.Substring(0, selectedFile.LastIndexOf("\\"));
                        }
                        if (fileNameTextBox.Text == "")
                        {
                            fileNameTextBox.Text = Path.GetFileNameWithoutExtension(selectedFile);
                            //fileNameTextBox.Text = selectedFile.Substring(selectedFile.LastIndexOf("\\") + 1, selectedFile.IndexOf(".xlsx") - selectedFile.LastIndexOf("\\") - 1) + ".json";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при чтении файла: " + ex.Message);
                    }
                }
            }
        }

        private void folderPathButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                folderBrowserDialog.InitialDirectory = "c:\\";
                //folderBrowserDialog.Title = "Выберите папку";
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Получите путь к выбранному файлу
                        string selectedFile = folderBrowserDialog.SelectedPath;
                        outputFilePathTextBox.Text = selectedFile;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при чтении файла: " + ex.Message);
                    }
                }
            }

        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private async void parseButton_Click(object sender, EventArgs e)
        {
            faultLabel.Visible = false;
            successLabel.Visible = false;
            try
            {
                if (File.Exists(inputFilePathTextBox.Text.Trim()))
                {
                    List<string> commands = ReadExcelFile(inputFilePathTextBox.Text.Trim());
                    string fileName = Path.GetFileNameWithoutExtension(fileNameTextBox.Text);
                    if (fileName.Length <= 0)
                    {
                        fileName = "ЗабылУказатьИмяФайла";
                    }

                    if (IsValidFileNameWithoutExtension(fileName))
                    {

                        string finalDirectory = outputFilePathTextBox.Text.Trim();
                        if (Directory.Exists(finalDirectory))
                        {
                            if (txtFileCheckBox.Checked)
                            {
                                using (FileStream fs = new FileStream(finalDirectory + "\\" + fileName + "_commands.txt", FileMode.Create))
                                using (StreamWriter writer = new StreamWriter(fs))
                                {
                                    writer.Write(string.Join(",\n", commands));
                                }
                            }

                            using (FileStream fs = new FileStream(finalDirectory + "\\" + fileName + ".json", FileMode.Create))
                            {
                                var xilica = new Device(29, "Xilica", "TCP", 0, new Connection(), StringArrayToObjectsArray(commands, 1), StringArrayToObjectsArray(commands, 2));
                                JsonSerializer.Serialize<AllDevices>(fs, new AllDevices(xilica), options);
                                Console.WriteLine("Data has been saved to file");
                            }
                            successLabel.Visible = true;
                            //await Task.Delay(10000);
                            //successLabel.Visible = false;
                        }

                        else
                        {
                            throw new Exception("Укажите существующую папку для сохранения");
                        }
                    }
                    else 
                    { 
                        throw new Exception("Некорректное имя сохраняемого файла");
                    }
                }
                else 
                {
                    throw new Exception("Укажите сущетсвующий файл Excel");
                }
            }
            catch (Exception ex) 
            {
                /*if(ex.Message.IndexOf("path")>=0)
                MessageBox.Show($"Ошибка: {ex.Message}");*/
                faultLabel.Text = ex.Message;
                faultLabel.Visible = true;

            }


        }
    }
}
