namespace SecondScreen
{
    public partial class Form1 : Form
    {
        Form imageForm = new Form();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Create and add the checkbox to Form1
            CheckBox displayImageCheckbox = new CheckBox
            {
                Text = "Display Image on Second Screen",
                AutoSize = true,
                Location = new Point(50, 50)
            };
            this.Controls.Add(displayImageCheckbox);

            // Setup the image form
            imageForm.FormBorderStyle = FormBorderStyle.None;
            imageForm.WindowState = FormWindowState.Maximized;
            imageForm.BackgroundImage = Image.FromFile("C:\\Users\\Sir XtC\\Documents\\AA-coding-my-projects\\C_SHARP_STUFF\\my_tests\\second_screen\\SecondScreen\\SecondScreen\\pain.jpg"); // Specify the image path
            imageForm.BackgroundImageLayout = ImageLayout.Stretch;

            // Handle the CheckedChanged event
            displayImageCheckbox.CheckedChanged += (sender, e) =>
            {
                if (displayImageCheckbox.Checked)
                {
                    DisplayImageOnSecondScreen();
                }
                else
                {
                    imageForm.Hide();
                }
            };
        }

        private void DisplayImageOnSecondScreen()
        {
            if (Screen.AllScreens.Length > 1)
            {
                Screen secondScreen = Screen.AllScreens[1]; // Assuming the second screen is the target
                imageForm.Left = secondScreen.WorkingArea.Left;
                imageForm.Top = secondScreen.WorkingArea.Top;
                imageForm.StartPosition = FormStartPosition.Manual;
                imageForm.Show();
            }
            else
            {
                MessageBox.Show("Second screen not found.");
            }
        }
    }
}
