using MySql.Data.MySqlClient;
using System;

namespace MysqlApp
{
    class Mysql_ReadDB
    {
        static void Main(string[] args)
        {
            // 接続文字列
            var connectionString =
               "Server=localhost;Port=3306;Uid=root;Pwd=standapp;Database=standapp";

            // 実行するSQL
            var sql = "SELECT * FROM user";

            // 接続・SQL実行に必要なインスタンスを生成
            using (var connection = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand(sql, connection))
            {
                // 接続開始
                connection.Open();

                // SELECT文の実行
                using (var reader = command.ExecuteReader())
                {
                    // 1行ずつ読み取ってコンソールに表示
                    while (reader.Read())
                    {
                        Console.WriteLine($"ID:{reader["user_id"]} NAME:{reader["user_name"]}　AC:{reader["account_type"]}");
                    }
                }
            }
        }
    }
}