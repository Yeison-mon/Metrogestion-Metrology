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

        public async Task<bool> ImportarRecepcion(int idrecepcion)
        {
            try
            {
                string sql = $@"select string_agg(id::text, ',') as ids, string_agg(idequipo::text, ',') as  idsequipo, 
                                string_agg(idmodelo::text,',')as idsmodelo, string_agg(idintervalo1::text, ',') as idsintervalo1, idcliente
                                from recepcion_detalle rd where rd.idrecepcion = {idrecepcion} and cotizado = 0 group by idcliente";
                DataTable dataTable = await dbHelper.ExecuteQueryAsync(sql);
                if (dataTable.Rows.Count > 0)
                {
                    DataRow row = dataTable.Rows[0];
                    string idsStr = row["ids"].ToString();
                    string idsEquipoStr = row["idsequipo"].ToString();
                    string idsModeloStr = row["ididsmodelos"].ToString();
                    string idsIntercalo1Str = row["idsintervalo1"].ToString();
                    int idcliente = (int)row["idcliente"];
                    string[] idsArray = idsStr.Split(',');
                    string[] idsEquipoArray = idsEquipoStr.Split(',');
                    string[] idsModeloArray = idsModeloStr.Split(',');
                    string[] idsIntervalo1Array = idsIntercalo1Str.Split(',');
                    string update = "";
                    for (int i = 0; i < idsArray.Length; i++)
                    {
                        string insert = $@"INSERT INTO public.cotizacion_detalle
                        (idcliente, idingreso, idequipo, idmodelo, idintervalo1)
                        VALUES({idcliente}, {int.Parse(idsArray[i])}, {int.Parse(idsEquipoArray[i])}, {int.Parse(idsModeloArray[i])}, {int.Parse(idsIntervalo1Array[i])});";
                        if (dbHelper.ExecuteNonQuery(insert) <= 0)
                        {
                            MessageBox.Show($"Alerta: No todos los items fueron añadidos -> Cantidad añadida: {i+1}"); 
                            return false;
                        } else
                        {
                            update = $@"update recepcion_detalle set cotizado = 1 where id = {idsArray[i]}";
                            dbHelper.ExecuteNonQuery(update);
                        }
                        update = $"UPDATE recepciones SET estado = 'Cotizado' WHERE id = {idrecepcion}";
                        dbHelper.ExecuteNonQuery(update);
                        return true;
                    }
                }
                return true;
            } catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message, "Acción cancelada");
                return false;
            }
        }
        #endregion
    }
}
