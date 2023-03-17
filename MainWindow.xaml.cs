using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
// Ronda Rutherford
// March 15 2023
// Lecture Example 
namespace LectureExample_03_2023_Images_Enumerable
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PopulateFilterComboBox();
        }

        public void PopulateFilterComboBox()
        {
            // Clears combo box (to prevent out of range error)
            cbFilter.Items.Clear();
            // Manually populates the combo box with the Photo Filter options, corresponding to the enumeration InstagramPost.PhotoFilter
            cbFilter.Items.Add($"{InstagramPost.PhotoFilter.Regular}"); // 0
            cbFilter.Items.Add($"{InstagramPost.PhotoFilter.Greyscale}"); // 1
            // selects index 0 (Regular)
            cbFilter.SelectedIndex = 0;
        }

        public string GetFilePath()
        {
            // Opens a file dialog to show a path to a file
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                return op.FileName;
            }
            else
            {
                return "";
            }
        }
        public BitmapImage CreateBitmapImage(string filePath)
        {
            return new BitmapImage(new Uri(filePath));
        }
        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            string filePath = GetFilePath();
            if (filePath != "")
            {
                lblFilePath.Content = filePath;
                imgSelectedImage.Source = CreateBitmapImage(filePath);
            }
            else
            {
                MessageBox.Show("Please select a valid picture");
            }
        }

        private void btnPost_Click(object sender, RoutedEventArgs e)
        {
            NewPost();
        }

        public void NewPost()
        {
            // Creates an instance of the InstagramPost with currently selected filter, photo, header and body
            InstagramPost.PhotoFilter filter = (InstagramPost.PhotoFilter)cbFilter.SelectedIndex;
            string header = txtHeader.Text;
            string body = txtBody.Text;
            string filePath = (string)lblFilePath.Content;
            InstagramPost post = new InstagramPost(filter, header, body, filePath);
            // Appends header and body of post to runDisplay
            runDisplay.Text += post.ToString();
            // Updates image to picture associated with post (applies filter)
            imgSelectedImage.Source = post.Picture;
        }

    }
}
