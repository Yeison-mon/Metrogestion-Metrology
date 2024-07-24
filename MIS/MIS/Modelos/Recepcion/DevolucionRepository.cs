using MIS.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Modelos.Recepcion
{
    public class DevolucionRepository
    {
        private readonly PostgreSQLHelper dbHelper;
        public DevolucionRepository()
        {
            dbHelper = PostgreSQLHelper.GetInstance();
        }

        public async Task<DataTable> Detalle(int id)
        {
            try
            {

                string query = $@"
                SELECT rd.id, renglon,
                   'NR-' || to_char(rd.fechaing, 'YY-') || to_char(r.recepcion, '0000') || '-' || rd.renglon AS ingreso,
                   'EQUIPO: ' || e.descripcion || '; MAGNITUD: ' || m.descripcion ||
                   '; MARCA: ' || ma.descripcion || '; MODELO: ' || mo.descripcion || CASE WHEN rd.codigo not in ('', 'Sin Información') THEN ' SERIE: ' || rd.serie || ' CÓDIGO: ' || rd.codigo ELSE ' SERIE: ' || rd.serie end ||
                   CASE WHEN rd.idintervalo1 > 0 then '; RANGO: (' || mi1.desde || ' a ' || mi1.hasta || ') ' || mi1.medida else '; RANGO: VER ESPECIFICACIONES' end ||
                   CASE WHEN rd.idintervalo2 > 0 then '; RANGO 2: (' || mi2.desde || ' a ' || mi2.hasta || ') ' || mi2.medida else '' end ||
                   CASE WHEN rd.accesorios != '' THEN '; OBSERVACIÓN: ' || rd.observacion || '; ACCESORIOS: ' || rd.accesorios ELSE '; OBSERVACIÓN: ' || rd.observacion end || '; SERVICIO: ' || rd.tipo_servicio  as descripcion,
                   coalesce(pd.certificado, 0) as  certificado
                    FROM recepcion_detalle rd  
                    INNER JOIN equipos e ON rd.idequipo = e.id  
                    INNER JOIN magnitudes m ON rd.idmagnitud = m.id  
                    INNER JOIN magnitud_intervalos mi1 ON rd.idintervalo1 = mi1.id  
                    INNER JOIN marcas ma ON rd.idmarca = ma.id  
                    INNER JOIN modelos mo ON rd.idmodelo = mo.id  
                    INNER JOIN recepciones r ON rd.idrecepcion = r.id
                    inner join magnitud_intervalos mi2 ON rd.idintervalo2 = mi2.id
                    inner join clientes c on r.idcliente = c.id
                    inner join inspeccion_detalle id on id.idingreso = rd.id
                    left join procesofinal_detalle pd on pd.idingreso = rd.id
                WHERE r.id = {id} and rd.inactivo = 0 and (rd.cotizado = 1 or c.convenio = 1) order by id asc";
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
                FG.ShowError($"Error al obtener datos de la base de datos: {ex.Message}", "error");
                return null;
            }
        }

        public async Task<DataTable> Buscar(int idrecepcion, int devolucion, int recepcion)
        {
            try
            {
                string where = $"where r.id = {idrecepcion}";
                if (devolucion > 0)
                {
                    where = $"where d.devolucion = {devolucion}";
                }
                if (recepcion > 0)
                {
                    where = $"where r.recepcion = {recepcion}";
                }
                string query = $@"select r.id, c.id as idcliente, r.recepcion, r.fecha as fecha_recepcion, coalesce(d.id, 0) as iddevolucion, r.idcliente, c.nombrecompleto as cliente, coalesce(d.estado, '') as estado, coalesce(d.devolucion , 0) as devolucion,
                            coalesce(d.fecha) as fecha
                        from recepciones r 
                    inner join clientes c on c.id = r.idcliente
                    inner join recepcion_detalle rd on rd.idrecepcion = r.id
                    left join devolucion_detalle dd on dd.idingreso = rd.id
                    left join devolucion d on d.id = dd.iddevolucion 
                    {where}
                    group by r.id, r.idcliente, r.fecha, c.id, c.nombrecompleto, d.id, d.devolucion, d.fecha, d.estado;";
                DataTable dataTable = await dbHelper.ExecuteQueryAsync(query);
                if (dataTable == null)
                    return null;
                else
                    return dataTable;
            }
            catch (Exception ex)
            {
                FG.ShowError("Error: " + ex.Message, "Error");
                return null;
            }
        }
        public async Task<int> Guardar(List<int> ids, int devolucion, string observacion)
        {
            try
            {
                string insert = "";
                string update = "";
                string busContador = "select devolucion from contador where id = 1";
                object contador = await dbHelper.ExecuteScalarAsync(busContador);
                if (contador != null)
                {
                    int devo = Convert.ToInt32(contador) + 1;
                    if (devolucion == 0)
                    {
                        insert = $"INSERT INTO devolucion(devolucion, idusuario, estado, observacion) " +
                                         $"VALUES({devo}, {FG.UserId}, 'Registrado', '{observacion}') RETURNING id";

                    }
                    else
                    {
                        insert = $"update devolucion set observacion='{observacion}', where devolucion = {devolucion} returning id";
                    }

                    object idGenerado = dbHelper.ExecuteScalar(insert);

                    if (idGenerado != null && idGenerado != DBNull.Value && Convert.ToInt32(idGenerado) != 0)
                    {
                        for (int i = 0; i < ids.Count; i++)
                        {

                            int id = ids[i];
                            int idingreso = Convert.ToInt32(dbHelper.ExecuteScalar($"select coalesce(idingreso, 0) from devolucion_detalle where idingreso = {id}"));
                            if (idingreso == 0)
                            {
                                insert = $@"INSERT INTO devolucion_detalle(idingreso, iddevolucion) 
                                VALUES ({id}, {Convert.ToInt32(idGenerado)})";
                                dbHelper.ExecuteNonQuery(insert);
                            }

                        }
                        if (devolucion <= 0)
                        {
                            update = $"UPDATE contador SET devolucion = {devo} WHERE id = 1";
                            dbHelper.ExecuteNonQuery(update);
                        }

                        if (devolucion > 0)
                        {
                            FG.ShowMsg("Actualizado con éxito", "");
                            return devolucion;
                        }
                        else
                        {
                            FG.ShowMsg("Guardado con éxito", "");
                            return devo;
                        }

                    }
                    else
                    {
                        FG.ShowAlert("No se guardo la devolucion", "GuardarDevolucion");
                        return 0;
                    }

                }
                else
                {
                    FG.ShowAlert("No se encontro el numero de devolucion en el contador.", "GuardarRecepcion");
                    return 0;
                }


            }
            catch (Exception ex)
            {
                FG.ShowError("Error al eliminar ingreso(s): " + ex.Message, "GuardarRecepcion");
                return 0;
            }
        }

        public async Task<int> EnviarCertificados(int iddevolucion)
        {
            try
            {
                var sql = $"select * from devolucion where id = {iddevolucion}";
                
                return 0;


            }
            catch (Exception ex)
            {
                FG.ShowError("Error al eliminar ingreso(s): " + ex.Message, "GuardarRecepcion");
                return 0;
            }
        }
    }
}
