using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplo_importante.datos.Entities
{

    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}"; // O agrega esta propiedad si deseas usar FullName



 
        public string Email { get; set; }       // Correo electrónico del Cliente
        public string Phone { get; set; }       // Teléfono del Cliente

        // Propiedad calculada para el nombre completo
    }
}


