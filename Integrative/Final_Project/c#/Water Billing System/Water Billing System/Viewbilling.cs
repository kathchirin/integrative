using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Water_Billing_System
{
    public partial class Viewbilling : Form
    {
        public Viewbilling()
        {
            InitializeComponent();
        }

        private HttpClient client = new HttpClient();

        public class Record
        {
            public string name { get; set; }
            public DateTime date { get; set; }
            public string month { get; set; }
            public string year { get; set; }
        }

        private async Task LoadData()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("http://localhost:3000/rec/record");

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    List<Record> records = JsonConvert.DeserializeObject<List<Record>>(jsonResponse);

                    // Bind the data to DataGridView
                    foreach (var record in records)
                    {
                        record.date = record.date.Date; // Keep only the date part
                    }

                    dgvBillR.DataSource = records;
                }
                else
                {
                    MessageBox.Show("Failed to fetch records. Status code: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching records: " + ex.Message);
            }
        }

        private async Task SearchRecords(string baseUrl, string keyword)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Constructing the URL for searching records
                    string url = $"{baseUrl}/record/search/{keyword}";

                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        List<Record> records = JsonConvert.DeserializeObject<List<Record>>(jsonResponse);

                        foreach (var record in records)
                        {
                            record.date = record.date.Date; // Keep only the date part
                        }
                        // Assuming dgvBillR is a DataGridView instance already declared in your form
                        dgvBillR.DataSource = records;
                    }
                    else
                    {
                        MessageBox.Show($"Error: {response.ReasonPhrase}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception: {ex.Message}");
            }
        }

        private async void Viewbilling_Load(object sender, EventArgs e)
        {
            await LoadData();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            MainMenu mm = new MainMenu();
            this.Hide();
            mm.Show();
        }

        private async void BtnSearch_Click(object sender, EventArgs e)
        {
            // Base URL of your API
            string baseUrl = "http://localhost:3000/rec";

            // Keyword to search
            string keyword = TbxSearch.Text;

            // Search records
            dgvBillR.Columns.Clear();
            await SearchRecords(baseUrl, keyword);
        }
    }
}
