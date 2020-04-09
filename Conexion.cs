using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Citas_1._0
{
    class Conexion
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataAdapter adap;
        SqlDataReader dr;

        public void Conectar()
        {
            try
            {
                cn = new SqlConnection("Data Source=DESKTOP-F9IBHA9\\SQLEXPRESS;initial Catalog=cotizacion;Persist Security Info=True;User ID=carlos;Password=1234");
                cn.Open();
                //MessageBox.Show("Conectado");
            }

            catch(Exception ex)
            {
                MessageBox.Show("No conectado" + ex.ToString());
            }
        }
        public void Desconectar()
        {
            cn.Close();
        }
        public void EjecutarSQL(String consulta)
        {
            cmd = new SqlCommand(consulta, cn);
            int filasAfectadas = cmd.ExecuteNonQuery();
            if(filasAfectadas > 0)
            {
                //MessageBox.Show("Agegado");
            }
            else
            {
                MessageBox.Show("Error");
            }
        }
        public void ActualizarGrid(DataGridView dg, string consulta)
        {
            this.Conectar();
            System.Data.DataSet ds = new System.Data.DataSet();
            adap = new SqlDataAdapter(consulta,cn);
            adap.Fill(ds, "Tabla_Cotizacion");
            dg.DataSource = ds;
            dg.DataMember = "Tabla_Cotizacion";
            this.Desconectar();
        }
    }
}
