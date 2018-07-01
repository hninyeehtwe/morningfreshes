using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public class DBConnect
{
    SqlConnection cn;
    SqlCommand cmd;


    public DBConnect()
    {
        cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MAlert_ConnString"].ConnectionString);
    }

    public int SetData(SqlCommand cmd)
    {
        if (cn.State == ConnectionState.Closed) cn.Open();
        cmd.Connection = cn;
        int rowsAffected = cmd.ExecuteNonQuery();
        if (cn.State == ConnectionState.Open) cn.Close();
        return rowsAffected;
    }

    public DataTable GetData(SqlCommand cmd)
    {
        DataTable t1 = new DataTable();
        cmd.Connection = cn;
        if (cn.State == ConnectionState.Closed) cn.Open();
        t1.Load(cmd.ExecuteReader());
        if (cn.State == ConnectionState.Open) cn.Close();
        return t1;
    }
}
