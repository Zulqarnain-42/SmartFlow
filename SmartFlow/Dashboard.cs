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
        private async void warehouseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form openForm = await CommonFunction.IsFormOpenAsync(typeof(ListWarehouse));
            if(openForm == null)
            {
                ListWarehouse warehouse = new ListWarehouse();
                warehouse.MdiParent = this;
                await CommonFunction.DisposeOnCloseAsync(warehouse);
                warehouse.Show();
            }
            else { openForm.BringToFront(); }
        }
        private async void stockTransferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form openForm = await CommonFunction.IsFormOpenAsync(typeof(StockTransfer));
            if(openForm == null)
            {
                StockTransfer stockTransfer = new StockTransfer();
                stockTransfer.MdiParent = this;
                await CommonFunction.DisposeOnCloseAsync(stockTransfer);
                stockTransfer.Show();
            }
            else { openForm.BringToFront(); }
        }
        private async void accountsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form openForm = await CommonFunction.IsFormOpenAsync(typeof(AccountHistory));
            if (openForm == null)
            {
                AccountHistory accounts = new AccountHistory();
                accounts.MdiParent = this;
                await CommonFunction.DisposeOnCloseAsync(accounts);
                accounts.Show();
            }
            else { openForm.BringToFront(); }
        }
        private async void accountGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form openForm = await CommonFunction.IsFormOpenAsync(typeof(AccountGroupHistory));
            if (openForm == null)
            {
                AccountGroupHistory accountGroupHistory = new AccountGroupHistory();
                accountGroupHistory.MdiParent = this;
                await CommonFunction.DisposeOnCloseAsync(accountGroupHistory);
                accountGroupHistory.Show();
            }
            else { openForm.BringToFront(); }
        }
        private async void damageEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form openForm = await CommonFunction.IsFormOpenAsync(typeof(DamageEntry));
            if (openForm == null)
            {
                DamageEntry damageEntry = new DamageEntry();
                damageEntry.MdiParent = this;
                await CommonFunction.DisposeOnCloseAsync(damageEntry);
                damageEntry.Show();
            }
            else { openForm.BringToFront(); }
        }
        private async void barcodeDesignToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form openForm = await CommonFunction.IsFormOpenAsync(typeof(BarcodeDesign));
            if(openForm == null)
            {
                BarcodeDesign barcodeDesign = new BarcodeDesign();
                barcodeDesign.MdiParent = this;
                await CommonFunction.DisposeOnCloseAsync(barcodeDesign);
                barcodeDesign.Show();
            }
            else { openForm.BringToFront(); }
        }
        private async void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form openForm = await CommonFunction.IsFormOpenAsync(typeof(Product));
            if(openForm == null)
            {
                Product product = new Product();
                product.MdiParent = this;
                await CommonFunction.DisposeOnCloseAsync(product);
                product.Show();
            }
            else { openForm.BringToFront(); }
            
        }
        private async void updateOpeningBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form openForm = await CommonFunction.IsFormOpenAsync(typeof(OpeningBalance));
            if(openForm == null)
            {
                OpeningBalance openingBalance = new OpeningBalance();
                openingBalance.MdiParent = this;
                await CommonFunction.DisposeOnCloseAsync(openingBalance);
                openingBalance.Show();
            }
            else { openForm.BringToFront(); }
        }
        private async void addQuantityUsingScannerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form openForm = await CommonFunction.IsFormOpenAsync(typeof(QtyUsingScanner));
            if(openForm == null)
            {
                QtyUsingScanner qtyUsingScanner = new QtyUsingScanner();
                qtyUsingScanner.MdiParent = this;
                await CommonFunction.DisposeOnCloseAsync(qtyUsingScanner);
                qtyUsingScanner.Show();
            }
            else { openForm.BringToFront(); }
            
        }
        private async void uploadUsingExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form openForm = await CommonFunction.IsFormOpenAsync(typeof(UploadExcel));
            if(openForm == null)
            {
                UploadExcel uploadExcel = new UploadExcel();
                uploadExcel.MdiParent = this;
                await CommonFunction.DisposeOnCloseAsync(uploadExcel);
                uploadExcel.Show();
            }
            else { openForm.BringToFront(); }
        }
        private async void addQuantityUsingMFRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form openForm = await CommonFunction.IsFormOpenAsync(typeof(QtyUsingMfr));
            if(openForm == null)
            {
                QtyUsingMfr qtyUsingMFR = new QtyUsingMfr();
                qtyUsingMFR.MdiParent = this;
                await CommonFunction.DisposeOnCloseAsync(qtyUsingMFR);
                qtyUsingMFR.Show();
            }
            else { openForm.BringToFront(); }
        }
        private async void addaccountbtn_Click(object sender, EventArgs e)
        {
            Form openForm = await CommonFunction.IsFormOpenAsync(typeof(Account));
            if(openForm == null)
            {
                Account account = new Account();
                account.MdiParent = this;
                await CommonFunction.DisposeOnCloseAsync(account);
                account.Show();
            }
            else { openForm.BringToFront(); }
        }
        private async void additembtn_Click(object sender, EventArgs e)
        {
            Form openForm = await CommonFunction.IsFormOpenAsync(typeof(CreateProduct));
            if(openForm == null)
            {
                CreateProduct createProduct = new CreateProduct();
                createProduct.MdiParent = this;
                await CommonFunction.DisposeOnCloseAsync(createProduct);
                createProduct.Show();
            }
            else { openForm.BringToFront(); }
        }
        private async void addmasterbtn_Click(object sender, EventArgs e)
        {
            Form openForm = await CommonFunction.IsFormOpenAsync(typeof(AccountGroupHistory));
            if(openForm == null)
            {
                AccountGroupHistory createGroupHistory = new AccountGroupHistory();
                createGroupHistory.MdiParent = this;
                await CommonFunction.DisposeOnCloseAsync(createGroupHistory);
                createGroupHistory.Show();
            }
            else { openForm.BringToFront(); }
        }
        private async void addpaymentbtn_Click(object sender, EventArgs e)
        {
            Payment payment = new Payment();
            payment.MdiParent = this;
            await CommonFunction.DisposeOnCloseAsync(payment);
            payment.Show();
        }
        private async void addreceiptbtn_Click(object sender, EventArgs e)
        {
            Receipts receipts = new Receipts();
            receipts.MdiParent = this;
            await CommonFunction.DisposeOnCloseAsync(receipts);
            receipts.Show();
        }
        private async void addjournalbtn_Click(object sender, EventArgs e)
        {
            Journal journal = new Journal();
            journal.MdiParent = this;
            await CommonFunction.DisposeOnCloseAsync(journal);
            journal.Show();
        }
        private async void addsalesbtn_Click(object sender, EventArgs e)
        {
            SaleInvoice invoice = new SaleInvoice();
            invoice.MdiParent = this;
            await CommonFunction.DisposeOnCloseAsync(invoice);
            invoice.Show();
        }
        private async void addpurchasebtn_Click(object sender, EventArgs e)
        {
            PurchaseInvoice purchase = new PurchaseInvoice();
            purchase.MdiParent = this;
            await CommonFunction.DisposeOnCloseAsync(purchase);
            purchase.Show();
        }
        private async void Dashboard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Form openForm = await CommonFunction.IsFormOpenAsync(typeof(Account));
                if(openForm == null)
                {
                    Account account = new Account();
                    account.MdiParent = this;
                    await CommonFunction.DisposeOnCloseAsync(account);
                    account.Show();
                }
                else { openForm.BringToFront(); }
                
                // Handle Ctrl+S shortcut (e.g., save data)
                e.Handled = true; // Prevent further processing of the key event
            }

            if (e.KeyCode == Keys.F2)
            {
                Form openForm = await CommonFunction.IsFormOpenAsync(typeof(Product));
                if(openForm == null)
                {
                    Product product = new Product();
                    product.MdiParent = this;
                    await CommonFunction.DisposeOnCloseAsync(product);
                    product.Show();
                }
                else { openForm.BringToFront(); }
                
                // Handle Ctrl+S shortcut (e.g., save data)
                e.Handled = true; // Prevent further processing of the key event
            }

            if (e.KeyCode == Keys.F3)
            {
                Form openForm = await CommonFunction.IsFormOpenAsync(typeof(AccountGroupHistory));
                if(openForm == null)
                {
                    AccountGroupHistory accountGroup = new AccountGroupHistory();
                    accountGroup.MdiParent = this;
                    await CommonFunction.DisposeOnCloseAsync(accountGroup);
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
                await CommonFunction.DisposeOnCloseAsync(payment);
                payment.Show();
                // Handle Ctrl+S shortcut (e.g., save data)
                e.Handled = true; // Prevent further processing of the key event
            }

            if (e.KeyCode == Keys.F6)
            {
                Receipts receipts = new Receipts();
                receipts.MdiParent = this;
                await CommonFunction.DisposeOnCloseAsync(receipts);
                receipts.Show();
                // Handle Ctrl+S shortcut (e.g., save data)
                e.Handled = true; // Prevent further processing of the key event
            }

            if (e.KeyCode == Keys.F7)
            {
                Journal journal = new Journal();
                journal.MdiParent = this;
                await CommonFunction.DisposeOnCloseAsync(journal);
                journal.Show();
                // Handle Ctrl+S shortcut (e.g., save data)
                e.Handled = true; // Prevent further processing of the key event
            }

            if (e.KeyCode == Keys.F8)
            {
                SaleInvoice saleInvoice = new SaleInvoice();
                saleInvoice.MdiParent = this;
                await CommonFunction.DisposeOnCloseAsync(saleInvoice);
                saleInvoice.Show();
                // Handle Ctrl+S shortcut (e.g., save data)
                e.Handled = true; // Prevent further processing of the key event
            }

            if (e.KeyCode == Keys.F9)
            {
                PurchaseInvoice purchaseInvoice = new PurchaseInvoice();
                purchaseInvoice.MdiParent = this;
                await CommonFunction.DisposeOnCloseAsync(purchaseInvoice);
                purchaseInvoice.Show();
                // Handle Ctrl+S shortcut (e.g., save data)
                e.Handled = true; // Prevent further processing of the key event
            }
        }
        private async void addOpenBoxProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form openForm = await CommonFunction.IsFormOpenAsync(typeof(OpenBoxProduct));
            if(openForm == null)
            {
                OpenBoxProduct openBoxProduct = new OpenBoxProduct();
                openBoxProduct.MdiParent = this;
                await CommonFunction.DisposeOnCloseAsync(openBoxProduct);
                openBoxProduct.Show();
            }
            else { openForm.BringToFront(); }
        }
        private async void termsConditionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form openForm = await CommonFunction.IsFormOpenAsync(typeof(Terms));
            if(openForm == null)
            {
                Terms termsandcondition = new Terms();
                termsandcondition.MdiParent = this;
                await CommonFunction.DisposeOnCloseAsync(termsandcondition);
                termsandcondition.Show();
            }
            else { openForm.BringToFront(); }
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private async void editCompanyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form openForm = await CommonFunction.IsFormOpenAsync(typeof(NewCompany));
            if(openForm == null)
            {
                NewCompany newCompany = new NewCompany();
                newCompany.MdiParent = this;
                await CommonFunction.DisposeOnCloseAsync(newCompany);
                newCompany.Show();
            }
            else { openForm.BringToFront(); }
        }
        private async void stockOpeningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form openForm = await CommonFunction.IsFormOpenAsync(typeof(OpeningStock));
            if(openForm == null)
            {
                OpeningStock openingStock = new OpeningStock();
                openingStock.MdiParent = this;
                await CommonFunction.DisposeOnCloseAsync(openingStock);
                openingStock.Show();
            }
            else { openForm.BringToFront(); }
        }
        private async void bookingItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BookItem bookItem = new BookItem();
            bookItem.MdiParent = this;
            await CommonFunction.DisposeOnCloseAsync(bookItem);
            bookItem.Show();
        }
        private async void taxPlanetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaxPlanet taxPlanet = new TaxPlanet()
            {
                WindowState = FormWindowState.Normal,
                StartPosition = FormStartPosition.CenterScreen,
            };
            taxPlanet.MdiParent = this;
            await CommonFunction.DisposeOnCloseAsync(taxPlanet);
            taxPlanet.Show();
        }
        private async void databaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DatabaseConnection databaseConnection = new DatabaseConnection();
            databaseConnection.MdiParent = this;
            await CommonFunction.DisposeOnCloseAsync(databaseConnection);
            databaseConnection.Show();
        }
        private async void fileSavingPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileManager fileManager = new FileManager();
            fileManager.MdiParent = this;
            await CommonFunction.DisposeOnCloseAsync(fileManager);
            fileManager.Show();
        }
        private async void updateAccountsUsingExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExcelAccounts excelAccounts = new ExcelAccounts();
            excelAccounts.MdiParent = this;
            await CommonFunction.DisposeOnCloseAsync(excelAccounts);
            excelAccounts.Show();
        }
        private async void packingListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PackingList packingList = new PackingList();
            packingList.MdiParent = this;
            await CommonFunction.DisposeOnCloseAsync(packingList);
            packingList.Show();
        }
        private async void deliveryNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeliveryNote deliveryNote = new DeliveryNote();
            deliveryNote.MdiParent = this;
            await CommonFunction.DisposeOnCloseAsync(deliveryNote);
            deliveryNote.Show();
        }
        private async void listOfGroupingAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListGroupingAccount listGroupingAccount = new ListGroupingAccount();
            listGroupingAccount.MdiParent = this;
            await CommonFunction.DisposeOnCloseAsync(listGroupingAccount);
            listGroupingAccount.Show();
        }
        private async void unitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UnitList unitList = new UnitList();
            unitList.MdiParent = this;
            await CommonFunction.DisposeOnCloseAsync(unitList);
            unitList.Show();
        }
        private async void balanceSheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BalanceSheet balanceSheet = new BalanceSheet();
            balanceSheet.MdiParent = this;
            await CommonFunction.DisposeOnCloseAsync(balanceSheet);
            balanceSheet.Show();
        }
        private async void aDDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PurchaseQuotationInvoice purchaseQuotationInvoice = new PurchaseQuotationInvoice();
            purchaseQuotationInvoice.MdiParent = this;
            await CommonFunction.DisposeOnCloseAsync(purchaseQuotationInvoice);
            purchaseQuotationInvoice.Show();
        }
        private async void aDDToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PurchaseOrder purchaseOrderInvoice = new PurchaseOrder();
            purchaseOrderInvoice.MdiParent = this;
            await CommonFunction.DisposeOnCloseAsync(purchaseOrderInvoice);
            purchaseOrderInvoice.Show();
        }
        private async void aDDToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            PurchaseInvoice purchaseInvoice = new PurchaseInvoice();
            purchaseInvoice.MdiParent = this;
            await CommonFunction.DisposeOnCloseAsync(purchaseInvoice);
            purchaseInvoice.Show();
        }
        private async void aDDToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            PurchaseReturnInvoice purchaseReturnInvoice = new PurchaseReturnInvoice();
            purchaseReturnInvoice.MdiParent = this;
            await CommonFunction.DisposeOnCloseAsync(purchaseReturnInvoice);
            purchaseReturnInvoice.Show();
        }
        private async void aDDToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            SaleQuotationInvoice saleQuotationInvoice = new SaleQuotationInvoice();
            saleQuotationInvoice.MdiParent = this;
            await CommonFunction.DisposeOnCloseAsync(saleQuotationInvoice);
            saleQuotationInvoice.Show();
        }
        private async void aDDToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            PerformaInvoice performaInvoice = new PerformaInvoice();
            performaInvoice.MdiParent = this;
            await CommonFunction.DisposeOnCloseAsync(performaInvoice);
            performaInvoice.Show();
        }
        private async void aDDToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            SaleInvoice saleInvoice = new SaleInvoice();
            saleInvoice.MdiParent = this;
            await CommonFunction.DisposeOnCloseAsync(saleInvoice);
            saleInvoice.Show();
        }
        private async void aDDToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            SaleReturnInvoice salereturnInvoice = new SaleReturnInvoice();
            salereturnInvoice.MdiParent = this;
            await CommonFunction.DisposeOnCloseAsync(salereturnInvoice);
            salereturnInvoice.Show();
        }
        private async void aDDToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            Payment payment = new Payment();
            payment.MdiParent = this;
            await CommonFunction.DisposeOnCloseAsync(payment);
            payment.Show();
        }
        private async void aDDToolStripMenuItem9_Click(object sender, EventArgs e)
        {
            Receipts receipts = new Receipts();
            receipts.MdiParent = this;
            await CommonFunction.DisposeOnCloseAsync(receipts);
            receipts.Show();
        }
        private async void mODIFYToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            ModifySaleQuotation modifySaleQuotation = new ModifySaleQuotation();
            modifySaleQuotation.MdiParent = this;
            await CommonFunction.DisposeOnCloseAsync(modifySaleQuotation);
            modifySaleQuotation.Show();
        }
        private async void mODIFYToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            ModifyProformaInvoice modifyproforma = new ModifyProformaInvoice();
            modifyproforma.MdiParent = this;
            await CommonFunction.DisposeOnCloseAsync(modifyproforma);
            modifyproforma.Show();
        }
        private async void mODIFYToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            ModifySaleInvoice modifySaleInvoice = new ModifySaleInvoice();
            modifySaleInvoice.MdiParent = this;
            await CommonFunction.DisposeOnCloseAsync(modifySaleInvoice);
            modifySaleInvoice.Show();
        }
        private async void mODIFYToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            ModifySaleReturnInvoice modifySaleReturnInvoice = new ModifySaleReturnInvoice();
            modifySaleReturnInvoice.MdiParent = this;
            await CommonFunction.DisposeOnCloseAsync(modifySaleReturnInvoice);
            modifySaleReturnInvoice.Show();
        }
        private async void mODIFYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModifyPurchaseInvoice modifyPurchaseInvoice = new ModifyPurchaseInvoice();
            modifyPurchaseInvoice.MdiParent = this;
            await CommonFunction.DisposeOnCloseAsync(modifyPurchaseInvoice);
            modifyPurchaseInvoice.Show();
        }
        private async void mODIFYToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ModifyPurchaseReturn modifyPurchaseReturn = new ModifyPurchaseReturn();
            modifyPurchaseReturn.MdiParent = this;
            await CommonFunction.DisposeOnCloseAsync(modifyPurchaseReturn);
            modifyPurchaseReturn.Show();
        }
        private async void mODIFYToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            ModifyPaymentVoucher modifyPaymentVoucher = new ModifyPaymentVoucher();
            modifyPaymentVoucher.MdiParent = this;
            await CommonFunction.DisposeOnCloseAsync(modifyPaymentVoucher);
            modifyPaymentVoucher.Show();
        }
        private async void mODIFYToolStripMenuItem9_Click(object sender, EventArgs e)
        {
            ModifyReceiptVoucher modifyReceiptVoucher = new ModifyReceiptVoucher();
            modifyReceiptVoucher.MdiParent = this;
            await CommonFunction.DisposeOnCloseAsync(modifyReceiptVoucher);
            modifyReceiptVoucher.Show();
        }
        private async void aDDToolStripMenuItem10_Click(object sender, EventArgs e)
        {
            Journal journal = new Journal();
            journal.MdiParent = this;
            await CommonFunction.DisposeOnCloseAsync(journal);
            journal.Show();
        }
        private async void aDDToolStripMenuItem11_Click(object sender, EventArgs e)
        {
            CreditNote creditNote = new CreditNote();
            creditNote.MdiParent = this;
            await CommonFunction.DisposeOnCloseAsync(creditNote);
            creditNote.Show();
        }
        private async void aDDToolStripMenuItem12_Click(object sender, EventArgs e)
        {
            DebitNote debitNote = new DebitNote();
            debitNote.MdiParent = this;
            await CommonFunction.DisposeOnCloseAsync(debitNote);
            debitNote.Show();
        }
        private async void aDDToolStripMenuItem13_Click(object sender, EventArgs e)
        {
            MaterialIssueToParty materialIssueToParty = new MaterialIssueToParty();
            materialIssueToParty.MdiParent = this;
            await CommonFunction.DisposeOnCloseAsync(materialIssueToParty);
            materialIssueToParty.Show();
        }
        private async void aDDToolStripMenuItem14_Click(object sender, EventArgs e)
        {
            MaterialReceivedFromParty materialReceivedFromParty = new MaterialReceivedFromParty();
            materialReceivedFromParty.MdiParent = this;
            await CommonFunction.DisposeOnCloseAsync(materialReceivedFromParty);
            materialReceivedFromParty.Show();
        }
        private async void lISTToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            ListSalesQuotation listSalesQuotation = new ListSalesQuotation();
            listSalesQuotation.MdiParent = this;
            await CommonFunction.DisposeOnCloseAsync(listSalesQuotation);
            listSalesQuotation.Show();
        }
        private async void lISTToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            ListProformaInvoice listProformaInvoice = new ListProformaInvoice();
            listProformaInvoice.MdiParent = this;
            await CommonFunction.DisposeOnCloseAsync(listProformaInvoice);
            listProformaInvoice.Show();
        }
        private async void lISTToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            ListSaleInvoice listSaleInvoice = new ListSaleInvoice();
            listSaleInvoice.MdiParent = this;
            await CommonFunction.DisposeOnCloseAsync(listSaleInvoice);
            listSaleInvoice.Show();
        }
        private async void lISTToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            ListSalesReturn listSalesReturn = new ListSalesReturn();
            listSalesReturn.MdiParent = this;
            await CommonFunction.DisposeOnCloseAsync(listSalesReturn);
            listSalesReturn.Show();
        }
        private async void lISTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListPurchaseQuotation listPurchaseQuotation = new ListPurchaseQuotation();
            listPurchaseQuotation.MdiParent = this;
            await CommonFunction.DisposeOnCloseAsync(listPurchaseQuotation);
            listPurchaseQuotation.Show();
        }
        private async void lISTToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ListPurchaseOrder listPurchaseOrder = new ListPurchaseOrder();
            listPurchaseOrder.MdiParent = this;
            await CommonFunction.DisposeOnCloseAsync(listPurchaseOrder);
            listPurchaseOrder.Show();
        }
        private async void lISTToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ListPurchaseInvoice listPurchaseInvoice = new ListPurchaseInvoice();
            listPurchaseInvoice.MdiParent = this;
            await CommonFunction.DisposeOnCloseAsync(listPurchaseInvoice);
            listPurchaseInvoice.Show();
        }
        private async void lISTToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ListPurchaseReturn listPurchaseReturn = new ListPurchaseReturn();
            listPurchaseReturn.MdiParent = this;
            await CommonFunction.DisposeOnCloseAsync(listPurchaseReturn);
            listPurchaseReturn.Show();
        }
        private async void lISTToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            ListPayment listPayment = new ListPayment();
            listPayment.MdiParent = this;
            await CommonFunction.DisposeOnCloseAsync(listPayment);
            listPayment.Show();
        }
        private async void lISTToolStripMenuItem9_Click(object sender, EventArgs e)
        {
            ListReceipt listReceipt = new ListReceipt();
            listReceipt.MdiParent = this;
            await CommonFunction.DisposeOnCloseAsync(listReceipt);
            listReceipt.Show();
        }
        private async void lISTToolStripMenuItem10_Click(object sender, EventArgs e)
        {
            ListJournal listJournal = new ListJournal();
            listJournal.MdiParent = this;
            await CommonFunction.DisposeOnCloseAsync(listJournal);
            listJournal.Show();
        }
        private async void lISTToolStripMenuItem11_Click(object sender, EventArgs e)
        {
            ListCreditNote listCreditNote = new ListCreditNote();
            listCreditNote.MdiParent = this;
            await CommonFunction.DisposeOnCloseAsync(listCreditNote);
            listCreditNote.Show();
        }
        private async void lISTToolStripMenuItem12_Click(object sender, EventArgs e)
        {
            ListDebitNote listDebitNote = new ListDebitNote();
            listDebitNote.MdiParent = this;
            await CommonFunction.DisposeOnCloseAsync(listDebitNote);
            listDebitNote.Show();
        }
        private async void lISTToolStripMenuItem13_Click(object sender, EventArgs e)
        {
            ListMaterialIssue listMaterialIssue = new ListMaterialIssue();
            listMaterialIssue.MdiParent = this;
            await CommonFunction.DisposeOnCloseAsync(listMaterialIssue);
            listMaterialIssue.Show();
        }
        private async void lISTToolStripMenuItem14_Click(object sender, EventArgs e)
        {
            ListMaterialReceived listMaterialReceived = new ListMaterialReceived();
            listMaterialReceived.MdiParent = this;
            await CommonFunction.DisposeOnCloseAsync(listMaterialReceived);
            listMaterialReceived.Show();
        }
    }
}