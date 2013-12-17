using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Data.SqlClient;
public class ClConn
{
    //Khai bao cac doi tuong truy cap CSDL
    SqlConnection sqlConn;
    SqlCommand sqlCmd;

    SqlDataAdapter sqlAdap;
    //Ham xay dung  
    public ClConn()
    {
        //sqlConn = new SqlConnection("Data Source=hoang-pc;Initial Catalog=QuanLyThuVien;Integrated Security=True");
        sqlConn = new SqlConnection("Data Source=KIEUDIEM;Initial Catalog=QuanLyThuVien;Integrated Security=True");
        //Khoi tao doi tuong SqlCommand
        sqlCmd = new SqlCommand();
    }
    //Phuong thuc them gia tri cung ten tham so vao cho doi tuong SqlCommand
    public void AddParameter(string namePara, object value)
    {
        sqlCmd.Parameters.AddWithValue(namePara, value);
    }

    //Phuong thuc rut trich du lieu: Query
    //Tra ve doi tuong DataTable luu tru tap cac mau tin
    //truy van duoc
    public DataTable ExecuteQuery(string strSQL)
    {
        //Khai bao doi tuong luu tru tap mau tin
        DataTable objTable = new DataTable();
        try
        {
            //Mo ket noi
            if (sqlConn.State != ConnectionState.Open)
                sqlConn.Open();
            //Khoi tao doi tuong SqolDataAdapter
            sqlAdap = new SqlDataAdapter(strSQL, sqlConn);
            //sqlAdap.SelectCommand = New SqlCommand()
            //Thuc thi: Goi phuong thuc Fill
            sqlAdap.Fill(objTable);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        sqlCmd.Parameters.Clear();
        sqlCmd.Dispose();
        return objTable;
    }
    public Boolean runSQLReturnValuseSo(string strSQL, out Decimal kq)
    {
        kq = 0; 
        try
        {
            if (sqlConn.State != ConnectionState.Open) sqlConn.Open();
            sqlCmd.Connection = sqlConn;
            sqlCmd.CommandText = strSQL;
            sqlCmd.CommandType = CommandType.Text;
            kq = Convert.ToDecimal(sqlCmd.ExecuteScalar());  
        }
        catch (Exception ex) { throw new Exception(ex.Message); }
        sqlCmd.Parameters.Clear();
        sqlCmd.Dispose();
        return (kq > 0);
    }
    //Phuong thuc cap nhat du lieu
    //Tra ve: True - neu thanh cong; False - neu khong thanh ocng
    public bool ExecuteUpdate(string strSQL, bool isStore)
    {
        //Khai bao mot bien luu tru so dong cap nhat thanh cong
        int rows = 0;
        try
        {
            //Mo ket noi
            if (sqlConn.State != ConnectionState.Open)
                sqlConn.Open();
            //Thiet lap mot so thuoc tinh
            sqlCmd.Connection = sqlConn;
            sqlCmd.CommandText = strSQL;
            if (isStore)
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
            }
            else
            {
                sqlCmd.CommandType = CommandType.Text;
            }
            //Thuc thi
            rows = sqlCmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        sqlCmd.Parameters.Clear();
        sqlCmd.Dispose();
        return (rows > 0);
    }

}