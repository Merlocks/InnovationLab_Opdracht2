using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static InnovationLab_Opdracht2.PostData;

namespace InnovationLab_Opdracht2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //functionality for light buttons

        private void Button_LightingOn_Click(object sender, RoutedEventArgs e)
        {
            var postData = new PostDataLighting
            {
                Toggle = true
            };

            PostData(postData, CheckForLightingAccessCode());
        }

        private void Button_LightingOff_Click(object sender, RoutedEventArgs e)
        {
            var postData = new PostDataLighting
            {
                Toggle = false
            };

            PostData(postData, CheckForLightingAccessCode());
        }

        //functionality for temperature input

        private void Button_Temperature_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(TextBox_Temperature.Text, out _))
            {
                var postData = new PostDataTemperature
                {
                    Temperature = int.Parse(TextBox_Temperature.Text)
                };

                PostData(postData, CheckForTemperatureAccessCode());
            }
        }

        //functionality for sun protector buttons

        private void Button_SunProtectorOn_Click(object sender, RoutedEventArgs e)
        {
            var postData = new PostDataSunProtector
            {
                Toggle = true
            };

            PostData(postData, CheckForSunProtectorAccessCode());
        }

        private void Button_SunProtectorOff_Click(object sender, RoutedEventArgs e)
        {
            var postData = new PostDataSunProtector
            {
                Toggle = false
            };

            PostData(postData, CheckForSunProtectorAccessCode());
        }

        //post method
        //takes an object obj as parameter, this is the data to be sent to api
        //takes a string accessCode as parameter, determines which device data needs to be sent to

        private void PostData(object obj, string accessCode)
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri($"https://thingsboard.cloud/api/v1/{accessCode}/");

            var json = JsonSerializer.Serialize(obj);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = client.PostAsync("telemetry", content).Result;

            Console.WriteLine(response);
        }

        private string CheckForTemperatureAccessCode()
        {
            //if statements for class rooms in Hertogstraat

            if (ComboBox_Campus.Text == "Hertogstraat" && ComboBox_ClassRoom.Text == "Class1")
            {
                return Class1H.AccessCode_Temperature;
            }

            if (ComboBox_Campus.Text == "Hertogstraat" && ComboBox_ClassRoom.Text == "Class2")
            {
                return Class2H.AccessCode_Temperature;
            }

            if (ComboBox_Campus.Text == "Hertogstraat" && ComboBox_ClassRoom.Text == "Class3")
            {
                return Class3H.AccessCode_Temperature;
            }

            //if statements for class rooms in Proximus

            if (ComboBox_Campus.Text == "Proximus" && ComboBox_ClassRoom.Text == "Class1")
            {
                return Class1P.AccessCode_Temperature;
            }

            if (ComboBox_Campus.Text == "Proximus" && ComboBox_ClassRoom.Text == "Class2")
            {
                return Class2P.AccessCode_Temperature;
            }

            if (ComboBox_Campus.Text == "Proximus" && ComboBox_ClassRoom.Text == "Class3")
            {
                return Class3P.AccessCode_Temperature;
            }

            return null;
        }

        private string CheckForLightingAccessCode()
        {
            //if statements for class rooms in Hertogstraat

            if (ComboBox_Campus.Text == "Hertogstraat" && ComboBox_ClassRoom.Text == "Class1")
            {
                return Class1H.AccessCode_Lighting;
            }

            if (ComboBox_Campus.Text == "Hertogstraat" && ComboBox_ClassRoom.Text == "Class2")
            {
                return Class2H.AccessCode_Lighting;
            }

            if (ComboBox_Campus.Text == "Hertogstraat" && ComboBox_ClassRoom.Text == "Class3")
            {
                return Class3H.AccessCode_Lighting;
            }

            //if statements for class rooms in Proximus

            if (ComboBox_Campus.Text == "Proximus" && ComboBox_ClassRoom.Text == "Class1")
            {
                return Class1P.AccessCode_Lighting;
            }

            if (ComboBox_Campus.Text == "Proximus" && ComboBox_ClassRoom.Text == "Class2")
            {
                return Class2P.AccessCode_Lighting;
            }

            if (ComboBox_Campus.Text == "Proximus" && ComboBox_ClassRoom.Text == "Class3")
            {
                return Class3P.AccessCode_Lighting;
            }

            return null;
        }

        private string CheckForSunProtectorAccessCode()
        {
            //if statements for class rooms in Hertogstraat

            if (ComboBox_Campus.Text == "Hertogstraat" && ComboBox_ClassRoom.Text == "Class1")
            {
                return Class1H.AccessCode_SunProtector;
            }

            if (ComboBox_Campus.Text == "Hertogstraat" && ComboBox_ClassRoom.Text == "Class2")
            {
                return Class2H.AccessCode_SunProtector;
            }

            if (ComboBox_Campus.Text == "Hertogstraat" && ComboBox_ClassRoom.Text == "Class3")
            {
                return Class3H.AccessCode_SunProtector;
            }

            //if statements for class rooms in Proximus

            if (ComboBox_Campus.Text == "Proximus" && ComboBox_ClassRoom.Text == "Class1")
            {
                return Class1P.AccessCode_SunProtector;
            }

            if (ComboBox_Campus.Text == "Proximus" && ComboBox_ClassRoom.Text == "Class2")
            {
                return Class2P.AccessCode_SunProtector;
            }

            if (ComboBox_Campus.Text == "Proximus" && ComboBox_ClassRoom.Text == "Class3")
            {
                return Class3P.AccessCode_SunProtector;
            }

            return null;
        }
    }
}
