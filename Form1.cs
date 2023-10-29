
namespace Dens_Editor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    }
    // logging functionality
    namespace Dens_Editor
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }

            private void InitializeComponent()
            {
                throw new NotImplementedException();
            }

            // add logging functionality
            private void Log(string message);
        // add text editor functionality
private void AddTextEditor()
{
                // Create a new instance of RichTextBox
                RichTextBox richTextBox = new RichTextBox
                {
                    // Set properties for the RichTextBox
                    Dock = DockStyle.Fill
                };

                // Add the RichTextBox control to your form
                Controls.Add(richTextBox);
}

private void OpenFile()
{
    // Create a new instance of OpenFileDialog
    OpenFileDialog openFileDialog = new OpenFileDialog();
    
    // Set properties for the OpenFileDialog
    openFileDialog.Filter = "Degamisu N64 Script (*.dens)|*.dens|";
    
    // Show the OpenFileDialog and wait for the user to select a file
    if (openFileDialog.ShowDialog() == DialogResult.OK)
    {
        // Open the selected file and read its contents
        string filePath = openFileDialog.FileName;
        string fileContents = File.ReadAllText(filePath);
        
        // Set the text of the RichTextBox to the file contents
        richTextBox.Text = fileContents;
    }
}
private void SaveFile()
{
    // Create a new instance of SaveFileDialog
    SaveFileDialog saveFileDialog = new SaveFileDialog();
    
    // Set properties for the SaveFileDialog
    saveFileDialog.Filter = "Degamisu N64 Script (*.dens)|*.dens|";
    
    // Show the SaveFileDialog and wait for the user to select a file
    if (saveFileDialog.ShowDialog() == DialogResult.OK)
    {
        // Save the contents of the RichTextBox to the selected file
        string filePath = saveFileDialog.FileName;
        File.WriteAllText(filePath, richTextBox.Text);
    }

}
        }
