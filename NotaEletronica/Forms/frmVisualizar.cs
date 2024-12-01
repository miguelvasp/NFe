using CrystalDecisions.CrystalReports.Engine;
using NotaEletronica.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;

namespace NotaEletronica.Forms
{
    public partial class frmVisualizar : Form
    {
        private string path = AppDomain.CurrentDomain.BaseDirectory + "Reports\\";
        string TipoRelatorio = "";
        public List<FiltroRelatorio> FiltrosRelatorio = new List<FiltroRelatorio>();

        public frmVisualizar(string pTipoRelatorio)
        {
            TipoRelatorio = pTipoRelatorio;
            InitializeComponent();
        }

        private void frmVisualizar_Load(object sender, EventArgs e)
        {
            ReportDocument rep = new ReportDocument();
            string Server = Util.Util.GetAppSettings("Server");
            string Banco = Util.Util.GetAppSettings("Banco");
            string Usuario = Util.Util.GetAppSettings("Usuario");
            string Senha = Util.Util.GetAppSettings("Senha");
            string ReportName = "";

            switch (TipoRelatorio)
            {
                case "BoletosLista": ReportName = "Boletos.rpt"; break; 
            }

            rep.Load(path + ReportName);
            rep.Database.Dispose();
            rep.SetDatabaseLogon(Usuario, Senha, Server, Banco);
            foreach (var i in FiltrosRelatorio)
            {
                rep.SetParameterValue(i.Nome, i.Valor);
            }
            crystalReportViewer1.ToolPanelView = ToolPanelViewType.GroupTree;
            crystalReportViewer1.ReportSource = rep;
            var connectionInfo = new ConnectionInfo();
            connectionInfo.ServerName = Server;
            connectionInfo.DatabaseName = Banco;
            connectionInfo.Password = Senha;
            connectionInfo.UserID = Usuario;
            connectionInfo.Type = ConnectionInfoType.SQL;
            for (int i = 0; i < crystalReportViewer1.LogOnInfo.Count; i++)
            {
                crystalReportViewer1.LogOnInfo[i].ConnectionInfo = connectionInfo;
            }
            foreach (CrystalDecisions.CrystalReports.Engine.Table tbl in rep.Database.Tables)
            {
                TableLogOnInfo logon = tbl.LogOnInfo;
                logon.ConnectionInfo = connectionInfo;
                tbl.ApplyLogOnInfo(logon);
                tbl.Location = tbl.Location;
            }

            crystalReportViewer1.Refresh();
        }
    }
}
