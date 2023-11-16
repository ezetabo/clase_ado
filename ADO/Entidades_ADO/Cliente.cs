using System.Text;

namespace Entidades_ADO
{
    public class Cliente
    {
        private string dni;
        private string nombre;
        private string apellido;
        private string telefono;

        public Cliente()
        {

        }

        public Cliente(string dni, string nombre, string apellido, string telefono)
        {
            this.dni = dni;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.telefono = telefono;
        }

        public string Dni { get => dni; set => dni = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Telefono { get => telefono; set => telefono = value; }

       
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{"Dni",-8}{":",2}{this.dni}");
            sb.AppendLine($"{"Nombre",-8}{":",2}{this.nombre}");
            sb.AppendLine($"{"Apellido",-8}{":",2}{this.apellido}");
            sb.AppendLine($"{"Telefono",-8}{":",2}{telefono}");
            return sb.ToString();
        }
    }
}