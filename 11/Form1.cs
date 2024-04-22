using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _11
{

    public partial class Form1 : Form
    {
        private List<Aeroflot> aeroflots = new List<Aeroflot>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GenerateAeroflots();
            SaveToFile();
            LoadFromFile();
            DisplayAeroflots();

        }
        private void GenerateAeroflots()
        {
            Random rnd = new Random();
            aeroflots.Clear();
            for (int i = 0; i < 10; i++)
            {
                string[] destignations = { "Москва", "Санкт-Петербург", "Новосибирск", "Екатеринбург" };
                string[] airplaneType = { "Boeing 737", "Airbus A320", "Bombardier CRJ-1000", "Embraer E190" };
                int index = rnd.Next(destignations.Length);
                int index2 = rnd.Next(airplaneType.Length);
                aeroflots.Add(new Aeroflot
                {
                    Destination = $"Пункт назначения: {destignations[index]}",
                    FlightNumber = "Номер рейса: " + Convert.ToString(i + 100),
                    AirplaneType = $"Тип самолета: {airplaneType[index2]}"
                });
            }
        }

        private void SaveToFile()
        {
            string filePath = @"C:\Users\MVM\Desktop\fmd.txt";
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var aeroflot in aeroflots)
                {
                    writer.WriteLine($"{aeroflot.Destination},{aeroflot.FlightNumber},{aeroflot.AirplaneType}");
                }
            }
        }
        private void LoadFromFile()
        {
            string filePath = @"C:\Users\MVM\Desktop\fmd.txt";
            if (!File.Exists(filePath))
            {
                MessageBox.Show("Файл не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            aeroflots.Clear();
            string[] lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length != 3) continue;
                var aeroflot = new Aeroflot
                {
                    Destination = parts[0],
                    FlightNumber = parts[1],
                    AirplaneType = parts[2]
                };
                aeroflots.Add(aeroflot);
            }
        }
        private void DisplayAeroflots()
        {
            string filePath = @"C:\Users\MVM\Desktop\fmd.txt";
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                listBox1.Items.Add(line);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string destination = textBox1.Text;
            if (string.IsNullOrEmpty(destination))
            {
                MessageBox.Show("Введите название пункта назначения.", "улюлю", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (var aeroflot in aeroflots)
            {
                if (aeroflot.Destination == "Пункт назначения: "+destination)
                {
                    listBox2.Items.Add($"{aeroflot.FlightNumber} - {aeroflot.AirplaneType}");
                }
            }
            Aeroflot found =aeroflots.FirstOrDefault(a => a.Destination.Contains("Пункт назначения: " + destination));
            if (found == null) 
            {
                MessageBox.Show("Некорректные данные", "улюлю", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    class Aeroflot
    {
        public string Destination { get; set; }
        public string FlightNumber { get; set; }
        public string AirplaneType { get; set; }

        //public override string ToString()
        //{
        //    return $"Destination: {Destination}, Flight Number: {FlightNumber}, Airplane Type: {AirplaneType}";
        //}
    }

        
}

