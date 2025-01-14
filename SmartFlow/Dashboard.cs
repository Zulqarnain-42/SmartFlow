using SmartFlow.Common;
using SmartFlow.Common.CommonForms;
using SmartFlow.General;
using SmartFlow.Masters;
using SmartFlow.Purchase;
using SmartFlow.Report;
using SmartFlow.Sales;
using SmartFlow.Setting;
using SmartFlow.Stock;
using SmartFlow.Transactions;
using System;
using System.Drawing;
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
            Form openForm = CommonFunction.IsFormOpen(typeof(ListWarehouse));
            if(openForm == null)
            {
                ListWarehouse warehouse = new ListWarehouse();
                warehouse.MdiParent = this;
                CommonFunction.DisposeOnClose(warehouse);
                warehouse.Show();
            }
            else { openForm.BringToFront(); }
        }
        private void purchaseOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PurchaseOrder purchaseOrderInvoice = new PurchaseOrder();
            purchaseOrderInvoice.MdiParent = this;
            CommonFunction.DisposeOnClose(purchaseOrderInvoice);
            purchaseOrderInvoice.Show();
        }
        private void purchaseInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PurchaseInvoice purchaseInvoice = new PurchaseInvoice();
            purchaseInvoice.MdiParent = this;
            CommonFunction.DisposeOnClose(purchaseInvoice);
            purchaseInvoice.Show();
        }
        private void purchaseReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PurchaseReturnInvoice purchaseReturnInvoice = new PurchaseReturnInvoice();
            purchaseReturnInvoice.MdiParent = this;
            CommonFunction.DisposeOnClose(purchaseReturnInvoice);
            purchaseReturnInvoice.Show();
        }
        private void salesQuotationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaleQuotationInvoice saleQuotationInvoice = new SaleQuotationInvoice();
            saleQuotationInvoice.MdiParent = this;
            CommonFunction.DisposeOnClose(saleQuotationInvoice);
            saleQuotationInvoice.Show();
        }
        private void directSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaleInvoice saleInvoice = new SaleInvoice();
            saleInvoice.MdiParent = this;
            CommonFunction.DisposeOnClose(saleInvoice);
            saleInvoice.Show();
        }
        private void salesReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaleReturnInvoice salereturnInvoice = new SaleReturnInvoice();
            salereturnInvoice.MdiParent = this;
            CommonFunction.DisposeOnClose(salereturnInvoice);
            salereturnInvoice.Show();
        }
        private void stockTransferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form openForm = CommonFunction.IsFormOpen(typeof(StockTransfer));
            if(openForm == null)
            {
                StockTransfer stockTransfer = new StockTransfer();
                stockTransfer.MdiParent = this;
                CommonFunction.DisposeOnClose(stockTransfer);
                stockTransfer.Show();
            }
            else { openForm.BringToFront(); }
        }
        private void paymentsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Payment payment = new Payment();
            payment.MdiParent = this;
            CommonFunction.DisposeOnClose(payment);
            payment.Show();
        }
        private void receiptsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Receipts receipts = new Receipts();
            receipts.MdiParent = this;
            CommonFunction.DisposeOnClose(receipts);
            receipts.Show();
        }
        private void journalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Journal journal = new Journal();
            journal.MdiParent = this;
            CommonFunction.DisposeOnClose(journal);
            journal.Show();
        }
        private void creditNoteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CreditNote creditNote = new CreditNote();
            creditNote.MdiParent = this;
            CommonFunction.DisposeOnClose(creditNote);
            creditNote.Show();
        }
        private void debitNoteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DebitNote debitNote = new DebitNote();
            debitNote.MdiParent = this;
            CommonFunction.DisposeOnClose(debitNote);
            debitNote.Show();
        }
        private void accountsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form openForm = CommonFunction.IsFormOpen(typeof(AccountHistory));
            if (openForm == null)
            {
                AccountHistory accounts = new AccountHistory();
                accounts.MdiParent = this;
                CommonFunction.DisposeOnClose(accounts);
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
                CommonFunction.DisposeOnClose(accountGroupHistory);
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
                CommonFunction.DisposeOnClose(damageEntry);
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
                barcodeDesign.MdiParent = this;
                CommonFunction.DisposeOnClose(barcodeDesign);
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
                CommonFunction.DisposeOnClose(product);
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
                CommonFunction.DisposeOnClose(openingBalance);
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
                CommonFunction.DisposeOnClose(qtyUsingScanner);
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
                CommonFunction.DisposeOnClose(uploadExcel);
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
                CommonFunction.DisposeOnClose(qtyUsingMFR);
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
                CommonFunction.DisposeOnClose(account);
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
                CommonFunction.DisposeOnClose(createProduct);
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
                CommonFunction.DisposeOnClose(createGroupHistory);
                createGroupHistory.Show();
            }
            else { openForm.BringToFront(); }
        }
        private void addpaymentbtn_Click(object sender, EventArgs e)
        {
            Payment payment = new Payment();
            payment.MdiParent = this;
            CommonFunction.DisposeOnClose(payment);
            payment.Show();
        }
        private void addreceiptbtn_Click(object sender, EventArgs e)
        {
            Receipts receipts = new Receipts();
            receipts.MdiParent = this;
            CommonFunction.DisposeOnClose(receipts);
            receipts.Show();
        }
        private void addjournalbtn_Click(object sender, EventArgs e)
        {
            Journal journal = new Journal();
            journal.MdiParent = this;
            CommonFunction.DisposeOnClose(journal);
            journal.Show();
        }
        private void addsalesbtn_Click(object sender, EventArgs e)
        {
            SaleInvoice invoice = new SaleInvoice();
            invoice.MdiParent = this;
            CommonFunction.DisposeOnClose(invoice);
            invoice.Show();
        }
        private void addpurchasebtn_Click(object sender, EventArgs e)
        {
            PurchaseInvoice purchase = new PurchaseInvoice();
            purchase.MdiParent = this;
            CommonFunction.DisposeOnClose(purchase);
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
                    CommonFunction.DisposeOnClose(account);
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
                    CommonFunction.DisposeOnClose(product);
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
                    CommonFunction.DisposeOnClose(accountGroup);
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
                CommonFunction.DisposeOnClose(payment);
                payment.Show();
                // Handle Ctrl+S shortcut (e.g., save data)
                e.Handled = true; // Prevent further processing of the key event
            }

            if (e.KeyCode == Keys.F6)
            {
                Receipts receipts = new Receipts();
                receipts.MdiParent = this;
                CommonFunction.DisposeOnClose(receipts);
                receipts.Show();
                // Handle Ctrl+S shortcut (e.g., save data)
                e.Handled = true; // Prevent further processing of the key event
            }

            if (e.KeyCode == Keys.F7)
            {
                Journal journal = new Journal();
                journal.MdiParent = this;
                CommonFunction.DisposeOnClose(journal);
                journal.Show();
                // Handle Ctrl+S shortcut (e.g., save data)
                e.Handled = true; // Prevent further processing of the key event
            }

            if (e.KeyCode == Keys.F8)
            {
                SaleInvoice saleInvoice = new SaleInvoice();
                saleInvoice.MdiParent = this;
                CommonFunction.DisposeOnClose(saleInvoice);
                saleInvoice.Show();
                // Handle Ctrl+S shortcut (e.g., save data)
                e.Handled = true; // Prevent further processing of the key event
            }

            if (e.KeyCode == Keys.F9)
            {
                PurchaseInvoice purchaseInvoice = new PurchaseInvoice();
                purchaseInvoice.MdiParent = this;
                CommonFunction.DisposeOnClose(purchaseInvoice);
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
                CommonFunction.DisposeOnClose(openBoxProduct);
                openBoxProduct.Show();
            }
            else { openForm.BringToFront(); }
        }
        private void purchaseQuotationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PurchaseQuotationInvoice purchaseQuotationInvoice = new PurchaseQuotationInvoice();
            purchaseQuotationInvoice.MdiParent = this;
            CommonFunction.DisposeOnClose(purchaseQuotationInvoice);
            purchaseQuotationInvoice.Show();
        }
        private void termsConditionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form openForm = CommonFunction.IsFormOpen(typeof(Terms));
            if(openForm == null)
            {
                Terms termsandcondition = new Terms();
                termsandcondition.MdiParent = this;
                CommonFunction.DisposeOnClose(termsandcondition);
                termsandcondition.Show();
            }
            else { openForm.BringToFront(); }
        }
        private void tsbLogin_Click(object sender, EventArgs e)
        {
            Login login = new Login(this);
            login.MdiParent = this;
            CommonFunction.DisposeOnClose(login);
            login.ShowDialog();
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
                newCompany.MdiParent = this;
                CommonFunction.DisposeOnClose(newCompany);
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
                CommonFunction.DisposeOnClose(openingStock);
                openingStock.Show();
            }
            else { openForm.BringToFront(); }
        }
        private void findAnInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form openForm = CommonFunction.IsFormOpen(typeof(FindPurchaseInvoiceForm));
            if(openForm == null)
            {
                FindPurchaseInvoiceForm findInvoiceForm = new FindPurchaseInvoiceForm() 
                {
                    WindowState = FormWindowState.Normal,
                    StartPosition = FormStartPosition.CenterScreen,
                };
                findInvoiceForm.MdiParent = this;
                CommonFunction.DisposeOnClose(findInvoiceForm);
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
                findSaleInvoiceForm.MdiParent = this;
                CommonFunction.DisposeOnClose(findSaleInvoiceForm);
                findSaleInvoiceForm.Show();
            }
            else { openForm.BringToFront(); }
        }
        private void matIssuedToPartyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MaterialIssueToParty materialIssueToParty = new MaterialIssueToParty();
            materialIssueToParty.MdiParent = this;
            CommonFunction.DisposeOnClose(materialIssueToParty);
            materialIssueToParty.Show();
        }
        private void matReceivedFromPartyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MaterialReceivedFromParty materialReceivedFromParty = new MaterialReceivedFromParty();
            materialReceivedFromParty.MdiParent = this;
            CommonFunction.DisposeOnClose(materialReceivedFromParty);
            materialReceivedFromParty.Show();
        }
        private void bookingItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BookItem bookItem = new BookItem();
            bookItem.MdiParent = this;
            CommonFunction.DisposeOnClose(bookItem);
            bookItem.Show();
        }
        private void taxPlanetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaxPlanet taxPlanet = new TaxPlanet()
            {
                WindowState = FormWindowState.Normal,
                StartPosition = FormStartPosition.CenterScreen,
            };
            taxPlanet.MdiParent = this;
            CommonFunction.DisposeOnClose(taxPlanet);
            taxPlanet.Show();
        }
        private void databaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DatabaseConnection databaseConnection = new DatabaseConnection();
            databaseConnection.MdiParent = this;
            CommonFunction.DisposeOnClose(databaseConnection);
            databaseConnection.Show();
        }
        private void fileSavingPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileManager fileManager = new FileManager();
            fileManager.MdiParent = this;
            CommonFunction.DisposeOnClose(fileManager);
            fileManager.Show();
        }
        private void updateAccountsUsingExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExcelAccounts excelAccounts = new ExcelAccounts();
            excelAccounts.MdiParent = this;
            CommonFunction.DisposeOnClose(excelAccounts);
            excelAccounts.Show();
        }
        private void packingListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PackingList packingList = new PackingList();
            packingList.MdiParent = this;
            CommonFunction.DisposeOnClose(packingList);
            packingList.Show();
        }
        private void deliveryNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeliveryNote deliveryNote = new DeliveryNote();
            deliveryNote.MdiParent = this;
            CommonFunction.DisposeOnClose(deliveryNote);
            deliveryNote.Show();
        }
        private void findAnInvoiceToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FindTransactionForm findTransactionForm = new FindTransactionForm();
            findTransactionForm.MdiParent = this;
            CommonFunction.DisposeOnClose(findTransactionForm);
            findTransactionForm.Show();
        }
        private void listOfGroupingAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListGroupingAccount listGroupingAccount = new ListGroupingAccount();
            listGroupingAccount.MdiParent = this;
            CommonFunction.DisposeOnClose(listGroupingAccount);
            listGroupingAccount.Show();
        }
        private void manageInventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StockManageForm stockManageForm = new StockManageForm();
            stockManageForm.MdiParent = this;
            CommonFunction.DisposeOnClose(stockManageForm);
            stockManageForm.Show();
        }
        private void unitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UnitList unitList = new UnitList();
            unitList.MdiParent = this;
            CommonFunction.DisposeOnClose(unitList);
            unitList.Show();
        }

        private void perfromaInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PerformaInvoice performaInvoice = new PerformaInvoice();
            performaInvoice.MdiParent = this;
            CommonFunction.DisposeOnClose (performaInvoice);
            performaInvoice.Show();
        }

        private void balanceSheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BalanceSheet balanceSheet = new BalanceSheet();
            balanceSheet.MdiParent = this;
            CommonFunction.DisposeOnClose(balanceSheet);
            balanceSheet.Show();
        }
    }
}