using MySql.Data.MySqlClient;

namespace Entidades_ADO
{
    public static class Cliente_Ado
    {
        private static string connectionString;
        private static MySqlConnection connection;
        private static MySqlCommand command;

        static Cliente_Ado()
        {
            Cliente_Ado.connectionString = "Server=localhost;Database=clase_ado;User ID=root;Password=;SslMode=none;";
            connection = new MySqlConnection(Cliente_Ado.connectionString);
            command = new MySqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = connection;
        }


        public static bool Guardar(Cliente cliente)
        {
            bool ok = true;
            try
            {
                string query = "INSERT INTO clientes (dni, nombre, apellido, telefono) VALUES (@dni, @nombre, @apellido, @telefono)";
                connection.Open();
                command.CommandText = query;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@dni", cliente.Dni);
                command.Parameters.AddWithValue("@nombre", cliente.Nombre);
                command.Parameters.AddWithValue("@apellido", cliente.Apellido);
                command.Parameters.AddWithValue("@telefono", cliente.Telefono);
                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar datos: " + ex.Message);
                ok = false;
            }
            finally
            {
                if (connection is not null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return ok;
        }

        public static List<Cliente> Leer()
        {
            List<Cliente> clientes = new List<Cliente>();
            try
            {
                string query = "SELECT * FROM clientes"; 

                connection.Open();
                command.CommandText = query;

                using (MySqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        string dni = dataReader.GetString(0);
                        string nombre = dataReader.GetString(1);
                        string apellido = dataReader.GetString(2);
                        string telefono = dataReader.GetString(3);

                        clientes.Add(new Cliente(dni, nombre, apellido, telefono));
                    }
                }

                return clientes;
            }
            catch (Exception ex)
            {
                
                Console.WriteLine("Error al leer datos: " + ex.Message);
                throw;
            }
            finally
            {
                if (connection is not null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }


        public static bool Modificar(Cliente cliente)
        {
            bool ok = true;
            try
            {
                string query = "UPDATE clientes SET nombre = @nombre, apellido = @apellido, telefono = @telefono WHERE dni = @dni";
                connection.Open();
                command.CommandText = query;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@dni", cliente.Dni);
                command.Parameters.AddWithValue("@nombre", cliente.Nombre);
                command.Parameters.AddWithValue("@apellido", cliente.Apellido);
                command.Parameters.AddWithValue("@telefono", cliente.Telefono);
                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al modificar datos: " + ex.Message);

                ok = false;
            }
            finally
            {
                if (connection is not null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return ok;
        }

        public static bool Eliminar(string dni)
        {
            bool ok = true;
            try
            {
                string query = "DELETE FROM clientes WHERE dni = @dniBuscado";
                connection.Open();
                command.CommandText = query;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@dniBuscado", dni);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
               
                Console.WriteLine("Error al eliminar datos: " + ex.Message);
                ok = false;
            }
            finally
            {
                if (connection is not null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return ok;
        }

    }
}
