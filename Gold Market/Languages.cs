using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gold_Market
{
    class Languages : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region Control Binding 

        private bool vendorview;
        public bool VendorView
        {
            get
            {
                return vendorview;
            }
            set
            {
                vendorview = value;
                OnPropertyChanged(nameof(VendorView));
            }
        }
        private bool vendorlistview;
        public bool VendorListView
        {
            get
            {
                return vendorlistview;
            }
            set
            {
                vendorlistview = value;
                OnPropertyChanged(nameof(VendorListView));
            }
        }









        #endregion









        private string flowdirection;
        public string FlowDirection
        {
            get
            {
                return flowdirection;
            }
            set
            {
                flowdirection = value;
                OnPropertyChanged(nameof(FlowDirection));
            }
        }
        private string supplierbtn;
        public string Supplierbtn
        {
            get
            {
                return supplierbtn;
            }
            set
            {
                supplierbtn = value;
                OnPropertyChanged(nameof(Supplierbtn));
            }
        }
        private string deletebtn;
        public string Deletebtn
        {
            get
            {
                return deletebtn;
            }
            set
            {
                deletebtn = value;
                OnPropertyChanged(nameof(Deletebtn));
            }
        }
        private string editbtn;
        public string Editbtn
        {
            get
            {
                return editbtn;
            }
            set
            {
                editbtn = value;
                OnPropertyChanged(nameof(Editbtn));
            }
        }
        private string addbtn;
        public string Addbtn
        {
            get
            {
                return addbtn;
            }
            set
            {
                addbtn = value;
                OnPropertyChanged(nameof(Addbtn));
            }
        }
        private string cancel;
        public string Cancel
        {
            get
            {
                return cancel;
            }
            set
            {
                cancel = value;
                OnPropertyChanged(nameof(Cancel));
            }
        }
        private string vendornamelbl;
        public string VendorNamelbl
        {
            get
            {
                return vendornamelbl;
            }
            set
            {
                vendornamelbl = value;
                OnPropertyChanged(nameof(VendorNamelbl));
            }
        }
        private string addlbl;
        public string Addlbl
        {
            get
            {
                return addlbl;
            }
            set
            {
                addlbl = value;
                OnPropertyChanged(nameof(Addlbl));
            }
        }
        private string karatgoldlbl;
        public string Karatgoldlbl
        {
            get
            {
                return karatgoldlbl;
            }
            set
            {
                karatgoldlbl = value;
                OnPropertyChanged(nameof(Karatgoldlbl));
            }
        }
        private string addkaratgoldlbl;
        public string AddKaratGoldlbl
        {
            get
            {
                return addkaratgoldlbl;
            }
            set
            {
                addkaratgoldlbl = value;
                OnPropertyChanged(nameof(AddKaratGoldlbl));
            }
        }
        private string vendorslbl;
        public string Vendorslbl
        {
            get
            {
                return vendorslbl;
            }
            set
            {
                vendorslbl = value;
                OnPropertyChanged(nameof(Vendorslbl));
            }
        }


        private string karatgoldnamelbl;
        public string KaratGoldNamelbl
        {
            get
            {
                return karatgoldnamelbl;
            }
            set
            {
                karatgoldnamelbl = value;
                OnPropertyChanged(nameof(KaratGoldNamelbl));
            }
        }
        private string vendornumberlbl;
        public string VendorNumberlbl
        {
            get
            {
                return vendornumberlbl;
            }
            set
            {
                vendornumberlbl = value;
                OnPropertyChanged(nameof(VendorNumberlbl));
            }
        }
        private string karatgoldamountlbl;
        public string KaratGoldAmountlbl
        {
            get
            {
                return karatgoldamountlbl;
            }
            set
            {
                karatgoldamountlbl = value;
                OnPropertyChanged(nameof(KaratGoldAmountlbl));
            }
        }
        private string inventorylbl;
        public string Inventorylbl
        {
            get
            {
                return inventorylbl;
            }
            set
            {
                inventorylbl = value;
                OnPropertyChanged(nameof(Inventorylbl));
            }
        }
        private string purchasinglbl;
        public string Purchasinglbl
        {
            get
            {
                return purchasinglbl;
            }
            set
            {
                purchasinglbl = value;
                OnPropertyChanged(nameof(Purchasinglbl));
            }
        }
        private string newpurchaselbl;
        public string NewPurchaselbl
        {
            get
            {
                return newpurchaselbl;
            }
            set
            {
                newpurchaselbl = value;
                OnPropertyChanged(nameof(NewPurchaselbl));
            }
        }
        private string karatgoldweightlbl;
        public string Karatgoldweightlbl
        {
            get
            {
                return karatgoldweightlbl;
            }
            set
            {
                karatgoldweightlbl = value;
                OnPropertyChanged(nameof(Karatgoldweightlbl));
            }
        }
        private string goldhandcostlbl;
        public string GoldHandCostlbl
        {
            get
            {
                return goldhandcostlbl;
            }
            set
            {
                goldhandcostlbl = value;
                OnPropertyChanged(nameof(GoldHandCostlbl));
            }
        }

        private string paidingoldlbl;
        public string PaidinGoldlbl
        {
            get
            {
                return paidingoldlbl;
            }
            set
            {
                paidingoldlbl = value;
                OnPropertyChanged(nameof(PaidinGoldlbl));
            }
        }
        private string addpaymentlbl;
        public string AddPaymentlbl
        {
            get
            {
                return addpaymentlbl;
            }
            set
            {
                addpaymentlbl = value;
                OnPropertyChanged(nameof(AddPaymentlbl));
            }
        }
        private string totalpaymentlbl;
        public string TotalPaymentlbl
        {
            get
            {
                return totalpaymentlbl;
            }
            set
            {
                totalpaymentlbl = value;
                OnPropertyChanged(nameof(TotalPaymentlbl));
            }
        }
        private string itemnamelbl;
        public string Itemnamelbl
        {
            get
            {
                return itemnamelbl;
            }
            set
            {
                itemnamelbl = value;
                OnPropertyChanged(nameof(Itemnamelbl));
            }
        }

        private string totalcostlbl;
        public string TotalCostlbl
        {
            get
            {
                return totalcostlbl;
            }
            set
            {
                totalcostlbl = value;
                OnPropertyChanged(nameof(TotalCostlbl));
            }
        }

        private string totalpaidingoldlbl;
        public string TotalPaidinGoldlbl
        {
            get
            {
                return totalpaidingoldlbl;
            }
            set
            {
                totalpaidingoldlbl = value;
                OnPropertyChanged(nameof(TotalPaidinGoldlbl));
            }
        }
        private string totalpurchaselbl;
        public string TotalPurchaselbl
        {
            get
            {
                return totalpurchaselbl;
            }
            set
            {
                totalpurchaselbl = value;
                OnPropertyChanged(nameof(TotalPurchaselbl));
            }
        }
        private string editpurchaselbl;
        public string EditPurchaselbl
        {
            get
            {
                return editpurchaselbl;
            }
            set
            {
                editpurchaselbl = value;
                OnPropertyChanged(nameof(EditPurchaselbl));
            }
        }
        private string newcustomerlbl;
        public string NewCustomerlbl
        {
            get
            {
                return newcustomerlbl;
            }
            set
            {
                newcustomerlbl = value;
                OnPropertyChanged(nameof(NewCustomerlbl));
            }
        }
        private string customerslbl;
        public string Customerslbl
        {
            get
            {
                return customerslbl;
            }
            set
            {
                customerslbl = value;
                OnPropertyChanged(nameof(Customerslbl));
            }
        }
        private string customernamelbl;
        public string CustomerNamelbl
        {
            get
            {
                return customernamelbl;
            }
            set
            {
                customernamelbl = value;
                OnPropertyChanged(nameof(CustomerNamelbl));
            }
        }


        private string customernumberlbl;
        public string CustomerNumberlbl
        {
            get
            {
                return customernumberlbl;
            }
            set
            {
                customernumberlbl = value;
                OnPropertyChanged(nameof(CustomerNumberlbl));
            }
        }

        private string accountinglbl;
        public string Accountinglbl
        {
            get
            {
                return accountinglbl;
            }
            set
            {
                accountinglbl = value;
                OnPropertyChanged(nameof(Accountinglbl));
            }
        }

        private string newpaymentlbl;
        public string NewPaymentlbl
        {
            get
            {
                return newpaymentlbl;
            }
            set
            {
                newpaymentlbl = value;
                OnPropertyChanged(nameof(NewPaymentlbl));
            }
        }
        private string paidincashlbl;
        public string PaidInCashlbl
        {
            get
            {
                return paidincashlbl;
            }
            set
            {
                paidincashlbl = value;
                OnPropertyChanged(nameof(PaidInCashlbl));
            }
        }
        private string chequenumberlbl;
        public string ChequeNumberlbl
        {
            get
            {
                return chequenumberlbl;
            }
            set
            {
                chequenumberlbl = value;
                OnPropertyChanged(nameof(ChequeNumberlbl));
            }
        }
        private string chequeholderlbl;
        public string ChequeHolderlbl
        {
            get
            {
                return chequeholderlbl;
            }
            set
            {
                chequeholderlbl = value;
                OnPropertyChanged(nameof(ChequeHolderlbl));
            }
        }
        private string duedatelbl;
        public string DueDatelbl
        {
            get
            {
                return duedatelbl;
            }
            set
            {
                duedatelbl = value;
                OnPropertyChanged(nameof(DueDatelbl));
            }
        }
        private string chequevaluelbl;
        public string ChequeValuelbl
        {
            get
            {
                return chequevaluelbl;
            }
            set
            {
                chequevaluelbl = value;
                OnPropertyChanged(nameof(ChequeValuelbl));
            }
        }
        private string banknamelbl;
        public string BankNamelbl
        {
            get
            {
                return banknamelbl;
            }
            set
            {
                banknamelbl = value;
                OnPropertyChanged(nameof(BankNamelbl));
            }
        }

        private string debitslbl;
        public string Debitslbl
        {
            get
            {
                return debitslbl;
            }
            set
            {
                debitslbl = value;
                OnPropertyChanged(nameof(Debitslbl));
            }
        }
        private string noteslbl;
        public string Noteslbl
        {
            get
            {
                return noteslbl;
            }
            set
            {
                noteslbl = value;
                OnPropertyChanged(nameof(Noteslbl));
            }
        }
        private string editpaymentlbl;
        public string EditPaymentlbl
        {
            get
            {
                return editpaymentlbl;
            }
            set
            {
                editpaymentlbl = value;
                OnPropertyChanged(nameof(EditPaymentlbl));
            }
        }
        private string newdebitlbl;
        public string NewDebitlbl
        {
            get
            {
                return newdebitlbl;
            }
            set
            {
                newdebitlbl = value;
                OnPropertyChanged(nameof(NewDebitlbl));
            }
        }
        private string debitvaluelbl;
        public string DebitValuelbl
        {
            get
            {
                return debitvaluelbl;
            }
            set
            {
                debitvaluelbl = value;
                OnPropertyChanged(nameof(DebitValuelbl));
            }
        }

        private string editdebitlbl;
        public string EditDebitlbl
        {
            get
            {
                return editdebitlbl;
            }
            set
            {
                editdebitlbl = value;
                OnPropertyChanged(nameof(EditDebitlbl));
            }
        }
        private string statementlbl;
        public string Statementlbl
        {
            get
            {
                return statementlbl;
            }
            set
            {
                statementlbl = value;
                OnPropertyChanged(nameof(Statementlbl));
            }
        }
        private string customeraddresslbl;
        public string Customeraddresslbl
        {
            get
            {
                return customeraddresslbl;
            }
            set
            {
                customeraddresslbl = value;
                OnPropertyChanged(nameof(Customeraddresslbl));
            }
        }
        private string totalhandcostlbl;
        public string TotalhandCostlbl
        {
            get
            {
                return totalhandcostlbl;
            }
            set
            {
                totalhandcostlbl = value;
                OnPropertyChanged(nameof(TotalhandCostlbl));
            }
        }

        private string editsupplierlbl;
        public string EditSupplierlbl
        {
            get
            {
                return editsupplierlbl;
            }
            set
            {
                editsupplierlbl = value;
                OnPropertyChanged(nameof(EditSupplierlbl));
            }
        }
        private string editkaratgoldlbl;
        public string EditKaratgoldlbl
        {
            get
            {
                return editkaratgoldlbl;
            }
            set
            {
                editkaratgoldlbl = value;
                OnPropertyChanged(nameof(EditKaratgoldlbl));
            }
        }

        private string totalpurchaseinvoicewithcostlbl;
        public string TotalpurchaseInvoiceWithCostlbl
        {
            get
            {
                return totalpurchaseinvoicewithcostlbl;
            }
            set
            {
                totalpurchaseinvoicewithcostlbl = value;
                OnPropertyChanged(nameof(TotalpurchaseInvoiceWithCostlbl));
            }
        }
        private string netinvoicebeforecostlbl;
        public string NetInvoiceBeforeCOstlbl
        {
            get
            {
                return netinvoicebeforecostlbl;
            }
            set
            {
                netinvoicebeforecostlbl = value;
                OnPropertyChanged(nameof(NetInvoiceBeforeCOstlbl));
            }
        }
        private string editcustomerlbl;
        public string EditCustomerlbl
        {
            get
            {
                return editcustomerlbl;
            }
            set
            {
                editcustomerlbl = value;
                OnPropertyChanged(nameof(EditCustomerlbl));
            }
        }
        private string servermanagementlbl;
        public string ServerManagementlbl
        {
            get
            {
                return servermanagementlbl;
            }
            set
            {
                servermanagementlbl = value;
                OnPropertyChanged(nameof(ServerManagementlbl));
            }
        }


        private string lastbackuplbl;
        public string LastBackuplbl
        {
            get
            {
                return lastbackuplbl;
            }
            set
            {
                lastbackuplbl = value;
                OnPropertyChanged(nameof(LastBackuplbl));
            }
        }

        private string backuplinklbl;
        public string BackupLinklbl
        {
            get
            {
                return backuplinklbl;
            }
            set
            {
                backuplinklbl = value;
                OnPropertyChanged(nameof(BackupLinklbl));
            }
        }

        private string manualbackuplbl;
        public string ManualBackuplbl
        {
            get
            {
                return manualbackuplbl;
            }
            set
            {
                manualbackuplbl = value;
                OnPropertyChanged(nameof(ManualBackuplbl));
            }
        }

        private string viewerrorlbl;
        public string ViewErrorlbl
        {
            get
            {
                return viewerrorlbl;
            }
            set
            {
                viewerrorlbl = value;
                OnPropertyChanged(nameof(ViewErrorlbl));
            }
        }
        private string errormessagelbl;
        public string ErrorMessagelbl
        {
            get
            {
                return errormessagelbl;
            }
            set
            {
                errormessagelbl = value;
                OnPropertyChanged(nameof(ErrorMessagelbl));
            }
        }
        private string exitapplicationlbl;
        public string ExitApplicationlbl
        {
            get
            {
                return exitapplicationlbl;
            }
            set
            {
                exitapplicationlbl = value;
                OnPropertyChanged(nameof(ExitApplicationlbl));
            }
        }






        public Languages()
        {
            if (StoriedParameter.Lang == "Ar")
            {


                ServerManagementlbl = "إدارة الخادم";

                NetInvoiceBeforeCOstlbl = "باقي الحساب قبل الاجور";

                TotalpurchaseInvoiceWithCostlbl = "إجمالي الشراء مع الاجور";

                #region Vendors 
                FlowDirection = "RightToLeft";

                Supplierbtn = "مورد جديد";

                Deletebtn = "الغاء الامر";

                Editbtn = "تحرير";

                Addbtn = "تخزين";



                Cancel = "الغاء";

                VendorNamelbl = "اسم المورد";

                Addlbl = "اضافة";

                VendorNumberlbl = "رقم المورد";

                EditCustomerlbl = "تعديل الزبون";





                Karatgoldlbl = "عيار الذهب";

                AddKaratGoldlbl = "إضافة عيار ذهب";

                Vendorslbl = "الموردين";

                KaratGoldNamelbl = "اسم عيار الذهب";

                KaratGoldAmountlbl = "قيمة عيار الذهب";

                Inventorylbl = "المستودع ";

                Purchasinglbl = "المشتريات";

                NewPurchaselbl = "شراء جديد";

                Karatgoldweightlbl = "وزن الذهب";

                GoldHandCostlbl = "اجور القطعة";



                PaidinGoldlbl = "دفعه بالذهب";

                AddPaymentlbl = "إضافة دفعه";

                TotalPaymentlbl = "المبلغ الإجمالي";

                Itemnamelbl = "اسم القطعة";

                TotalCostlbl = "تكلفة القطع المشتراه";

                TotalPaidinGoldlbl = "إجمالي المدفوع بالذهب";

                TotalPurchaselbl = "باقي الحساب مع الاجور";

                EditPurchaselbl = "تعديل شراء";

                TotalhandCostlbl = "إجمالي الاجور";
                #endregion




                NewCustomerlbl = "زبون جديد";

                Customerslbl = "الزبائن";

                CustomerNamelbl = "اسم الزبون";

                CustomerNumberlbl = "رقم الزبون";

                Accountinglbl = "محاسبة";

                NewPaymentlbl = "دفعة جديدة";

                PaidInCashlbl = "دفع نقدا";

                Customeraddresslbl = "عنوان الزبون";



                

                ChequeNumberlbl = "رقم الشيك";

                ChequeHolderlbl = "اسم الساحب";

                DueDatelbl = "تاريخ الاستحقاق";

                ChequeValuelbl = "قيمة الشيك";

                BankNamelbl = "اسم البنك";

                Debitslbl = "الديون";

                Noteslbl = "ملحوظات";

                EditPaymentlbl = "تعديل الدفعه";

                NewDebitlbl = "دين جديد";

                DebitValuelbl = "قيمة الدين";

                EditDebitlbl = "تعديل الدين";

                Statementlbl = "كشف حساب";

                EditSupplierlbl = "تعديل المورد";

                EditKaratgoldlbl = "تعديل عيار الذهب";

                LastBackuplbl = "تاريخ اخر نسخة احتياطية";

                BackupLinklbl = "رابط النسخ الاحتياطي";

                ManualBackuplbl = "رفع النسخة الاحتياطية";

                ViewErrorlbl = "عرض خطأ";

                ErrorMessagelbl = "رسالة خطأ";

                ExitApplicationlbl = "الخروج من التطبيق";

            }
            else if (StoriedParameter.Lang == "En")
            {


                ErrorMessagelbl = "Error Message";

                BackupLinklbl = "Backup Link";

                LastBackuplbl = "Last Backup";

                ServerManagementlbl = "Server Management";


                EditCustomerlbl = "Edit Customer";


                NetInvoiceBeforeCOstlbl = "Net Invoice Before Cost";

                TotalpurchaseInvoiceWithCostlbl = "Total Purchase Invoice With Cost";

                #region Vendors 

                EditKaratgoldlbl = "Edit Karat Gold";

                FlowDirection = "LeftToRight";

                Supplierbtn = "Add new Vendor";

                Deletebtn = "Cancel";

                Editbtn = "Editbtn";

                Addbtn = "Save";

                Cancel = "Cancel";

                VendorNamelbl = "Vendor Name";

                Addlbl = "Add";



                Karatgoldlbl = "Karat Gold";

                AddKaratGoldlbl = "Add Karat Gold";

                Vendorslbl = "Vendors";

                KaratGoldNamelbl = "Karat Gold Name";

                VendorNumberlbl = "Vendor Number";

                KaratGoldAmountlbl = "Karat Gold Amount";

                Inventorylbl = "Inventory";

                Purchasinglbl = "Purchasing";

                NewPurchaselbl = "New Purchase";

                Karatgoldweightlbl = "Karat Gold Weight";

                GoldHandCostlbl = "Gold Hand Cost";

                PaidinGoldlbl = "Paid In Gold";

                AddPaymentlbl = "Add Payment";

                TotalPaymentlbl = "Total Payment";

                Itemnamelbl = "Item Name";

                TotalCostlbl = "Total Cost";

                TotalPaidinGoldlbl = "Total Paid In Gold";

                TotalPurchaselbl = "Total Purchase";

                EditPurchaselbl = "Edit purchase";

                TotalhandCostlbl = "Total Hand Cost";

                #endregion



                ManualBackuplbl = "Manual Backup";

                NewCustomerlbl = "New Customer";

                Customerslbl = "Customers";

                CustomerNamelbl = "Customer Name";

                CustomerNumberlbl = "Customer Number";

                Accountinglbl = "Accounting";

                NewPaymentlbl = "New Payment";

                PaidInCashlbl = "Paid In Cash";

                ChequeNumberlbl = "Cheque Number";

                ChequeHolderlbl = "Cheque Holder";

                DueDatelbl = "Due Date";

                ChequeValuelbl = "Cheque Value";

                BankNamelbl = "Bank Name";

                Debitslbl = "Debits";

                Noteslbl = "Notes";

                EditPaymentlbl = "Edit Payment";

                NewDebitlbl = "New Debit";

                DebitValuelbl = "Debit Value";

                EditDebitlbl = "Edit Debit";

                Statementlbl = "Statement";

                Customeraddresslbl = "Customer Address";

                EditSupplierlbl = "Edit Supplier";

                ViewErrorlbl = "View Error";

                ExitApplicationlbl = "Exit Application";

            }

        }


    }
}
