using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Task
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void NewFile_Click(object sender, RoutedEventArgs e)
        {
            textBox.Document.Blocks.Clear();
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                TextRange range = new TextRange(textBox.Document.ContentStart, textBox.Document.ContentEnd);
                using (FileStream fileStream = new FileStream(openFileDialog.FileName, FileMode.Open))
                {
                    range.Load(fileStream, DataFormats.Rtf);
                }
            }
        }

        private void SaveFile_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                TextRange range = new TextRange(textBox.Document.ContentStart, textBox.Document.ContentEnd);
                using (FileStream fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create))
                {
                    range.Save(fileStream, DataFormats.Rtf);
                }
            }
        }

        private void Copy_Click(object sender, RoutedEventArgs e)
        {
            textBox.Copy();
        }

        private void Paste_Click(object sender, RoutedEventArgs e)
        {
            textBox.Paste();
        }

        private void Cut_Click(object sender, RoutedEventArgs e)
        {
            textBox.Cut();
        }

        private void Undo_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.CanUndo)
                textBox.Undo();
        }

        private void TextColor_Click(object sender, RoutedEventArgs e)
        {
            var selectedText = textBox.Selection;
            if (!selectedText.IsEmpty)
            {
                selectedText.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.Red);
            }
        }

        private void ClearFormatting_Click(object sender, RoutedEventArgs e)
        {
            var selectedText = textBox.Selection;
            if (!selectedText.IsEmpty)
            {
                selectedText.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.Black);
                selectedText.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Normal);
            }
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Text Editor version 1.0\nCreated for educational purposes.", "About");
        }
    }
}
