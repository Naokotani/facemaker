using System.Collections.Generic;
using System.Diagnostics;
using System.Security.RightsManagement;
using System.Windows;
using System.Windows.Controls;
using M01_First_WPF_Proj;

namespace M01_First_WPF_Proj
{
    public partial class PeoplePage : Page
    {
        Frame _main;
        List<Person> _people;
        Person _currPerson;
        int _currIndex;
        ViewModel _model;

        public PeoplePage(Frame main)
        {
            InitializeComponent();
            _main = main;
           LoadPeople();
            _currPerson = _people[0];
            _currIndex = 0;
            _model = main.DataContext as ViewModel;

            setContext();
        }

        private void LoadPeople()
        {
            DataAccess dataAccess = new DataAccess();
            _people = dataAccess.GetAllPeople();
            PeopleListBox.ItemsSource = _people;
        }

        public void setModel(Person person)
        {
            _model.fName = person.FirstName;
            _model.lName = person.LastName;
            _model.address = person.Address;
            _model.hair = person.Hair;
            _model.eyes = person.Eyes;
            _model.mouth = person.Mouth;
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            next_person();        
        }

        private void next_person()
        {
            _currIndex--;
            if (_currIndex <= 0)
            {
                _currIndex = _people.Count - 1;
            }
            _currPerson = _people[_currIndex];
            setModel(_currPerson);
            setContext();
        }


        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            _currIndex++;
            if (_currIndex >= _people.Count)
            {
                _currIndex = 0;
            }
            _currPerson = _people[_currIndex];
            setModel(_currPerson);
            setContext();
        }
        private void setContext()
        {
            DataContext = new
            {
                name = _currPerson.FirstName + _currPerson.LastName,
                address = _currPerson.Address,
                hair = _currPerson.Hair,
                eyes = _currPerson.Eyes,
                nose = _currPerson.Nose,
                mouth = _currPerson.Mouth,
            };
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            _currPerson = new Person();

            setContext();
            this.NavigationService.Navigate(new NamePage(_main));
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            DataAccess db = new DataAccess();
            db.DeletePerson(_currPerson.PersonId);
            _people = db.GetAllPeople();
            setModel(new Person());
            setContext();
        }
    }
}

