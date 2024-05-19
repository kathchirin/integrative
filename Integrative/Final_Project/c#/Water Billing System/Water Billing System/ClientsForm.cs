using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Windows.Forms;

namespace Water_Billing_System
{
    public partial class ClientsForm : Form
    {
        public ClientsForm()
        {
            InitializeComponent();
        }
        private HttpClient client = new HttpClient();


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
                        dgvClientsR.DataSource = clients;
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

        // Assuming you have a Client class that matches the structure of your API response
        public class Client
        {
            public int client_id { get; set; }
            public string last_name { get; set; }
            public string first_name { get; set; }
            public string middle_name { get; set; }
            public string contact_no { get; set; }
            public string purok { get; set; }
            public string month { get; set; }
            public int year { get; set; }
            public DateTime date { get; set; }
        }

        public class Clients
        {
            public string lastName { get; set; }
            public string firstName { get; set; }
            public string middleName { get; set; }
            public string contactNo { get; set; }
            public string purok { get; set; }
        }

        public class Clientupdate
        {
            [JsonProperty("firstName")]
            public string FirstName { get; set; }

            [JsonProperty("middleName")]
            public string MiddleName { get; set; }

            [JsonProperty("lastName")]
            public string LastName { get; set; }

            [JsonProperty("contactNo")]
            public string ContactNo { get; set; }

            public Clientupdate(string firstName, string middleName, string lastName, string contactNo)
            {
                FirstName = firstName;
                MiddleName = middleName;
                LastName = lastName;
                ContactNo = contactNo;
            }

            public string ToJson()
            {
                return JsonConvert.SerializeObject(this);
            }
        }

        private async Task AddClientAsync()
        {
            string apiUrl = "http://localhost:3000/api/client";

            Clients newClient = new Clients
            {
                lastName = TbxLastN.Text,
                firstName = TbxFirstN.Text,
                middleName = TbxMiddleN.Text,
                contactNo = TbxContactNo.Text,
                purok = TbxPurok.Text
            };

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string jsonClient = JsonConvert.SerializeObject(newClient);
                    StringContent content = new StringContent(jsonClient, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Client added successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Failed to add client. Status code: " + response.StatusCode);
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


        private async void ClientsForm_Load(object sender, EventArgs e)
        {
            BtnUpdate.Hide();
            BtnDelete.Hide();
            LbID.Hide();

            await LoadClientsAsync();



        }

        private async void BtnAdd_Click(object sender, EventArgs e)
        {
            await AddClientAsync();
            dgvClientsR.Columns.Clear();
            await LoadClientsAsync();

        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            MainMenu main = new MainMenu();
            this.Hide();
            main.Show();

        }

        private void BtnBack_MouseMove(object sender, MouseEventArgs e)
        {
            BtnBack.BackColor = Color.Red;
        }

        private void BtnBack_MouseLeave(object sender, EventArgs e)
        {
            BtnBack.BackColor = Color.White;
        }

        private void BtnClear_MouseMove(object sender, MouseEventArgs e)
        {
            BtnClear.BackColor = Color.Red;
        }

        private void BtnClear_MouseLeave(object sender, EventArgs e)
        {
            BtnClear.BackColor = Color.White;
        }

        private void dgvClientsR_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                BtnAdd.Hide();
                BtnUpdate.Show();
                BtnDelete.Show();
                LbID.Text = dgvClientsR.Rows[e.RowIndex].Cells[0].Value.ToString();
                TbxLastN.Text = dgvClientsR.Rows[e.RowIndex].Cells[1].Value.ToString();
                TbxFirstN.Text = dgvClientsR.Rows[e.RowIndex].Cells[2].Value.ToString();
                TbxMiddleN.Text = dgvClientsR.Rows[e.RowIndex].Cells[3].Value.ToString();
                TbxContactNo.Text = dgvClientsR.Rows[e.RowIndex].Cells[4].Value.ToString();
                TbxPurok.Text = dgvClientsR.Rows[e.RowIndex].Cells[5].Value.ToString();
            }
            catch { }
        }

        private async void BtnUpdate_Click(object sender, EventArgs e)
        {
            var client = new Clientupdate(
           TbxFirstN.Text,
           TbxMiddleN.Text,
           TbxLastN.Text,
           TbxContactNo.Text
         );

            var json = client.ToJson();
            string url = "http://localhost:3000/api/client";
            string clientId = LbID.Text;

            using (var httpClient = new HttpClient())
            {
                try
                {
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await httpClient.PutAsync($"{url}/{clientId}", content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Client updated successfully!");
                        dgvClientsR.Columns.Clear();
                        await LoadClientsAsync();

                    }
                    else
                    {
                        MessageBox.Show($"Error: {response.ReasonPhrase}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Exception: {ex.Message}");
                }
            }
        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            // Get client ID from a text box or any input source
            string clientId = LbID.Text;

            // Ensure the clientId is not empty or invalid
            if (string.IsNullOrEmpty(clientId))
            {
                MessageBox.Show("Please enter a valid client ID.");
                return;
            }

            // Replace with your actual API endpoint
            string url = $"http://localhost:3000/api/client/{clientId}";

            using (var httpClient = new HttpClient())
            {
                try
                {
                    // Log the URL being called
                    Console.WriteLine($"Sending DELETE request to: {url}");

                    var response = await httpClient.DeleteAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Client deleted successfully!");

                        // Clear the DataGridView columns and reload the clients
                        dgvClientsR.Columns.Clear();
                        await LoadClientsAsync();
                    }
                    else
                    {
                        // Log detailed error message
                        string errorMessage = $"Error: {response.StatusCode} - {response.ReasonPhrase}";
                        MessageBox.Show(errorMessage);
                        Console.WriteLine(errorMessage);
                    }
                }
                catch (HttpRequestException httpEx)
                {
                    // Log detailed HTTP request exception
                    string httpErrorMessage = $"HTTP Request Exception: {httpEx.Message}";
                    MessageBox.Show(httpErrorMessage);
                    Console.WriteLine(httpErrorMessage);
                }
                catch (Exception ex)
                {
                    // Log detailed general exception
                    string generalErrorMessage = $"General Exception: {ex.Message}";
                    MessageBox.Show(generalErrorMessage);
                    Console.WriteLine(generalErrorMessage);
                }
            }

        }

        private async void BtnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = TbxSearch.Text;

            // Replace with your actual API endpoint
            string url = $"http://localhost:3000/api/clients/search?term={Uri.EscapeDataString(searchTerm)}";

            using (var httpClient = new HttpClient())
            {
                try
                {
                    var response = await httpClient.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        Client[] clients = JsonConvert.DeserializeObject<Client[]>(jsonResponse);
                        dgvClientsR.DataSource = clients;
                    }
                    else
                    {
                        MessageBox.Show($"Error: {response.ReasonPhrase}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Exception: {ex.Message}");
                }
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            dgvClientsR.Columns.Clear();
            await LoadClientsAsync();
        }
    }
}
