using Microsoft.Graph;
using Azure.Identity;
using Microsoft.Graph.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;

namespace LookR
{
    public partial class Form1 : Form
    {
        private GraphServiceClient _graphClient;

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load; // Subscribe to the Load event
        }

        private async void btnSignIn_Click(object sender, EventArgs e)
        {
            try
            {
                _graphClient = await SignInAndInitializeGraphClientAsync();
                MessageBox.Show("Signed in successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Hide the login button and show the relevant controls
                btnSignIn.Visible = false;
                btnRefreshData.Visible = true;
                label1.Visible = true;
                label2.Visible = true;
                comboBox1.Visible = true;
                comboBox2.Visible = true;
                dataGridView1.Visible = true;

                // Populate mailboxes
                await PopulateMailboxesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during sign-in: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<GraphServiceClient> SignInAndInitializeGraphClientAsync()
        {
            var credential = new InteractiveBrowserCredential(new InteractiveBrowserCredentialOptions
            {
                ClientId = "13c794df-dbb1-4c56-8cd2-39a571ba4107",
                TenantId = "8ea298b1-d7bb-482d-b8fc-0ffae2500f6b"
            });

            _graphClient = new GraphServiceClient(credential, new[] { "Mail.Read", "Mail.Read.Shared", "User.Read.All" });

            return _graphClient;
        }

        private async Task PopulateMailboxesAsync()
        {
            try
            {
                // Create a list to hold the mailboxes
                var mailFolders = new List<MailboxItem>();

                // List of shared mailboxes you want to check access to
                var sharedMailboxesEmails = new List<string>
        {
            "kund@se.paam.systems",
            "info@paam.systems",
            "invoice@paam.systems",
            "order@paam-systems.se",
            "faktura@se.paam.systems",
            "info@se.paam.systems",
            "recruitment@paam.systems",
            "admin@paam.systems",
            "it@paam.systems",
            "production@paam.systems"
        };

                foreach (var sharedMailboxEmail in sharedMailboxesEmails)
                {
                    try
                    {
                        // Fetch the inbox folder of the shared mailbox to check access
                        var inboxFolder = await _graphClient.Users[sharedMailboxEmail].MailFolders["inbox"].GetAsync();

                        // If successful, add the shared mailbox to the list
                        var sharedMailboxItem = new MailboxItem
                        {
                            DisplayName = $"({sharedMailboxEmail})",
                            Id = inboxFolder.Id, // Use the retrieved Inbox ID
                            IsShared = true,
                            SharedMailboxEmail = sharedMailboxEmail
                        };

                        mailFolders.Add(sharedMailboxItem);
                    }
                    catch
                    {
                        // If access is denied or any other error occurs, skip this mailbox
                        continue;
                    }
                }

                // Bind the list to the ComboBox
                comboBox1.DataSource = mailFolders;
                comboBox1.DisplayMember = "DisplayName";
                comboBox1.ValueMember = "Id";

                // Make ComboBox visible
                comboBox1.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching mailboxes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Populate time frame options
            comboBox2.Items.Add("Last 7 Days");
            comboBox2.Items.Add("Last 30 Days");
            comboBox2.Items.Add("A Year");
            comboBox2.Items.Add("All Time");
            comboBox2.SelectedIndex = 0; // Set default selection
        }

        private async Task GetEmailMessagesAsync(TimeSpan timeSpan)
        {
            try
            {
                var startDate = DateTime.UtcNow - timeSpan;

                // Get the selected mailbox from the ComboBox
                var selectedMailbox = (MailboxItem)comboBox1.SelectedItem;
                if (selectedMailbox == null)
                {
                    MessageBox.Show("Please select a mailbox.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Fetch all mail folders from the selected mailbox
                var mailboxFolders = await _graphClient.Users[selectedMailbox.SharedMailboxEmail].MailFolders.GetAsync();

                // Dictionary to store email count per sender per folder
                var senderFolderCount = new Dictionary<string, Dictionary<string, int>>();

                foreach (var folder in mailboxFolders.Value)
                {
                    // Fetch emails from each folder
                    var messages = await _graphClient.Users[selectedMailbox.SharedMailboxEmail].MailFolders[folder.Id].Messages
                        .GetAsync((config) =>
                        {
                            config.QueryParameters.Filter = $"receivedDateTime ge {startDate.ToString("o")}";
                            config.QueryParameters.Select = new[] { "from", "receivedDateTime" };
                            config.QueryParameters.Top = 50000;
                        });

                    // Count emails by sender and store the folder name
                    foreach (var message in messages.Value)
                    {
                        var senderEmail = message.From.EmailAddress.Address;
                        var folderName = folder.DisplayName;

                        if (senderEmail.Contains("/0") || senderEmail.Contains("/O") || senderEmail.Contains("/o"))
                        {
                            continue; // Skip this email
                        }

                        if (!senderFolderCount.ContainsKey(senderEmail))
                        {
                            senderFolderCount[senderEmail] = new Dictionary<string, int>();
                        }

                        if (senderFolderCount[senderEmail].ContainsKey(folderName))
                        {
                            senderFolderCount[senderEmail][folderName]++;
                        }
                        else
                        {
                            senderFolderCount[senderEmail][folderName] = 1;
                        }
                    }
                }

                // Prepare data for display, flattening sender and folder information
                var emailData = senderFolderCount.SelectMany(kvp =>
                    kvp.Value.Select(folderKvp => new
                    {
                        Sender = kvp.Key,
                        Folder = folderKvp.Key,
                        Count = folderKvp.Value
                    })
                )
                .OrderByDescending(x => x.Count) // Sort by email count in descending order
                .ToList();

                // Calculate the total count of emails displayed
                int totalEmailCount = emailData.Sum(entry => entry.Count);

                // Update the label with the total count of emails displayed
                lblTotalCount.Text = $"Total Emails: {totalEmailCount}";

                // Bind to the DataGridView
                dataGridView1.DataSource = emailData;
                dataGridView1.Visible = true; // Ensure the DataGridView is visible
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching emails: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async void btnRefreshData_Click(object sender, EventArgs e)
        {
            // Determine the time span based on the selection
            TimeSpan timeSpan = TimeSpan.FromDays(0);
            switch (comboBox2.SelectedItem.ToString())
            {
                case "Last 7 Days":
                    timeSpan = TimeSpan.FromDays(7);
                    break;
                case "Last 30 Days":
                    timeSpan = TimeSpan.FromDays(30);
                    break;
                case "A Year":
                    timeSpan = TimeSpan.FromDays(365);
                    break;
                case "All Time":
                    timeSpan = TimeSpan.FromDays(3650); // 10 years as a rough estimate
                    break;
            }

            await GetEmailMessagesAsync(timeSpan); 
        }


    }
    public class MailboxItem
    {
        public string DisplayName { get; set; }
        public string Id { get; set; }
        public bool IsShared { get; set; }
        public string SharedMailboxEmail { get; set; }
    }
}
