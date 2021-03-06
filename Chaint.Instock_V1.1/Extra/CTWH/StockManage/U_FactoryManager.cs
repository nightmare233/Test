﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CTWH.Common;
using DataModel;
namespace CTWH.StockManage
{
    public partial class U_FactoryManager : DevExpress.XtraEditors.XtraUserControl
    {
        CTWH.Common.MSSQL.WMSAccess _WMSAccess;

        public U_FactoryManager()
        {
            InitializeComponent();
        }
        private void DisposeData()
        {
            _WMSAccess.SqlStateChange -= new CTWH.Common.MSSQL.WMSAccess.SqlStateEventHandler(access_SqlStateChange);
            _WMSAccess = null;
        }
        void access_SqlStateChange(object sender, SqlStateEventArgs e)
        {
            if (e.IsConnect == false)
            {
                Utils.WriteTxtLog(Utils.FilePath_txtMSSQLLog, "DataBase Error:" + e.Info);
            }
        }
        private void U_FactoryManager_Load(object sender, EventArgs e)
        {
            _WMSAccess = Utils.WMSSqlAccess;
            _WMSAccess.SqlStateChange += new CTWH.Common.MSSQL.WMSAccess.SqlStateEventHandler(access_SqlStateChange);

            WMSDS ids = this._WMSAccess.Select_T_Factory("");
            this.gridFactory.DataSource = ids.T_Factory;
            this.gridView1.BestFitColumns();
        }
    }
}
