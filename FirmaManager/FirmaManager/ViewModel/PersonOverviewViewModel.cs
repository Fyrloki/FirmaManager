using FirmaManager.Command;
using FirmaManager.Common;
using FimaManager.Common.Enum;
using FirmaManager.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows;
using FirmaManager.View;

namespace FirmaManager.ViewModel
{
    public class PersonOverviewViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private string _status;
        private List<Person> _personList;
        private Person _selectedPerson;
        private string _previousLastNameSearchcriteria;
        private string _previousFirstNameSearchcriteria;

        public PersonOverviewViewModel()
        {
            GetPersonsCommand = new RelayCommand((s) => SearchPeople());
            DeletePersonCommand = new RelayCommand((s) => DeletePerson(), (s) => SelectedPerson != null);
            CloseWindowCommand = new RelayCommand((s) => CloseWindow());

            OpenCreatePersonWindowCommand = new RelayCommand(
                (s) =>
                {
                    new CreatePersonWindow().ShowDialog();
                    RefreshPersonList();
                });

            OpenUpdatePersonWindowCommand = new RelayCommand(
                (s) =>
                {
                    CreatePersonWindow window = new(SelectedPerson.Uid);

                    if (!window.IsWindowClosing)
                    {
                        window.ShowDialog();
                    }

                    RefreshPersonList();
                }
                ,(s) => SelectedPerson != null);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string Status 
        {
            get => _status;

            set
            {
                if (value != _status)
                {
                    _status = value;
                    OnPropertyChanged();
                }
            }
        }

        public List<Person> PersonList
        {
            get => _personList;

            set
            {
                if(value != _personList)
                {
                    _personList = value;
                    OnPropertyChanged();
                }    
            }
        }

        public Person SelectedPerson
        {
            get => _selectedPerson;

            set
            {
                if (value != _selectedPerson)
                {
                    _selectedPerson = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand CloseWindowCommand { get; set; }

        public ICommand OpenCreatePersonWindowCommand { get; }

        public ICommand OpenUpdatePersonWindowCommand { get; }

        public ICommand DeletePersonCommand { get; }

        public ICommand GetPersonsCommand { get; }

        public string LastNameSearchCriteria { get; set; }

        public string FirstNameSearchCriteria { get; set; }

        private void RefreshPersonList()
        {
            Status = string.Empty;

            PersonList = GetPersonModel.GetPersonList(
                string.IsNullOrEmpty(_previousLastNameSearchcriteria) ? Constants.WILDCARD : _previousLastNameSearchcriteria
                , string.IsNullOrEmpty(_previousFirstNameSearchcriteria) ? Constants.WILDCARD : _previousFirstNameSearchcriteria);

            if (PersonList.Count == 0)
            {
                Status = Constants.NO_PERSON_FOUND_MESSAGE;
            }
        }

        private void SearchPeople()
        {
            Status = string.Empty;

            PersonList = GetPersonModel.GetPersonList(
                string.IsNullOrEmpty(LastNameSearchCriteria) ? Constants.WILDCARD : LastNameSearchCriteria
                , string.IsNullOrEmpty(FirstNameSearchCriteria) ? Constants.WILDCARD : FirstNameSearchCriteria);

            _previousFirstNameSearchcriteria = FirstNameSearchCriteria;
            _previousLastNameSearchcriteria = LastNameSearchCriteria;

            if (PersonList.Count == 0)
            {
                Status = Constants.NO_PERSON_FOUND_MESSAGE;
            }
        }

        private void DeletePerson()
        {
            Status = string.Empty;

            if (MessageBox.Show($"{Constants.SURE_REQUEST_PART_ONE_MESSAGEBOX} {SelectedPerson.FirstName} {SelectedPerson.Surname} {Constants.SURE_REQUEST_PART_TWO_MESSAGEBOX}"
                , Constants.DELETE_TITLE_MESSAGEBOX
                , MessageBoxButton.YesNo
                , MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (DeletePersonModel.DeletePerson(SelectedPerson) == StatusOfInteraction.personNotExists)
                {
                    _ = MessageBox.Show($"{SelectedPerson.FirstName} {SelectedPerson.Surname}" + Constants.PERSON_ALREADY_DELETED_MESSAGE
                        , Constants.DELETE_TITLE_MESSAGEBOX
                        , MessageBoxButton.OK
                        , MessageBoxImage.Warning);
                }
                else
                {
                    Status = Constants.DELETE_PERSON_SUCCESSFUL;
                }

                PersonList = GetPersonModel.GetPersonList(
                    string.IsNullOrEmpty(_previousLastNameSearchcriteria) ? Constants.WILDCARD : LastNameSearchCriteria
                    , string.IsNullOrEmpty(_previousFirstNameSearchcriteria) ? Constants.WILDCARD : FirstNameSearchCriteria);
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}