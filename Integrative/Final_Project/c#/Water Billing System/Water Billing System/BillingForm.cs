using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Newtonsoft.Json;
using static Water_Billing_System.BillingForm;

namespace Water_Billing_System
{
    public partial class BillingForm : Form
    {
        public BillingForm()
        {
            InitializeComponent();
        }

        string billid = "";
        public class ClientId
        {
            public string last_name { get; set; }
            public string first_name { get; set; }
            public string month { get; set; }
            public string year { get; set; }
        }
        public class Client
        {
            public int client_id { get; set; }
            public string last_name { get; set; }
            public string first_name { get; set; }
            public string contact_no { get; set; }
            public string purok { get; set; }
        }

        private async Task LoadClientsAsync()
        {
            string apiUrl = "http://localhost:3000/api/clients";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        Client[] clients = JsonConvert.DeserializeObject<Client[]>(jsonResponse);
                        dgvClientRecord.DataSource = clients;
                    }
                    else
                    {
                        MessageBox.Show("Failed to retrieve data from the API. Status code: " + response.StatusCode);
                    }
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show("An error occurred while sending the request: " + ex.Message);
                    MessageBox.Show("Warning: Connection to the API is lost. Please check your network connection and try again.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        public class ResponseResult
        {
            public string message { get; set; }
            public object result { get; set; }
        }

        private static readonly HttpClient client = new HttpClient();

        private async Task UpdateBillingInfo()
        {
            try
            {
                string url = "http://localhost:3000/bill/billing/update"; // Replace with your actual API URL
                HttpResponseMessage response = await client.PostAsync(url, null);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseResult>(responseBody);

                MessageBox.Show(result.message);
            }
            catch (HttpRequestException e)
            {
                MessageBox.Show($"Request error: {e.Message}");
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error: {e.Message}");
            }
        }

        private async Task FetchBillingInfo(int clientId)
        {
            try
            {
                string paidUrl = $"http://localhost:3000/bill/billing/paid/{clientId}"; 
                string unpaidUrl = $"http://localhost:3000/bill/billing/unpaid/{clientId}"; 

                var paidBillingTask = client.GetAsync(paidUrl);
                var unpaidBillingTask = client.GetAsync(unpaidUrl);

                await Task.WhenAll(paidBillingTask, unpaidBillingTask);

                var paidBillingResponse = await paidBillingTask;
                var unpaidBillingResponse = await unpaidBillingTask;

                paidBillingResponse.EnsureSuccessStatusCode();
                unpaidBillingResponse.EnsureSuccessStatusCode();

                string paidBillingBody = await paidBillingResponse.Content.ReadAsStringAsync();
                string unpaidBillingBody = await unpaidBillingResponse.Content.ReadAsStringAsync();

                var paidBillingInfo = JsonConvert.DeserializeObject<List<BillingInfo>>(paidBillingBody);
                var unpaidBillingInfo = JsonConvert.DeserializeObject<List<BillingInfo>>(unpaidBillingBody);

                dgvPaid.DataSource = paidBillingInfo;
                dgvUnpaid.DataSource = unpaidBillingInfo;
            }
            catch (HttpRequestException e)
            {
                MessageBox.Show($"Request error: {e.Message}");
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error: {e.Message}");
            }
        }

        public class BillingInfo
        {
            public int billing_id { get; set; }
            public string month { get; set; }
            public int year { get; set; }
            public string status { get; set; }
        }

        private async void BillingForm_Load(object sender, EventArgs e)
        {
           await UpdateBillingInfo();
           await LoadClientsAsync();
        }

        private void BtnSearchClient_Click(object sender, EventArgs e)
        {
        }

        private async Task checkID(int clientId)
        {
            var apiUrl = $"http://localhost:3000/bill/client/{clientId}";
            using (var client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        var clientData = JsonConvert.DeserializeObject<Client>(jsonResponse);

                        if (clientData != null)
                        {
                            LbName.Text = $"{clientData.first_name}  {clientData.last_name}";
                        }
                        else
                        {
                            MessageBox.Show("Client data is empty.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Failed to retrieve client. Status code: " + response.StatusCode);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error retrieving client: " + ex.Message);
                }
            }
        }

        private static async Task<int> GetUnpaidBillingCount(int clientId)
        {
            try
            {
                var apiUrl = $"http://localhost:3000/bill/billing/unpaid/count/{clientId}";

                using (var client = new HttpClient())
                {
                    Console.WriteLine($"Sending request to: {apiUrl}");
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    Console.WriteLine($"Received response with status code: {response.StatusCode}");

                    response.EnsureSuccessStatusCode(); // Ensure response is successful

                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Received JSON response: {jsonResponse}");

                    var unpaidCount = JsonConvert.DeserializeObject<int>(jsonResponse);
                    Console.WriteLine($"Unpaid billing count: {unpaidCount}");
                    return unpaidCount;
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error retrieving unpaid billing count: {ex.Message}");
                return -1; // Or handle the error accordingly
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error parsing JSON response: {ex.Message}");
                return -1; // Or handle the error accordingly
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return -1; // Or handle the error accordingly
            }
        }


        private static async Task PayBilling(int billingId)
        {
            var apiUrl = $"http://localhost:3000/bill/billing/pay/{billingId}";

            try
            {
                using (var client = new HttpClient())
                {
                    HttpResponseMessage response = await client.PutAsync(apiUrl, null);

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Billing paid successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Failed to pay billing. Status code: " + response.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error paying billing: " + ex.Message);
            }
        }

        public class Bill
        {
            public string name { get; set; }
            public DateTime date { get; set; }
            public string month { get; set; }
            public int year { get; set; }
        }

        private static async Task AddBillRecord(Bill bill)
        {
            // Check if the name property is null
            if (string.IsNullOrEmpty(bill.name))
            {
                Console.WriteLine("Error: Name property cannot be null or empty.");
                return;
            }

            var apiUrl = "http://localhost:3000/bill/billing/record";

            try
            {
                using (var client = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(bill);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);
                    string responseBody = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Bill record added successfully.");
                    }
                    else
                    {
                        Console.WriteLine($"Failed to add bill record. Status code: {response.StatusCode}");
                        Console.WriteLine($"Response content: {responseBody}");
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error adding bill record: {ex.Message}");
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error parsing JSON response: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }





        private async void BtnPaid_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(billid);
                await PayBilling(id);
                RtbReceipt.Clear();
                RtbReceipt.Text += ("*************************************");
                RtbReceipt.Text += ("**\t           BARANGAY BASAK           ");
                RtbReceipt.Text += ("**\t       WATER BILLING SYSTEM       **");
                RtbReceipt.Text += ("***********************************");
                RtbReceipt.Text += ("Brgy. Basak, San Juan, Southern Leyte\n");
                RtbReceipt.Text += ("Date: " + DateTime.Now + "\n\n");
                RtbReceipt.Text += ("Name: " + LbName.Text + "\n");
                RtbReceipt.Text += ("Month Paid: " + LbMonth.Text + "\n");
                RtbReceipt.Text += ("Year: " + LbYear.Text + "\n");
                RtbReceipt.Text += ("Balance: " + LbBalance.Text + "\n");
                RtbReceipt.Text += ("Amount: 20\n");
                RtbReceipt.Text += ("\n                             Signature:         ");

                dgvPaid.Columns.Clear();
                dgvUnpaid.Columns.Clear();
                await FetchBillingInfo(database.idContent);
                int rowCount = dgvUnpaid.RowCount;
                int total = rowCount * 20;
                LbBalance.Text = total.ToString();

              

            }
            catch { }
            DateTime now = DateTime.Now;
            Bill bill = new Bill
            {
               name = LbName.Text,
               date = now, 
               month = LbMonth.Text,
               year = int.Parse(LbYear.Text)
            };

            LbMonth.ResetText();
            LbYear.ResetText();

            await AddBillRecord(bill);
           
        }

        private void BtnBack_MouseLeave(object sender, EventArgs e)
        {
            BtnBack.BackColor = Color.White;
        }

        private void BtnBack_MouseMove(object sender, MouseEventArgs e)
        {
            BtnBack.BackColor = Color.Red;
        }

       

        private void BtnPrintReceipt_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.Show();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            MainMenu main = new MainMenu();
            this.Hide();
            main.Show();
        }

        private async void dgvClientRecord_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.RowIndex >= dgvClientRecord.Rows.Count)
                {
                    return; // Invalid row index, exit method
                }

                DataGridViewRow row = dgvClientRecord.Rows[e.RowIndex];
                database.idContent = int.Parse(row.Cells[0].Value.ToString());
                await checkID(database.idContent);

                await FetchBillingInfo(database.idContent);
                int rowCount = dgvUnpaid.RowCount;
                int total = rowCount * 20;
                LbBalance.Text = total.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvUnpaid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                billid = dgvUnpaid.Rows[e.RowIndex].Cells[0].Value.ToString();
                LbMonth.Text = dgvUnpaid.Rows[e.RowIndex].Cells[1].Value.ToString();
                LbYear.Text = dgvUnpaid.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
            catch { }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(RtbReceipt.Text, new Font("Century Gothic", 36, FontStyle.Bold), Brushes.Black, new Point(10, 10));
        }
    }
}
