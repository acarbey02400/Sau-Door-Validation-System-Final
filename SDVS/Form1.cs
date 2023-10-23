using Autofac;
using Business.Abstract;
using Business.Concrete;
using Core.Entities.Concrete;
using DataAccess.Concrete;
using Entities.Concrete;
using System.IO.Ports;
namespace SDVS
{
    public partial class Form1 : Form
    {
        IUserService _userService;
        IUserValidationDoorService _userValiditaionDoorService;
        IContainer _container;
        public Form1(IContainer container)
        {
            InitializeComponent();
            _container = container;
            _userService = _container.Resolve<IUserService>();
            _userValiditaionDoorService = _container.Resolve<IUserValidationDoorService>();
            userValidationDoorListed();
        }
        private void userAdd()
        {
            bool _status = false;
            if (statusCombobox.SelectedIndex == 0)
            {
                _status = true;
            }
            var result = _userService.add(new User
            {
                firstName = nameTextbox.Text,
                lastName = surnameTextbox.Text,
                UId = UIDTextbox.Text,
                userTypeId = userTypeCombobox.SelectedIndex + 1,
                status = _status,
                lastLogin = DateTime.Now
            });
            MessageBox.Show(result.Message + "\n" + result.Success.ToString());
        }



        private void userDelete()
        {
            var result = _userService.delete(_userService.getByUId(UIDTextbox.Text).Data);
        }


        private void userUpdate()
        {
            bool _status = false;
            if (statusCombobox.SelectedIndex == 0)
            {
                _status = true;
            }
            var _result = _userService.getByUId(UIDTextbox.Text);
            var result = _userService.update(new User
            {
                firstName = nameTextbox.Text,
                lastName = surnameTextbox.Text,
                status = _status,
                UId = UIDTextbox.Text,
                userTypeId = userTypeCombobox.SelectedIndex + 1,
                id = _result.Data.id,
                lastLogin = _result.Data.lastLogin
            });
        }



        private void button2_Click(object sender, EventArgs e)
        {
            UIDTextbox.Text = "Lütfen kartý okutunuz.";
            string UId = CardRead();
            if (comboBox3.SelectedIndex == 2)
            {
                nameTextbox.Enabled = true;
                surnameTextbox.Enabled = true;
                statusCombobox.Enabled = true;
                userTypeCombobox.Enabled = true;
            }
            if (comboBox3.SelectedIndex != 0)
            {
                var result = _userService.getByUId(UId.Substring(0, UId.Length - 2));
                if (result.Data == null)
                {
                    MessageBox.Show("Kullanýcý bulunamadý.");

                    return;
                }
                nameTextbox.Text = result.Data.firstName;
                surnameTextbox.Text = result.Data.lastName;
                userTypeCombobox.SelectedIndex = result.Data.userTypeId - 1;
                if (result.Data.status)
                    statusCombobox.SelectedIndex = 0;
                else statusCombobox.SelectedIndex = 1;
            }



        }

        private string CardRead()
        {

            string[] ports = SerialPort.GetPortNames();
            string[] data = { };
            string UId = "";
            SerialPort serialPort = new SerialPort(ports[0], 9600);

            serialPort.Open();
            if (serialPort.IsOpen)
            {

                UId = serialPort.ReadLine();
                UIDTextbox.Text = UId.Substring(0, UId.Length - 2);
            }
            serialPort.Close();
            return UId;
        }



        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex == 1 || comboBox3.SelectedIndex == 2)
            {
                nameTextbox.Enabled = false;
                surnameTextbox.Enabled = false;
                statusCombobox.Enabled = false;
                userTypeCombobox.Enabled = false;

            }
            else
            {
                nameTextbox.Enabled = true;
                surnameTextbox.Enabled = true;
                statusCombobox.Enabled = true;
                userTypeCombobox.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex == 0)
            {
                userAdd();
            }
            else if (comboBox3.SelectedIndex == 1)
            {
                userDelete();
            }
            else if (comboBox3.SelectedIndex == 2)
            {
                userUpdate();
            }
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void authUIdRead_Click(object sender, EventArgs e)
        {
            authUIdTextBox.Text = "Lütfen kartý okutunuz.";

            string UId = CardRead();
            var result = _userService.getByUId(UId.Substring(0, UId.Length - 2));
            if (result.Data == null)
            {
                MessageBox.Show("Kullanýcý bulunamadý.");
                authUIdTextBox.Text = "";

                return;
            }


            authNameTextBox.Text = result.Data.firstName;
            authSurNameTextBox.Text = result.Data.lastName;
            authUIdTextBox.Text = result.Data.UId;

            if (authCombobox.SelectedIndex == 2 || authCombobox.SelectedIndex == 3)
            {
                var _result = _userValiditaionDoorService.getById(result.Data.id);
                if (_result.Data == null)
                {
                    MessageBox.Show("Bu kullanýcýya ait herhangi bir yetki eklemesi/kýsýtlamasý bulunamadý.");
                    return;
                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var result = _userService.getByUId(authUIdTextBox.Text);
            if (authCombobox.SelectedIndex == 0)
            {
                restrictionOfAuth(result.Data.id);
            }
            else if (authCombobox.SelectedIndex == 1)
            {
                AddAuth(result.Data.id);
            }
            else
            {
                MessageBox.Show("lütfen bir iþlem seçiniz");
            }
        }

        private void deleteAuth(UserValidationDoor data)
        {
            _userValiditaionDoorService.delete(data);
            userValidationDoorListed();
        }

        private void updateAuth(UserValidationDoor userValidationDoor)
        {

            var result = _userValiditaionDoorService.update(new UserValidationDoor
            {
                id = userValidationDoor.id,
                doorId = authDoorCombobox.SelectedIndex + 1,
                name = userValidationDoor.name,
                startDate = authStartDateTime.Value,
                stopDate = authStopDateTime.Value,
                status = userValidationDoor.status,
                userId = userValidationDoor.userId
            });
            MessageBox.Show(result.Message);
            userValidationDoorListed();
        }

        private void AddAuth(int userId)
        {
            var result = _userValiditaionDoorService.add(new UserValidationDoor
            {
                doorId = authDoorCombobox.SelectedIndex + 1,
                userId = userId,
                name = authNameTextBox.Text + " " + "Yetki",
                startDate = authStartDateTime.Value,
                stopDate = authStopDateTime.Value,
                status = true,
            });
            MessageBox.Show(result.Message);
            userValidationDoorListed();
        }

        private void restrictionOfAuth(int userId)
        {


            var result = _userValiditaionDoorService.add(new UserValidationDoor
            {
                doorId = authCombobox.SelectedIndex + 1,
                name = authNameTextBox.Text + " " + "Kýsýt",
                startDate = authStartDateTime.Value,
                stopDate = authStopDateTime.Value,
                status = false,
                userId = userId
            });
            MessageBox.Show(result.Message);
            userValidationDoorListed();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            var result = _userService.getById(Convert.ToInt32(dataGridView1.CurrentRow.Cells["userId"].Value));
            authNameTextBox.Text = result.Data.firstName;
            authSurNameTextBox.Text = result.Data.lastName;
            authUIdTextBox.Text = result.Data.UId;
            button5.Visible = true;
            authCombobox.Enabled = false;
            userValidationDoorListed();
        }

        private void userValidationDoorListed()
        {
            dataGridView1.DataSource = _userValiditaionDoorService.getAll().Data;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            deleteAuth(_userValiditaionDoorService.getById(Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value)).Data);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            updateAuth(_userValiditaionDoorService.getById(Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value)).Data);
            button5.Visible = false;
            authCombobox.Enabled = true;

        }
    }
}