using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace sansyou1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            userControl11.Visible = true;
            userControl11.Dock = DockStyle.Fill;

            userControl21.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // userテーブルの情報を取得
        private void button1_Click(object sender, EventArgs e) 
        {
            // db情報
            var server = "localhost";  // Hosename
            var port = 3306;              // Port
            var user = "root";         // Username
            var pass = "standapp";        // Password
            var databasename = "standapp";// DatabaseName
            var charset = "utf8";      // Encode
            var connectionString = $"Server={server};Port={port};Username={user};Password={pass};Database={databasename};Charset={charset};";
            try
            {
                //string connStr = "server=localhost;port=3306;userid=root;password=1215;database=test_database2";
                //MySqlConnection conn = new MySqlConnection(connStr);
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {

                    conn.Open(); // 接続開始

                    DataTable tbl = new DataTable(); // インスタンスの生成

                    MySqlDataAdapter DataAdp = new MySqlDataAdapter("SELECT * FROM user;", conn); // 実行するsql文を定義

                    int rec = DataAdp.Fill(tbl);
                    dataGridView1.DataSource = tbl; // データベースの中身を表示
                    conn.Close(); // 接続終了 
                }

            }
            catch (MySqlException mes)
            {
                // 例外処理
                MessageBox.Show("例外発生:" + mes.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            int user_id = 2;
            int sche_id = 2;
            int date = 0;
            string sche_start = "0:00";
            string sche_fin = "2:00";
            string sche_name = "会議";
            string memo = "場所は会議室";
            int importance = 0;
            int remainder = 1;

            //db情報
            var server = "localhost";  // Hosename
            var port = 3306;              // Port
            var user = "root";         // Username
            var pass = "standapp";        // Password
            var databasename = "standapp";// DatabaseName
            var charset = "utf8";      // Encode
            var connectionString = $"Server={server};Port={port};Username={user};Password={pass};Database={databasename};Charset={charset};";
            try
            {
                //string connStr = "server=localhost;port=3306;userid=root;password=1215;database=test_database2";
                //MySqlConnection conn = new MySqlConnection(connStr);
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    //MySqlCommand cmd = new MySqlCommand("insert into calendar values(@uid,@sid,@date,@s_str,@s_fin,@s_name,@memo,@imp,@rem);", conn); // 実行するsql文を定義
                    MySqlCommand cmd = new MySqlCommand("update calendar set date = @date where sche_id = @sid;", conn); // 実行するsql文を定義
                    // パラメータ設定
                    cmd.Parameters.Add(new MySqlParameter("uid", user_id));
                    cmd.Parameters.Add(new MySqlParameter("sid", sche_id));
                    cmd.Parameters.Add(new MySqlParameter("date", date));
                    cmd.Parameters["@date"].Value = textBox1.Text;
                    cmd.Parameters.Add(new MySqlParameter("s_str", sche_start));
                    cmd.Parameters.Add(new MySqlParameter("s_fin", sche_fin));
                    cmd.Parameters.Add(new MySqlParameter("s_name", sche_name));
                    cmd.Parameters.Add(new MySqlParameter("memo", memo));
                    cmd.Parameters.Add(new MySqlParameter("imp", importance));
                    cmd.Parameters.Add(new MySqlParameter("rem", remainder));

                    // オープン
                    cmd.Connection.Open();
                    try
                    {
                    // 実行
                    cmd.ExecuteNonQuery();
                    }
                    catch(System.FormatException mes)
                    {
                        MessageBox.Show("例外発生:" + mes.Message);
                    }
                    
                    // クローズ
                    cmd.Connection.Close();
                }
            }
            catch (MySqlException mes)
            {
                // 例外処理
                MessageBox.Show("例外発生:" + mes.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var server = "localhost";  // Hosename
            var port = 3306;              // Port
            var user = "root";         // Username
            var pass = "standapp";        // Password
            var databasename = "standapp";// DatabaseName
            var charset = "utf8";      // Encode
            var connectionString = $"Server={server};Port={port};Username={user};Password={pass};Database={databasename};Charset={charset};";
            try
            {
                //string connStr = "server=localhost;port=3306;userid=root;password=1215;database=test_database2";
                //MySqlConnection conn = new MySqlConnection(connStr);
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {

                    conn.Open(); // 接続開始

                    DataTable tbl = new DataTable(); // インスタンスの生成

                    MySqlDataAdapter DataAdp = new MySqlDataAdapter("SELECT * FROM calendar;", conn); // 実行するsql文を定義

                    DataAdp.Fill(tbl);
                    dataGridView1.DataSource = tbl; // データベースの中身を表示
                    conn.Close(); // 接続終了 
                }
            }
            catch (MySqlException mes)
            {
                // 例外処理
                MessageBox.Show("例外発生:" + mes.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            userControl11.Visible = false;

            userControl21.Visible = true;
            userControl11.Dock = DockStyle.Fill;
        }

        private void userControl21_Load(object sender, EventArgs e)
        {
         
        }

        private void button5_Click(object sender, EventArgs e)
        {
            userControl21.Visible = false;

            userControl11.Visible = true;
            userControl11.Dock = DockStyle.Fill;
        }
    }
}
