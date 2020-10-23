using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DS_Project
{
    public partial class MainForm : Form
    {
        List<driver> drivers = new List<driver>();
        List<car> cars = new List<car>();
        List<client> clients = new List<client>();
        List<Admin> admins = new List<Admin>();
        int C_id = 0;
        int D_id = 0;
        int CurrentIDClient ;
        int CurrentIDDriver ;
        public MainForm()
        {
            InitializeComponent();
            DS_Project.ReadAndWrite r = new ReadAndWrite();
            r.readcars(cars);
            r.readAdmins(admins);
            r.readclients(clients);
            r.readdrivers(drivers);
            C_id = clients.Count;
            D_id = drivers.Count;

        }

        private void ClientBtn_Click(object sender, EventArgs e)
        {
            DriverPanel.Visible = false;
            ClientLoginPanel.Visible = false;
            MainPanel.Visible = false;
            ClientRegiterPanel.Visible = false;
            ClientPanel.Visible = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DriverPanel.Visible = false;
            MainPanel.Visible = true;
            ClientPanel.Visible = false;
            ClientRegiterPanel.Visible = false;
            ClientLoginPanel.Visible = false;
        }

        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            DriverPanel.Visible = false;
            ClientLoginPanel.Visible = false;
            ClientRegiterPanel.Visible = true;
            ClientPanel.Visible = false;
            MainPanel.Visible = false;
            ClientIDtxt.Text = Convert.ToString(C_id);

        }

        private void ClientRegister_Click(object sender, EventArgs e)
        {
            string ClName = ClientNametxt.Text;
            string ClID = ClientIDtxt.Text;
            string ClPass = ClientPasswordtxt.Text;

            DS_Project.client c = new client();
            bool check = c.register(ClID, ClName, ClPass, clients);
            if (check == true)
            {
                registerResult.Text = "You Registered Successfully .";
                registerResult.ForeColor = Color.Green;
                C_id++;
            }
            else if (check == false)
            {
                registerResult.Text = "please, Enter Another Name .";
                registerResult.ForeColor = Color.Red;
            }
        }

        private void BackreButt_Click(object sender, EventArgs e)
        {
            DriverPanel.Visible = false;
            MainPanel.Visible = false;
            ClientPanel.Visible = true;
            ClientRegiterPanel.Visible = false;
            ClientLoginPanel.Visible = false;
            ClientIDtxt.Text = ClientNametxt.Text = ClientPasswordtxt.Text = registerResult.Text = "";

        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            DriverPanel.Visible = false;
            ClientLoginPanel.Visible = true;
            MainPanel.Visible = false;
            ClientPanel.Visible = false;
            ClientRegiterPanel.Visible = false;
        }

        private void C_backbutt_Click(object sender, EventArgs e)
        {
            DriverPanel.Visible = false;
            ClientLoginPanel.Visible = false;
            MainPanel.Visible = false;
            ClientPanel.Visible = true;
            ClientRegiterPanel.Visible = false;
            C_passtxt.Text = C_nametxt.Text = loginResult.Text = "";
        }

        private void C_loginButt_Click(object sender, EventArgs e)
        {
            string ClName = C_nametxt.Text;
            string ClPass = C_passtxt.Text;
            int id = 0;
            DS_Project.client c = new client();
            int check = c.login(id, ClName, ClPass, clients);
            CurrentIDClient = check;
            if (check >-1)
            {
                DriverPanel.Visible = false;
                ClientFunctionsPanel.Visible = true;
                ClientLoginPanel.Visible = false;
                MainPanel.Visible = false;
                ClientPanel.Visible = false;
                ClientRegiterPanel.Visible = false;
            }
            else if (check == -1)
            {
                loginResult.Text = "Incorrect name or Password .";
                loginResult.ForeColor = Color.Red;
            }
        }

        private void Reserve_taxiButt_Click(object sender, EventArgs e)
        {
            label7.Visible = true;
            label8.Visible = true;
            PickUptxt.Visible = true;
            ArriveTotxt.Visible = true;
            ReserveDonebutt.Visible = true;
        }

        private void Client_back_Click(object sender, EventArgs e)
        {
            DriverPanel.Visible = false;
            ClientFunctionsPanel.Visible = false;
            ClientLoginPanel.Visible = true;
            MainPanel.Visible = false;
            ClientPanel.Visible = false;
            ClientRegiterPanel.Visible = false;
            C_passtxt.Text = C_nametxt.Text =  "";
            label7.Visible = false;
            label8.Visible = false;
            PickUptxt.Visible = false;
            ArriveTotxt.Visible = false;
            ReserveDonebutt.Visible = false;
            PickUptxt.Text = ArriveTotxt.Text=Reservelbl.Text = "";
        }

        private void ReserveDonebutt_Click(object sender, EventArgs e)
        {
            string pikup = PickUptxt.Text;
            string arive = ArriveTotxt.Text;
            string Dnam="w";

            DS_Project.client c = new client(C_nametxt.Text,Convert.ToString(CurrentIDClient),C_passtxt.Text);
            bool check = c.reserve_taxi(CurrentIDClient,pikup, arive, Dnam ,drivers,clients);
            if (check == true)
            {
                Reservelbl.Text = "Car Will Arrive In Minutes .";

                Reservelbl.ForeColor = Color.Green;
            }
            else if (check == false)
            {
                Reservelbl.Text = "Sorry, No Drivers Available.";
                Reservelbl.ForeColor = Color.Red;

            }
        }

        private void DriverBackButt_Click(object sender, EventArgs e)
        {
            MainPanel.Visible = true;
            ClientPanel.Visible = false;
            ClientRegiterPanel.Visible = false;
            ClientLoginPanel.Visible = false;
            DriverPanel.Visible = false;
            DriverNametxt.Text = DriverPasswordtxt.Text = Loglbl.Text = "";
        }

        private void DriverBtn_Click(object sender, EventArgs e)
        {
            MainPanel.Visible = false;
            ClientPanel.Visible = false;
            ClientRegiterPanel.Visible = false;
            ClientLoginPanel.Visible = false;
            DriverPanel.Visible = true;
        }

        private void DriverLoginButt_Click(object sender, EventArgs e)
        {
            string DName = DriverNametxt.Text;
            string DPass = DriverPasswordtxt.Text;
            bool status = true;
            int fade = 0;

            DS_Project.driver d = new driver();
            int check = d.login(fade, DPass, DName,status, drivers);
            CurrentIDDriver = check;
            if (check >-1)
            {
                DriverPanel.Visible = false;
                ClientFunctionsPanel.Visible = false;
                ClientLoginPanel.Visible = false;
                MainPanel.Visible = false;
                ClientPanel.Visible = false;
                ClientRegiterPanel.Visible = false;
                DriverFunctionsPanel.Visible = true;
            }
            else if (check == -1)
            {
                Loglbl.Text = "Incorrect name or Password .";
                Loglbl.ForeColor = Color.Red;
            }
            if(drivers[CurrentIDDriver].status==true)
            {
                statuslbl.Text = "Free" ;
                statuslbl.ForeColor = Color.Green;
            }
            else if (drivers[CurrentIDDriver].status == false)
            {
                statuslbl.Text = "Busy";
                statuslbl.ForeColor = Color.Red;
            }
        }

        private void DriverFuncBackButt_Click(object sender, EventArgs e)
        {
            MainPanel.Visible = false;
            ClientPanel.Visible = false;
            ClientRegiterPanel.Visible = false;
            ClientLoginPanel.Visible = false;
            DriverPanel.Visible = true;
            DriverFunctionsPanel.Visible = false;
            DriverNametxt.Text = DriverPasswordtxt.Text =Loglbl.Text = "";
        }

        private void ChangeStatusButt_Click(object sender, EventArgs e)
        {
            if ( drivers[CurrentIDDriver].status == true)
            {
                drivers[CurrentIDDriver].status = false;
            }
            else if (drivers[CurrentIDDriver].status == false)
            {
                drivers[CurrentIDDriver].status = true;
            }



            if (drivers[CurrentIDDriver].status == true)
            {
                statuslbl.Text = "Free";
                statuslbl.ForeColor = Color.Green;
            }
            else if (drivers[CurrentIDDriver].status == false)
            {
                statuslbl.Text = "Busy";
                statuslbl.ForeColor = Color.Red;
            }
        }

        private void AdminBtn_Click(object sender, EventArgs e)
        {
            MainPanel.Visible = false;
            ClientPanel.Visible = false;
            ClientRegiterPanel.Visible = false;
            ClientLoginPanel.Visible = false;
            DriverPanel.Visible = false;
            AdminPanel.Visible = true;
        }

        private void AdminBackButt_Click(object sender, EventArgs e)
        {
            MainPanel.Visible = true;
            ClientPanel.Visible = false;
            ClientRegiterPanel.Visible = false;
            ClientLoginPanel.Visible = false;
            DriverPanel.Visible = false;
            AdminPanel.Visible = false;
            AdminPasstxt.Text = AdminNametxt.Text = "";

        }

        private void AdminLogButt_Click(object sender, EventArgs e)
        {
            string Aname = AdminNametxt.Text;
            string Apass = AdminPasstxt.Text;
            DS_Project.Admin A = new Admin(Aname,Apass);
            bool check = A.log_in(Aname, Apass, admins);
            if (check == true)
            {
                DriverPanel.Visible = false;
                ClientFunctionsPanel.Visible = false;
                ClientLoginPanel.Visible = false;
                MainPanel.Visible = false;
                ClientPanel.Visible = false;
                ClientRegiterPanel.Visible = false;
                AdminFuncPanel.Visible = true;
                AdminPanel.Visible = false;
            }
            else if (check == false)
            {
                AdminlogResultlbl.Text = "Incorrect name or Password .";
                AdminlogResultlbl.ForeColor = Color.Red;
            }

        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            DS_Project.ReadAndWrite w = new ReadAndWrite();
            w.Writeadmins(admins);
            w.WriteCars(cars);
            w.Writeclients(clients);
            w.Writedrivers(drivers);
            this.Close();
        }

        private void AdminFuncbackButt_Click(object sender, EventArgs e)
        {
            MainPanel.Visible = false;
            ClientPanel.Visible = false;
            ClientRegiterPanel.Visible = false;
            ClientLoginPanel.Visible = false;
            DriverPanel.Visible = false;
            AdminPanel.Visible = true;
            AdminFuncPanel.Visible = false;
            AdminNametxt.Text = AdminPasstxt.Text =AdminlogResultlbl.Text= "";
        }

        private void AddCarBackButt_Click(object sender, EventArgs e)
        {
            DriverPanel.Visible = false;
            ClientFunctionsPanel.Visible = false;
            ClientLoginPanel.Visible = false;
            MainPanel.Visible = false;
            ClientPanel.Visible = false;
            ClientRegiterPanel.Visible = false;
            AdminFuncPanel.Visible = true;
            AddCarPanel.Visible = false;
            PlatNumbertxt.Text = Modeltxt.Text = Yeartxt.Text = Driveridtxt.Text = Colortxt.Text = "";
        }

        private void AddCarAgreeButt_Click(object sender, EventArgs e)
        {
            string platNum = PlatNumbertxt.Text;
            string Ccolor = Colortxt.Text;
            string Cyear = Yeartxt.Text;
            string Cmodel = Modeltxt.Text;
            string Cdriverid = Driveridtxt.Text;

            car Ca = new car(platNum, Ccolor, Cyear, Cmodel, Cdriverid);
            cars.Add(Ca);
            CarResultlbl.Text = "Car Add Successfully :)";
            CarResultlbl.ForeColor = Color.Green;
        }

        private void AddCarButt_Click(object sender, EventArgs e)
        {
            AdminFuncPanel.Visible = false;
            AddCarPanel.Visible = true;
        }

        private void AddDbackButt_Click(object sender, EventArgs e)
        {
            
            AdminFuncPanel.Visible = true;
            AddDriverPanel.Visible = false;
            DNametxt.Text = DPasstxt.Text = DSalarytxt.Text =  "";
        }

        private void AddDButt_Click(object sender, EventArgs e)
        {
            string Dname = DNametxt.Text;
            string Dpass = DPasstxt.Text;
            string Dsalary = DSalarytxt.Text;
            driver DR = new driver();
            DR.name = Dname;
            DR.password = Dpass;
            DR.salary = Dsalary;
            DR.id = Convert.ToString(drivers.Count);

            drivers.Add(DR);
            AddDresultlbl.Text = "Driver Add Successfully :)";
            AddDresultlbl.ForeColor = Color.Green;

        }

        private void AddDriverButt_Click(object sender, EventArgs e)
        {
            AdminFuncPanel.Visible = false;
            AddDriverPanel.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DriverPanel.Visible = false;
            ClientFunctionsPanel.Visible = false;
            ClientLoginPanel.Visible = false;
            MainPanel.Visible = false;
            ClientPanel.Visible = false;
            ClientRegiterPanel.Visible = false;
            DriverFunctionsPanel.Visible = true;
            DriverHistoryPanel.Visible = false;
            DriverView.Items.Clear();

        }

        private void DriverHistoryButt_Click(object sender, EventArgs e)
        {
            DriverHistoryPanel.Visible = true;
            DriverPanel.Visible = false;
            ClientFunctionsPanel.Visible = false;
            ClientLoginPanel.Visible = false;
            MainPanel.Visible = false;
            ClientPanel.Visible = false;
            ClientRegiterPanel.Visible = false;
            DriverFunctionsPanel.Visible = false;

            for (int i = 0; i < drivers[CurrentIDDriver].DriverTrips.Count; i++)
            {
                ListViewItem V = new ListViewItem(drivers[CurrentIDDriver].DriverTrips[i].pickUp);
                V.SubItems.Add(drivers[CurrentIDDriver].DriverTrips[i].client);
                V.SubItems.Add(drivers[CurrentIDDriver].DriverTrips[i].arrive);
                DriverView.Items.Add(V);
            }
        }

        private void HisCbackButt_Click(object sender, EventArgs e)
        {
            DriverHistoryPanel.Visible = false;
            DriverPanel.Visible = false;
            ClientLoginPanel.Visible = false;
            MainPanel.Visible = false;
            ClientPanel.Visible = false;
            ClientRegiterPanel.Visible = false;
            DriverFunctionsPanel.Visible = false;
            ClientFunctionsPanel.Visible = true;
            ClientHistoryPanel.Visible = false;
            ClientView.Items.Clear();
        }

        private void ViewClientHistoryButt_Click(object sender, EventArgs e)
        {
            DriverHistoryPanel.Visible = false;
            DriverPanel.Visible = false;
            ClientFunctionsPanel.Visible = false;
            ClientLoginPanel.Visible = false;
            MainPanel.Visible = false;
            ClientPanel.Visible = false;
            ClientRegiterPanel.Visible = false;
            DriverFunctionsPanel.Visible = false;
            DriverFunctionsPanel.Visible = false;
            ClientHistoryPanel.Visible = true;

            for (int i = 0; i < clients[CurrentIDClient].ClientTrips.Count; i++)
            {
                ListViewItem V = new ListViewItem(clients[CurrentIDClient].ClientTrips[i].pickUp);
                V.SubItems.Add(clients[CurrentIDClient].ClientTrips[i].arrive);
                V.SubItems.Add(clients[CurrentIDClient].ClientTrips[i].driver);
                ClientView.Items.Add(V);
            }

        }

        private void AHisBaButt_Click(object sender, EventArgs e)
        {
            DriverHistoryPanel.Visible = false;
            DriverPanel.Visible = false;
            ClientFunctionsPanel.Visible = false;
            ClientLoginPanel.Visible = false;
            MainPanel.Visible = false;
            ClientPanel.Visible = false;
            ClientRegiterPanel.Visible = false;
            DriverFunctionsPanel.Visible = false;
            DriverFunctionsPanel.Visible = false;
            ClientHistoryPanel.Visible = false;
            AdminFuncPanel.Visible = true;
            AdminHistoryPanel.Visible = false;
            AdminPanel.Visible = false;
            AdminView.Items.Clear();
        }

        private void ReportButt_Click(object sender, EventArgs e)
        {
            DriverHistoryPanel.Visible = false;
            DriverPanel.Visible = false;
            ClientFunctionsPanel.Visible = false;
            ClientLoginPanel.Visible = false;
            MainPanel.Visible = false;
            ClientPanel.Visible = false;
            ClientRegiterPanel.Visible = false;
            DriverFunctionsPanel.Visible = false;
            DriverFunctionsPanel.Visible = false;
            ClientHistoryPanel.Visible = false;
            AdminFuncPanel.Visible = false;
            AdminHistoryPanel.Visible = true;
            AdminPanel.Visible = false;

            for (int i = 0; i < drivers.Count; i++)
            {
                for (int j = 0; j < drivers[i].DriverTrips.Count; j++)
                {
                    ListViewItem V = new ListViewItem(drivers[i].name);
                    V.SubItems.Add(drivers[i].DriverTrips[j].client);
                    V.SubItems.Add(drivers[i].DriverTrips[j].pickUp);
                    V.SubItems.Add(drivers[i].DriverTrips[j].arrive);
                    AdminView.Items.Add(V);
                }
            }
        }

        private void AdminView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ClientIDtxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void ClientHistoryPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ClientRegiterPanel_Paint(object sender, PaintEventArgs e)
        {

        }
        
    }
}
