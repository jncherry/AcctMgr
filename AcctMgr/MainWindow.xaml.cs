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
            dpTransDate.SelectedDate = DateTime.Now.Date;            
        }

        private void btnCancelTransaction_Click(object sender, RoutedEventArgs e)
        {
            ClearAll();
        }

        

        private void btnEnterTrans_Click(object sender, RoutedEventArgs e)
        {
            double amt, cred, deb;           

            try
            {
                if (cboTransType.SelectedIndex == 0)
                {

                    if (Double.TryParse(txtTransAmt.Text, out amt))
                    {
                        Double.TryParse(txtTotalDebit.Text, out deb);
                        txtAcctBal.Text = SubAmt(amt).ToString();
                        deb += amt;
                        txtTotalDebit.Text = deb.ToString();
                        ClearAll();
                    }
                }
                else if (cboTransType.SelectedIndex == 1)
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
                else if (cboTransType.SelectedIndex == 2)
                {
                    if (Double.TryParse(txtTransAmt.Text, out amt))
                    {
                        if (rbTransTo.IsChecked == true)
                        {
                            Double.TryParse(txtTotalCredit.Text, out cred);
                            txtAcctBal.Text = AddAmt(amt).ToString();
                            cred += amt;
                            txtTotalCredit.Text = cred.ToString();
                            ClearAll();
                        }
                        else if (rbTransFrom.IsChecked == true)
                        {
                            Double.TryParse(txtTotalDebit.Text, out deb);
                            txtAcctBal.Text = SubAmt(amt).ToString();
                            deb += amt;
                            txtTotalDebit.Text = deb.ToString();
                            ClearAll();
                        }
                        else
                        {
                            MessageBox.Show("'To' or 'From' must be selected in order to transfer funds!", "Action Required!", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
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
            rbTransFrom.Visibility = Visibility.Hidden;
            rbTransTo.Visibility = Visibility.Hidden;
        }

        public double SubAmt(double _amt)
        {
            double transAmt, newBal = 0;

            try
            {
                Double.TryParse(txtAcctBal.Text, out transAmt);
                if (transAmt >= _amt)
                {
                    newBal = transAmt - _amt;
                }
                else
                {
                    MessageBox.Show("Debit Amount Exceeds Balance!", "Overdraw Warning!!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("Error: " + ee.Message);
            }

            return newBal;
        }

        private void cboTransType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Handle Hidden radio buttons for transfer feature
            if (cboTransType.SelectedIndex == 2)
            {
                rbTransFrom.Visibility = Visibility.Visible;
                rbTransTo.Visibility = Visibility.Visible;
                lblTransferAcct.Visibility = Visibility.Visible;
                cboTransferAcct.Visibility = Visibility.Visible;
            }
            else
            {
                rbTransFrom.Visibility = Visibility.Hidden;
                rbTransTo.Visibility = Visibility.Hidden;
                lblTransferAcct.Visibility = Visibility.Hidden;
                cboTransferAcct.Visibility = Visibility.Hidden;
            }
        }
    }
}
