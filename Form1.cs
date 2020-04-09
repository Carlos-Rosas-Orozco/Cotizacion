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
    public partial class Cotizaciones : Form
    {
        int id;
        Boolean editar;
        public Cotizaciones()
        {
            InitializeComponent();
        }
        Conexion con = new Conexion();
        public void ActualizarGrid()
        {
            con.ActualizarGrid(this.DataGrid, "Select id_tabla,producto,unidad_medida,cantidad,precio_unitario, importe from Tabla_Cotizacion ");
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            editar = false;
            this.ActualizarGrid();
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void lblArticulo_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (editar)
            {
                con.Conectar();
                string consulta = "update Tabla_Cotizacion set producto = '" + txtProducto.Text + "', unidad_medida ='" + txtUnidadMedida.Text + "', cantidad = " + txtCantidad.Text + ",precio_unitario = " + txtPrecioUnitario.Text + ",importe = " + txtImporte.Text + "where id_tabla = " + id +";";
                con.EjecutarSQL(consulta);
                this.ActualizarGrid();
                con.Desconectar();
                this.limpiar();
                editar = false;
            }
            else
            {
                con.Conectar();
                string consulta = "insert into Tabla_Cotizacion (producto,unidad_medida,cantidad,precio_unitario,importe) values ('" + txtProducto.Text + "','" + txtUnidadMedida.Text + "'," + txtCantidad.Text + "," + txtPrecioUnitario.Text + "," + txtImporte.Text + ");";
                con.EjecutarSQL(consulta);
                con.Desconectar();
                this.ActualizarGrid();
                this.limpiar();
            }
            double subtotal = 0;
            double iva = 0;
            double total = 0;
            foreach (DataGridViewRow row in DataGrid.Rows)
            {
                subtotal += Convert.ToDouble(row.Cells["importe"].Value);
            }
            txtSubtotal.Text = Convert.ToString(subtotal);
            iva = subtotal * 0.16;
            total = subtotal + iva;
            txtIva.Text = Convert.ToString(iva);
            txtTotal.Text = Convert.ToString(total);
        }

        private void txtPrecioUnitario_Leave(object sender, EventArgs e)
        {
            double v1, v2, r;
            v1 = Convert.ToDouble(txtCantidad.Text);
            v2 = Convert.ToDouble(txtPrecioUnitario.Text);
            r = v1 * v2;
            txtImporte.Text = r.ToString();
        }

        private void txtSubtotal_Leave(object sender, EventArgs e)
        {
            //Control inactivo
        }
        public void limpiar()
        {
            txtCantidad.Text = " ";
            txtPrecioUnitario.Text = " ";
            txtProducto.Text = " ";
            txtUnidadMedida.Text = " ";
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            editar = true;
            id = int.Parse(this.DataGrid.CurrentRow.Cells[0].Value.ToString());
            txtProducto.Text = this.DataGrid.CurrentRow.Cells[1].Value.ToString();
            txtUnidadMedida.Text = this.DataGrid.CurrentRow.Cells[2].Value.ToString();
            txtCantidad.Text = this.DataGrid.CurrentRow.Cells[3].Value.ToString();
            txtPrecioUnitario.Text = this.DataGrid.CurrentRow.Cells[4].Value.ToString();
            txtImporte.Text = this.DataGrid.CurrentRow.Cells[5].Value.ToString();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            id = int.Parse(this.DataGrid.CurrentRow.Cells[0].Value.ToString());
            var resultado = MessageBox.Show("¿Desea eliminar el producto?", "Confime el borrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                con.Conectar();
                string consulta = "delete from Tabla_Cotizacion where id_tabla = " + id + ";";
                con.EjecutarSQL(consulta);
                this.ActualizarGrid();
                con.Desconectar();
            }
            else
            {

            }
        }

        private void txtBuscarProducto_KeyUp(object sender, KeyEventArgs e)
        {
            con.ActualizarGrid(this.DataGrid, "select id_tabla,producto,unidad_medida,cantidad,precio_unitario, importe from Tabla_Cotizacion where producto like '" + txtBuscarProducto.Text + "%';");
        }

        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            /**DateTime fecha = DateTime.Today;
            con.Conectar();
            string consulta = "insert into Numero_Cotizacion (nombre_cotizacion,subtotal,iva,total) values ('" + txtNombreCotizacion.Text + "'," + txtSubtotal.Text + "," + txtIva.Text + "," + txtTotal.Text + ");";
            con.EjecutarSQL(consulta);
            con.Desconectar();**/
            ReporteCrystal generar = new ReporteCrystal();
            generar.Show();
        }
    }

}
