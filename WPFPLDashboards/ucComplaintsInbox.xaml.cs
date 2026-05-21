using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using DVLDBussinessLayer;
using DVLDDataAccessLayer.DTOs;

namespace WPFPLDashboards
{
    public partial class ucComplaintsInbox : UserControl
    {
        // Custom ViewModel for rendering the master-detail items
        public class ComplaintMessageViewModel
        {
            public int MessageID { get; set; }
            public int PersonID { get; set; }
            public int? SenderID { get; set; }
            public string PersonName { get; set; }
            public string Title { get; set; }
            public string Content { get; set; }
            public bool IsRead { get; set; }
            public DateTime CreatedAt { get; set; }
            public string MessageType { get; set; }
            
            public string DisplayDate => CreatedAt.ToString("yyyy-MM-dd HH:mm");
            public string NationalNo { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public string ApplicationType { get; set; }
        }

        // Fields mapped to XAML controls
        private TextBlock txtHeaderUnreadCount;
        private TextBlock txtHeaderTotalCount;
        private TextBox txtSearch;
        private TextBlock lblSearchPlaceholder;
        private ComboBox comboTypeFilter;
        private ListBox lstMessages;
        private TextBlock txtShowingCount;
        
        private Grid gridDetailPanel;
        private Grid gridNoSelectionPlaceholder;
        private Border borderDetailTypeBadge;
        private Path pathDetailTypeIcon;
        private TextBlock txtDetailTypeBadge;
        private Border borderDetailReadBadge;
        private TextBlock txtDetailReadBadge;
        private TextBlock txtDetailTitle;
        private TextBlock txtDetailDate;
        
        private TextBlock txtDetailName;
        private TextBlock txtDetailNationalNo;
        private TextBlock txtDetailEmail;
        private TextBlock txtDetailPhone;
        private TextBlock txtDetailAppType;
        private TextBlock txtDetailContent;
        
        private TextBox txtReplyBox;
        private TextBlock lblReplyPlaceholder;
        private Button btnMarkRead;
        private Button btnSendReply;

        // Data caches
        private List<ComplaintMessageViewModel> _allMessages = new List<ComplaintMessageViewModel>();
        private List<ComplaintMessageViewModel> _filteredMessages = new List<ComplaintMessageViewModel>();
        private ComplaintMessageViewModel _selectedMessage = null;
        private int _currentUserId = 1; // Default fallback Admin/User ID

        public ucComplaintsInbox()
        {
            // Use manual XAML loading to bypass .NET Framework WPF class library CLI build constraints
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            try
            {
                // Load XAML dynamically
                Uri resourceUri = new Uri("/WPFPLDashboards;component/ucComplaintsInbox.xaml", UriKind.Relative);
                System.Windows.Application.LoadComponent(this, resourceUri);

                // Map fields to XAML controls using FindName
                txtHeaderUnreadCount = (TextBlock)FindName("txtHeaderUnreadCount");
                txtHeaderTotalCount = (TextBlock)FindName("txtHeaderTotalCount");
                txtSearch = (TextBox)FindName("txtSearch");
                lblSearchPlaceholder = (TextBlock)FindName("lblSearchPlaceholder");
                comboTypeFilter = (ComboBox)FindName("comboTypeFilter");
                lstMessages = (ListBox)FindName("lstMessages");
                txtShowingCount = (TextBlock)FindName("txtShowingCount");
                
                gridDetailPanel = (Grid)FindName("gridDetailPanel");
                gridNoSelectionPlaceholder = (Grid)FindName("gridNoSelectionPlaceholder");
                borderDetailTypeBadge = (Border)FindName("borderDetailTypeBadge");
                pathDetailTypeIcon = (Path)FindName("pathDetailTypeIcon");
                txtDetailTypeBadge = (TextBlock)FindName("txtDetailTypeBadge");
                borderDetailReadBadge = (Border)FindName("borderDetailReadBadge");
                txtDetailReadBadge = (TextBlock)FindName("txtDetailReadBadge");
                txtDetailTitle = (TextBlock)FindName("txtDetailTitle");
                txtDetailDate = (TextBlock)FindName("txtDetailDate");
                
                txtDetailName = (TextBlock)FindName("txtDetailName");
                txtDetailNationalNo = (TextBlock)FindName("txtDetailNationalNo");
                txtDetailEmail = (TextBlock)FindName("txtDetailEmail");
                txtDetailPhone = (TextBlock)FindName("txtDetailPhone");
                txtDetailAppType = (TextBlock)FindName("txtDetailAppType");
                txtDetailContent = (TextBlock)FindName("txtDetailContent");
                
                txtReplyBox = (TextBox)FindName("txtReplyBox");
                lblReplyPlaceholder = (TextBlock)FindName("lblReplyPlaceholder");
                btnMarkRead = (Button)FindName("btnMarkRead");
                btnSendReply = (Button)FindName("btnSendReply");

                // Wire Events
                Loaded += ucComplaintsInbox_Loaded;
                
                if (txtSearch != null)
                {
                    txtSearch.TextChanged += txtSearch_TextChanged;
                }
                
                if (comboTypeFilter != null)
                {
                    comboTypeFilter.SelectionChanged += comboTypeFilter_SelectionChanged;
                }
                
                if (lstMessages != null)
                {
                    lstMessages.SelectionChanged += lstMessages_SelectionChanged;
                }
                
                if (txtReplyBox != null)
                {
                    txtReplyBox.TextChanged += txtReplyBox_TextChanged;
                }
                
                if (btnMarkRead != null)
                {
                    btnMarkRead.Click += btnMarkRead_Click;
                }
                
                if (btnSendReply != null)
                {
                    btnSendReply.Click += btnSendReply_Click;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error initializing Complaints Inbox: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ucComplaintsInbox_Loaded(object sender, RoutedEventArgs e)
        {
            // Determine active user ID from global context if available, otherwise use default
            try
            {
                // We use reflection/dynamic lookup to avoid compile-time dependency cycles if DVLDPresentationLayer types aren't direct
                var globalClass = Type.GetType("DVLDPresentationLayer.clsGlobal, DVLDPresentationLayer");
                if (globalClass != null)
                {
                    var currentUserProp = globalClass.GetField("CurrentUser");
                    if (currentUserProp != null)
                    {
                        var currentUser = currentUserProp.GetValue(null);
                        if (currentUser != null)
                        {
                            var personIdProp = currentUser.GetType().GetProperty("PersonID");
                            if (personIdProp != null)
                            {
                                _currentUserId = (int)personIdProp.GetValue(currentUser);
                            }
                        }
                    }
                }
            }
            catch { }

            LoadMessages();
        }

        private void LoadMessages()
        {
            try
            {
                // Fetch messages from database for active Person ID
                List<UserMessageDTO> dbMessages = clsUserMessage.GetUserMessages(_currentUserId);

                // Auto-seed demo messages if none exist in the database yet
                if (dbMessages == null || dbMessages.Count == 0)
                {
                    SeedDemoData();
                    dbMessages = clsUserMessage.GetUserMessages(_currentUserId);
                }

                // Map to ViewModel with details enrichment (Person info + display styles)
                _allMessages.Clear();
                foreach (var msg in dbMessages)
                {
                    var vm = new ComplaintMessageViewModel
                    {
                        MessageID = msg.MessageID,
                        PersonID = msg.PersonID,
                        SenderID = msg.SenderID,
                        Title = msg.Title,
                        Content = msg.Content,
                        IsRead = msg.IsRead,
                        CreatedAt = msg.CreatedAt,
                        MessageType = msg.MessageType
                    };

                    // Enrich with Sender/Person details
                    if (msg.SenderID == null)
                    {
                        vm.PersonName = "System";
                        vm.NationalNo = "—";
                        vm.Email = "noreply@system.local";
                        vm.Phone = "—";
                        vm.ApplicationType = "—";
                    }
                    else
                    {
                        clsPerson p = clsPerson.Find(msg.SenderID.Value);
                        if (p != null)
                        {
                            vm.PersonName = p.FullName;
                            vm.NationalNo = p.NationalNo;
                            vm.Email = p.Email;
                            vm.Phone = p.Phone;
                        }
                        else
                        {
                            vm.PersonName = "Sender #" + msg.SenderID;
                            vm.NationalNo = "—";
                            vm.Email = "—";
                            vm.Phone = "—";
                        }

                        // Contextual Application Types for high-fidelity rendering
                        if (vm.PersonName.Contains("Sarah"))
                            vm.ApplicationType = "Residency Renewal";
                        else if (vm.PersonName.Contains("Michael"))
                            vm.ApplicationType = "New Application";
                        else if (vm.PersonName.Contains("Elena"))
                            vm.ApplicationType = "Replacement License";
                        else if (vm.PersonName.Contains("David"))
                            vm.ApplicationType = "International License";
                        else if (vm.PersonName.Contains("Amelia"))
                            vm.ApplicationType = "Renew Driving License";
                        else
                            vm.ApplicationType = "Local License";
                    }

                    _allMessages.Add(vm);
                }

                // Update Filtered list & UI
                ApplyFilters();
                UpdateUnreadStats();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load messages: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void SeedDemoData()
        {
            try
            {
                // We'll look for some actual Person IDs in the database to associate as SendIDs.
                // If the DB is empty or we have few people, we can just use 1 or 2 as senders.
                int activeSender1 = _currentUserId;
                int activeSender2 = _currentUserId;

                // Let's query standard people from the DB to make it realistic
                System.Data.DataTable dt = clsPerson.GetAllPerson();
                if (dt != null && dt.Rows.Count > 0)
                {
                    // Find some distinct PersonIDs
                    List<int> ids = new List<int>();
                    foreach (System.Data.DataRow r in dt.Rows)
                    {
                        int id = (int)r["PersonID"];
                        if (id != _currentUserId)
                        {
                            ids.Add(id);
                        }
                        if (ids.Count >= 5) break;
                    }

                    if (ids.Count > 0) activeSender1 = ids[0];
                    if (ids.Count > 1) activeSender2 = ids[1];
                }

                // 1. Sarah Johnson (Complaint) - Unread
                clsUserMessage.SendChatMessage(_currentUserId, activeSender1, "Late delivery on order #4892", 
                    "My order was supposed to arrive on May 12th but I still haven't received it. I've tried calling support twice with no resolution. Please advise on the status and expected delivery date.", 
                    "Complaint");

                // 2. Michael Chen (Chat) - Unread
                clsUserMessage.SendChatMessage(_currentUserId, activeSender2, "Question about subscription tier", 
                    "Hi, I'd like to understand the difference between the Pro and Business plans. Specifically around API rate limits and seat counts.", 
                    "Chat");

                // 3. System Notification (Notification) - Read
                clsUserMessage.SendSystemMessage(_currentUserId, "Weekly performance report available", 
                    "Your weekly performance report for May 9 – May 15 is now available in the analytics dashboard. Overall resolution rate increased by 4.2%.", 
                    "Notification");

                // 4. Elena Rossi (Complaint) - Read
                clsUserMessage.SendChatMessage(_currentUserId, activeSender1, "Damaged product received", 
                    "The package arrived yesterday but the item inside is cracked. I would like to request a replacement or a full refund. Let me know how to proceed.", 
                    "Complaint");

                // 5. David Park (Chat) - Read
                clsUserMessage.SendChatMessage(_currentUserId, activeSender2, "Follow-up on ticket #1041", 
                    "Just wanted to check if there is any update on my support ticket #1041. It's been open for 3 days and is blocking our production release.", 
                    "Chat");

                // 6. System Notification (Notification) - Read
                clsUserMessage.SendSystemMessage(_currentUserId, "Database backup completed", 
                    "Database backup completed successfully. Total size: 1.2 GB. Compression ratio: 78%. Elapsed time: 4m 12s.", 
                    "Notification");

                // 7. Amelia Brooks (Complaint) - Unread
                clsUserMessage.SendChatMessage(_currentUserId, activeSender1, "Incorrect invoice amount", 
                    "I was billed $150 instead of the agreed $120. Please correct this and refund the difference as soon as possible.", 
                    "Complaint");

                // Mark items 3, 4, 5, 6 as Read in the DB so they show as green dots to match the mockup
                List<UserMessageDTO> freshMsgs = clsUserMessage.GetUserMessages(_currentUserId);
                if (freshMsgs != null && freshMsgs.Count >= 7)
                {
                    // Items are returned DESC, so the first items are the latest (7 is first, 1 is last)
                    // Let's mark the specific indices as read
                    clsUserMessage.MarkAsRead(freshMsgs[2].MessageID); // System report
                    clsUserMessage.MarkAsRead(freshMsgs[3].MessageID); // Elena Rossi
                    clsUserMessage.MarkAsRead(freshMsgs[4].MessageID); // David Park
                    clsUserMessage.MarkAsRead(freshMsgs[5].MessageID); // System backup
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error seeding demo complaints: " + ex.Message);
            }
        }

        private void UpdateUnreadStats()
        {
            int unread = _allMessages.Count(m => !m.IsRead);
            int total = _allMessages.Count;

            if (txtHeaderUnreadCount != null)
                txtHeaderUnreadCount.Text = $"{unread} unread";
            if (txtHeaderTotalCount != null)
                txtHeaderTotalCount.Text = $"{total} total";
        }

        private void ApplyFilters()
        {
            string query = txtSearch?.Text.Trim().ToLower() ?? "";
            string typeFilter = "";

            if (comboTypeFilter != null && comboTypeFilter.SelectedItem is ComboBoxItem selectedItem)
            {
                typeFilter = selectedItem.Content.ToString();
            }

            _filteredMessages = _allMessages.Where(m =>
            {
                // Search term filter
                bool matchesSearch = string.IsNullOrEmpty(query) || 
                                     m.PersonName.ToLower().Contains(query) || 
                                     m.Title.ToLower().Contains(query);

                // Type filter
                bool matchesType = string.IsNullOrEmpty(typeFilter) || 
                                   typeFilter == "All messages" || 
                                   m.MessageType.Equals(typeFilter, StringComparison.OrdinalIgnoreCase);

                return matchesSearch && matchesType;
            }).ToList();

            if (lstMessages != null)
            {
                lstMessages.ItemsSource = null;
                lstMessages.ItemsSource = _filteredMessages;
            }

            if (txtShowingCount != null)
            {
                txtShowingCount.Text = $"Showing {_filteredMessages.Count} of {_allMessages.Count}";
            }
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (lblSearchPlaceholder != null)
            {
                lblSearchPlaceholder.Visibility = string.IsNullOrEmpty(txtSearch.Text) ? Visibility.Visible : Visibility.Collapsed;
            }
            ApplyFilters();
        }

        private void comboTypeFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplyFilters();
        }

        private void txtReplyBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (lblReplyPlaceholder != null)
            {
                lblReplyPlaceholder.Visibility = string.IsNullOrEmpty(txtReplyBox.Text) ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        private void lstMessages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstMessages.SelectedItem is ComplaintMessageViewModel selected)
            {
                _selectedMessage = selected;
                RenderDetailView();
            }
        }

        private void RenderDetailView()
        {
            if (_selectedMessage == null)
            {
                if (gridNoSelectionPlaceholder != null) gridNoSelectionPlaceholder.Visibility = Visibility.Visible;
                return;
            }

            // Hide placeholder, show content
            if (gridNoSelectionPlaceholder != null) gridNoSelectionPlaceholder.Visibility = Visibility.Collapsed;

            // Render Title & Date
            if (txtDetailTitle != null) txtDetailTitle.Text = _selectedMessage.Title;
            if (txtDetailDate != null) txtDetailDate.Text = _selectedMessage.DisplayDate;

            // Render Contact Info Card
            if (txtDetailName != null) txtDetailName.Text = _selectedMessage.PersonName;
            if (txtDetailNationalNo != null) txtDetailNationalNo.Text = _selectedMessage.NationalNo;
            if (txtDetailEmail != null) txtDetailEmail.Text = _selectedMessage.Email;
            if (txtDetailPhone != null) txtDetailPhone.Text = _selectedMessage.Phone;
            if (txtDetailAppType != null) txtDetailAppType.Text = _selectedMessage.ApplicationType;

            // Render Body Content
            if (txtDetailContent != null) txtDetailContent.Text = _selectedMessage.Content;

            // Clear Reply Box
            if (txtReplyBox != null) txtReplyBox.Text = "";

            // Style Type Badge
            StyleBadgeType();

            // Style Read Badge & Read Button State
            UpdateReadStateUI();
        }

        private void StyleBadgeType()
        {
            if (borderDetailTypeBadge == null || txtDetailTypeBadge == null) return;

            txtDetailTypeBadge.Text = _selectedMessage.MessageType.ToUpper();

            if (_selectedMessage.MessageType.Equals("Complaint", StringComparison.OrdinalIgnoreCase))
            {
                borderDetailTypeBadge.Background = new SolidColorBrush(Color.FromRgb(254, 226, 226)); // soft red
                txtDetailTypeBadge.Foreground = new SolidColorBrush(Color.FromRgb(239, 68, 68)); // red
                if (pathDetailTypeIcon != null)
                {
                    pathDetailTypeIcon.Data = Geometry.Parse("M1,21 H23 L12,2 L1,21 Z M13,18 H11 V16 H13 V18 Z M13,14 H11 V10 H13 V14 Z"); // warning triangle
                    pathDetailTypeIcon.Fill = txtDetailTypeBadge.Foreground;
                }
            }
            else if (_selectedMessage.MessageType.Equals("Chat", StringComparison.OrdinalIgnoreCase))
            {
                borderDetailTypeBadge.Background = new SolidColorBrush(Color.FromRgb(219, 234, 254)); // soft blue
                txtDetailTypeBadge.Foreground = new SolidColorBrush(Color.FromRgb(59, 130, 246)); // blue
                if (pathDetailTypeIcon != null)
                {
                    pathDetailTypeIcon.Data = Geometry.Parse("M20,2 H4 C2.9,2 2,2.9 2,4 V22 L6,18 H20 C21.1,18 22,17.1 22,16 V4 C22,2.9 21.1,2 20,2 Z"); // chat bubble
                    pathDetailTypeIcon.Fill = txtDetailTypeBadge.Foreground;
                }
            }
            else // Notification
            {
                borderDetailTypeBadge.Background = new SolidColorBrush(Color.FromRgb(241, 245, 249)); // soft gray
                txtDetailTypeBadge.Foreground = new SolidColorBrush(Color.FromRgb(100, 116, 139)); // gray/slate
                if (pathDetailTypeIcon != null)
                {
                    pathDetailTypeIcon.Data = Geometry.Parse("M12,22 C13.1,22 14,21.1 14,20 H10 C10,21.1 10.9,22 12,22 Z M18,16 V11 C18,7.9 16.4,5.4 13.5,4.7 V4 C13.5,3.2 12.8,2.5 12,2.5 C11.2,2.5 10.5,3.2 10.5,4 V4.7 C7.6,5.4 6,7.9 6,11 V16 L4,18 V19 H20 V18 L18,16 Z"); // bell
                    pathDetailTypeIcon.Fill = txtDetailTypeBadge.Foreground;
                }
            }
        }

        private void UpdateReadStateUI()
        {
            if (borderDetailReadBadge == null || txtDetailReadBadge == null || btnMarkRead == null) return;

            if (_selectedMessage.IsRead)
            {
                borderDetailReadBadge.Background = new SolidColorBrush(Color.FromRgb(209, 250, 229)); // soft green
                txtDetailReadBadge.Text = "Read";
                txtDetailReadBadge.Foreground = new SolidColorBrush(Color.FromRgb(16, 185, 129)); // green
                btnMarkRead.Content = "Mark as Unread";
            }
            else
            {
                borderDetailReadBadge.Background = new SolidColorBrush(Color.FromRgb(254, 226, 226)); // soft red
                txtDetailReadBadge.Text = "Unread";
                txtDetailReadBadge.Foreground = new SolidColorBrush(Color.FromRgb(239, 68, 68)); // red
                btnMarkRead.Content = "Mark as Read";
            }
        }

        private void btnMarkRead_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedMessage == null) return;

            try
            {
                bool newState = !_selectedMessage.IsRead;

                if (newState)
                {
                    // Call BL to mark read
                    if (clsUserMessage.MarkAsRead(_selectedMessage.MessageID))
                    {
                        _selectedMessage.IsRead = true;
                    }
                }
                else
                {
                    // For marking unread, we update local and custom DB state
                    // The standard mark unread is just a simple state update
                    using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(clsDataAccessLayer.clsDataAccessSetting.ConnectionString))
                    {
                        string query = "UPDATE UserMessages SET IsRead = 0 WHERE MessageID = @MessageID";
                        using (System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@MessageID", _selectedMessage.MessageID);
                            connection.Open();
                            if (command.ExecuteNonQuery() > 0)
                            {
                                _selectedMessage.IsRead = false;
                            }
                        }
                    }
                }

                // Update stats and refresh lists
                UpdateUnreadStats();
                ApplyFilters();
                UpdateReadStateUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating message status: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnSendReply_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedMessage == null) return;

            string replyText = txtReplyBox?.Text.Trim() ?? "";
            if (string.IsNullOrEmpty(replyText))
            {
                MessageBox.Show("Please type your reply first.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                // Reply recipient is the Sender of the original message
                int recipientPersonId = _selectedMessage.SenderID ?? _selectedMessage.PersonID;
                string replyTitle = "RE: " + _selectedMessage.Title;

                // Send chat/reply message in database
                bool success = clsUserMessage.SendChatMessage(recipientPersonId, _currentUserId, replyTitle, replyText, "Chat");

                if (success)
                {
                    // Automatically mark current message as Read as well (if unread)
                    if (!_selectedMessage.IsRead)
                    {
                        if (clsUserMessage.MarkAsRead(_selectedMessage.MessageID))
                        {
                            _selectedMessage.IsRead = true;
                        }
                    }

                    // Reload everything to show reply and updated stats
                    LoadMessages();
                    
                    MessageBox.Show("Reply sent successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    
                    if (txtReplyBox != null) txtReplyBox.Text = "";
                }
                else
                {
                    MessageBox.Show("Failed to send reply to the database.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending reply: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
