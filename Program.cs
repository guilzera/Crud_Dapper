using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

class Program
{
    private const string CONNECTION_STRING = @"Server=localhost,1433;Database=Blog;User Id=sa;Password=@Teste123@;TrustServerCertificate=True";

    static void Main(string[] args)
    {
        // ReadUsers();
        // ReadUser();
        // CreateUser();
        // UpdateUser();
        // DeleteUser();
    }

    public static void ReadUsers()
    {
        using(var connection = new SqlConnection(CONNECTION_STRING))
        {
            var users = connection.GetAll<User>();

            foreach(var user in users)
                Console.WriteLine(user.Name);
        }
    }

    public static void ReadUser()
    {
        using(var connection = new SqlConnection(CONNECTION_STRING))
        {
            var user = connection.Get<User>(1);

            Console.WriteLine(user.Name);
        }
    }

    public static void CreateUser()
    {
        var user = new User()
        {
            Bio = "Equipe balta.io",
            Email = "hello@balta.io",
            Image = "https://...",
            Name = "Equipe balta.io",
            PasswordHash = "HASH",
            Slug = "Equipe-balta"
        };

        using(var connection = new SqlConnection(CONNECTION_STRING))
        {
            connection.Insert<User>(user);
            Console.WriteLine("Cadastro realizado com sucesso!");
        }
    }

    public static void UpdateUser()
    {
        var user = new User()
        {
            Id = 2,
            Bio = "Equipe | balta.io",
            Email = "hello@balta.io",
            Image = "https://...",
            Name = "Equipe de suporte balta.io",
            PasswordHash = "HASH",
            Slug = "Equipe-balta"
        };

        using(var connection = new SqlConnection(CONNECTION_STRING))
        {
            connection.Update<User>(user);
            Console.WriteLine("Atualização realizada com sucesso!");
        }
    }

    public static void DeleteUser()
    {
        using(var connection = new SqlConnection(CONNECTION_STRING))
        {
            var user = connection.Get<User>(2);
            connection.Delete<User>(user);
            Console.WriteLine("Exclusão realizada com sucesso!");
        }
    }
}
