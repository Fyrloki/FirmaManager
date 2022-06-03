using FimaManager.Business.Interfaces;
using FirmaManager.Common;
using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;
using FirmaManager.WinFormsClient.Interfaces;
using FimaManager.Common.Configs;
using FirmaManager.EntityFrameworkData.Models;


namespace FirmaManager.WinFormsClient
{
    public partial class UpdateCreatePersonForm : Form
    {
        private readonly IPersonManager _personManager;
        private readonly INameManipulator _nameManipulator;
        private readonly bool _isCreate;
        private readonly Person _person;
        private readonly Person _oldPerson;
        private bool _isPersonValid;

        public UpdateCreatePersonForm(IPersonManager personManager, INameManipulator nameManipulator) : this(personManager, nameManipulator, null) { }

        public UpdateCreatePersonForm(IPersonManager personManager, INameManipulator nameManipulator, Person person)
        {
            _isPersonValid = false;
            _personManager = personManager;
            _nameManipulator = nameManipulator;
            _isCreate = person is null;

            if(!_isCreate)
            {
                _person = person;
                _oldPerson = new Person(person.Surname, person.FirstName);
            }

            InitializeComponent();
        }

        private bool IsPersonValueChanged => txtFirstName.Text != _oldPerson.FirstName || txtLastName.Text != _oldPerson.Surname;

        private bool IsFirstNameValid => IsNameValid(txtFirstName.Text.Trim());

        private bool IsLastNameValid => IsNameValid(txtLastName.Text.Trim());

        private void UpdateCreatePersonForm_Shown(object sender, EventArgs e)
        {
            btnOK.Tag = Constants.OKBUTTON_TAG;
            btnUpdate.Tag = Constants.UPDATEBUTTON_TAG;
            btnCancel.Tag = Constants.CANCELBUTTON_TAG;
            btnCreate.Tag = Constants.CREATEBUTTON_TAG;
            txtPersonnumber.Tag = Constants.PERSONNUMBER_TAG;
            txtLastName.Tag = Constants.LASTNAME_TAG;
            txtFirstName.Tag = Constants.FIRSTNAME_TAG;
            dtpBirthdate.MaxDate = DateTime.Today;
            dtpBirthdate.Value = DateTime.Today;

            FormatForm();
            txtLastName.Focus();
            txtLastName.SelectionStart = 0;
            txtLastName.SelectionLength = txtLastName.Text.Length;
        }

        private void FormatForm()
        {
            if (_isCreate)
            {
                FormatForCreate();
            }
            else
            {
                FormatForUpdate();
            }
        }

        private void FormatForUpdate()
        {
            this.Text = $@"{_person.FirstName} {_person.Surname} {_person.PersonNumber}" + Constants.FORMTITLE_UPDATE;

            _isPersonValid = true;
            txtFirstName.Text = _person.FirstName;
            txtLastName.Text = _person.Surname;
            lblPersonnumberValue.Text = _person.PersonNumber;
            lblBirthdayValue.Text = _person.Birthday;
            lblGenderValue.Text = _person.Gender == Constants.SHORTED_GENDER_MALE ? Constants.GENDER_MALE : Constants.GENDER_FEMALE;

            cbGender.Visible = false;
            dtpBirthdate.Visible = false;
            txtPersonnumber.Visible = false;
            btnUpdate.Enabled = false;

            lblBirthdayValue.Visible = true;
            lblGenderValue.Visible = true;
            lblPersonnumberValue.Visible = true;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button button = (Button) sender;

            switch (button.Tag)
            {
                case Constants.OKBUTTON_TAG:
                {
                    if (!IsPersonValueChanged)
                    {
                        Close();
                    }
                    else if (IsFirstNameValid && IsLastNameValid)
                    {
                        SaveChanges();
                        Close();
                    }

                    break;
                }
                case Constants.CANCELBUTTON_TAG:
                {
                    Close();
                    break;
                }
                case Constants.UPDATEBUTTON_TAG:
                {
                    ValidatePersonName(txtLastName);
                    ValidatePersonName(txtFirstName);

                    if (IsFirstNameValid && IsLastNameValid)
                    {
                        SaveChanges();
                    }

                    break;
                }
                case Constants.CREATEBUTTON_TAG:
                {
                    CreatePerson();
                    break;
                }
            }
        }

        private void TextBoxValueChanged(object sender, EventArgs e)
        {
            var textBox = (TextBox)sender;
            statusStrip.Visible = false;

            if(textBox != null && textBox.Tag.ToString() == Constants.PERSONNUMBER_TAG)
            {
                TxtPersonnumber_TextChanged(textBox);
            }
            else
            {
                ValidatePersonName(textBox);
            }

            if (!IsFirstNameValid || !IsLastNameValid)
            {
                btnUpdate.Enabled = false;
            }
            else
            {
                btnUpdate.Enabled = true;
            }
        }

        private void SaveChanges()
        {
            _person.FirstName = _nameManipulator.GetCleanedName(txtFirstName.Text);
            _person.Surname = _nameManipulator.GetCleanedName(txtLastName.Text);

            using (DieFirmaContext context = new DieFirmaContext(new Configurator()))
            {
                var status = _personManager.UpdatePerson(_person, context);

                if (status == FimaManager.Common.Enum.StatusOfInteraction.personNotExists)
                {
                    MessageBox.Show($@"{_oldPerson.FirstName} {_oldPerson.Surname}" + Constants.NOT_EXISTS_ANYMORE, Constants.UPDATE_PERSON_MESSAGEBOX, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Close();

                    return;
                }
            }

            _oldPerson.Surname = _person.Surname;
            _oldPerson.FirstName = _person.FirstName;
            Text = $@"{_person.FirstName} {_person.Surname} {_person.PersonNumber}" + Constants.FORMTITLE_UPDATE;
            ShowStatus(Constants.CHANGES_SAVED, Color.Green);
            btnUpdate.Enabled = false;
        }

        private void FormatForCreate()
        {
            Text = Constants.FORMTITLE_CREATE;
            dtpBirthdate.MaxDate = DateTime.Now;
            dtpBirthdate.Enabled = true;
            cbGender.Enabled = true;
            txtPersonnumber.Enabled = true;

            btnOK.Visible = false;
            btnCreate.Visible = true;

            AcceptButton = btnCreate;
        }

        private void CreatePerson()
        {
            ValidateForCreate();

            if (_isPersonValid)
            {
                try
                {
                    using (DieFirmaContext context = new DieFirmaContext(new Configurator()))
                    {
                        _personManager.CreatePerson(GetPersonFromForm(), context);
                    }

                    Close();
                }
                catch (Microsoft.EntityFrameworkCore.DbUpdateException exception)
                {
                    if (exception.InnerException.Message.Contains(Constants.PERSONNUMBER_NOT_UNIQUE_EXCEPTION_MESSAGE))
                    {
                        _isPersonValid = false;
                        ShowStatus(Constants.PERSONNUMBER_ALREADY_EXIST, Color.Red);
                        txtPersonnumber.BackColor = Color.LightCoral;
                        return;
                    }

                    throw exception;
                }
            }
        }

        private Person GetPersonFromForm()
        {
            return new Person(Guid.NewGuid(), 
                _nameManipulator.GetCleanedName(txtLastName.Text), 
                _nameManipulator.GetCleanedName(txtFirstName.Text), 
                dtpBirthdate.Value.ToString(Constants.DATE_FORMAT), 
                cbGender.SelectedIndex == 0 ? Constants.SHORTED_GENDER_MALE : Constants.SHORTED_GENDER_FEMALE, txtPersonnumber.Text);
        }

        private void ValidatePersonName(TextBox textBox)
        {
            string name = _nameManipulator.GetCleanedName(textBox.Text);

            if (IsNameValid(name))
            {
                if (statusStrip.Text.Contains(textBox.Tag.ToString()))
                {
                    statusStrip.Visible = !(IsFirstNameValid && IsLastNameValid);
                    statusStrip.Text = textBox.Tag.ToString().Contains(Constants.FIRSTNAME_TAG)
                        ? txtLastName.Tag + Constants.NAME_ERROR 
                        : txtFirstName.Tag + Constants.NAME_ERROR;
                }

                textBox.BackColor = Color.White;
                return;
            }

            ShowStatus(textBox.Tag + Constants.NAME_ERROR, Color.Red);
            textBox.BackColor = Color.LightCoral;
            _isPersonValid = false;
        }

        private void ValidateForCreate()
        {
            _isPersonValid = true;
            ValidatePersonName(txtFirstName);
            ValidatePersonName(txtLastName);
            ValidatePersonnumber();
            ValidateGender();
        }

        private void ValidateGender()
        {
            if (cbGender.SelectedIndex == -1)
            {
                ShowStatus(Constants.GENDER_NOT_SELECTED, Color.Red);
                _isPersonValid = false;
            }
        }

        private void ShowStatus(string status, Color color)
        {
            statusStrip.ForeColor = color;
            statusStrip.Visible = true;
            statusStrip.Text = status;
        }

        public bool IsNameValid(string valueToProve)
        {
            return Regex.IsMatch(valueToProve, @"^[a-zA-ZäöüÄÖÜ\s-]+$") 
                   && !valueToProve.Contains("--") 
                   && !string.IsNullOrEmpty(valueToProve) 
                   && valueToProve[0] != '-' 
                   && valueToProve[^1] != '-';
        }

        private void ValidatePersonnumber()
        {
            txtPersonnumber.BackColor = Color.White;

            if (string.IsNullOrEmpty(txtPersonnumber.Text))
            {
                txtPersonnumber.BackColor = Color.LightCoral;
                ShowStatus(Constants.PERSONNUMBER_EMPTY, Color.Red);
                _isPersonValid = false;
            }
        }

        private void TxtPersonnumber_TextChanged(TextBox textBox)
        {
            textBox.BackColor = Color.White;

            if (!Regex.IsMatch(textBox.Text, @"^[a-zA-Z0-9]+$") && !string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = textBox.Text.Remove(textBox.Text.Length - 1, 1);
                textBox.SelectionStart = textBox.Text.Length;
                textBox.SelectionLength = 0;
            }

            ValidatePersonnumber();
        }
    }
}