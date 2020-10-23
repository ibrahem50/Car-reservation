using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DS_Project
{
    class ReadAndWrite
    {
        public void WriteCars(List<car> a)
        {
            FileStream fs = new FileStream("cars.txt", FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(fs);
            for (int i = 0; i < a.Count; i++)
            {
                sw.WriteLine(a[i].plate_number + '@' + a[i].color + '@' + a[i].year + '@' + a[i].model + '@' + a[i].driver_id);
            }
            sw.Close();
        }

        public void Writedrivers(List<driver> a)
        {
            FileStream fs = new FileStream("drivers.txt", FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(fs);
            for (int i = 0; i < a.Count; i++)
            {
                sw.Write(a[i].name + '@' + a[i].password + '@' + a[i].id + '@' + a[i].salary + '@' + a[i].status);
                for (int j = 0; j < a[i].DriverTrips.Count; j++)
                {
                    sw.Write('@' + a[i].DriverTrips[j].arrive + '@' + a[i].DriverTrips[j].pickUp + '@' + a[i].DriverTrips[j].client);
                }
                sw.WriteLine();
            }
            sw.Close();
        }

        public void Writeclients(List<client> C)
        {
            FileStream fs = new FileStream("clients.txt", FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(fs);
            for (int i = 0; i < C.Count; i++)
            {
                sw.Write(C[i].c_name + '@' + C[i].c_id + '@' + C[i].c_password);
                for(int j=0;j<C[i].ClientTrips.Count;j++)
                {
                    sw.Write('@' + C[i].ClientTrips[j].arrive + '@' + C[i].ClientTrips[j].pickUp + '@' + C[i].ClientTrips[j].driver);
                }
                sw.WriteLine();
            }
            sw.Close();
        }

        public void Writeadmins(List<Admin> A)
        {
            FileStream fs = new FileStream("admins.txt", FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(fs);
            for (int i = 0; i < A.Count; i++)
            {
                sw.WriteLine(A[i].a_name + '@' + A[i].a_password);
            }
            sw.Close();
        }


        public void readcars(List<car> ca)
        {
            string outputs;
            string[] output;
            FileStream fs = new FileStream("cars.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            while (sr.Peek() != -1)
            {
                outputs = sr.ReadLine();
                output = outputs.Split('@');
                car c = new car(output[0], output[1], output[2], output[3], output[4]);
                ca.Add(c);
            }
            sr.Close();
        }



        public void readdrivers(List<driver> Dd)
        {
            string outputs;
            string[] output;
            FileStream fs = new FileStream("drivers.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            while (sr.Peek() != -1)
            {
                outputs = sr.ReadLine();
                output = outputs.Split('@');
                driver Dr = new driver(output[0],output[1], output[2], output[3], bool.Parse(output[4]));
                for (int i = 5; i < output.Length;i++)
                {
                    Trip T = new Trip();
                    T.arrive = output[i]; T.pickUp = output[i + 1]; T.client = output[i + 2];
                    Dr.DriverTrips.Add(T);
                    i += 2;
                }
                    Dd.Add(Dr);
            }
            sr.Close();
        }
        public void readclients(List<client> cl)
        {
            string outputs;
            string[] output;
            FileStream fs = new FileStream("clients.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            while (sr.Peek() != -1)
            {
                outputs = sr.ReadLine();
                output = outputs.Split('@');
                client c = new client(output[0], output[1], output[2]);
                for (int i = 3; i < output.Length; i++)
                {
                    Trip T = new Trip();
                    T.arrive = output[i]; T.pickUp = output[i + 1]; T.driver = output[i + 2];
                    c.ClientTrips.Add(T);
                    i += 2;
                }
                cl.Add(c);
            }
            sr.Close();
        }

        public void readAdmins(List<Admin> Ad)
        {
            string outputs;
            string[] output;
            FileStream fs = new FileStream("admins.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            while (sr.Peek() != -1)
            {
                outputs = sr.ReadLine();
                output = outputs.Split('@');
                Admin A = new Admin(output[0], output[1]);
                Ad.Add(A);
            }
            sr.Close();
        }

    }
    
}
