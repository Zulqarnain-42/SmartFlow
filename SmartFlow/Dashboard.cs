using SmartFlow.Common;
using SmartFlow.Common.CommonForms;
using SmartFlow.General;
using SmartFlow.Masters;
using SmartFlow.Payroll;
using SmartFlow.Purchase;
using SmartFlow.Sales;
using SmartFlow.Sales.CommonForm;
using SmartFlow.Setting;
using SmartFlow.Stock;
using SmartFlow.Transactions;
using System;
using System.Windows.Forms;

namespace SmartFlow
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }
        private void warehouseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form openForm = CommonFunction.IsFormOpen(typeof(Warehouse));
            if(openForm == null)
            {
                Warehouse warehouse = new Warehouse();
                warehouse.Show();
            }
            else { openForm.BringToFront(); }
        }
        private void purchaseOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PurchaseOrder purchaseOrderInvoice = new PurchaseOrder();
            purchaseOrderInvoice.MdiParent = this;
            purchaseOrderInvoice.Show();
        }
        private void purchaseInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PurchaseInvoice purchaseInvoice = new PurchaseInvoice();
            purchaseInvoice.MdiParent = this;
            purchaseInvoice.Show();
        }
        private void purchaseReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PurchaseReturnInvoice purchaseReturnInvoice = new PurchaseReturnInvoice();
            purchaseReturnInvoice.MdiParent = this;
            purchaseReturnInvoice.Show();
        }
        private void salesQuotationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaleQuotationInvoice saleQuotationInvoice = new SaleQuotationInvoice();
            saleQuotationInvoice.MdiParent = this;
            saleQuotationInvoice.Show();
        }
        private void directSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaleInvoice saleInvoice = new SaleInvoice();
            saleInvoice.MdiParent = this;
            saleInvoice.Show();
        }
        private void salesReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaleReturnInvoice salereturnInvoice = new SaleReturnInvoice();
            salereturnInvoice.MdiParent = this;
            salereturnInvoice.Show();
        }
        private void stockTransferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form openForm = CommonFunction.IsFormOpen(typeof(StockTransfer));
            if(openForm == null)
            {
                StockTransfer stockTransfer = new StockTransfer();
                stockTransfer.MdiParent = this;
                stockTransfer.Show();
            }
            else { openForm.BringToFront(); }
        }
        private void paymentsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Payment payment = new Payment();
            payment.MdiParent = this;
            payment.Show();
        }
        private void receiptsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Receipts receipts = new Receipts();
            receipts.MdiParent = this;
            receipts.Show();
        }
        private void journalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Journal journal = new Journal();
            journal.MdiParent = this;
            journal.Show();
        }
        private void creditNoteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CreditNote creditNote = new CreditNote();
            creditNote.MdiParent = this;
            creditNote.Show();
        }
        private void debitNoteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DebitNote debitNote = new DebitNote();
            debitNote.MdiParent = this;
            debitNote.Show();
        }
        private void accountsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form openForm = CommonFunction.IsFormOpen(typeof(AccountHistory));
            if (openForm == null)
            {
                AccountHistory accounts = new AccountHistory();
                accounts.MdiParent = this;
                accounts.Show();
            }
            else { openForm.BringToFront(); }
        }
        private void accountGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form openForm = CommonFunction.IsFormOpen(typeof(AccountGroupHistory));
            if (openForm == null)
            {
                AccountGroupHistory accountGroupHistory = new AccountGroupHistory();
                accountGroupHistory.MdiParent = this;
                accountGroupHistory.Show();
            }
            else { openForm.BringToFront(); }
        }
        private void damageEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form openForm = CommonFunction.IsFormOpen(typeof(DamageEntry));
            if (openForm == null)
            {
                DamageEntry damageEntry = new DamageEntry();
                damageEntry.MdiParent = this;
                damageEntry.Show();
            }
            else { openForm.BringToFront(); }
        }
        private void barcodeDesignToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form openForm = CommonFunction.IsFormOpen(typeof(BarcodeDesign));
            if(openForm == null)
            {
                BarcodeDesign barcodeDesign = new BarcodeDesign();
                barcodeDesign.Show();
            }
            else { openForm.BringToFront(); }
        }
        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form openForm = CommonFunction.IsFormOpen(typeof(Product));
            if(openForm == null)
            {
                Product product = new Product();
                product.MdiParent = this;
                product.Show();
            }
            else { openForm.BringToFront(); }
            
        }
        private void updateOpeningBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form openForm = CommonFunction.IsFormOpen(typeof(OpeningBalance));
            if(openForm == null)
            {
                OpeningBalance openingBalance = new OpeningBalance();
                openingBalance.MdiParent = this;
                openingBalance.Show();
            }
            else { openForm.BringToFront(); }
        }
        private void addQuantityUsingScannerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form openForm = CommonFunction.IsFormOpen(typeof(QtyUsingScanner));
            if(openForm == null)
            {
                QtyUsingScanner qtyUsingScanner = new QtyUsingScanner();
                qtyUsingScanner.MdiParent = this;
                qtyUsingScanner.Show();
            }
            else { openForm.BringToFront(); }
            
        }
        private void uploadUsingExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form openForm = CommonFunction.IsFormOpen(typeof(UploadExcel));
            if(openForm == null)
            {
                UploadExcel uploadExcel = new UploadExcel();
                uploadExcel.MdiParent = this;
                uploadExcel.Show();
            }
            else { openForm.BringToFront(); }
        }
        private void addQuantityUsingMFRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form openForm = CommonFunction.IsFormOpen(typeof(QtyUsingMfr));
            if(openForm == null)
            {
                QtyUsingMfr qtyUsingMFR = new QtyUsingMfr();
                qtyUsingMFR.MdiParent = this;
                qtyUsingMFR.Show();
            }
            else { openForm.BringToFront(); }
        }
        private void addaccountbtn_Click(object sender, EventArgs e)
        {
            Form openForm = CommonFunction.IsFormOpen(typeof(Account));
            if(openForm == null)
            {
                Account account = new Account();
                account.MdiParent = this;
                account.Show();
            }
            else { openForm.BringToFront(); }
        }
        private void additembtn_Click(object sender, EventArgs e)
        {
            Form openForm = CommonFunction.IsFormOpen(typeof(CreateProduct));
            if(openForm == null)
            {
                CreateProduct createProduct = new CreateProduct();
                createProduct.MdiParent = this;
                createProduct.Show();
            }
            else { openForm.BringToFront(); }
        }
        private void addmasterbtn_Click(object sender, EventArgs e)
        {
            Form openForm = CommonFunction.IsFormOpen(typeof(AccountGroupHistory));
            if(openForm == null)
            {
                AccountGroupHistory createGroupHistory = new AccountGroupHistory();
                createGroupHistory.MdiParent = this;
                createGroupHistory.Show();
            }
            else { openForm.BringToFront(); }
        }
        private void addpaymentbtn_Click(object sender, EventArgs e)
        {
            Payment payment = new Payment();
            payment.MdiParent = this;
            payment.Show();
        }
        private void addreceiptbtn_Click(object sender, EventArgs e)
        {
            Receipts receipts = new Receipts();
            receipts.MdiParent = this;
            receipts.Show();
        }
        private void addjournalbtn_Click(object sender, EventArgs e)
        {
            Journal journal = new Journal();
            journal.MdiParent = this;
            journal.Show();
        }
        private void addsalesbtn_Click(object sender, EventArgs e)
        {
            SaleInvoice invoice = new SaleInvoice();
            invoice.MdiParent = this; 
            invoice.Show();
        }
        private void addpurchasebtn_Click(object sender, EventArgs e)
        {
            PurchaseInvoice purchase = new PurchaseInvoice();
            purchase.MdiParent = this;
            purchase.Show();
        }
        private void Dashboard_KeyDown(object sender, KeyEventArgs e)
            {
            if (e.KeyCode == Keys.F1)
            {
                Form openForm = CommonFunction.IsFormOpen(typeof(Account));
                if(openForm == null)
                {
                    Account account = new Account();
                    account.MdiParent = this;
                    account.Show();
                }
                else { openForm.BringToFront(); }
                
                // Handle Ctrl+S shortcut (e.g., save data)
                e.Handled = true; // Prevent further processing of the key event
            }

            if (e.KeyCode == Keys.F2)
            {
                Form openForm = CommonFunction.IsFormOpen(typeof(Product));
                if(openForm == null)
                {
                    Product product = new Product();
                    product.MdiParent = this;
                    product.Show();
                }
                else { openForm.BringToFront(); }
                
                // Handle Ctrl+S shortcut (e.g., save data)
                e.Handled = true; // Prevent further processing of the key event
            }

            if (e.KeyCode == Keys.F3)
            {
                Form openForm = CommonFunction.IsFormOpen(typeof(AccountGroupHistory));
                if(openForm == null)
                {
                    AccountGroupHistory accountGroup = new AccountGroupHistory();
                    accountGroup.MdiParent = this;
                    accountGroup.Show();
                }
                else { openForm.BringToFront(); }
                
                // Handle Ctrl+S shortcut (e.g., save data)
                e.Handled = true; // Prevent further processing of the key event
            }

            if (e.KeyCode == Keys.F5)
            {
                Payment payment = new Payment();
                payment.MdiParent = this;
                payment.Show();
                // Handle Ctrl+S shortcut (e.g., save data)
                e.Handled = true; // Prevent further processing of the key event
            }

            if (e.KeyCode == Keys.F6)
            {
                Receipts receipts = new Receipts();
                receipts.MdiParent = this;
                receipts.Show();
                // Handle Ctrl+S shortcut (e.g., save data)
                e.Handled = true; // Prevent further processing of the key event
            }

            if (e.KeyCode == Keys.F7)
            {
                Journal journal = new Journal();
                journal.MdiParent = this;
                journal.Show();
                // Handle Ctrl+S shortcut (e.g., save data)
                e.Handled = true; // Prevent further processing of the key event
            }

            if (e.KeyCode == Keys.F8)
            {
                SaleInvoice saleInvoice = new SaleInvoice();
                saleInvoice.MdiParent = this;
                saleInvoice.Show();
                // Handle Ctrl+S shortcut (e.g., save data)
                e.Handled = true; // Prevent further processing of the key event
            }

            if (e.KeyCode == Keys.F9)
            {
                PurchaseInvoice purchaseInvoice = new PurchaseInvoice();
                purchaseInvoice.MdiParent = this;
                purchaseInvoice.Show();
                // Handle Ctrl+S shortcut (e.g., save data)
                e.Handled = true; // Prevent further processing of the key event
            }
        }
        private void addOpenBoxProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form openForm = CommonFunction.IsFormOpen(typeof(OpenBoxProduct));
            if(openForm == null)
            {
                OpenBoxProduct openBoxProduct = new OpenBoxProduct();
                openBoxProduct.MdiParent = this;
                openBoxProduct.Show();
            }
            else { openForm.BringToFront(); }
        }
        private void purchaseQuotationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PurchaseQuotationInvoice purchaseQuotationInvoice = new PurchaseQuotationInvoice();
            purchaseQuotationInvoice.MdiParent = this;
            purchaseQuotationInvoice.Show();
        }
        private void termsConditionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form openForm = CommonFunction.IsFormOpen(typeof(Terms));
            if(openForm == null)
            {
                Terms termsandcondition = new Terms();
                termsandcondition.MdiParent = this;
                termsandcondition.Show();
            }
            else { openForm.BringToFront(); }
        }
        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form openForm = CommonFunction.IsFormOpen(typeof(ChangePassword));
            if(openForm == null)
            {
                ChangePassword changePassword = new ChangePassword();
                changePassword.Show();
            }
            else { openForm.BringToFront(); }
        }
        private void tsbLogin_Click(object sender, EventArgs e)
        {
            Login login = new Login(this);
            login.ShowDialog();
        }
        private void stockLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form openForm = CommonFunction.IsFormOpen(typeof(StockLocation));
            if(openForm == null)
            {
                StockLocation stockLocation = new StockLocation();
                stockLocation.MdiParent = this;
                stockLocation.Show();
            }
            else { openForm.BringToFront(); }
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void editCompanyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form openForm = CommonFunction.IsFormOpen(typeof(NewCompany));
            if(openForm == null)
            {
                NewCompany newCompany = new NewCompany();
                newCompany.Show();
            }
            else { openForm.BringToFront(); }
        }
        private void stockOpeningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form openForm = CommonFunction.IsFormOpen(typeof(OpeningStock));
            if(openForm == null)
            {
                OpeningStock openingStock = new OpeningStock();
                openingStock.MdiParent = this;
                openingStock.Show();
            }
            else { openForm.BringToFront(); }
        }
        private void currencyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Currency currency = new Currency();
            currency.Show();
        }
        private void groupingAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GroupingAccount groupingAccount = new GroupingAccount();
            groupingAccount.Show();
        }
        private void purchaseTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PurchaseType purchaseType = new PurchaseType();
            purchaseType.Show();
        }
        private void saleTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaleType saleType = new SaleType();
            saleType.Show();
        }
        private void findAnInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form openForm = CommonFunction.IsFormOpen(typeof(FindPurchaseInvoiceForm));
            if(openForm == null)
            {
                FindPurchaseInvoiceForm findInvoiceForm = new FindPurchaseInvoiceForm();
                findInvoiceForm.Show();
            }
            else { openForm.BringToFront(); }
        }
        private void findAnInvoiceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form openForm = CommonFunction.IsFormOpen(typeof(FindSaleInvoiceForm));
            if(openForm == null)
            {
                FindSaleInvoiceForm findSaleInvoiceForm = new FindSaleInvoiceForm();
                findSaleInvoiceForm.Show();
            }
            else { openForm.BringToFront(); }
        }
        private void matIssuedToPartyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MaterialIssueToParty materialIssueToParty = new MaterialIssueToParty();
            materialIssueToParty.MdiParent = this;
            materialIssueToParty.Show();
        }
        private void matReceivedFromPartyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MaterialReceivedFromParty materialReceivedFromParty = new MaterialReceivedFromParty();
            materialReceivedFromParty.MdiParent = this;
            materialReceivedFromParty.Show();
        }
        private void bookingItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BookItem bookItem = new BookItem();
            bookItem.MdiParent = this;
            bookItem.Show();
        }
        private void taxPlanetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaxPlanet taxPlanet = new TaxPlanet();
            taxPlanet.ShowDialog();
        }
        private void allToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string hiddendata = "Sale";
            FromToDateSearchForm fromtodateform = new FromToDateSearchForm(hiddendata);
            fromtodateform.MdiParent = this;
            fromtodateform.Show();
        }
        private void allPurchaseQuotationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string hiddendata = "Purchase";
            FromToDateSearchForm fromtodateform = new FromToDateSearchForm(hiddendata);
            fromtodateform.MdiParent = this;
            fromtodateform.Show();
        }
        private void databaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DatabaseConnection databaseConnection = new DatabaseConnection();
            databaseConnection.ShowDialog();
        }
        private void fileSavingPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileManager fileManager = new FileManager();
            fileManager.ShowDialog();
        }
        private void updateAccountsUsingExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExcelAccounts excelAccounts = new ExcelAccounts();
            excelAccounts.MdiParent = this;
            excelAccounts.Show();
        }
        private void packingListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PackingList packingList = new PackingList();
            packingList.MdiParent = this;
            packingList.Show();
        }
        private void deliveryNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeliveryNote deliveryNote = new DeliveryNote();
            deliveryNote.MdiParent = this;
            deliveryNote.Show();
        }
    }
}