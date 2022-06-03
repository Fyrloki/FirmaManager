using FimaManager.Business.Interfaces;
using FimaManager.Common.Configs;
using FimaManager.Common.Enum;
using FirmaManager.Common;
using FirmaManager.EntityFrameworkData.Models;
using FirmaManager.WinFormsClient.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FirmaManager.WinFormsClient
{
    public partial class PersonViewForm : Form
    {
        private readonly INameManipulator _nameManipulator;
        private readonly IPersonManager _personManager;
        private string _firstNameSearchValue;
        private string _lastNameSearchValue;

        public PersonViewForm(IPersonManager personManager, INameManipulator nameManipulator)
        {
            _personManager = personManager;
            _nameManipulator = nameManipulator;

            InitializeComponent();
        }

        private void PersonForm_Shown(object sender, EventArgs e)
        {
            dgvPersonList.RowHeadersVisible = false;
            txtLastName.Focus();
        }

        private void TxtFirstName_Enter(object sender, EventArgs e)
        {
            txtFirstName.SelectAll();
        }

        private void TxtLastName_Enter(object sender, EventArgs e)
        {
            txtLastName.SelectAll();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnSearch.Focus();

            SaveSearchValues();

            using DieFirmaContext context = new DieFirmaContext(new Configurator());

            FillPersonsInPersonView(_personManager.GetPersons(new Person(_lastNameSearchValue, _firstNameSearchValue), context));
        }

        private void SaveSearchValues()
        {
            _firstNameSearchValue = string.IsNullOrEmpty(txtFirstName.Text.Trim()) ? Constants.WILDCARD : _nameManipulator.GetCleanedName(txtFirstName.Text);
            _lastNameSearchValue = string.IsNullOrEmpty(txtLastName.Text.Trim()) ? Constants.WILDCARD : _nameManipulator.GetCleanedName(txtLastName.Text);
        }

        private void FillPersonsInPersonView(List<Person> persons)
        {
            dgvPersonList.Rows.Clear();

            if(messageStrip.Text == Constants.NO_PERSON_FOUND_MESSAGE)
            {
                messageStrip.Visible = false;
            }

            if (!persons.Any())
            {
                messageStrip.Visible = true;
                messageStrip.Text = Constants.NO_PERSON_FOUND_MESSAGE;
                return;
            }

            int rowIndex = 0;

            foreach (Person person in persons)
            {
                AddRowToPersonView(rowIndex, person);
                rowIndex++;
            }

            dgvPersonList.ClearSelection();
        }

        private void AddRowToPersonView(int rowIndex, Person person)
        {
            dgvPersonList.Rows.Add();
            dgvPersonList.Rows[rowIndex].Cells[0].Value = person.Surname;
            dgvPersonList.Rows[rowIndex].Cells[1].Value = person.FirstName;
            dgvPersonList.Rows[rowIndex].Cells[2].Value = GetConvertedGender(person.Gender);
            dgvPersonList.Rows[rowIndex].Cells[3].Value = person.Birthday;
            dgvPersonList.Rows[rowIndex].Cells[4].Value = person.PersonNumber;
            dgvPersonList.Rows[rowIndex].Cells[5].Value = person.Uid;
        }

        private void DgvPersonList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void DgvPersonList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            BtnUpdate_Click(sender, e);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            string message = Constants.SURE_REQUEST_PART_ONE_MESSAGEBOX + $" {GetPersonName()} " + Constants.SURE_REQUEST_PART_TWO_MESSAGEBOX;

            if (MessageBoxDisplayer.ShowYesNoQuestion(message, Constants.DELETE_TITLE_MESSAGEBOX) == DialogResult.Yes)
            {
                DeletePerson();
                BtnSearch_Click(null, null);
            }
        }

        private void DeletePerson()
        {
            using (DieFirmaContext context = new DieFirmaContext(new Configurator()))
            {
                StatusOfInteraction status = _personManager.DeletePerson(GetSelectedPerson(), context);

                if (status == StatusOfInteraction.personNotExists)
                {
                    messageStrip.Visible = false;
                    MessageBox.Show(GetPersonName() + Constants.PERSON_ALREADY_DELETED_MESSAGE, Constants.DELETE_TITLE_MESSAGEBOX, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }
            }

            messageStrip.Visible = true;
            messageStrip.Text = Constants.DELETE_PERSON_SUCCESSFUL;
        }

        private Person GetSelectedPerson()
        {
            return new Person((Guid)dgvPersonList.SelectedCells[5].Value,
                (string)dgvPersonList.SelectedCells[0].Value,
                (string)dgvPersonList.SelectedCells[1].Value,
                (string)dgvPersonList.SelectedCells[3].Value,
                (string)dgvPersonList.SelectedCells[2].Value == Constants.GENDER_MALE ? Constants.SHORTED_GENDER_MALE : Constants.SHORTED_GENDER_FEMALE,
                (string)dgvPersonList.SelectedCells[4].Value);
        }

        private string GetPersonName()
        {
            Person person = GetSelectedPerson();

            return $"{person.FirstName} {person.Surname}";
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            Guid guid = GetUidOfSelectedPerson();

            using (DieFirmaContext context = new DieFirmaContext(new Configurator()))
            {
                Person person = _personManager.GetPerson(guid, context);

                if (person is null)
                {
                    MessageBox.Show($"{GetPersonName()}" + Constants.NOT_EXISTS_ANYMORE, Constants.UPDATE_PERSON_MESSAGEBOX, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    BtnSearch_Click(null, null);
                    return;
                }

                new UpdateCreatePersonForm(_personManager, _nameManipulator, person).ShowDialog();

            }
            
            BtnSearch_Click(null, null);
        }

        private void BtnNewPerson_Click(object sender, EventArgs e)
        {
            new UpdateCreatePersonForm(_personManager, _nameManipulator).ShowDialog();
            
            BtnSearch_Click(null, null);
        }

        private object GetConvertedGender(string gender) => gender == Constants.SHORTED_GENDER_MALE ? Constants.GENDER_MALE : Constants.GENDER_FEMALE;

        private Guid GetUidOfSelectedPerson() => (Guid)dgvPersonList.SelectedCells[5].Value;
    }
}