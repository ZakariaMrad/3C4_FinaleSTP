using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
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

namespace Exercice03
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class PageZiko : Window
    {
        private List<User> users = new List<User>();
        
        public PageZiko()
        {
            InitializeComponent();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to clear all data?", "Clear", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                ClearValues();
            }
        }

        private void ClearValues()
        {
            RadioBMr.IsChecked = false;
            RadioBMrs.IsChecked = false;
            PrefixT.Foreground = new SolidColorBrush(Colors.Black);
            FirstN.Text = "";
            FirstNT.Foreground = new SolidColorBrush(Colors.Black);
            LastN.Text = "";
            LastNT.Foreground = new SolidColorBrush(Colors.Black);
            Adress.Text = "";
            PostalCode.Text = "";
            PostalCodeT.Foreground = new SolidColorBrush(Colors.Black);
            Province.Text = "Select a province";
            Birth.Text = "";
            Username.Text = "";
            UsernameT.Foreground = new SolidColorBrush(Colors.Black);
            Password.Password = "";
            Password.Foreground = new SolidColorBrush(Colors.Black);
            ConfPassword.Password = "";
            ConfPassword.Foreground = new SolidColorBrush(Colors.Black);
            Agreement.IsChecked = false;
            AgreementT.Foreground = new SolidColorBrush(Colors.Black);
            Subscription.IsChecked = false;
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder message = new StringBuilder();
            if (RadioBMr.IsChecked == false && RadioBMrs.IsChecked == false)
            {
                message.AppendLine("Select a prefix");
                PrefixT.Foreground = new SolidColorBrush(Colors.Red);
            }
            if (FirstN.Text == "")
            {
                message.AppendLine("Enter a Fisrt Name");
                FirstNT.Foreground = new SolidColorBrush(Colors.Red);
            }
            if (LastN.Text == "")
            {
                message.AppendLine("Enter a Last Name");
                LastNT.Foreground = new SolidColorBrush(Colors.Red);
            }
            if (PostalCode.Text == "")
            {
                message.AppendLine("Enter a Postal Code");
                PostalCodeT.Foreground = new SolidColorBrush(Colors.Red);
            }
            if (Username.Text == "")
            {
                message.AppendLine("Enter a Username");
                UsernameT.Foreground = new SolidColorBrush(Colors.Red);
            }
            if (Password.Password == "")
            {
                message.AppendLine("Enter a Password");
                Password.Foreground = new SolidColorBrush(Colors.Red);
            }
            if (ConfPassword.Password == "")
            {
                message.AppendLine("Confirm your Password");
                ConfPassword.Foreground = new SolidColorBrush(Colors.Red);
            }
            if (Agreement.IsChecked == false)
            {
                message.AppendLine("You must agree to terms and service");
                AgreementT.Foreground = new SolidColorBrush(Colors.Red);
            }
            if (users.Count!=0)
                if (users.FirstOrDefault(s => s.Username == Username.Text) is not null)
                {
                    message.AppendLine("Username already in use");
                    UsernameT.Foreground = new SolidColorBrush(Colors.Red);
                }
            if (Password.Password != ConfPassword.Password)
            {
                message.AppendLine("Password do not match");
                Password.Foreground = new SolidColorBrush(Colors.Red);
                ConfPassword.Foreground = new SolidColorBrush(Colors.Red);
            }

            DateTime brithDate = new DateTime(0);
            if (Birth.SelectedDate is not null)
                brithDate = Birth.SelectedDate.Value.Date;

            if (message.Length!=0)
                 MessageBox.Show(message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                users.Add(new User(RadioBMr.IsChecked.GetValueOrDefault(), FirstN.Text, LastN.Text, Adress.Text, PostalCode.Text, Province.Text, brithDate , Username.Text, Password.Password, Subscription.IsChecked.GetValueOrDefault()));
                UserCounter.Text = users.Count().ToString();
                MessageBox.Show("New user "+Username.Text+" created!", "User Created", MessageBoxButton.OK, MessageBoxImage.Information);
                ClearValues();
            }

        }
    }

    public class User
    {
        private bool MaritalStatus { get; set; } //false = man, true = female
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private string Adress { get; set; }
        private string PostalCode { get; set; }
        private string Province { get; set; }
        private DateTime Birth { get; set; }
        public string Username { get; set; }
        private string Password { get; set; }
        private bool Subscription { get; set; }

        public User(bool maritalStatus, string firstName, string lastName, string adress, string postalCode, string province,DateTime birth, string username, string password, bool subscription)
        {
            MaritalStatus = maritalStatus;
            FirstName = firstName;
            LastName = lastName;
            Adress = adress;
            PostalCode = postalCode;
            Province = province;
            Birth = birth;
            Username = username;
            Password = password;
            Subscription = subscription;
        }
    }
}
