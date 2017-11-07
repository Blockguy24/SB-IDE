﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SB_IDE.Dialogs
{
    /// <summary>
    /// Interaction logic for Graduate.xaml
    /// </summary>
    public partial class Graduate : Window
    {
        public bool OK = false;
        public static string ProjectPath = "";

        public Graduate()
        {
            InitializeComponent();

            FontSize = 12 + MainWindow.zoom;
            label.FontSize = 16 + MainWindow.zoom;

            OK = false;
            textBoxGraduate.Focus();
            textBoxGraduate.Text = ProjectPath;
            buttonGraduateContinue.IsEnabled = Directory.Exists(textBoxGraduate.Text);
        }

        private void buttonGraduateFolder_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = true;
            fbd.SelectedPath = ProjectPath;
            DialogResult result = fbd.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                buttonGraduateContinue.IsEnabled = true;
                textBoxGraduate.Text = fbd.SelectedPath;
            }
        }

        private void buttonGraduateCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
            ProjectPath = textBoxGraduate.Text;
        }

        private void buttonGraduateContinue_Click(object sender, RoutedEventArgs e)
        {
            if (Directory.Exists(textBoxGraduate.Text))
            {
                OK = true;
                ProjectPath = textBoxGraduate.Text;
                Close();
            }
        }
    }
}
