using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using WpfApp1.ViewModel;

namespace WpfApp1.View
{
    
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Declaration of a instance of MainViewModel object that will be loaded when MainWindows is runnig
        /// </summary>
        private MainViewModel viewModel;

        private static readonly Regex _regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text

        public MainWindow()
        {
            InitializeComponent();
            this.viewModel = new MainViewModel();
            this.DataContext = this.viewModel; 
        }

        /// <summary>
        /// The event handler is previewing text input. 
        /// Here a regular expression matches the text input only if it is not a number,
        /// and then it is not made to entry textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Text To validate</param>
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

     

        

        
    }
}
