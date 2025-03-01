using SmartFlow.Common;
using SmartFlow.General;
using SmartFlow.Masters;
using SmartFlow.Purchase;
using SmartFlow.Report;
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

        private async void warehouseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form openForm = await CommonFunction.IsFormOpenAsync(typeof(ListWarehouse));
            if(openForm == null)
            {
                ListWarehouse warehouse = new ListWarehouse();
                warehouse.MdiParent = this;
                CommonFunction.DisposeOnClose(warehouse);
                warehouse.Show();
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
                CommonFunction.DisposeOnClose(barcodeDesign);
                barcodeDesign.Show();
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
                CommonFunction.DisposeOnClose(account);
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
                CommonFunction.DisposeOnClose(createProduct);
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

        private async void Dashboard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Form openForm = await CommonFunction.IsFormOpenAsync(typeof(Account));
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
                Form openForm = await CommonFunction.IsFormOpenAsync(typeof(Product));
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
                Form openForm = await CommonFunction.IsFormOpenAsync(typeof(AccountGroupHistory));
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

        private async void addOpenBoxProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form openForm = await CommonFunction.IsFormOpenAsync(typeof(OpenBoxProduct));
            if(openForm == null)
            {
                OpenBoxProduct openBoxProduct = new OpenBoxProduct();
                openBoxProduct.MdiParent = this;
                CommonFunction.DisposeOnClose(openBoxProduct);
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
                CommonFunction.DisposeOnClose(termsandcondition);
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
                CommonFunction.DisposeOnClose(newCompany);
                newCompany.Show();
            }
            else { openForm.BringToFront(); }
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

        private void unitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UnitList unitList = new UnitList();
            unitList.MdiParent = this;
            CommonFunction.DisposeOnClose(unitList);
            unitList.Show();
        }

        private void balanceSheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountWiseSale accountWiseSale = new AccountWiseSale();
            accountWiseSale.MdiParent = this;
            CommonFunction.DisposeOnClose (accountWiseSale);
            accountWiseSale.Show();
        }

        private void aDDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PurchaseQuotationInvoice purchaseQuotationInvoice = new PurchaseQuotationInvoice();
            purchaseQuotationInvoice.MdiParent = this;
            CommonFunction.DisposeOnClose(purchaseQuotationInvoice);
            purchaseQuotationInvoice.Show();
        }

        private void aDDToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PurchaseOrder purchaseOrderInvoice = new PurchaseOrder();
            purchaseOrderInvoice.MdiParent = this;
            CommonFunction.DisposeOnClose(purchaseOrderInvoice);
            purchaseOrderInvoice.Show();
        }
        private void aDDToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            PurchaseInvoice purchaseInvoice = new PurchaseInvoice();
            purchaseInvoice.MdiParent = this;
            CommonFunction.DisposeOnClose(purchaseInvoice);
            purchaseInvoice.Show();
        }
        private void aDDToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            PurchaseReturnInvoice purchaseReturnInvoice = new PurchaseReturnInvoice();
            purchaseReturnInvoice.MdiParent = this;
            CommonFunction.DisposeOnClose(purchaseReturnInvoice);
            purchaseReturnInvoice.Show();
        }
        private void aDDToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            SaleQuotationInvoice saleQuotationInvoice = new SaleQuotationInvoice();
            saleQuotationInvoice.MdiParent = this;
            CommonFunction.DisposeOnClose(saleQuotationInvoice);
            saleQuotationInvoice.Show();
        }
        private void aDDToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            PerformaInvoice performaInvoice = new PerformaInvoice();
            performaInvoice.MdiParent = this;
            CommonFunction.DisposeOnClose(performaInvoice);
            performaInvoice.Show();
        }
        private void aDDToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            SaleInvoice saleInvoice = new SaleInvoice();
            saleInvoice.MdiParent = this;
            CommonFunction.DisposeOnClose(saleInvoice);
            saleInvoice.Show();
        }
        private void aDDToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            SaleReturnInvoice salereturnInvoice = new SaleReturnInvoice();
            salereturnInvoice.MdiParent = this;
            CommonFunction.DisposeOnClose(salereturnInvoice);
            salereturnInvoice.Show();
        }
        private void aDDToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            Payment payment = new Payment();
            payment.MdiParent = this;
            CommonFunction.DisposeOnClose(payment);
            payment.Show();
        }
        private void aDDToolStripMenuItem9_Click(object sender, EventArgs e)
        {
            Receipts receipts = new Receipts();
            receipts.MdiParent = this;
            CommonFunction.DisposeOnClose(receipts);
            receipts.Show();
        }
        private void mODIFYToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            ModifySaleQuotation modifySaleQuotation = new ModifySaleQuotation();
            modifySaleQuotation.MdiParent = this;
            CommonFunction.DisposeOnClose(modifySaleQuotation);
            modifySaleQuotation.Show();
        }
        private void mODIFYToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            ModifyProformaInvoice modifyproforma = new ModifyProformaInvoice();
            modifyproforma.MdiParent = this;
            CommonFunction.DisposeOnClose(modifyproforma);
            modifyproforma.Show();
        }
        private void mODIFYToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            ModifySaleInvoice modifySaleInvoice = new ModifySaleInvoice();
            modifySaleInvoice.MdiParent = this;
            CommonFunction.DisposeOnClose(modifySaleInvoice);
            modifySaleInvoice.Show();
        }
        private void mODIFYToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            ModifySaleReturnInvoice modifySaleReturnInvoice = new ModifySaleReturnInvoice();
            modifySaleReturnInvoice.MdiParent = this;
            CommonFunction.DisposeOnClose(modifySaleReturnInvoice);
            modifySaleReturnInvoice.Show();
        }
        private void mODIFYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModifyPurchaseQuotation modifyPurchaseQuotation = new ModifyPurchaseQuotation();
            modifyPurchaseQuotation.MdiParent = this;
            CommonFunction.DisposeOnClose(modifyPurchaseQuotation);
            modifyPurchaseQuotation.Show();
        }
        private void mODIFYToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ModifyPurchaseReturn modifyPurchaseReturn = new ModifyPurchaseReturn();
            modifyPurchaseReturn.MdiParent = this;
            CommonFunction.DisposeOnClose(modifyPurchaseReturn);
            modifyPurchaseReturn.Show();
        }
        private void mODIFYToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            ModifyPaymentVoucher modifyPaymentVoucher = new ModifyPaymentVoucher();
            modifyPaymentVoucher.MdiParent = this;
            CommonFunction.DisposeOnClose(modifyPaymentVoucher);
            modifyPaymentVoucher.Show();
        }
        private void mODIFYToolStripMenuItem9_Click(object sender, EventArgs e)
        {
            ModifyReceiptVoucher modifyReceiptVoucher = new ModifyReceiptVoucher();
            modifyReceiptVoucher.MdiParent = this;
            CommonFunction.DisposeOnClose(modifyReceiptVoucher);
            modifyReceiptVoucher.Show();
        }
        private void aDDToolStripMenuItem10_Click(object sender, EventArgs e)
        {
            Journal journal = new Journal();
            journal.MdiParent = this;
            CommonFunction.DisposeOnClose(journal);
            journal.Show();
        }
        private void aDDToolStripMenuItem13_Click(object sender, EventArgs e)
        {
            MaterialIssueToParty materialIssueToParty = new MaterialIssueToParty();
            materialIssueToParty.MdiParent = this;
            CommonFunction.DisposeOnClose(materialIssueToParty);
            materialIssueToParty.Show();
        }
        private void aDDToolStripMenuItem14_Click(object sender, EventArgs e)
        {
            MaterialReceivedFromParty materialReceivedFromParty = new MaterialReceivedFromParty();
            materialReceivedFromParty.MdiParent = this;
            CommonFunction.DisposeOnClose(materialReceivedFromParty);
            materialReceivedFromParty.Show();
        }
        private void lISTToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            ListSalesQuotation listSalesQuotation = new ListSalesQuotation();
            listSalesQuotation.MdiParent = this;
            CommonFunction.DisposeOnClose(listSalesQuotation);
            listSalesQuotation.Show();
        }
        private void lISTToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            ListProformaInvoice listProformaInvoice = new ListProformaInvoice();
            listProformaInvoice.MdiParent = this;
            CommonFunction.DisposeOnClose(listProformaInvoice);
            listProformaInvoice.Show();
        }
        private void lISTToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            ListSaleInvoice listSaleInvoice = new ListSaleInvoice();
            listSaleInvoice.MdiParent = this;
            CommonFunction.DisposeOnClose(listSaleInvoice);
            listSaleInvoice.Show();
        }
        private void lISTToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            ListSalesReturn listSalesReturn = new ListSalesReturn();
            listSalesReturn.MdiParent = this;
            CommonFunction.DisposeOnClose(listSalesReturn);
            listSalesReturn.Show();
        }
        private void lISTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListPurchaseQuotation listPurchaseQuotation = new ListPurchaseQuotation();
            listPurchaseQuotation.MdiParent = this;
            CommonFunction.DisposeOnClose(listPurchaseQuotation);
            listPurchaseQuotation.Show();
        }
        private void lISTToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ListPurchaseOrder listPurchaseOrder = new ListPurchaseOrder();
            listPurchaseOrder.MdiParent = this;
            CommonFunction.DisposeOnClose(listPurchaseOrder);
            listPurchaseOrder.Show();
        }
        private void lISTToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ListPurchaseInvoice listPurchaseInvoice = new ListPurchaseInvoice();
            listPurchaseInvoice.MdiParent = this;
            CommonFunction.DisposeOnClose(listPurchaseInvoice);
            listPurchaseInvoice.Show();
        }
        private void lISTToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ListPurchaseReturn listPurchaseReturn = new ListPurchaseReturn();
            listPurchaseReturn.MdiParent = this;
            CommonFunction.DisposeOnClose(listPurchaseReturn);
            listPurchaseReturn.Show();
        }
        private void lISTToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            ListPayment listPayment = new ListPayment();
            listPayment.MdiParent = this;
            CommonFunction.DisposeOnClose(listPayment);
            listPayment.Show();
        }
        private void lISTToolStripMenuItem9_Click(object sender, EventArgs e)
        {
            ListReceipt listReceipt = new ListReceipt();
            listReceipt.MdiParent = this;
            CommonFunction.DisposeOnClose(listReceipt);
            listReceipt.Show();
        }
        private void lISTToolStripMenuItem10_Click(object sender, EventArgs e)
        {
            ListJournal listJournal = new ListJournal();
            listJournal.MdiParent = this;
            CommonFunction.DisposeOnClose(listJournal);
            listJournal.Show();
        }
        private void lISTToolStripMenuItem13_Click(object sender, EventArgs e)
        {
            ListMaterialIssue listMaterialIssue = new ListMaterialIssue();
            listMaterialIssue.MdiParent = this;
            CommonFunction.DisposeOnClose(listMaterialIssue);
            listMaterialIssue.Show();
        }
        private void lISTToolStripMenuItem14_Click(object sender, EventArgs e)
        {
            ListMaterialReceived listMaterialReceived = new ListMaterialReceived();
            listMaterialReceived.MdiParent = this;
            CommonFunction.DisposeOnClose(listMaterialReceived);
            listMaterialReceived.Show();
        }
        private void currencyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrencyList listCurrencyList = new CurrencyList();
            listCurrencyList.MdiParent = this;
            CommonFunction.DisposeOnClose(listCurrencyList);
            listCurrencyList.Show();
        }
        private void mODIFYToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ModifyPurchaseOrder modifyPurchaseOrder = new ModifyPurchaseOrder();
            modifyPurchaseOrder.MdiParent = this;
            CommonFunction.DisposeOnClose(modifyPurchaseOrder);
            modifyPurchaseOrder.Show();
        }
        private void mODIFYToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ModifyPurchaseInvoice modifyPurchaseInvoice = new ModifyPurchaseInvoice();
            modifyPurchaseInvoice.MdiParent = this;
            CommonFunction.DisposeOnClose(modifyPurchaseInvoice);
            modifyPurchaseInvoice.Show();
        }
        private void accountMastersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountGroupHistory accountGroupHistory = new AccountGroupHistory();
            accountGroupHistory.MdiParent = this;
            CommonFunction.DisposeOnClose(accountGroupHistory);
            accountGroupHistory.Show();
        }
        private void aDDToolStripMenuItem25_Click(object sender, EventArgs e)
        {
            CreateProduct createProduct = new CreateProduct();
            createProduct.MdiParent = this;
            CommonFunction.DisposeOnClose(createProduct);
            createProduct.Show();
        }
        private void lISTToolStripMenuItem25_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            product.MdiParent = this;
            CommonFunction.DisposeOnClose(product);
            product.Show();
        }
        private void aDDToolStripMenuItem27_Click(object sender, EventArgs e)
        {
            Account account = new Account();
            account.MdiParent = this;
            CommonFunction.DisposeOnClose(account);
            account.Show();
        }
        private void lISTToolStripMenuItem27_Click(object sender, EventArgs e)
        {
            AccountHistory accountHistory = new AccountHistory();
            accountHistory.MdiParent = this;
            CommonFunction.DisposeOnClose(accountHistory);
            accountHistory.Show();
        }

        private void mODIFYToolStripMenuItem10_Click(object sender, EventArgs e)
        {
            ModifyJournalVoucher modifyJournalVoucher = new ModifyJournalVoucher();
            modifyJournalVoucher.MdiParent = this;
            modifyJournalVoucher.Show();
        }


        private async void aDDToolStripMenuItem16_Click(object sender, EventArgs e)
        {
            Form openForm = await CommonFunction.IsFormOpenAsync(typeof(StockTransfer));
            if (openForm == null)
            {
                StockTransfer stockTransfer = new StockTransfer();
                stockTransfer.MdiParent = this;
                CommonFunction.DisposeOnClose(stockTransfer);
                stockTransfer.Show();
            }
            else { openForm.BringToFront(); }
        }

        private void lISTToolStripMenuItem16_Click(object sender, EventArgs e)
        {
            ListStockTransfer listStockTransfer = new ListStockTransfer();
            listStockTransfer.MdiParent = this;
            listStockTransfer.Show();
        }

        private async void aDDToolStripMenuItem17_Click(object sender, EventArgs e)
        {
            Form openForm = await CommonFunction.IsFormOpenAsync(typeof(DamageEntry));
            if (openForm == null)
            {
                DamageEntry damageEntry = new DamageEntry();
                damageEntry.MdiParent = this;
                CommonFunction.DisposeOnClose(damageEntry);
                damageEntry.Show();
            }
            else { openForm.BringToFront(); }
        }

        private void lISTToolStripMenuItem17_Click(object sender, EventArgs e)
        {
            ListDamageEntry listDamageEntry = new ListDamageEntry();
            listDamageEntry.MdiParent = this;
            listDamageEntry.Show();
        }

        private async void aDDToolStripMenuItem18_Click(object sender, EventArgs e)
        {
            Form openForm = await CommonFunction.IsFormOpenAsync(typeof(QtyUsingScanner));
            if (openForm == null)
            {
                QtyUsingScanner qtyUsingScanner = new QtyUsingScanner();
                qtyUsingScanner.MdiParent = this;
                CommonFunction.DisposeOnClose(qtyUsingScanner);
                qtyUsingScanner.Show();
            }
            else { openForm.BringToFront(); }
        }

        private async void aDDToolStripMenuItem19_Click(object sender, EventArgs e)
        {
            Form openForm = await CommonFunction.IsFormOpenAsync(typeof(QtyUsingMfr));
            if (openForm == null)
            {
                QtyUsingMfr qtyUsingMFR = new QtyUsingMfr();
                qtyUsingMFR.MdiParent = this;
                CommonFunction.DisposeOnClose(qtyUsingMFR);
                qtyUsingMFR.Show();
            }
            else { openForm.BringToFront(); }
        }

        private void lISTToolStripMenuItem19_Click(object sender, EventArgs e)
        {
            ListQtyUsingMFr listQtyUsingMFr = new ListQtyUsingMFr();
            listQtyUsingMFr.MdiParent = this;
            listQtyUsingMFr.Show();
        }

        private void aDDToolStripMenuItem20_Click(object sender, EventArgs e)
        {
            BookItem bookItem = new BookItem();
            bookItem.MdiParent = this;
            CommonFunction.DisposeOnClose(bookItem);
            bookItem.Show();
        }

        private void aDDToolStripMenuItem21_Click(object sender, EventArgs e)
        {
            PackingList packingList = new PackingList();
            packingList.MdiParent = this;
            CommonFunction.DisposeOnClose(packingList);
            packingList.Show();
        }

        private void aDDToolStripMenuItem22_Click(object sender, EventArgs e)
        {
            DeliveryNote deliveryNote = new DeliveryNote();
            deliveryNote.MdiParent = this;
            CommonFunction.DisposeOnClose(deliveryNote);
            deliveryNote.Show();
        }

        private void mODIFYToolStripMenuItem20_Click(object sender, EventArgs e)
        {
            ModifyBookingItem modifyBookingItem = new ModifyBookingItem();
            modifyBookingItem.MdiParent = this;
            modifyBookingItem.Show();
        }

        private void lISTToolStripMenuItem20_Click(object sender, EventArgs e)
        {
            ListBookingItem listBookingItem = new ListBookingItem();
            listBookingItem.MdiParent = this;
            listBookingItem.Show();
        }

        private void mODIFYToolStripMenuItem21_Click(object sender, EventArgs e)
        {
            ModifyPackingList packingList = new ModifyPackingList();
            packingList.MdiParent = this;
            packingList.Show();
        }

        private void lISTToolStripMenuItem21_Click(object sender, EventArgs e)
        {
            ListPackinglist listPackinglist = new ListPackinglist();
            listPackinglist.MdiParent = this;
            listPackinglist.Show();
        }

        private void mODIFYToolStripMenuItem22_Click(object sender, EventArgs e)
        {
            ModifyDeliveryNote modifyDeliveryNote = new ModifyDeliveryNote();
            modifyDeliveryNote.MdiParent = this;
            modifyDeliveryNote.Show();
        }

        private void lISTToolStripMenuItem22_Click(object sender, EventArgs e)
        {
            ListDeliveryNote listDeliveryNote = new ListDeliveryNote();
            listDeliveryNote.MdiParent = this;
            listDeliveryNote.Show();
        }

        private void aDDToolStripMenuItem11_Click(object sender, EventArgs e)
        {
            PurchaseType purchaseType = new PurchaseType();
            purchaseType.MdiParent = this;
            purchaseType.Show();
        }

        private void mODIFYToolStripMenuItem11_Click(object sender, EventArgs e)
        {
            ModifyPurchaseType modifyPurchaseType = new ModifyPurchaseType();
            modifyPurchaseType.MdiParent = this;
            modifyPurchaseType.Show();
        }

        private void lISTToolStripMenuItem11_Click(object sender, EventArgs e)
        {
            ListPurchaseType listPurchaseType = new ListPurchaseType();
            listPurchaseType.MdiParent = this;
            listPurchaseType.Show();
        }

        private void aDDToolStripMenuItem12_Click(object sender, EventArgs e)
        {
            SaleType saleType = new SaleType();
            saleType.MdiParent = this;
            saleType.Show();
        }

        private void mODIFYToolStripMenuItem12_Click(object sender, EventArgs e)
        {
            ModifySaleType modifySaleType = new ModifySaleType();
            modifySaleType.MdiParent = this;
            modifySaleType.Show();
        }

        private void lISTToolStripMenuItem12_Click(object sender, EventArgs e)
        {
            ListSaleType listSaleType = new ListSaleType();
            listSaleType.MdiParent = this;
            listSaleType.Show();
        }

        private void mODIFYToolStripMenuItem13_Click(object sender, EventArgs e)
        {
            ModifyMaterialIssue modifyMaterialIssue = new ModifyMaterialIssue();
            modifyMaterialIssue.MdiParent = this;
            modifyMaterialIssue.Show();
        }

        private void mODIFYToolStripMenuItem14_Click(object sender, EventArgs e)
        {
            ModifyMaterialReceived modifyMaterialReceived = new ModifyMaterialReceived();
            modifyMaterialReceived.MdiParent = this;
            modifyMaterialReceived.Show();
        }

        private void lISTToolStripMenuItem18_Click(object sender, EventArgs e)
        {
            ListQtyUsingScanner listQtyUsingScanner = new ListQtyUsingScanner();
            listQtyUsingScanner.MdiParent = this;
            listQtyUsingScanner.Show();
        }

        private void aDDToolStripMenuItem15_Click(object sender, EventArgs e)
        {
            DebitNote debitNote = new DebitNote();
            debitNote.MdiParent = this;
            debitNote.Show();
        }

        private void mODIFYToolStripMenuItem15_Click(object sender, EventArgs e)
        {
            ModifyDebitNote modifyDebitNote = new ModifyDebitNote();
            modifyDebitNote.MdiParent = this;
            modifyDebitNote.Show();
        }

        private void lISTToolStripMenuItem15_Click(object sender, EventArgs e)
        {
            ListDebitNote listDebitNote = new ListDebitNote();
            listDebitNote.MdiParent = this;
            listDebitNote.Show();
        }

        private void aDDToolStripMenuItem24_Click(object sender, EventArgs e)
        {
            CreditNote creditNote = new CreditNote();
            creditNote.MdiParent = this;
            creditNote.Show();
        }

        private void mODIFYToolStripMenuItem24_Click(object sender, EventArgs e)
        {
            ModifyCreditNote modifyCreditNote = new ModifyCreditNote();
            modifyCreditNote.MdiParent = this;
            modifyCreditNote.Show();
        }

        private void lISTToolStripMenuItem24_Click(object sender, EventArgs e)
        {
            ListCreditNote listCreditNote = new ListCreditNote();
            listCreditNote.MdiParent = this;
            listCreditNote.Show();
        }

        private void uPLOADUSINGEXCELToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExcelAccounts excelAccounts = new ExcelAccounts();
            excelAccounts.MdiParent = this;
            CommonFunction.DisposeOnClose(excelAccounts);
            excelAccounts.Show();
        }

        private void aCCOUNTSTATEMENTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountStatement accountStatement = new AccountStatement();
            accountStatement.MdiParent = this;
            CommonFunction.DisposeOnClose(accountStatement);
            accountStatement.Show();
        }

        private void aCCOUNTWISERECEIPTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountWiseReceipt accountWiseReceipt = new AccountWiseReceipt();
            accountWiseReceipt.MdiParent = this;
            CommonFunction.DisposeOnClose (accountWiseReceipt);
            accountWiseReceipt.Show();
        }

        private void aCCOUNTWISEPAYMENTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountWisePayment accountWisePayment = new AccountWisePayment();
            accountWisePayment.MdiParent = this;
            CommonFunction.DisposeOnClose(accountWisePayment);
            accountWisePayment.Show();
        }

        private void oPENINGBALANCEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpeningBalance openingBalance = new OpeningBalance();
            openingBalance.MdiParent = this;
            CommonFunction.DisposeOnClose(openingBalance);
            openingBalance.Show();
        }

        private void brToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListBrands listBrands = new ListBrands();
            listBrands.MdiParent = this;
            CommonFunction.DisposeOnClose(listBrands);
            listBrands.Show();
        }

        private void racksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListRacks listRacks = new ListRacks();
            listRacks.MdiParent = this;
            CommonFunction.DisposeOnClose(listRacks);
            listRacks.Show();
        }

        private void sEARCHWITHSERIALNOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchWithSerialNo searchWithSerialNo = new SearchWithSerialNo();
            searchWithSerialNo.MdiParent = this;
            CommonFunction.DisposeOnClose(searchWithSerialNo);
            searchWithSerialNo.Show();
        }

        private void aDDBOXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BoxForm boxForm = new BoxForm();
            boxForm.MdiParent = this;
            CommonFunction.DisposeOnClose(boxForm);
            boxForm.Show();
        }

        private void lISTBOXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListPackingBox listPackingBox = new ListPackingBox();
            listPackingBox.MdiParent = this;
            CommonFunction.DisposeOnClose(listPackingBox);
            listPackingBox.Show();
        }

        private void iTEMWISESALEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ItemWiseSale itemWiseSale = new ItemWiseSale();
            itemWiseSale.MdiParent = this;
            CommonFunction.DisposeOnClose(itemWiseSale);
            itemWiseSale.Show();
        }

        private void iTEMSTOCKHISTORYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ItemHistory itemHistory = new ItemHistory();
            itemHistory.MdiParent = this;
            CommonFunction.DisposeOnClose(itemHistory);
            itemHistory.Show();
        }

        private void iTEMWISEPURCHASEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ItemWisePurchase itemWisePurchase = new ItemWisePurchase();
            itemWisePurchase.MdiParent = this;
            CommonFunction.DisposeOnClose(itemWisePurchase);
            itemWisePurchase.Show();
        }

        private void iTEMWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ItemWiseSalesReturn itemWiseSalesReturn = new ItemWiseSalesReturn();
            itemWiseSalesReturn.MdiParent = this;
            CommonFunction.DisposeOnClose(itemWiseSalesReturn);
            itemWiseSalesReturn.Show();
        }

        private void cHECKSTOCKBYBRANDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BrandWiseStock brandWiseStock = new BrandWiseStock();
            brandWiseStock.MdiParent = this;
            CommonFunction.DisposeOnClose(brandWiseStock);
            brandWiseStock.Show();
        }
    }
}