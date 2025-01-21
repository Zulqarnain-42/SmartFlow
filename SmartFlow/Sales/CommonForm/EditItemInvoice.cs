using DocumentFormat.OpenXml.Bibliography;
using SmartFlow.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace SmartFlow.Sales.CommonForm
{
    public partial class EditItemInvoice : Form
    {
        private int _rowIndex = 0;
        private string _productmfr = string.Empty;
        private string _productname = string.Empty;
        private int _productid = 0;
        private int _quantity = 0;
        private int _unitid = 0;
        private string _unitname = string.Empty;
        private float _price = 0;
        private float _vat = 0;
        private float _discount = 0;
        private float _itemtotal = 0;
        private int _warehouseid = 0;
        private string _itemdescription = string.Empty;
        private float _lengthinmeter = 0;
        private float _priceinmeter = 0;
        private float _vatpercentage = 0;
        public EditItemInvoice(int rowindex,string productmfr,string productname,int productid,int quantity,int unitid,string unitname,float price,
            float vat,float discount,float itemtotal,int warehouseid,string itemdescription,float lengthinmeter,float priceinmeter,float vatpercentage)
        {
            InitializeComponent();
            this._rowIndex = rowindex;
            this._productmfr = productmfr;
            this._productname = productname;
            this._productid = productid;
            this._quantity = quantity;
            this._unitid = unitid;
            this._unitname = unitname;
            this._vat = vat;
            this._price = price;
            this._discount = discount;
            this._itemtotal = itemtotal;
            this._warehouseid = warehouseid;
            this._itemdescription = itemdescription;
            this._lengthinmeter = lengthinmeter;
            this._priceinmeter = priceinmeter;
            this._vatpercentage = vatpercentage;
        }

        private async void EditItemInvoice_Load(object sender, EventArgs e)
        {
            await CommonFunction.FillUnitDataAsync(unitcombobox);
            await CommonFunction.FillWarehouseDataAsync(warehousecombo);
            label1.Text = _productmfr.ToString();
            label2.Text = _productname.ToString();
            qtytxtbox.Text = _quantity.ToString();
            pricetxtbox.Text = _price.ToString();
            lengthinmetertxtbox.Text = _lengthinmeter.ToString();
            discounttxtbox.Text = _discount.ToString();
            vattxtbox.Text = _vatpercentage.ToString();
            itemdescriptiontxtbox.Text = _itemdescription.ToString();
            unitcombobox.SelectedValue = _unitid;
            warehousecombo.SelectedValue = _warehouseid;
            totalwithvatanddiscountlbl.Text = _itemtotal.ToString("N2");
            unitidlbl.Text = _unitid.ToString();
            warehouseidlbl.Text = _warehouseid.ToString();
            productidlbl.Text = _productid.ToString();
            rowindexlbl.Text = _rowIndex.ToString();
            vatamountlbl.Text = _vat.ToString("N2");
        }
    }
}
