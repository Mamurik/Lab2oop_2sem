using System;
using System.IO;
using System.Text;
using System.Windows;
using Microsoft.Win32;

namespace Lab2
{
    public partial class MainWindow : Window
    {
        private int n = 10; // Размер буфера для чтения файла
        private string filePath = "D:\\Labs\\4sem\\ООПиП\\2\\lab2.txt"; // Путь к файлу по умолчанию
        private DateTime lastReadTime; // Время последнего чтения файла

        public MainWindow()
        {
            InitializeComponent();
        }

        // Обработчик события нажатия кнопки выбора файла
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                TextBoxFilePath.Text = openFileDialog.FileName;
                filePath = openFileDialog.FileName;
            }
        }

        // Метод для чтения файла
        private void ReadFile()
        {
            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("Файл не выбран.");
                return;
            }

            try
            {
                byte[] buffer = new byte[n]; // Создание буфера для чтения данных из файла

                using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    int bytesRead = fileStream.Read(buffer, 0, buffer.Length); // Чтение данных из файла в буфер
                    if (bytesRead > 0)
                    {
                        lastReadTime = DateTime.Now; // Запись текущего времени в переменную lastReadTime
                        string content = Encoding.Default.GetString(buffer, 0, bytesRead); // Преобразование прочитанных байтов в строку

                        string displayContent = $"Текст из файла:\n{content}\n\nПоследнее время чтения: {lastReadTime}";

                        Clipboard.SetText(displayContent); // Копирование текста из файла в буфер обмена
                        MessageBox.Show("Время последнего чтения сохранено в буфер обмена.");

                        // Обновление текстовых блоков с содержимым файла и временем последнего чтения
                        FirstResultTextBlock.Text = content;
                        SecondResultTextBlock.Text = $"Последнее время чтения: {lastReadTime}";
                    }
                    else
                    {
                        MessageBox.Show("Файл пустой.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при чтении файла: " + ex.Message);
            }
        }

        // Обработчик события нажатия кнопки "Сохранить"
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            ReadFile();
        }
    }
}