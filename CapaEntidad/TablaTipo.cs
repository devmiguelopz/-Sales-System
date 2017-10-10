using CapaDominio;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class TablaTipo
    {
    }
    public class tBaseDetalleVenta : List<DetalleVenta>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            SqlDataRecord ret = new SqlDataRecord(
                new SqlMetaData("DetalleVenta", SqlDbType.Int),
                new SqlMetaData("IdProducto", SqlDbType.Int),
                new SqlMetaData("IdVenta", SqlDbType.Int),
                new SqlMetaData("Cantidad", SqlDbType.Int),
                new SqlMetaData("PrecioUnitario", SqlDbType.Decimal),
                new SqlMetaData("Igv", SqlDbType.Money),
                new SqlMetaData("SubTotal", SqlDbType.Money)
                );
            foreach (DetalleVenta data in this)
            {
                ret.SetInt32(0, data.IdDetalleVenta);
                ret.SetInt32(1, data.IdP);
                ret.SetInt32(2, data.IdVenta);
                ret.SetInt32(3, data.Cantidad);
                ret.SetDecimal(4, data.PUnitario);
                ret.SetDecimal(5, data.Igv);
                ret.SetDecimal(6, data.SubTotal);
                yield return ret;
            }
        }
    }
}
