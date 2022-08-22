using CrudApp;
using System.Data.SqlClient;
using System.Xml.Serialization;


public class Program
{


    public static void Main(string[] args)
    {
        string connectionString = @"Data Source=TL308\SQLEXPRESS;Initial Catalog=CoDb;Integrated Security=True";
        SqlConnection sqlConnection = new SqlConnection(connectionString);
        sqlConnection.Open();

        try
        {
            Console.WriteLine("Connection established successfully!");
            string answer;
            do
            {
                Console.WriteLine("Select the operation to perform: \n1. Creation\n2. Retrieve\n3. Updation\n4. Deletion ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        //CREATE operation
                        Console.WriteLine("Enter your name:");
                        string userName = Console.ReadLine();
                        Console.WriteLine("Enter your age:");
                        int userAge = int.Parse(Console.ReadLine());
                        int new_id = Data.CreateUser(userName, userAge, sqlConnection);
                        Console.WriteLine("Data inserted successfully. ID of inserted record: " + new_id);
                        break;

                    case 2:
                        //RETRIEVE operation
                        List<User> users = Data.RetrieveUser(sqlConnection);
                        for(int i = 0; i < users.Count; i++)
                        {
                            Console.WriteLine("ID: "+users[i].UserId);
                            Console.WriteLine("Name: " + users[i].UserName);
                            Console.WriteLine("Age: " + users[i].UserAge);
                        }
                        break;

                    case 3:
                        //UPDATE operation
                        Console.WriteLine("Enter the user id that you would like to update:");
                        int u_id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the age of the user to update");
                        int u_age = int.Parse(Console.ReadLine());
                        Data.UpdateUser(u_age, u_id, sqlConnection);

                        break;

                    case 4:
                        //DELETE operation
                        Console.WriteLine("Enter the id of the record to be deleted !");
                        int d_id = int.Parse(Console.ReadLine());
                        Console.WriteLine(Data.DeleteUser(d_id, sqlConnection));
                        break;

                    default:
                        Console.WriteLine("Invalid input");
                        break;

                }
                Console.WriteLine("Do you want to continue ?");
                answer = Console.ReadLine();

            } while (answer == "y" || answer == "Y"|| answer == "yes" || answer == "Yes");

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        finally
        {
            sqlConnection.Close();
        }
    }
    // See https://aka.ms/new-console-template for more info
}
