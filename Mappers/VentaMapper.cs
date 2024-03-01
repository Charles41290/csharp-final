using DTOs;
using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mappers
{
    public class VentaMapper
    {
        public static Venta MapearAVenta(VentaDTO ventaDto)
        {
            Venta venta = new Venta();
            venta.Comentarios = ventaDto.Comentarios;
            venta.IdUsuario = ventaDto.IdUsuario;
            return venta;
        }

        public static VentaDTO MapearADto(Venta venta) 
        {
            VentaDTO ventaDto = new VentaDTO();
            ventaDto.Comentarios = venta.Comentarios;
            ventaDto.IdUsuario = venta.IdUsuario;
            return ventaDto;
        }
    }
}
