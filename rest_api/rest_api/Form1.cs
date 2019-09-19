using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using GMap.NET.MapProviders;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System.Net.Http;

namespace rest_api
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public async void button1_Click(object sender, EventArgs e)
        {
            //Static.EditableText = textBox1.Text;
            api_helper h = new api_helper();
            var q = "";
            try
            {
                q = await h.PhoneApiAsync(textBox1.Text);
            }
            catch(HttpRequestException)
            {
                MessageBox.Show("Check the internet connection", "Internet error");
            }
            //var q = Task.Run(() => h.PhoneApiAsync());
            //q.Wait();
            //string x = await h.PhoneApiAsync();
            //PhoneParameters s = JsonConvert.DeserializeObject<PhoneParameters>(q.Result);
            PhoneParameters s = JsonConvert.DeserializeObject<PhoneParameters>(q);
            if(s != null)
            {
                textBox2.Text = (s.valid);
                textBox2.Enabled = false;
                textBox3.Text = (s.number);
                textBox3.Enabled = false;
                textBox4.Text = (s.local_format);
                textBox4.Enabled = false;
                textBox5.Text = (s.international_format);
                textBox5.Enabled = false;
                textBox6.Text = (s.country_prefix);
                textBox6.Enabled = false;
                textBox7.Text = (s.country_code);
                textBox7.Enabled = false;
                textBox8.Text = (s.country_name);
                textBox8.Enabled = false;
                textBox9.Text = (s.location);
                textBox9.Enabled = false;
                textBox10.Text = (s.carrier);
                textBox10.Enabled = false;
                textBox11.Text = (s.line_type);
                textBox11.Enabled = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            //Static.EditableText = textBox12.Text;
            api_helper h1 = new api_helper();

            var q = "";
            try
            {
                q = await h1.IPApiAsync(textBox12.Text);
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Check the internet connection", "Internet error");
            }
            //var t = Task.Run(() => h1.IPApiAsync());
            //t.Wait();
            //string x = await h1.IPApiAsync();
            //t.Wait();
            IPParameters s1 = JsonConvert.DeserializeObject<IPParameters>(q);

            //bool b = String.IsNullOrEmpty(q);
            if (!String.IsNullOrEmpty(q))
            {
                try
                {
                    textBox13.Text = (s1.org);
                    textBox13.Enabled = false;
                    textBox14.Text = (s1.hostname);
                    textBox14.Enabled = false;
                    textBox15.Text = (s1.city);
                    textBox15.Enabled = false;
                    textBox16.Text = (s1.region);
                    textBox16.Enabled = false;
                    textBox17.Text = (s1.country);
                    textBox17.Enabled = false;
                    textBox18.Text = (s1.loc);
                    textBox18.Enabled = false;
                    textBox19.Text = (s1.postal);
                    textBox19.Enabled = false;

                    map.DragButton = MouseButtons.Left;
                    map.MapProvider = GMapProviders.GoogleMap;

                    string coord = s1.loc;
                    string[] coordList = coord.Split(',');

                    string lat = "";
                    string longt = "";
                    foreach (string coord1 in coordList)
                    {
                        lat = coordList[0];
                        longt = coordList[1];
                    }

                    double latitude = Convert.ToDouble(lat);
                    double longtitude = Convert.ToDouble(longt);
                    map.Position = new PointLatLng(latitude, longtitude);
                    map.MinZoom = 1;
                    map.MaxZoom = 100;
                    map.Zoom = 15;

                    PointLatLng point = new PointLatLng(latitude, longtitude);
                    GMapMarker marker = new GMarkerGoogle(point, GMarkerGoogleType.blue_dot);
                    GMapOverlay markers = new GMapOverlay("markers");
                    markers.Markers.Add(marker);
                    map.Overlays.Add(markers);
                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("Enter a vlid IP address", "IP not valid");
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
