using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Client
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {
           
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                ToolTip t = new ToolTip();
                t.Show("Only numbers are allowed", textBox1, 1000);
            }
 
        }

        private bool checkSysExistence(int sysNum)
        {
            MongoClient dbClient = new MongoClient("");
            var database = dbClient.GetDatabase("test");
            var collection = database.GetCollection<BsonDocument>("Systems");
            var arrayFilter = Builders<BsonDocument>.Filter.Eq("sys_id", sysNum);
            var sysExists = collection.Find(arrayFilter).FirstOrDefault();
            if (sysExists != null)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        private void writeNewSysToDB(int sysNum)
        {
            MongoClient dbClient = new MongoClient("");
            var database = dbClient.GetDatabase("test");
            var collection = database.GetCollection<BsonDocument>("Systems");
            var newSYS = new BsonDocument { { "sys_id", sysNum }, { "life", 0 }, { "charging", "N" } 
                
        };
            collection.InsertOne(newSYS);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Get the SYS Number
            if(textBox1.Text != "")
            {
                int sysNum = Int32.Parse(textBox1.Text);
                // Check if it exists
                if (checkSysExistence(sysNum))
                {
                    MessageBox.Show("System already exists. Choose another number");
                }
                else
                {
                    // Write to local file path
                    string path = Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)).FullName;
                    if (Environment.OSVersion.Version.Major >= 6)
                    {
                        path = Directory.GetParent(path).ToString();
                        path += "\\Documents\\Neuroware";
                        DirectoryInfo di = Directory.CreateDirectory(path);
                        FileStream fs = File.Create(path + "\\sys.ini");
                        Byte[] sys = new UTF8Encoding(true).GetBytes(textBox1.Text);
                        fs.Write(sys, 0, sys.Length);
                        fs.Close();
                    }
                    // Write to MongoDB
                    writeNewSysToDB(sysNum);

                    // Show next Form
                    this.Hide();
                    var form2 = new Form1();
                    form2.Closed += (s, args) => this.Close();
                    form2.Show();
                }
            }


        }
    }
}
