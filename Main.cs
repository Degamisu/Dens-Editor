using System;
using System.IO;
using System.Windows.Forms;

namespace Dens_Editor
{
    public partial class Form1 : Form
    {
        private RichTextBox richTextBox;

        public Form1()
        {
            InitializeComponent();
            
            richTextBox = new RichTextBox();
            AddTextEditor();
        }

        private void InitializeComponent()
        {
            // Auto-generated code by Windows Forms Designer
            // Add initialization logic for controls on the form
        }

        private void AddTextEditor()
        {
            richTextBox = new RichTextBox();
            richTextBox.Dock = DockStyle.Fill;
            Controls.Add(richTextBox);
        }

        private void OpenFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Degamisu N64 Script (*.dens)|*.dens|All Files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string fileContents = File.ReadAllText(filePath);
                richTextBox.Text = fileContents;
            }
        }

        private void SaveFile()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Degamisu N64 Script (*.dens)|*.dens|All Files (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                File.WriteAllText(filePath, richTextBox.Text);
            }
        }
    }
}