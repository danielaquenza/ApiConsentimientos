//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApiConsentimientos
{
    using System;
    using System.Collections.Generic;
    
    public partial class Usuario
    {
        public string tipoId { get; set; }
        public int numeroId { get; set; }
        public string contrasena { get; set; }
        public bool admin { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string especialidad { get; set; }
        public string tarjetaProfesional { get; set; }
        public string email { get; set; }
        public byte[] firma { get; set; }
        public byte[] huella { get; set; }
        public byte[] huellaImg { get; set; }
    }
}
