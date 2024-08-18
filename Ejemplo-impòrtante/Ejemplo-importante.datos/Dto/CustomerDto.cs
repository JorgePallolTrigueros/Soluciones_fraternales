using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplo_importante.datos.Dto

{
    public class CustomerDto
    {
        public int CustomerId { get; set; }   // Identificador del Cliente
        public string FirstName { get; set; } // Nombre del Cliente
        public string LastName { get; set; }  // Apellido del Cliente
        public string Email { get; set; }     // Correo electrónico del Cliente
        public string Phone { get; set; }     // Teléfono del Cliente

        // Propiedad calculada para el nombre completo
        public string FullName => $"{FirstName} {LastName}";







    }
}

