using FirmaManager.Command;
using FirmaManager.Common;
using FirmaManager.Model;
using FirmaManager.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows;

namespace FirmaManager.ViewModel
{
    public class CreatePersonViewModel : ViewModelBase ,INotifyPropertyChanged
    {
        private DateTime _birthdate;
        private Guid? _guid;
        private Visibility _updateButtonVisbility;
        private Person _person;
        private string _status;
        private string _operationName;
        private string _lastName;
        private string _firstName;
        private string _personnumber;
        private string _selectedGender;
        private string _title;

        public CreatePersonViewModel()
        {
            CloseWindowCommand = new RelayCommand((s) => CloseWindow());

            ApplyCommand = new RelayCommand((s) => ApplyPerson(), (s) => IsPersonValid() && IsPersonNameChanged());

            SavePersonCommand = new RelayCommand((s) => SavePerson(), (s) => IsPersonValid());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand SavePersonCommand { get; }

        public ICommand ApplyCommand { get; }

        public ICommand CloseWindowCommand { get; }

        public string Status
        {
            get => _status;

            set
            {
                _status = value;

                OnPropertyChanged();
            }
        }

        public string Title
        {
            get => _title;

            set
            {
                _title = value;

                OnPropertyChanged();
            }
        }

        public Guid? Guid
        {
            get => _guid;

            set
            {
                _guid = value;

                OnPropertyChanged("IsCreate");
            }
        }

        public bool IsCreate => Guid is null;

        public string LastName 
        {
            get => _lastName;
                
            set
            {
                _lastName = value;

                OnPropertyChanged("IsLastNameValid");
                OnPropertyChanged();
            }
        }

        public string FirstName
        {
            get => _firstName;

            set
            {
                _firstName = value;
                
                OnPropertyChanged("IsFirstNameValid");
                OnPropertyChanged();
            }
        }

        public string Personnumber
        {
            get => _personnumber;

            set
            {
                if (!Regex.IsMatch(value, @"^[a-zA-Z0-9]+$") && !string.IsNullOrEmpty(value))
                {
                    value = value.Remove(value.Length - 1, 1);
                }

                _personnumber = value;

                OnPropertyChanged();
                OnPropertyChanged("IsPersonnumberValid");
            }
        }

        public string SelectedGender
        {
            get => _selectedGender;

            set
            {
                _selectedGender = value;

                OnPropertyChanged();
                OnPropertyChanged("IsGenderValid");
            }
        }

        public DateTime Birthdate
        {
            get => _birthdate;

            set
            {
                if (value != _birthdate)
                {
                    _birthdate = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsLastNameValid => PersonPropertiesValidator.IsPersonNameValid(LastName);

        public bool IsFirstNameValid => PersonPropertiesValidator.IsPersonNameValid(FirstName);

        public bool IsPersonnumberValid
        {
            get
            {
                if (IsCreate)
                {
                    return PersonPropertiesValidator.IsPersonNumberUnique(Personnumber) && !string.IsNullOrEmpty(Personnumber) && !string.IsNullOrWhiteSpace(Personnumber);
                }
                else
                {
                    return !string.IsNullOrEmpty(Personnumber) && !string.IsNullOrWhiteSpace(Personnumber);
                }
            }
        }

        public bool IsGenderValid => !string.IsNullOrEmpty(SelectedGender);

        public string OperationName
        {
            get => _operationName;

            set
            {
                _operationName = value;

                OnPropertyChanged();
            }
        }

        public static List<string> Genderlist => new() { Constants.GENDER_MALE, Constants.GENDER_FEMALE };

        public Visibility UpdateButtonVisbility
        {
            get => _updateButtonVisbility;

            set
            {
                _updateButtonVisbility = value;

                OnPropertyChanged();
            }
        }

        public void PrepareWindowForCreate()
        {
            Title = $"{Constants.TITLE} {Constants.WINDOWTITLE_CREATE}";
            OperationName = Constants.CREATE_DESIGNATION;
            Birthdate = DateTime.Today;
        }

        public void PrepareWindowForUpdate(Guid guid)
        {
            Guid = guid;
            OperationName = Constants.OK_DESIGNATION;
            _person = GetPersonModel.GetPerson((Guid)_guid);

            if(_person == null)
            {
                MessageBox.Show(Constants.PERSON_DOES_NOT_EXISTS_ANYMORE, Constants.PERSON_DOES_NOT_EXISTS_ANYMORE, MessageBoxButton.OK, MessageBoxImage.Information);
                CloseWindow();
                return;
            }

            LastName = _person.Surname;
            FirstName = _person.FirstName;
            Personnumber = _person.PersonNumber;
            SelectedGender = _person.Gender;
            Birthdate = DateTime.Parse(_person.Birthday);
            Title = $"{Constants.TITLE} {Personnumber} {Constants.WINDOWTITLE_UPDATE}";
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!Equals(field, newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }

            return false;
        }

        private bool IsPersonNameChanged() => _person != null && (_person.FirstName != FirstName || _person.Surname != LastName);

        private bool IsPersonValid() => IsLastNameValid && IsFirstNameValid && IsGenderValid && IsPersonnumberValid;

        private void ApplyPerson()
        {
            SavePerson(out bool isSuccess, out string message);

            if (isSuccess)
            {
                Status = Constants.CHANGES_SAVED;
                _person.FirstName = FirstName;
                _person.Surname = LastName;
                return;
            }

            Status = message;
        }

        private void SavePerson()
        {
            SavePerson(out bool isSuccess, out string message);

            if (isSuccess)
            {
                CloseWindow();

                return;
            }

            Status = Constants.CHANGES_NOT_SAVED;

            MessageBox.Show(message, Constants.FAIL_CAPTION, MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void SavePerson(out bool isSuccess, out string message)
        {
            isSuccess = SavePersonModel.IsPersonSaveSuccessful(
                _guid
                , NameManipulator.GetCleanedName(LastName)
                , NameManipulator.GetCleanedName(FirstName)
                , Birthdate
                , SelectedGender
                , Personnumber
                , out message);
        }
    }
}