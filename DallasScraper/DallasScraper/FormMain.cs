using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DallasScraper
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            List<PropertyRecord> list = new List<PropertyRecord>();
            string streetnumber = tbStreetNumber.Text;
            string streetName = tbStreetName.Text;

            ScrapeEngine webscrape = new ScrapeEngine();

            string content = webscrape.DownloadHTMLSearchOfAddress(streetnumber, streetName);

            list = webscrape.ParseHTMLOfResults(content);
            List<PropertyRecord> list2 = new List<PropertyRecord>();
            foreach (PropertyRecord element in list)
            {
                list2.AddRange(webscrape.SearchByName(element.OwnerName));
                
            }
            list.AddRange(list2);
            
            foreach (PropertyRecord element in list)
            {
               listBox1.Items.Add(element.ToString());
            
            }

        }
    }
}
