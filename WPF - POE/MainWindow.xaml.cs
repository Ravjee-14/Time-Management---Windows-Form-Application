using System;
using System.Collections.Generic;
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
using System.Collections;
using System.IO;

namespace WPF___POE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Classes are declared into the main
        Module myModule = new Module();
        Working myWork = new Working();
        Semester mySemester = new Semester();
        
        public MainWindow()
        {
            InitializeComponent();
        }

        //Button that calculates minimum study hours and remaining hours
        private void btnCalc_Click(object sender, RoutedEventArgs e)
        {
            //Try and catch for error handlings
            try
            {
                //Values from text box are declared to the corresponding class names
                myWork.HoursWorked = double.Parse(txtHoursWorked.Text);
                myWork.ModuleWork = txtModuleWork.Text;
                mySemester.NumWeeks = double.Parse(txtNumWeeks.Text);
                myWork.DateWorking = dpWorking.Text;

                List<Module> values = new List<Module>() {
                new Module() { Code = txtCode.Text, Name = txtName.Text, Credits = double.Parse(txtCredits.Text), HoursWeekly = double.Parse(txtHoursWeekly.Text) },
                new Module() { Code = txtCode2.Text, Name = txtName2.Text, Credits = double.Parse(txtCredits2.Text), HoursWeekly = double.Parse(txtHoursWeekly2.Text) },
                new Module() { Code = txtCode3.Text, Name = txtName3.Text, Credits = double.Parse(txtCredits3.Text), HoursWeekly = double.Parse(txtHoursWeekly3.Text) },
                new Module() { Code = txtCode4.Text, Name = txtName4.Text, Credits = double.Parse(txtCredits4.Text), HoursWeekly = double.Parse(txtHoursWeekly4.Text) }
            };

                //Linq query to get values
                var v = from s in values
                        where s.Code == txtModuleWork.Text
                        select new { code = s.Code, credits = s.Credits, hoursWeekly = s.HoursWeekly };

                //Linq to display information
                foreach (var item in v)
                {
                    //Calculations used to determine minimum study hours
                    myWork.StudyHoursWeekly = (item.credits * 10 / mySemester.NumWeeks) - item.hoursWeekly;
                    double remHours = myWork.StudyHoursWeekly - myWork.HoursWorked;
                    MessageBox.Show("Minimum Study Hours for: " + item.code + " is -> " + Math.Round(myWork.StudyHoursWeekly, 2) + " Remaining hours for this week is " + Math.Round(remHours, 2));
                }


                //List used to stores values in memory
                List<Working> SemesterList = new List<Working>()
                {
                    new Working() { HoursWorked = myWork.HoursWorked, ModuleWork = myWork.ModuleWork, StudyHoursWeekly = myWork.StudyHoursWeekly, DateWorking = myWork.DateWorking}
                };

                MessageBox.Show("Success!!!");
            }
            //Catch with will display error message
            catch (Exception)
            {
                MessageBox.Show("Missing or Incorrect value" +
                                "\nPlease Enter Again");
            }

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //Try and catch for error handlings
            try
            {
                //List to help upload modules into memory
                List<Module> values = new List<Module>() { 
                new Module() { Code = txtCode.Text, Name = txtName.Text, Credits = double.Parse(txtCredits.Text), HoursWeekly = double.Parse(txtHoursWeekly.Text) },
                new Module() { Code = txtCode2.Text, Name = txtName2.Text, Credits = double.Parse(txtCredits2.Text), HoursWeekly = double.Parse(txtHoursWeekly2.Text) },
                new Module() { Code = txtCode3.Text, Name = txtName3.Text, Credits = double.Parse(txtCredits3.Text), HoursWeekly = double.Parse(txtHoursWeekly3.Text) },
                new Module() { Code = txtCode4.Text, Name = txtName4.Text, Credits = double.Parse(txtCredits4.Text), HoursWeekly = double.Parse(txtHoursWeekly4.Text) }
            };

                MessageBox.Show("Added Successfully");
           }
            //Catch with will display error message
            catch (Exception)
            {
                MessageBox.Show("Incorrect Values or Not Missing value" +
                                "\nPlease Enter Again" +
                                "\n* Make sure all Textboxes are filled");
            }
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            //Try and catch for error handlings
            try
            {
                //Values from text box are declared to the corresponding class names
                mySemester.NumWeeks = double.Parse(txtNumWeeks.Text);
                mySemester.DateSemester = dpSemester.Text;

                //List to load relevant information into memory
                List<Semester> SemesterList = new List<Semester>()
                {
                    new Semester() { NumWeeks = mySemester.NumWeeks, DateSemester = mySemester.DateSemester}
                };

                MessageBox.Show("Successfully Submitted");
            }
            //Catch with will display error message
            catch (Exception)
            {
                MessageBox.Show("Incorrect or Missing Values Added!" +
                                "\nPlease Enter Again");
            }

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //try statement to tell user if a value has not been inputted
            try
            {
                // try statement to tell user if the file cannot be written
                try
                {
                    //destination to save file
                    //please enter save destination before starting the program
                    StreamWriter tw = new StreamWriter("C:\\");

                    //what will be written in the file
                    tw.Write("-------------------------------------------------------------- - " +
                             "\nDate ----------------------\t" + myWork.DateWorking +
                             "\nModule Code is ----------------------\t" + myModule.Code +
                             "\nMinimum Hours is --------------\t" + myWork.StudyHoursWeekly +
                             "\nHours spent working is ----------------\t" + myWork.HoursWorked +
                             "\nRemaining hours is -----------------\t" + myWork.StudyHoursWeekly +
                             "\n---------------------------------------------------------------");
                    tw.Close();

                    MessageBox.Show("File has successfully been written");
                }
                //catch expception to display what went wrong
                catch (Exception)
                {
                    MessageBox.Show("Unable to Save to file" +
                                    "\nReason - Access Denied from System Firewall");
                }
            }
            //catch statment to tell user what is wrong
            catch (Exception)
            {
                MessageBox.Show("Please enter a value in all fields" +
                                "\nNo Special characters are allowed");
            }
        }

        private void btnDisplay_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Bring in list from working class to help get values
                List<Working> SemesterList = new List<Working>()
                {
                    new Working() { HoursWorked = myWork.HoursWorked, ModuleWork = myWork.ModuleWork, StudyHoursWeekly = myWork.StudyHoursWeekly, DateWorking = myWork.DateWorking}
                };

                //Linq Query
                var q = from a in SemesterList
                        where a.ModuleWork == txtModuleWork.Text
                        select new { HoursWorked = a.HoursWorked, ModuleWork = a.ModuleWork, StudyHoursWeekly = a.StudyHoursWeekly, DateWorking = a.DateWorking };

                //Linq Query to get values 
                foreach(var semesterItem in q)
                {
                    txtDspHours.Text = semesterItem.StudyHoursWeekly.ToString();
                    txtDspHoursSpent.Text = semesterItem.HoursWorked.ToString();

                    double remHours = semesterItem.StudyHoursWeekly - semesterItem.HoursWorked;
                    txtDspRemHours.Text = remHours.ToString();
                }

                //List Modules in this class to help get values
                List<Module> values = new List<Module>() {
                new Module() { Code = txtCode.Text, Name = txtName.Text, Credits = double.Parse(txtCredits.Text), HoursWeekly = double.Parse(txtHoursWeekly.Text) },
                new Module() { Code = txtCode2.Text, Name = txtName2.Text, Credits = double.Parse(txtCredits2.Text), HoursWeekly = double.Parse(txtHoursWeekly2.Text) },
                new Module() { Code = txtCode3.Text, Name = txtName3.Text, Credits = double.Parse(txtCredits3.Text), HoursWeekly = double.Parse(txtHoursWeekly3.Text) },
                new Module() { Code = txtCode4.Text, Name = txtName4.Text, Credits = double.Parse(txtCredits4.Text), HoursWeekly = double.Parse(txtHoursWeekly4.Text) }
            };

                //Linq query to get values
                var v = from s in values
                        where s.Code == txtCode.Text
                        select new { code = s.Code, name = s.Name, credits = s.Credits, hoursWeekly = s.HoursWeekly };

                //Linq to display information
                foreach (var item in v)
                {
                    txtDspCode.Text = item.code.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Missing or Incorrect Values");
            }
        }

        //radio button class to show or hide textboxes ,labels and buttons
        private void radModule1_Checked(object sender, RoutedEventArgs e)
        {
            this.txtCode.Visibility = System.Windows.Visibility.Visible;
            this.txtName.Visibility = System.Windows.Visibility.Visible;
            this.txtCredits.Visibility = System.Windows.Visibility.Visible;
            this.txtHoursWeekly.Visibility = System.Windows.Visibility.Visible;

            this.txtCode2.Visibility = System.Windows.Visibility.Hidden;
            this.txtName2.Visibility = System.Windows.Visibility.Hidden;
            this.txtCredits2.Visibility = System.Windows.Visibility.Hidden;
            this.txtHoursWeekly2.Visibility = System.Windows.Visibility.Hidden;

            this.txtCode3.Visibility = System.Windows.Visibility.Hidden;
            this.txtName3.Visibility = System.Windows.Visibility.Hidden;
            this.txtCredits3.Visibility = System.Windows.Visibility.Hidden;
            this.txtHoursWeekly3.Visibility = System.Windows.Visibility.Hidden;

            this.txtCode4.Visibility = System.Windows.Visibility.Hidden;
            this.txtName4.Visibility = System.Windows.Visibility.Hidden;
            this.txtCredits4.Visibility = System.Windows.Visibility.Hidden;
            this.txtHoursWeekly4.Visibility = System.Windows.Visibility.Hidden;
        }

        //radio button class to show or hide textboxes ,labels and buttons
        private void radModule2_Checked(object sender, RoutedEventArgs e)
        {
            this.txtCode.Visibility = System.Windows.Visibility.Hidden;
            this.txtName.Visibility = System.Windows.Visibility.Hidden;
            this.txtCredits.Visibility = System.Windows.Visibility.Hidden;
            this.txtHoursWeekly.Visibility = System.Windows.Visibility.Hidden;

            this.txtCode2.Visibility = System.Windows.Visibility.Visible;
            this.txtName2.Visibility = System.Windows.Visibility.Visible;
            this.txtCredits2.Visibility = System.Windows.Visibility.Visible;
            this.txtHoursWeekly2.Visibility = System.Windows.Visibility.Visible;

            this.txtCode3.Visibility = System.Windows.Visibility.Hidden;
            this.txtName3.Visibility = System.Windows.Visibility.Hidden;
            this.txtCredits3.Visibility = System.Windows.Visibility.Hidden;
            this.txtHoursWeekly3.Visibility = System.Windows.Visibility.Hidden;

            this.txtCode4.Visibility = System.Windows.Visibility.Hidden;
            this.txtName4.Visibility = System.Windows.Visibility.Hidden;
            this.txtCredits4.Visibility = System.Windows.Visibility.Hidden;
            this.txtHoursWeekly4.Visibility = System.Windows.Visibility.Hidden;
        }

        //radio button class to show or hide textboxes ,labels and buttons
        private void radModule3_Checked(object sender, RoutedEventArgs e)
        {
            this.txtCode.Visibility = System.Windows.Visibility.Hidden;
            this.txtName.Visibility = System.Windows.Visibility.Hidden;
            this.txtCredits.Visibility = System.Windows.Visibility.Hidden;
            this.txtHoursWeekly.Visibility = System.Windows.Visibility.Hidden;

            this.txtCode2.Visibility = System.Windows.Visibility.Hidden;
            this.txtName2.Visibility = System.Windows.Visibility.Hidden;
            this.txtCredits2.Visibility = System.Windows.Visibility.Hidden;
            this.txtHoursWeekly2.Visibility = System.Windows.Visibility.Hidden;

            this.txtCode3.Visibility = System.Windows.Visibility.Visible;
            this.txtName3.Visibility = System.Windows.Visibility.Visible;
            this.txtCredits3.Visibility = System.Windows.Visibility.Visible;
            this.txtHoursWeekly3.Visibility = System.Windows.Visibility.Visible;

            this.txtCode4.Visibility = System.Windows.Visibility.Hidden;
            this.txtName4.Visibility = System.Windows.Visibility.Hidden;
            this.txtCredits4.Visibility = System.Windows.Visibility.Hidden;
            this.txtHoursWeekly4.Visibility = System.Windows.Visibility.Hidden;
        }

        //radio button class to show or hide textboxes ,labels and buttons
        private void radModule4_Checked(object sender, RoutedEventArgs e)
        {
            this.txtCode.Visibility = System.Windows.Visibility.Hidden;
            this.txtName.Visibility = System.Windows.Visibility.Hidden;
            this.txtCredits.Visibility = System.Windows.Visibility.Hidden;
            this.txtHoursWeekly.Visibility = System.Windows.Visibility.Hidden;

            this.txtCode2.Visibility = System.Windows.Visibility.Hidden;
            this.txtName2.Visibility = System.Windows.Visibility.Hidden;
            this.txtCredits2.Visibility = System.Windows.Visibility.Hidden;
            this.txtHoursWeekly2.Visibility = System.Windows.Visibility.Hidden;

            this.txtCode3.Visibility = System.Windows.Visibility.Hidden;
            this.txtName3.Visibility = System.Windows.Visibility.Hidden;
            this.txtCredits3.Visibility = System.Windows.Visibility.Hidden;
            this.txtHoursWeekly3.Visibility = System.Windows.Visibility.Hidden;

            this.txtCode4.Visibility = System.Windows.Visibility.Visible;
            this.txtName4.Visibility = System.Windows.Visibility.Visible;
            this.txtCredits4.Visibility = System.Windows.Visibility.Visible;
            this.txtHoursWeekly4.Visibility = System.Windows.Visibility.Visible;
        }
    }
}
