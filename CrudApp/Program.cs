using System.Data.SqlClient;
// See https://aka.ms/new-console-template for more information
string connectionString = @"Data Source=LAPTOP-ENJ0A7G1;Initial Catalog=CoDb;Integrated Security=True";
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
                string insertQuery = "INSERT INTO DETAILS(user_Name, user_Age) VALUES('" + userName + "'," + userAge + ")";
                SqlCommand insertCommand = new SqlCommand(insertQuery, sqlConnection);
                insertCommand.ExecuteNonQuery();
                Console.WriteLine("Data is successfully inserted into table !!");
                break;

            case 2:
                //RETRIEVE operation
                string displayQuery = "SELECT * FROM Details";
                SqlCommand displayCommand = new SqlCommand(displayQuery, sqlConnection);
                SqlDataReader dataReader = displayCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    Console.WriteLine("Id: " + dataReader.GetValue(0).ToString());
                    Console.WriteLine("Name: " + dataReader.GetValue(1).ToString());
                    Console.WriteLine("Age: " + dataReader.GetValue(2).ToString());
                }
                dataReader.Close();
                break;

            case 3:
                //UPDATE operation
                int u_id;
                int u_age;
                Console.WriteLine("Enter the user id that you would like to update:");
                u_id = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the age of the user to update");
                u_age = int.Parse(Console.ReadLine());
                string updateQuery = "UPDATE Details SET user_age = " + u_age + "WHERE user_id = " + u_id + "";
                SqlCommand updateCommand = new SqlCommand(updateQuery, sqlConnection);
                updateCommand.ExecuteNonQuery();
                Console.WriteLine("Data updated successfully !");
                break;

            case 4:
                //DELETE operation
                Console.WriteLine("Enter the id of the record to be deleted !");
                int d_id = int.Parse(Console.ReadLine());
                string deleteQuery = "DELETE FROM DETAILS WHERE user_id = " + d_id;
                SqlCommand deleteCommand = new SqlCommand(deleteQuery, sqlConnection);
                deleteCommand.ExecuteNonQuery();
                Console.WriteLine("Deletion successful !");
                break;

            default:
                Console.WriteLine("Invalid input");
                break;

        }
        Console.WriteLine("Do you want to continue ?");
        answer = Console.ReadLine();

    } while (answer != "No");

}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

finally
{
    sqlConnection.Close();
}