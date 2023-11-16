using Entidades_ADO;
using System;

namespace UI_User_ADO
{
    public class Program
    {
        static void Main(string[] args)
        {
            Cliente miCliente = new Cliente ("25123123","Jose","Gonzalez","6456456");

        
            if ( Cliente_Ado.Guardar(miCliente))
            {
                Console.WriteLine("exito al guardar");
            }
            else
            {
                Console.WriteLine("ocurrio un error al guardar");
            }

        }
    }
}