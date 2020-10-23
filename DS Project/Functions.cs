using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DS_Project
{
    struct Trip
    {
        public string pickUp;
        public string arrive;
        public string driver;
        public string client;
    }

    class car
    {
        public string plate_number;
        public string color;
        public string year;
        public string model;
        public string driver_id;

        public car()
        {
            plate_number = " ";
            color = " ";
            year = null;
            model = " ";
            driver_id = null;
        }

        public car(string n, string c, string y, string m, string d)
        {
            plate_number = n;
            color = c;
            year = y;
            model = m;
            driver_id = d;
        }
    }

    class driver
    {
        public string name;
        public string password;
        public string id;
        public string salary;
        public bool status;
        public List<Trip> DriverTrips;

        public driver()
        {
            DriverTrips = new List<Trip>();
            name = " ";
            password = "";
            id = "";
            salary = "";
            status = true;
        }

        public driver(string n,string Pass ,string i, string s,bool st)
        {
            DriverTrips = new List<Trip>();
            name = n;
            password = Pass;
            id = i;
            salary = s;
            status = st;
        }

        public int login(int iD,string pass, string nam,bool S,List<driver> D)
        {
            bool check = false;

            for (int i = 0; i < D.Count; i++)
            {
                if (nam == D[i].name && pass == D[i].password)
                {
                    iD = Convert.ToInt32(D[i].id);
                    S = D[i].status;
                    check = true;
                    break;
                }
            }
            if (check == true)
                return iD;

            else
                return -1;
        }

        public bool receive_client_request()
        {
            if (status == true)
            {
                return true;
            }
            else
                return false;
        }

        public bool change_his_status()
        {
            if (status == true)
                return false;

            else 
                return true;


        }

        public void view_all_trips(Trip []t,driver driv)
        {
            t = new Trip[100]; 
            string A,P; 
            for(int i=0;i<driv.DriverTrips.Count;i++)
            {
                A=driv.DriverTrips[i].arrive;
                P = driv.DriverTrips[i].pickUp;
                t[i].pickUp = P;
                t[i].arrive = A;
            }
        }
    }

    class client
    {
        public string c_name;
        public string c_id;
        public string c_password;
        public List<Trip> ClientTrips;

        public client()
        {
            ClientTrips = new List<Trip>();
            c_name = "";
            c_id = "";
            c_password = "";
        }

        public client(string nam, string ID, string pass)
        {
            ClientTrips = new List<Trip>();
            c_name = nam ;
            c_id =ID ;
            c_password = pass ;
        }

        public bool register(string iD, string nam, string pass, List<client> cl)
        {
            bool check = true;
            for (int i = 0; i < cl.Count; i++)
            {
                if (nam == cl[i].c_name)
                {
                    check = false;
                    break;
                }
            }
            if (check == false)
                return false;

            else
            {
                client nclient = new client();
                nclient.c_name = nam;
                nclient.c_password = pass;
                nclient.c_id = iD;
                cl.Add(nclient);

                return true;
            }

        }


        public int login(int Id, string nam, string pass, List<client> cl)
        {
            bool check = false;
            for (int i = 0; i < cl.Count; i++)
            {
                if (nam == cl[i].c_name && pass == cl[i].c_password)
                {
                    Id =i; 
                    check = true;
                    break;
                }
            }
            if (check == true)
                return Id;

            else
                return -1;
        }

        public bool reserve_taxi(int clientID, string pickup, string Arrive,string Dname ,List<driver> Dr, List<client> Cl)
        {
            
            bool check = false;
            for (int i = 0; i < Dr.Count; i++)
            {
                if (Dr[i].status == true)
                {
                    check = true;
                    Dr[i].status = false;
                    Dname = Dr[i].name;
                    Trip T = new Trip();
                    T.pickUp = pickup; T.arrive = Arrive;
                    T.client = Cl[clientID].c_name;
                    T.driver = Dname;
                    Dr[i].DriverTrips.Add(T);
                    Cl[clientID].ClientTrips.Add(T);
                    break;
                }
            }
            if (check == true)
            {
                return true;
            }
            else
                return false;

        }

         void viewClientHistory(Trip[] t, client cli)
        {
            t = new Trip[100];
            string A, P;
            for (int i = 0; i < cli.ClientTrips.Count; i++)
            {
                A = cli.ClientTrips[i].arrive;
                P = cli.ClientTrips[i].pickUp;
                t[i].pickUp = P;
                t[i].arrive = A;
            }

        }
    }

    class Admin
    {
        public string a_name;
        public string a_password;

        public Admin(string nam,string pass)
        {
            a_name = nam;
            a_password = pass;
        }
        public bool log_in(string nam, string pass, List<Admin> Adm)
        {
            bool check = false;
            for (int i = 0; i < Adm.Count; i++)
            {
                if (nam == Adm[i].a_name && pass == Adm[i].a_password)
                {
                    check = true;
                    break;
                }
            }
            if (check == true)
                return true;

            else
                return false;
        }

        public void add_driver(string Dname, string Dpass, string Dsalary, List<driver> drivers)
        {
            driver DR = new driver();
            DR.name = Dname;
            DR.password = Dpass;
            DR.salary = Dsalary;
            DR.id = Convert.ToString(drivers.Count);

            drivers.Add(DR);
        }

        public void add_car(string platNum, string Ccolor, string Cyear, string Cmodel, string Cdriverid, car c, List<car> Ca)
        {
            car C = new car(platNum, Ccolor, Cyear, Cmodel, Cdriverid);
            Ca.Add(C);
        }

        public void reportOfAllTrips()
        {

        }
    }

}