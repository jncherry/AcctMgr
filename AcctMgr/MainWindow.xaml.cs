﻿using System;
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
        
        //Enter button functionality for all transaction types
        private void btnEnterTrans_Click(object sender, RoutedEventArgs e)
        {
            double amt;           

            try
            {
                if (cboTransType.SelectedIndex == 0)
                {

                    if (Double.TryParse(txtTransAmt.Text, out amt))
                    {
                        debit(amt);
                    }
                }
                else if (cboTransType.SelectedIndex == 1)
                {                   
                
                    if (Double.TryParse(txtTransAmt.Text, out amt))
                    {
                        credit(amt);
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
                            credit(amt);
                        }
                        else if (rbTransFrom.IsChecked == true)
                        {
                            credit(amt);
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


        //Public Functions for Transactions
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
            //Handle Hidden radio buttons, label, and combo box for transfer feature
            if (cboTransType.SelectedIndex == 2)
            {
                rbTransFrom.Visibility = Visibility.Visible;
                rbTransTo.Visibility = Visibility.Visible;
            }
            else
            {
                rbTransFrom.Visibility = Visibility.Hidden;
                rbTransTo.Visibility = Visibility.Hidden;
            }
        }
        
        public void ClearAll()
        {
            txtTransAmt.Text = "";
            cboTransType.SelectedIndex = -1;
            txtDesc.Text = "";
            rbTransFrom.Visibility = Visibility.Hidden;
            rbTransTo.Visibility = Visibility.Hidden;
        }

        public void debit(double amt)
        {
            double deb;
            Double.TryParse(txtTotalDebit.Text, out deb);
            txtAcctBal.Text = SubAmt(amt).ToString();
            deb += amt;
            txtTotalDebit.Text = deb.ToString();
            ClearAll();
        }

        public void credit(double amt)
        {
            double cred;
            Double.TryParse(txtTotalCredit.Text, out cred);
            txtAcctBal.Text = AddAmt(amt).ToString();
            cred += amt;
            txtTotalCredit.Text = cred.ToString();
            ClearAll();
        }

        private void AcctMgrMain_Loaded(object sender, RoutedEventArgs e)
        {

            AcctMgr.DBCheckingDataSet dBCheckingDataSet = ((AcctMgr.DBCheckingDataSet)(this.FindResource("dBCheckingDataSet")));
            // Load data into the table Checking. You can modify this code as needed.
            AcctMgr.DBCheckingDataSetTableAdapters.CheckingTableAdapter dBCheckingDataSetCheckingTableAdapter = new AcctMgr.DBCheckingDataSetTableAdapters.CheckingTableAdapter();
            dBCheckingDataSetCheckingTableAdapter.Fill(dBCheckingDataSet.Checking);
            System.Windows.Data.CollectionViewSource checkingViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("checkingViewSource")));
            checkingViewSource.View.MoveCurrentToFirst();
        }
    }
}
