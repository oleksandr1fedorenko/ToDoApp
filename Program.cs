namespace Test1;
using System.Data.SqlClient;

public class Program
{

    public static void Main(string[] args)
    {

        Console.WriteLine("Hello, World!");

        Database();

    }




    private static void Database()
    {
        
         var conn = new SqlConnection();
        conn.ConnectionString =
        "Data Source=0.0.0.0;" +
        "User Instance=true;" +
        "User Id=root;" +
        "Password=root;"; // +
        //"AttachDbFilename=|DataDirectory|DataBaseName.mdf;";

        try
        {
            conn.Open();
        } catch (Exception e)
        {
            Console.WriteLine("error");
        }
        


        // string connetionString = null;
        // SqlConnection connection  ;
        // SqlCommand command ;
        // string sql = null;
        // SqlDataReader dataReader ;
        // connetionString = "Data Source=127.0.0.1;Initial Catalog=Test;User ID=root;Password=root";
        // sql = "Your SQL Statement Here , like Select * from product";
        // connection = new SqlConnection(connetionString);
        // try
        // {
        //     connection.Open();
        //     command = new SqlCommand(sql, connection);
        //     dataReader = command.ExecuteReader();
        //     while (dataReader.Read())
        //     {
        //         Console.WriteLine(dataReader.GetValue(0) + " - " + dataReader.GetValue(1) + " - " + dataReader.GetValue(2));
        //     }
        //     dataReader.Close();
        //     command.Dispose();
        //     connection.Close();
        // }
        // catch (Exception ex)
        // {
        //     Console.WriteLine("Can not open connection !");
        // }   




    }
    

    


}
