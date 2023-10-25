using System;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using NAudio.Wave;
using NAudio.Lame;
using static HuffmanCompression;

namespace MyApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void ChangeFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Текстові файли (*.txt;*.cmp)|*.txt;*.cmp|Зображення (*.jpg;*.png)|*.jpg;*.png|Музика (*.mp3;*.wav)|*.mp3;*.wav";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog1.FileName;
                label_Path.Text = selectedFilePath;
                string fileExtension = System.IO.Path.GetExtension(selectedFilePath).ToLower();
                string selectedCompressionMethod = "";

                bool isCompressedFile = fileExtension == ".cmp";

                if (isCompressedFile)
                {
                    selectedCompressionMethod = "Алгоритм Хоффмана";
                }
                else if (fileExtension == ".txt")
                {
                    selectedCompressionMethod = "Алгоритм Хоффмана";
                }
                else if (fileExtension == ".jpg" || fileExtension == ".png")
                {
                    selectedCompressionMethod = "Алгоритм стиснення для зображень";
                }
                else if (fileExtension == ".mp3" || fileExtension == ".wav")
                {
                    selectedCompressionMethod = "Алгоритм стиснення для аудіофайлів";
                }

                Label_Method.Text = "Метод стиснення: " + selectedCompressionMethod;
                btn_stysnuty.Enabled = !isCompressedFile;
                btn_decod.Enabled = isCompressedFile;
            }
        }
        private void btn_stysnuty_Click(object sender, EventArgs e)
        {
            string selectedFilePath = label_Path.Text;

            if (string.IsNullOrEmpty(selectedFilePath))
            {
                MessageBox.Show("Будь ласка, спочатку виберіть файл для стиснення.", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string fileExtension = System.IO.Path.GetExtension(selectedFilePath).ToLower();

            if (fileExtension == ".txt")
            {
                CompressTextFile(selectedFilePath);
            }
            else if (fileExtension == ".jpg" || fileExtension == ".png")
            {
                CompressImageFile(selectedFilePath);
            }
            else if (fileExtension == ".mp3" || fileExtension == ".wav")
            {
                CompressAudioFile(selectedFilePath);
            }
            else
            {
                MessageBox.Show("Неможливо визначити метод стиснення для даного типу файлу.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_decod_Click(object sender, EventArgs e)
        {
            string selectedFilePath = label_Path.Text;

            if (string.IsNullOrEmpty(selectedFilePath))
            {
                MessageBox.Show("Будь ласка, спочатку виберіть файл для декодування.", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string fileExtension = System.IO.Path.GetExtension(selectedFilePath).ToLower();

            if (fileExtension == ".cmp")
                DeCompressTextFile(selectedFilePath);
                    else
                        MessageBox.Show("Неможливо визначити метод стиснення для даного типу файлу.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
        }

        public static string decodecText;
        private void CompressTextFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("Будь ласка, спочатку виберіть файл для стиснення.", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string fileExtension = System.IO.Path.GetExtension(filePath).ToLower();

            if (fileExtension != ".txt")
            {
                MessageBox.Show("Неможливо визначити метод стиснення для даного типу файлу.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Стиснуті текстові файли (*.cmp)|*.cmp";
            saveFileDialog.Title = "Виберіть місце для збереження стисненого файлу";
            saveFileDialog.DefaultExt = "cmp";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                decodecText = File.ReadAllText(filePath);
                string outputFilePath = saveFileDialog.FileName;
                Compress(filePath, outputFilePath);
                MessageBox.Show("Файл успішно стиснутий і збережений.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private void DeCompressTextFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("Будь ласка, спочатку виберіть файл для розтиснення.", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string fileExtension = System.IO.Path.GetExtension(filePath).ToLower();

            if (fileExtension != ".cmp")
            {
                MessageBox.Show("Неможливо визначити метод розтиснення для даного типу файлу.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Розтисенні текстові файли (*.txt)|*.txt";
            saveFileDialog.Title = "Виберіть місце для збереження розтисненого файлу";
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); // Установите начальную папку

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string outputFilePath = saveFileDialog.FileName;
                File.WriteAllText(outputFilePath, decodecText);
                MessageBox.Show("Файл успішно розтиснутий і збережений.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void CompressImageFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("Будь ласка, спочатку виберіть файл для стиснення.", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string fileExtension = System.IO.Path.GetExtension(filePath).ToLower();

            if (fileExtension != ".jpg" && fileExtension != ".png")
            {
                MessageBox.Show("Неможливо визначити метод стиснення для даного типу файлу.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Стиснуті медіа файли (*.jpg;*.png)|*.jpg;*.png";
            saveFileDialog.Title = "Виберіть місце для збереження стисненого файлу";
            saveFileDialog.DefaultExt = ".jpg";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string outputFilePath = saveFileDialog.FileName;

                int compressionQuality = 75;

                using (var image = new Bitmap(filePath))
                {
                    var jpegEncoder = GetEncoder(ImageFormat.Jpeg);
                    var encoderParameters = new EncoderParameters(1);
                    encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, compressionQuality);
                    image.Save(outputFilePath, jpegEncoder, encoderParameters);
                }

                MessageBox.Show("Файл успішно стиснутий і збережений.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void CompressAudioFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("Будь ласка, спочатку виберіть файл для стиснення.", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string fileExtension = System.IO.Path.GetExtension(filePath).ToLower();

            if (fileExtension != ".mp3" && fileExtension != ".wav")
            {
                MessageBox.Show("Неможливо визначити метод стиснення для даного типу аудіофайлу.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Стиснуті аудіо файли (*.mp3)|*.mp3";
            saveFileDialog.Title = "Виберіть місце для збереження стисненого аудіофайлу";
            saveFileDialog.DefaultExt = ".mp3";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string outputFilePath = saveFileDialog.FileName;

                using (var reader = new AudioFileReader(filePath))
                {
                    // Устанавливаем параметры сжатия
                    var writer = new LameMP3FileWriter(outputFilePath, reader.WaveFormat, LAMEPreset.STANDARD);

                    // Копируем данные из исходного аудиофайла в сжатый
                    reader.CopyTo(writer);
                    writer.Close();
                }

                MessageBox.Show("Аудіофайл успішно стиснутий і збережений.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }
    }
}