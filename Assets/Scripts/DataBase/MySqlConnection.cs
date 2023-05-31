using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using MySql.Data.MySqlClient;
using System.Net;

public class DB_Control : MonoBehaviour
{
    public static MySqlConnection SqlConn;

    static string ipAddress = "127.0.0.1";
    static string db_id = "root";
    static string db_pw = "1234";
    static string db_name = "DB";

    string strConn = string.Format("server ={0};uid={1};pwd={2};database={3};charset=utf8;", ipAddress, db_id, db_pw, db_name);

    private void Awake()
    {
        try
        {
            SqlConn = new MySqlConnection(strConn);
        }
        catch (System.Exception e)
        {
            Debug.Log(e.ToString());
        }


    }
    private void Start()
    {
        string query = "select * from TB_TABLE";
        DataSet ds = OnSelectRequest(query, "TB_TABLE");

        Debug.Log(ds.GetXml());
    }
    
    //데이터 삽입,업데이트 쿼리시 사용 함수
    public static bool OnLnsertOrUpdateRequest(string str_query)
    {
        try
        {
            MySqlCommand sqlCommand = new MySqlCommand();
            sqlCommand.Connection = SqlConn;
            sqlCommand.CommandText = str_query;

            SqlConn.Open();

            sqlCommand.ExecuteNonQuery();
            SqlConn.Close();

            return true;
        }
        catch (System.Exception e)
        {
            Debug.Log(e.ToString());
            return false;
        }
    }

    //select 조회 쿼리시 사용
    //2번째 파라미터 table_name 은 Dataset 이름을 정의하기 위함
    public static DataSet OnSelectRequest(string p_query,string table_name)
    {
        try
        {
            SqlConn.Open();     //DB 연결

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = SqlConn;
            cmd.CommandText = p_query;

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sd.Fill(ds, table_name);

            SqlConn.Close();    //DB 연결 해제

            return ds;
        }
        catch (System.Exception e)
        {
            Debug.Log(e.ToString());
            return null;
        }
    }

    private void OnApplicationQuit()
    {
        SqlConn.Close();
    }
};
