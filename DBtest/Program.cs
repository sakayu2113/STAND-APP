using (MySqlConnection conn = new MySqlConnection(connectionString))
{
    conn.Open();

    // SQL発行
    MySqlCommand selectCommand = new MySqlCommand("SELECT * FROM MyTable", conn);
    MySqlDataReader results = selectCommand.ExecuteReader();

    // 行ごとにループ
    while (results.Read())
    {
        Console.WriteLine("Column 0: {0} Column 1: {1}", results[0], results[1]);
    }
}