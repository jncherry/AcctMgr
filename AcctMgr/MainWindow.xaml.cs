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

namespace AcctMgr
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

        private void btnCancelTransaction_Click(object sender, RoutedEventArgs e)
        {
            ClearAll();
        }

        private void btnEnterTrans_Click(object sender, RoutedEventArgs e)
        {
            double amt, cred, deb, trans;           

            try
            {

                if (cboTransType.SelectedIndex == 1)
                {
                
                    if (Double.TryParse(txtTransAmt.Text, out amt))
                    {
                        Double.TryParse(txtTotalCredit.Text, out cred);
                        txtAcctBal.Text = AddAmt(amt).ToString();
                        cred += amt;
                        txtTotalCredit.Text = cred.ToString();
                        ClearAll();
                    }
                    else
                    {
                        MessageBox.Show("Error! Transaction amount must be numeric!", "Invalid Input!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    
                              
                }
                else if (cboTransType.SelectedIndex == 0)
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            } 
        }

        public double AddAmt(double _amt)
        {
            double transAmt, newBal = 0;

            try
            {
                Double.TryParse(txtAcctBal.Text, out transAmt);                
                newBal = _amt + transAmt;                  
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
            }
            
            return newBal; 
        }

        public void ClearAll()
        {
            cboAccounts.SelectedIndex = -1;
            txtTransAmt.Text = "";
            cboTransType.SelectedIndex = -1;
            txtDesc.Text = "";
        }
    }
}
