using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using MongoDB.Bson;
using MongoDB.Driver;



namespace Client
{
    public partial class Form1 : Form
    {

        int power = 0;
        string charging = "N";
        int systemNumber = 0;
        Thread db;
        public Form1()
        {
            InitializeComponent();
        }

        private int getSysNum()
        {
            string path = Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)).FullName;
            if (Environment.OSVersion.Version.Major >= 6)
            {
                path = Directory.GetParent(path).ToString();
                path += "\\Documents\\Neuroware\\sys.ini";
                string text = System.IO.File.ReadAllText(@path);
                int sysNum = Int32.Parse(text);
                return sysNum;
            }
            else
            {
                return 0;
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            systemNumber = getSysNum();
            Thread battery = new Thread(ShowPowerStatus);
           
            battery.Start();
            db = new Thread(MongoDB);
            db.IsBackground = true;
            db.Start();
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            //if the form is minimized  
            //hide it from the task bar  
            //and show the system tray icon (represented by the NotifyIcon control)  
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
            }
        }
        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void ShowPowerStatus()
        {
            while (true)
            {
                
                PowerStatus status = SystemInformation.PowerStatus;
                string pbarstat = status.BatteryLifePercent.ToString("P0").TrimEnd('%');
                string chargerPlugged = status.PowerLineStatus.ToString();
                int pbarCount = Int32.Parse(pbarstat);
                power = pbarCount;
                if (chargerPlugged.Equals("Online"))
                {
                    charger.Invoke(new MethodInvoker(delegate { charger.Text = "SYS is Plugged In"; }));
                    charging = "Y";
                }
                else
                {
                    charging = "N";
                }
                if(progressBar1.Value != pbarCount)
                {
                    progressBar1.Invoke(new MethodInvoker(delegate { progressBar1.Value = pbarCount; }));
                    

                }
                else
                {
                    Thread.Sleep(1000);
                }

            }

        }

        private void MongoDB()
        {
            MongoClient dbClient = new MongoClient("");
            var database = dbClient.GetDatabase("test");
            var collection = database.GetCollection<BsonDocument>("Systems");
            //var filter = Builders<BsonDocument>.Filter.Eq("sys_id", 2);
            //var update = Builders<BsonDocument>.Update.Set("sys_id", 3);
            //collection.UpdateOne(filter, update);
            while (true)
            {

                var arrayFilter = Builders<BsonDocument>.Filter.Eq("sys_id", systemNumber);
                var lifeUpdate = Builders<BsonDocument>.Update.Set("life", power);
                var chargerUpdate = Builders<BsonDocument>.Update.Set("charging", charging);
                collection.UpdateOne(arrayFilter, lifeUpdate);
                collection.UpdateOne(arrayFilter, chargerUpdate);

                Thread.Sleep(5000);
            }
        }
    }
}
