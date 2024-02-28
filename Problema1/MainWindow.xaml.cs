using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Problema1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int[] tabel;
        Random random = new Random();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            int.TryParse(tbxCount.Text, out int numar);
            if (numar <= 0)
            {
                MessageBox.Show("Trebuie un numar de elemente mai mare decat 0", "Eroare!");
                return;
            }
            tabel = new int[numar];
            for (int i = 0; i < numar; i++)
            {
                int randomNumber = random.Next(0, 200);
                tabel[i] = randomNumber;
                tbInitial.Text += $"{randomNumber}, ";
            }
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            int[] elemente = (from i in tabel
                           where i % 2 != 0 && i >= 20 && i <= 100
                           select i).ToArray();
            if(elemente.Length  == 0)
            {
                tbResultText.Text = "Nu au fost gasite numere";
                return;
            }
            tbResultText.Text = $"Masivul rezultat: {elemente.Length}";
            foreach (var numar in elemente)
            {
                tbResult.Text += $"{numar}, ";
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            tbxCount.Clear();
            tbInitial.Text = string.Empty;
            tbResult.Text = string.Empty;
            tbResultText.Text = "Masiv rezultat: ";
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}