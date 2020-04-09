using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Citas_1._0
{
    public partial class ReporteCrystal : Form
    {
        private Reporte_Cotizacion Reporte_Cotizacion1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;

        public ReporteCrystal()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.Reporte_Cotizacion1 = new Citas_1._0.Reporte_Cotizacion();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = 0;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ReportSource = this.Reporte_Cotizacion1;
            this.crystalReportViewer1.Size = new System.Drawing.Size(908, 464);
            this.crystalReportViewer1.TabIndex = 0;
            // 
            // ReporteCrystal
            // 
            this.ClientSize = new System.Drawing.Size(908, 464);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "ReporteCrystal";
            this.ResumeLayout(false);

        }
    }
}
