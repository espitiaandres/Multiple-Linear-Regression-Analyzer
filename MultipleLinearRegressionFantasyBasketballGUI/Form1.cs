using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
namespace MultipleLinearRegressionFantasyBasketballGUI
{
    public partial class Form1 : Form
    {
        //declare any global variables here
        public string DataDirectory;
        public Form1()
        {
            InitializeComponent();           
            pictureBox1.ImageLocation = "C:\\Users\\Andres\\Documents\\Multiple-Linear-Regression-Models-Example-GUI-Example.png";
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.BackgroundImage = Properties.Resources.Basketball_GUI_Background;
            createAllSpreadSheetsAndPlotsButton.Enabled = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Anchor = AnchorStyles.None;
            label2.Anchor = AnchorStyles.None;
            browseRawDataFileButton.Anchor = AnchorStyles.None;
            domainUpDown1.Anchor = AnchorStyles.None;
            createAllSpreadSheetsAndPlotsButton.Anchor = AnchorStyles.None;
            browseRawDataFileButton.Anchor = AnchorStyles.None;
            pictureBox1.Anchor = AnchorStyles.None;
            browseRawDataFileButton.TextAlign = ContentAlignment.MiddleCenter;
            domainUpDown1.InterceptArrowKeys = true;
            UpdateInitializationFile("read");
        }
        private void Form1_FormClosing(Object sender, FormClosingEventArgs e)
        {
            UpdateInitializationFile("write");
        }
        private void UpdateInitializationFile(string ReadOrWrite)
        {
            string InitializationFile = "Process.ini.txt";
            if (ReadOrWrite == "read")
            {
                string[] InitializationData = File.ReadAllLines(InitializationFile);
                string RawDataDirectory = InitializationData[0];
                if (Directory.Exists(RawDataDirectory))
                {
                    DataDirectory = RawDataDirectory;
                }
                else
                {
                    DataDirectory = "C:\\";
                }
            }
            else //(ReadOrWrite == "write")
            {
                if(Directory.Exists(DataDirectory))
                {
                    string[] IniFileContents = new string[2];
                    IniFileContents[0] = DataDirectory;
                    File.WriteAllLines(InitializationFile, IniFileContents);
                }
            }
        } 
        private void label1_Click(object sender, EventArgs e)
        {
        }
        private void browseRawDataFileButton_Click(object sender, EventArgs e)
        {          
            OpenFileDialog browsedialog = new OpenFileDialog();  // to have an Initial Directory, its best to use an .ini file in the same folder as this project
            browsedialog.InitialDirectory = DataDirectory;
            browsedialog.Filter = "csv|*.csv"; //only allows the browsedialog to show csv files
            if (browsedialog.ShowDialog() == DialogResult.OK)
            {
                string TextToDisplay = browsedialog.FileName;
                DataDirectory = Path.GetDirectoryName(browsedialog.FileName) + "\\";
                string[] CSVfiles = Directory.GetFiles(DataDirectory, "*.csv");
                for (int i = 0; i < CSVfiles.Length; i++)
                {
                    if (!(CSVfiles[i].EndsWith("X_Transpose_X_Matrix.csv") ||
                          CSVfiles[i].EndsWith("X_Transpose_X_Matrix Inverse.csv") ||
                          CSVfiles[i].EndsWith("Beta_Matrix.csv") ||
                          CSVfiles[i].EndsWith("Category Means and STDEVs.csv") ||
                          CSVfiles[i].EndsWith("Outliers.csv")||
                          CSVfiles[i].EndsWith("ANOVA Table and 95% Double Sided Confidence Intervals.csv")))                                           
                    {
                        domainUpDown1.Items.Add(CSVfiles[i]);
                    }
                }
                if (domainUpDown1.Items.Count > 0)
                {
                    createAllSpreadSheetsAndPlotsButton.Enabled = true;
                    browseRawDataFileButton.Text = "Click down arrow to scroll all .csv raw data files in directory";
                }
                else
                {
                    createAllSpreadSheetsAndPlotsButton.Enabled = false;
                    browseRawDataFileButton.Text = "No .csv files in the directory chosen";
                }
                domainUpDown1.Text = CSVfiles[0];
                //domainUpDown1.Text = TextToDisplay;                
            }
        }
        private void label1_Click_1(object sender, EventArgs e)
        {
        }
        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {
        }
        private void createAllSpreadSheetsAndPlotsButton_Click(object sender, EventArgs e)
        {
            string FullDataFileName = domainUpDown1.Text;
            string TemplateDirectory = "C:\\Users\\Andres\\Documents\\";
            FantasyBasketballDataAnalysis.DataAnalysis dataSet = new FantasyBasketballDataAnalysis.DataAnalysis(DataDirectory, FullDataFileName, TemplateDirectory);
            createAllSpreadSheetsAndPlotsButton.Text = "Done! Check the folder for all created files";
            UpdateInitializationFile("write");
            createAllSpreadSheetsAndPlotsButton.Enabled = true;         
        }
        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
