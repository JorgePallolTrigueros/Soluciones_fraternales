using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplo_importante.datos.Entities
{
    public class Order
    {
        public int OrderId { get; set; }            // Identificador de la Orden
        public DateTime OrderDate { get; set; }     // Fecha de la Orden
        public decimal TotalAmount { get; set; }    // Importe total de la Orden

        // Relación con Customer
        public int CustomerId { get; set; }         // Clave foránea al Cliente
        public virtual Customer Customer { get; set; }  // Propiedad de navegación para el Cliente

    }
}

