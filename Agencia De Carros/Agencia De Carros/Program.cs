using System;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
namespace AgenciaCarrosConsola
{
    class Program
    {
        // Cadena de conexión
        static string connectionString = "Server=DESKTOP-ECO5SNR\\SQLEXPRESS;Database=AgenciaCarros;Trusted_Connection=True;TrustServerCertificate=True;";

        static void Main(string[] args)
        {
            int opcion;
            do
            {
                Console.WriteLine("=== Menú Principal ===");
                Console.WriteLine("1. CRUD Agencias");
                Console.WriteLine("2. CRUD Carros");
                Console.WriteLine("0. Salir");
                Console.Write("Selecciona una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        MenuAgencias();
                        break;
                    case 2:
                        MenuCarros();
                        break;
                    case 0:
                        Console.WriteLine("Saliendo...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            } while (opcion != 0);
        }

        // Menú para Agencias
        static void MenuAgencias()
        {
            int opcion;
            do
            {
                Console.WriteLine("\n=== CRUD Agencias ===");
                Console.WriteLine("1. Crear Agencia");
                Console.WriteLine("2. Leer Agencias");
                Console.WriteLine("3. Actualizar Agencia");
                Console.WriteLine("4. Eliminar Agencia");
                Console.WriteLine("0. Volver al Menú Principal");
                Console.Write("Selecciona una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        CrearAgencia();
                        break;
                    case 2:
                        LeerAgencias();
                        break;
                    case 3:
                        ActualizarAgencia();
                        break;
                    case 4:
                        EliminarAgencia();
                        break;
                    case 0:
                        Console.WriteLine("Volviendo...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            } while (opcion != 0);
        }

        // Menú para Carros
        static void MenuCarros()
        {
            int opcion;
            do
            {
                Console.WriteLine("\n=== CRUD Carros ===");
                Console.WriteLine("1. Crear Carro");
                Console.WriteLine("2. Leer Carros");
                Console.WriteLine("3. Actualizar Carro");
                Console.WriteLine("4. Eliminar Carro");
                Console.WriteLine("0. Volver al Menú Principal");
                Console.Write("Selecciona una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        CrearCarro();
                        break;
                    case 2:
                        LeerCarros();
                        break;
                    case 3:
                        ActualizarCarro();
                        break;
                    case 4:
                        EliminarCarro();
                        break;
                    case 0:
                        Console.WriteLine("Volviendo...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            } while (opcion != 0);
        }

        // CRUD para Agencias
        static void CrearAgencia()
        {
            Console.Write("Nombre de la Agencia: ");
            string nombre = Console.ReadLine();
            Console.Write("Dirección: ");
            string direccion = Console.ReadLine();
            Console.Write("Teléfono: ");
            string telefono = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO agencias (nombre, direccion, telefono, email) VALUES (@nombre, @direccion, @telefono, @email)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@direccion", direccion);
                cmd.Parameters.AddWithValue("@telefono", telefono);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Agencia creada exitosamente.");
            }
        }

        static void LeerAgencias()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM agencias";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                Console.WriteLine("\n=== Lista de Agencias ===");
                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["id_agencia"]}, Nombre: {reader["nombre"]}, Dirección: {reader["direccion"]}, Teléfono: {reader["telefono"]}, Email: {reader["email"]}");
                }
            }
        }

        static void ActualizarAgencia()
        {
            Console.Write("ID de la Agencia a actualizar: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Nuevo Nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Nueva Dirección: ");
            string direccion = Console.ReadLine();
            Console.Write("Nuevo Teléfono: ");
            string telefono = Console.ReadLine();
            Console.Write("Nuevo Email: ");
            string email = Console.ReadLine();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE agencias SET nombre = @nombre, direccion = @direccion, telefono = @telefono, email = @email WHERE id_agencia = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@direccion", direccion);
                cmd.Parameters.AddWithValue("@telefono", telefono);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Agencia actualizada exitosamente.");
            }
        }

        static void EliminarAgencia()
        {
            Console.Write("ID de la Agencia a eliminar: ");
            int id = int.Parse(Console.ReadLine());

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM agencias WHERE id_agencia = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Agencia eliminada exitosamente.");
            }
        }

        // CRUD para Carros
        static void CrearCarro()
        {
            Console.Write("Modelo: ");
            string modelo = Console.ReadLine();
            Console.Write("Marca: ");
            string marca = Console.ReadLine();
            Console.Write("Año: ");
            int anio = int.Parse(Console.ReadLine());
            Console.Write("Precio: ");
            decimal precio = decimal.Parse(Console.ReadLine());
            Console.Write("ID de la Agencia: ");
            int idAgencia = int.Parse(Console.ReadLine());

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO carros (modelo, marca, anio, precio, id_agencia) VALUES (@modelo, @marca, @anio, @precio, @id_agencia)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@modelo", modelo);
                cmd.Parameters.AddWithValue("@marca", marca);
                cmd.Parameters.AddWithValue("@anio", anio);
                cmd.Parameters.AddWithValue("@precio", precio);
                cmd.Parameters.AddWithValue("@id_agencia", idAgencia);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Carro creado exitosamente.");
            }
        }

        static void LeerCarros()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM carros";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                Console.WriteLine("\n=== Lista de Carros ===");
                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["id_carro"]}, Modelo: {reader["modelo"]}, Marca: {reader["marca"]}, Año: {reader["anio"]}, Precio: {reader["precio"]}, ID Agencia: {reader["id_agencia"]}");
                }
            }
        }

        static void ActualizarCarro()
        {
            Console.Write("ID del Carro a actualizar: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Nuevo Modelo: ");
            string modelo = Console.ReadLine();
            Console.Write("Nueva Marca: ");
            string marca = Console.ReadLine();
            Console.Write("Nuevo Año: ");
            int anio = int.Parse(Console.ReadLine());
            Console.Write("Nuevo Precio: ");
            decimal precio = decimal.Parse(Console.ReadLine());
            Console.Write("Nuevo ID de la Agencia: ");
            int idAgencia = int.Parse(Console.ReadLine());

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE carros SET modelo = @modelo, marca = @marca, anio = @anio, precio = @precio, id_agencia = @id_agencia WHERE id_carro = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@modelo", modelo);
                cmd.Parameters.AddWithValue("@marca", marca);
                cmd.Parameters.AddWithValue("@anio", anio);
                cmd.Parameters.AddWithValue("@precio", precio);
                cmd.Parameters.AddWithValue("@id_agencia", idAgencia);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Carro actualizado exitosamente.");
            }
        }

        static void EliminarCarro()
        {
            Console.Write("ID del Carro a eliminar: ");
            int id = int.Parse(Console.ReadLine());

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM carros WHERE id_carro = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Carro eliminado exitosamente.");
            }
        }
    }
}

