using System;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace SecureExaminer
{
    public partial class MainForm : Form
    {
        private ChromiumWebBrowser browser;
        private KeyboardHook _hook;
        private Panel navPanel;
        private Button backButton;
        private Button forwardButton;
        private Button closeButton;

        private string examUrl;

        public MainForm()
        {
            InitializeComponent();

            // ✅ Keyboard Hook set (disable Alt+Tab, WinKey etc.)
            _hook = new KeyboardHook();

            // ✅ Window full screen setup
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;

            // ✅ Prompt for Exam URL
            examUrl = Prompt.ShowDialog("Enter Exam URL", "SecureExaminer");
            if (string.IsNullOrEmpty(examUrl))
            {
                Application.Exit();
                return;
            }

            // ✅ Top Navigation Panel
            navPanel = new Panel
            {
                Height = 40,
                Dock = DockStyle.Top,
                BackColor = System.Drawing.Color.LightGray
            };
            this.Controls.Add(navPanel);

            // ✅ Back Button
            backButton = new Button
            {
                Text = "Back",
                Width = 80,
                Top = 5,
                Left = 10
            };
            backButton.Click += BackButton_Click;
            navPanel.Controls.Add(backButton);

            // ✅ Forward Button
            forwardButton = new Button
            {
                Text = "Forward",
                Width = 80,
                Top = 5,
                Left = 100
            };
            forwardButton.Click += ForwardButton_Click;
            navPanel.Controls.Add(forwardButton);

            // ✅ Close Button
            closeButton = new Button
            {
                Text = "Close",
                Width = 80,
                Top = 5,
                Left = navPanel.Width - 90,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            closeButton.Click += CloseButton_Click;
            navPanel.Controls.Add(closeButton);


            // ✅ Browser Setup
            browser = new ChromiumWebBrowser(examUrl)
            {
                MenuHandler = new CustomMenuHandler(),
                RequestHandler = new CustomRequestHandler(), // ✅ This line add karo
                Dock = DockStyle.None,
                Top = navPanel.Bottom,
                Left = 0,
                Width = this.ClientSize.Width,
                Height = this.ClientSize.Height - navPanel.Height,
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right
            };
            this.Controls.Add(browser);

            browser.BringToFront();
            navPanel.BringToFront();


            // ✅ Panel resize event to fix Close button when resizing
            navPanel.Resize += NavPanel_Resize;
        }

        private void NavPanel_Resize(object sender, EventArgs e)
        {
            closeButton.Left = navPanel.Width - closeButton.Width - 10;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            if (browser.CanGoBack)
            {
                browser.Back();
            }
        }

        private void ForwardButton_Click(object sender, EventArgs e)
        {
            if (browser.CanGoForward)
            {
                browser.Forward();
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _hook.Dispose();
            base.OnFormClosed(e);
        }
    }
}
