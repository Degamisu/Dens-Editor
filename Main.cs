using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.text.RegularExpressions;

namespace Dens_Editor
{
    public partial class Form1 : Form
    {
        private RichTextBox richTextBox;
        private MenuStrip menuStrip;
        private ToolStripMenuItem fileMenuItem;
        private ToolStripMenuItem newMenuItem;
        private ToolStripMenuItem saveMenuItem;
        private ToolStripMenuItem loadMenuItem;

        public Form1()
        {
            InitializeComponent();

            richTextBox = new RichTextBox();
            AddTextEditor();
            AddToolbar();
        }

        private void InitializeComponent()
        {
            // Auto-generated code by Windows Forms Designer
            // Add initialization logic for controls on the form
        }

        public class SyntaxHighlighter
{
    private RichTextBox richTextBox;

    public SyntaxHighlighter(RichTextBox richTextBox)
    {
        this.richTextBox = richTextBox;
    }

    public void HighlightSyntax()
    {
        // Define your syntax highlighting rules
        var syntaxRules = new[]
        {
            new SyntaxRule("Group", Color.Blue, @"\bGroup\b"),
            new SyntaxRule("Math", Color.Red, @"\bMath\b"),
            new SyntaxRule("Haul", Color.Green, @"\bHaul\b"),
            new SyntaxRule("Funct", Color.Orange, @"\bFunct\b")
        };

        // Get the current text of the RichTextBox
        string text = richTextBox.Text;

        // Apply syntax highlighting to the text
        foreach (var rule in syntaxRules)
        {
            var matches = Regex.Matches(text, rule.Pattern);
            foreach (Match match in matches)
            {
                richTextBox.Select(match.Index, match.Length);
                richTextBox.SelectionColor = rule.Color;
            }
        }
    }

    private class SyntaxRule
    {
        public string Name { get; }
        public Color Color { get; }
        public string Pattern { get; }

        public SyntaxRule(string name, Color color, string pattern)
        {
            Name = name;
            Color = color;
            Pattern = pattern;
        }
    }
}

        private void AddTextEditor()
        {
            richTextBox = new RichTextBox();
            richTextBox.Dock = DockStyle.Fill;
            Controls.Add(richTextBox);

    SyntaxHighlighter syntaxHighlighter = new SyntaxHighlighter(richTextBox);
    syntaxHighlighter.HighlightSyntax();
}

        private void AddToolbar()
        {
            menuStrip = new MenuStrip();
            fileMenuItem = new ToolStripMenuItem("File");
            newMenuItem = new ToolStripMenuItem("New");
            saveMenuItem = new ToolStripMenuItem("Save as .dens");
            loadMenuItem = new ToolStripMenuItem("Load");

            newMenuItem.Click += NewMenuItem_Click;
            saveMenuItem.Click += SaveMenuItem_Click;
            loadMenuItem.Click += LoadMenuItem_Click;

            fileMenuItem.DropDownItems.Add(newMenuItem);
            fileMenuItem.DropDownItems.Add(saveMenuItem);
            fileMenuItem.DropDownItems.Add(loadMenuItem);

            menuStrip.Items.Add(fileMenuItem);
            Controls.Add(menuStrip);
        }

        private void NewMenuItem_Click(object sender, EventArgs e)
        {
            // Add logic for creating a new file
            // Display a success message to the user
            MessageBox.Show("New file created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SaveMenuItem_Click(object sender, EventArgs e)
        {
            // Add logic for saving the file as .dens (Degamisu N64 Script)
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Dens Script Files (*.dens)|*.dens";
            saveFileDialog.DefaultExt = "dens";
            saveFileDialog.AddExtension = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                // Save the file logic here
                File.WriteAllText(filePath, richTextBox);   

                MessageBox.Show("File saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Loads a .dens file when the Load menu item is clicked.
        private void LoadMenuItem_Click(object sender, EventArgs e)
        {
            // Add logic for loading a .dens file 
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Dens Script Files (*.dens)|*.dens";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                // Add logic for loading the .dens file here

                MessageBox.Show("File loaded successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}