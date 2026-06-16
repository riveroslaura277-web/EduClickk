using EduClick.Models;

namespace EduClick.Data
{
    public static class DatosPrueba
    {
        public static List<Estudiante> Estudiantes() => new()
        {
            new Estudiante { Id=1,  Codigo="EST001", Nombres="Ana",       Apellidos="García",   Grado=1, Estado="Activo"   },
            new Estudiante { Id=2,  Codigo="EST002", Nombres="Luis",      Apellidos="Martínez", Grado=1, Estado="Activo"   },
            new Estudiante { Id=3,  Codigo="EST003", Nombres="María",     Apellidos="López",    Grado=1, Estado="Inactivo" },
            new Estudiante { Id=4,  Codigo="EST004", Nombres="Pedro",     Apellidos="Ramírez",  Grado=1, Estado="Activo"   },
            new Estudiante { Id=5,  Codigo="EST005", Nombres="Laura",     Apellidos="Torres",   Grado=2, Estado="Activo"   },
            new Estudiante { Id=6,  Codigo="EST006", Nombres="Carlos",    Apellidos="Herrera",  Grado=2, Estado="Activo"   },
            new Estudiante { Id=7,  Codigo="EST007", Nombres="Sofía",     Apellidos="Vargas",   Grado=2, Estado="Inactivo" },
            new Estudiante { Id=8,  Codigo="EST008", Nombres="Diego",     Apellidos="Castro",   Grado=2, Estado="Activo"   },
            new Estudiante { Id=9,  Codigo="EST009", Nombres="Valentina", Apellidos="Morales",  Grado=3, Estado="Activo"   },
            new Estudiante { Id=10, Codigo="EST010", Nombres="Andrés",    Apellidos="Jiménez",  Grado=3, Estado="Activo"   },
            new Estudiante { Id=11, Codigo="EST011", Nombres="Isabella",  Apellidos="Rojas",    Grado=3, Estado="Activo"   },
            new Estudiante { Id=12, Codigo="EST012", Nombres="Sebastián", Apellidos="Mendoza",  Grado=3, Estado="Inactivo" },
            new Estudiante { Id=13, Codigo="EST013", Nombres="Camila",    Apellidos="Ríos",     Grado=4, Estado="Activo"   },
            new Estudiante { Id=14, Codigo="EST014", Nombres="Felipe",    Apellidos="Peña",     Grado=4, Estado="Activo"   },
            new Estudiante { Id=15, Codigo="EST015", Nombres="Natalia",   Apellidos="Salinas",  Grado=4, Estado="Activo"   },
            new Estudiante { Id=16, Codigo="EST016", Nombres="Mateo",     Apellidos="Cruz",     Grado=4, Estado="Inactivo" },
            new Estudiante { Id=17, Codigo="EST017", Nombres="Daniela",   Apellidos="Flores",   Grado=5, Estado="Activo"   },
            new Estudiante { Id=18, Codigo="EST018", Nombres="Santiago",  Apellidos="Reyes",    Grado=5, Estado="Activo"   },
            new Estudiante { Id=19, Codigo="EST019", Nombres="Gabriela",  Apellidos="Soto",     Grado=5, Estado="Activo"   },
            new Estudiante { Id=20, Codigo="EST020", Nombres="Nicolás",   Apellidos="Medina",   Grado=5, Estado="Inactivo" },
        };

        public static List<Docente> Docentes() => new()
        {
            new Docente { Id=1, Nombres="Jorge",    Apellidos="García",   Correo="j.garcia@educlick.co",   Telefono="3101234567", Especialidad="Matemáticas",       Estado="Activo"   },
            new Docente { Id=2, Nombres="Patricia", Apellidos="López",    Correo="p.lopez@educlick.co",    Telefono="3209876543", Especialidad="Español",            Estado="Activo"   },
            new Docente { Id=3, Nombres="Ricardo",  Apellidos="Martínez", Correo="r.martinez@educlick.co", Telefono="3154567890", Especialidad="Ciencias Naturales", Estado="Activo"   },
            new Docente { Id=4, Nombres="Sandra",   Apellidos="Torres",   Correo="s.torres@educlick.co",   Telefono="3001112233", Especialidad="Ciencias Sociales",  Estado="Inactivo" },
            new Docente { Id=5, Nombres="Mauricio", Apellidos="Herrera",  Correo="m.herrera@educlick.co",  Telefono="3123334455", Especialidad="Inglés",             Estado="Activo"   },
            new Docente { Id=6, Nombres="Claudia",  Apellidos="Vargas",   Correo="c.vargas@educlick.co",   Telefono="3176665544", Especialidad="Educación Física",   Estado="Activo"   },
            new Docente { Id=7, Nombres="Héctor",   Apellidos="Castro",   Correo="h.castro@educlick.co",   Telefono="3187778899", Especialidad="Arte",               Estado="Activo"   },
            new Docente { Id=8, Nombres="Liliana",  Apellidos="Morales",  Correo="l.morales@educlick.co",  Telefono="3219990011", Especialidad="Tecnología",         Estado="Inactivo" },
        };

        public static List<Acudiente> Acudientes() => new()
        {
            new Acudiente { Id=1,  Nombres="Rosa",    Apellidos="García",   Direccion="Calle 10 #5-20",   Telefono="3101111111", NombreEstudiante="Ana García",       Estado="Activo"   },
            new Acudiente { Id=2,  Nombres="Marco",   Apellidos="Martínez", Direccion="Carrera 8 #12-34", Telefono="3202222222", NombreEstudiante="Luis Martínez",    Estado="Activo"   },
            new Acudiente { Id=3,  Nombres="Elena",   Apellidos="López",    Direccion="Av. 15 #22-10",    Telefono="3153333333", NombreEstudiante="María López",      Estado="Inactivo" },
            new Acudiente { Id=4,  Nombres="Ernesto", Apellidos="Ramírez",  Direccion="Calle 45 #8-90",   Telefono="3004444444", NombreEstudiante="Pedro Ramírez",    Estado="Activo"   },
            new Acudiente { Id=5,  Nombres="Gloria",  Apellidos="Torres",   Direccion="Carrera 20 #3-15", Telefono="3125555555", NombreEstudiante="Laura Torres",     Estado="Activo"   },
            new Acudiente { Id=6,  Nombres="Alfredo", Apellidos="Herrera",  Direccion="Calle 67 #11-22",  Telefono="3176666666", NombreEstudiante="Carlos Herrera",   Estado="Activo"   },
            new Acudiente { Id=7,  Nombres="Beatriz", Apellidos="Vargas",   Direccion="Av. 30 #18-44",    Telefono="3187777777", NombreEstudiante="Sofía Vargas",     Estado="Inactivo" },
            new Acudiente { Id=8,  Nombres="Rodrigo", Apellidos="Castro",   Direccion="Calle 12 #7-33",   Telefono="3218888888", NombreEstudiante="Diego Castro",     Estado="Activo"   },
            new Acudiente { Id=9,  Nombres="Carmen",  Apellidos="Morales",  Direccion="Carrera 5 #25-60", Telefono="3109999999", NombreEstudiante="Valentina Morales",Estado="Activo"   },
            new Acudiente { Id=10, Nombres="Jaime",   Apellidos="Jiménez",  Direccion="Av. 68 #14-28",    Telefono="3200000001", NombreEstudiante="Andrés Jiménez",   Estado="Activo"   },
        };

        public static List<Usuarios> Usuarios() => new()
        {
            new Usuarios { Id=1, Nombres="Carlos",   Apellidos="Martínez", Correo="c.martinez@educlick.co", Rol="Rector",     Estado="Activo",    FechaRegistro=new DateTime(2024,1,15) },
            new Usuarios { Id=2, Nombres="Jorge",    Apellidos="García",   Correo="j.garcia@educlick.co",   Rol="Docente",    Estado="Activo",    FechaRegistro=new DateTime(2024,1,20) },
            new Usuarios { Id=3, Nombres="Patricia", Apellidos="López",    Correo="p.lopez@educlick.co",    Rol="Docente",    Estado="Activo",    FechaRegistro=new DateTime(2024,2,1)  },
            new Usuarios { Id=4, Nombres="Andrea",   Apellidos="Suárez",   Correo="a.suarez@educlick.co",   Rol="Secretaria", Estado="Activo",    FechaRegistro=new DateTime(2024,2,10) },
            new Usuarios { Id=5, Nombres="Miguel",   Apellidos="Peña",     Correo="m.pena@educlick.co",     Rol="Docente",    Estado="Pendiente", FechaRegistro=new DateTime(2024,5,20) },
            new Usuarios { Id=6, Nombres="Luisa",    Apellidos="Ramos",    Correo="l.ramos@educlick.co",    Rol="Docente",    Estado="Pendiente", FechaRegistro=new DateTime(2024,5,22) },
            new Usuarios { Id=7, Nombres="Fernando", Apellidos="Cruz",     Correo="f.cruz@educlick.co",     Rol="Secretaria", Estado="Pendiente", FechaRegistro=new DateTime(2024,5,25) },
            new Usuarios { Id=8, Nombres="Teresa",   Apellidos="Molina",   Correo="t.molina@educlick.co",   Rol="Docente",    Estado="Bloqueado", FechaRegistro=new DateTime(2024,3,5)  },
        };
    }
}