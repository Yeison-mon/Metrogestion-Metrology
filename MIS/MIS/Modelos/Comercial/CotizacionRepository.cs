using MIS.Helpers;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;

namespace MIS.Modelos.Comercial
{
    public class CotizacionRepository
    {
        private readonly PostgreSQLHelper dbHelper;
        public CotizacionRepository()
        {
            dbHelper = PostgreSQLHelper.GetInstance();
        }
        #region Registro
        public async Task<DataTable> BuscarCliente(int idcliente, string documento)
        {
            try
            {
                string query = "";
                if (idcliente == 0 && documento != "")
                {
                    query = $@"select c.id, c.documento as documento, c.nombrecompleto as nombrecompleto from clientes c 
                        where c.id > 0 and documento = '{documento}' order by c.nombrecompleto";
                }
                if (idcliente > 0 && documento == "")
                {
                    query = $"select c.id, c.documento as documento, c.nombrecompleto as nombrecompleto from clientes c " +
                    $" where c.id = {idcliente} order by c.nombrecompleto";
                }
                if (query != "")
                {
                    DataTable dataTable = await dbHelper.ExecuteQueryAsync(query);
                    if (dataTable.Rows.Count > 0)
                        return dataTable;
                    else
                        return null;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error BuscarClientesModal(): " + ex.Message);
                return null;
            }
        }

        public async Task<DataTable> Detalle(int idcliente, int idcotizacion)
        {
            try
            {
                string where = "";
                if (idcotizacion > 0)
                {
                    where += $" where r.recepcion = {idcotizacion} and cd.idcliente = {idcliente}";
                }
                else
                {
                    where += $" where cd.idrecepcion = 0 and cd.idcliente = {idcliente}";
                }
                string query = $@"";
                DataTable dataTable = await dbHelper.ExecuteQueryAsync(query);
                if (dataTable != null)
                {
                    return dataTable;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener datos de la base de datos: {ex.Message}", "warning");
                return null;
            }
        }

        public async Task<bool> ImportarDetalle(int recepcion)
        {
            string sql = "select * from ";
            return true;
        }
        #endregion
    }
}
