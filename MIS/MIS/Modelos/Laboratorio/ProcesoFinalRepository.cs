using MIS.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MIS.Modelos.Laboratorio
{
    public class ProcesoFinalRepository
    {
        private readonly PostgreSQLHelper dbHelper;
        public ProcesoFinalRepository()
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
                   coalesce(pd.lavado, '') as lavado, coalesce(pd.componentes::Text, '0') as componentes, coalesce(pd.desarme, '') as desarme, coalesce(pd.ensamblaje, '') as ensamblaje,
                   'MIS-'|| m.abreviatura || '-' || trim(to_char(now(), 'YYYY')) || '-' as nomenclatura, coalesce(pd.certificado::text, '') as certificado, 
                    coalesce(pd.fecha_certificado, '') as fecha_certificado,  coalesce(pd.idacreditado, 1) as tipo, coalesce(pd.observacion, '') as observacion
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
                    inner join ordentrabajo_detalle od on od.idingreso = rd.id
                    left join procesofinal_detalle pd on pd.idingreso = od.idingreso
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

        public async Task<DataTable> Buscar(int idrecepcion, int ordentrabajo, int procesofinal)
        {
            try
            {
                string where = "where ";
                if (ordentrabajo > 0)
                {
                    where += $"o.orden = {ordentrabajo}";
                }
                else if (idrecepcion > 0)
                {
                    where += $"r.id = {idrecepcion}";
                }
                 else if (procesofinal > 0)
                {
                    where += $"pf.procesofinal = {procesofinal}";
                }
                else
                {
                    FG.ShowAlert("No se proporciono la informacion", "Alerta");
                    return null;
                }
                string query = $@"select r.id, coalesce(pf.id, 0) as idipf, r.idcliente, c.nombrecompleto as cliente, coalesce(pf.estado, '') as estado, coalesce(pf.procesofinal, 0) as  procesofinal,
                            o.orden as ordentrabajo, o.idusuorden as idmetrologo, o.fecha as fecha_orden, coalesce(pf.fecha) as fecha
                        from recepciones r 
                    inner join clientes c on c.id = r.idcliente
                    inner join recepcion_detalle rd on rd.idrecepcion = r.id 
                    inner join ordentrabajo_detalle od on od.idingreso = rd.id
                    inner join ordentrabajo o on o.id = od.idorden 
                    left join procesofinal_detalle pd on pd.idingreso = od.idingreso
                    left join procesosfinales pf on pf.id = pd.idprocesofinal
                        {where} and o.idusuorden = {FG.UserId}
                    group by r.id, r.idcliente, c.nombrecompleto, pf.id, o.orden, o.fecha, o.idusuorden, pf.estado, pf.procesofinal, pf.fecha;";
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
        public async Task<int> GuardarProcesoFinal(List<int> ids, List<string> lavados, List<string> componentes, List<string> desarmes, List<string> ensambles, List<int> certificados,List<string> fechas, List<int> tipos, int ipf, string observacion)
        {
            try
            {
                string insert = "";
                string update = "";
                string busContador = "select proceso_final from contador where id = 1";
                object contador = await dbHelper.ExecuteScalarAsync(busContador);
                if (contador != null)
                {
                    int con_proceso_final = Convert.ToInt32(contador) + 1;
                    if (ipf == 0)
                    {
                        insert = $"INSERT INTO procesosfinales(procesofinal, idusuario, estado, observacion) " +
                                         $"VALUES({con_proceso_final}, {FG.UserId}, 'Inspeccionado', '{observacion}') RETURNING id";

                    }
                    else
                    {
                        insert = $"update procesosfinales set observacion='{observacion}' where procesofinal = {ipf} returning id";
                    }

                    object idGenerado = dbHelper.ExecuteScalar(insert);

                    if (idGenerado != null && idGenerado != DBNull.Value && Convert.ToInt32(idGenerado) != 0)
                    {
                        for (int i = 0; i < ids.Count; i++)
                        {

                            int id = ids[i];
                            string lavado = lavados[i];
                            string componente = componentes[i];
                            string desarme = desarmes[i];
                            string ensamble = ensambles[i];
                            int tipo = tipos[i];
                            int certificado = certificados[i];
                            string fecha = fechas[i];
                            int idingreso = Convert.ToInt32(dbHelper.ExecuteScalar($"select coalesce(idingreso, 0) from procesofinal_detalle where idingreso = {id}"));
                            if (idingreso > 0)
                            {
                                update = $@"UPDATE procesofinal_detalle
                                        SET lavado='{lavado}', componentes='{componente}', desarme='{desarme}', ensamblaje= '{ensamble}', certificado= {certificado}, idacreditado={tipo}, fecha_certificado='{fecha}'
                                        WHERE idingreso = {id}";
                                dbHelper.ExecuteNonQuery(update);
                            }
                            else
                            {
                                insert = $@"INSERT INTO procesofinal_detalle (idingreso, idprocesofinal, lavado, componentes, desarme, ensamblaje, certificado, fecha_certificado, idacreditado) 
                                    VALUES ({id}, {Convert.ToInt32(idGenerado)}, '{lavado}', '{componente}', '{desarme}', '{ensamble}', {certificado}, '{fecha}', {tipo})";
                                dbHelper.ExecuteNonQuery(insert);
                            }

                        }
                        if (ipf <= 0)
                        {
                            update = $"UPDATE contador SET proceso_final= {con_proceso_final} WHERE id = 1";
                            dbHelper.ExecuteNonQuery(update);
                        }

                        if (ipf > 0)
                        {
                            MessageBox.Show("Actualizado con éxito");
                            return ipf;
                        }
                        else
                        {
                            MessageBox.Show("Guardado con éxito");
                            return con_proceso_final;
                        }

                    }
                    else
                    {
                        MessageBox.Show("No se guardo la IPF", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return 0;
                    }

                }
                else
                {
                    MessageBox.Show("No se encontro el numero de inspeccion en el contador.", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return 0;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar ingreso(s): " + ex.Message, "GuardarRecepcion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        public int Culminar(int idipf)
        {
            try
            {
                string update = $"update procesosfinales set estado='Culminado' where id= {idipf} returning id";
                object idGenerado = dbHelper.ExecuteScalar(update);
                if (Convert.ToInt32(idGenerado) > 0) 
                    return 1;
                else 
                    return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar ingreso(s): " + ex.Message, "GuardarRecepcion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
    }
}
