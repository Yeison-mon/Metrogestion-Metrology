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

                string where = $" where cd.idcliente = {idcliente} and cd.idcotizacion = {idcotizacion}";
                string query = $@"SELECT cd.id, renglon, cd.idcliente,
                           'NR-' || to_char(rd.fechaing, 'YY-') || to_char(r.recepcion, '0000') || '-' || rd.renglon AS ingreso,
                           'EQUIPO: ' || e.descripcion || '; MAGNITUD: ' || m.descripcion ||
                           '; MARCA: ' || ma.descripcion || '; MODELO: ' || mo.descripcion || CASE WHEN cd.codigo not in ('', 'Sin Información') THEN ' SERIE: ' || cd.serie || ' CÓDIGO: ' || cd.codigo ELSE ' SERIE: ' || cd.serie end ||
                           CASE WHEN cd.idintervalo1 > 0 then '; RANGO: (' || mi1.desde || ' a ' || mi1.hasta || ') ' || mi1.medida else '; RANGO: VER ESPECIFICACIONES' end ||
                           CASE WHEN cd.idintervalo2 > 0 then '; RANGO 2: (' || mi2.desde || ' a ' || mi2.hasta || ') ' || mi2.medida else '' end as descripcion,
                           cd.precio, cd.iva, cd.descuento, case when cd.cantidad = 0 then 1 else cd.cantidad end as cantidad, tm.descripcion as moneda
                           from cotizacion_detalle cd 
                        INNER JOIN equipos e ON cd.idequipo = e.id  
                        INNER JOIN magnitudes m ON e.idmagnitud = m.id  
                        INNER JOIN magnitud_intervalos mi1 ON cd.idintervalo1 = mi1.id  
                        inner JOIN modelos mo ON cd.idmodelo = mo.id  
                        inner JOIN marcas ma ON mo.idmarca = ma.id
                        inner join magnitud_intervalos mi2 ON cd.idintervalo2 = mi2.id
                        inner join tipo_moneda tm on tm.id = cd.idmoneda
                        left join recepcion_detalle rd on rd.id = cd.idingreso 
                        left JOIN recepciones r ON rd.idrecepcion = r.id
                        left join inspeccion_detalle id on id.idingreso = rd.id
                        {where} order by id desc";
                //MessageBox.Show(query);
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
                string sql = $@"select string_agg(id::text, ',') as ids, string_agg(idequipo::text, ',') as  idsequipo, string_agg(serie, ',') as series, string_agg(codigo, ',') as codigos, 
                                string_agg(idmodelo::text,',')as idsmodelo, string_agg(idintervalo1::text, ',') as idsintervalo1, string_agg(idintervalo2::text, ',') as idsintervalo2, idcliente
                                from recepcion_detalle rd where rd.idrecepcion = {idrecepcion} and cotizado = 0 group by idcliente";
                DataTable dataTable = await dbHelper.ExecuteQueryAsync(sql);
                if (dataTable.Rows.Count > 0)
                {
                    DataRow row = dataTable.Rows[0];
                    string idsStr = row["ids"].ToString();
                    string idsEquipoStr = row["idsequipo"].ToString();
                    string idsModeloStr = row["idsmodelo"].ToString();
                    string idsIntercalo1Str = row["idsintervalo1"].ToString();
                    string idsIntercalo2Str = row["idsintervalo2"].ToString();
                    string seriesStr = row["series"].ToString();
                    string codigosStr = row["codigos"].ToString();
                    int idcliente = (int)row["idcliente"];
                    string[] idsArray = idsStr.Split(',');
                    string[] idsEquipoArray = idsEquipoStr.Split(',');
                    string[] idsModeloArray = idsModeloStr.Split(',');
                    string[] idsIntervalo1Array = idsIntercalo1Str.Split(',');
                    string[] idsIntervalo2Array = idsIntercalo2Str.Split(',');
                    string[] seriesArray = seriesStr.Split(',');
                    string[] codigosArray = codigosStr.Split(',');
                    string update = "";
                    for (int i = 0; i < idsArray.Length; i++)
                    {
                        string insert = $@"INSERT INTO public.cotizacion_detalle
                        (idcliente, idingreso, idequipo, idmodelo, idintervalo1, idintervalo2, serie, codigo, iva)
                        VALUES({idcliente}, {int.Parse(idsArray[i])}, {int.Parse(idsEquipoArray[i])}, {int.Parse(idsModeloArray[i])}, {int.Parse(idsIntervalo1Array[i])}, {int.Parse(idsIntervalo2Array[i])}, '{seriesArray[i]}', '{codigosArray[i]}', 19);";
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
