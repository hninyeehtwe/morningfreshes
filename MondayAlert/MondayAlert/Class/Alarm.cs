using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MondayAlert.Views.ViewModel;
using System.Data.SqlClient;
using System.Data;

namespace MondayAlert.Class
{
    public class Alarm
    {
        public SupriseQuestion GetSupriseQuestion()
        {

            try
            {
                DBConnect db = new DBConnect();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GET_RandomSupriseQuestion";

                DataTable tbl = db.GetData(cmd);
                SupriseQuestion sq = new SupriseQuestion();
                if (tbl.Rows.Count>0) {
                    sq.SupriseID = Convert.ToInt32(tbl.Rows[0]["SurpriseID"].ToString());
                    sq.Question = tbl.Rows[0]["SurpriseQuestion"].ToString();
                    sq.OptionA = tbl.Rows[0]["OptionA"].ToString();
                    sq.OptionB=tbl.Rows[0]["OptionB"].ToString();
                    sq.OptionC = tbl.Rows[0]["OptionC"].ToString();
                    sq.Answer = tbl.Rows[0]["Answer"].ToString();
                    sq.Image = tbl.Rows[0]["Image"].ToString();

                    return sq;
                }
                return null;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable GetGiftCouponByPriority()
        {
            try
            {
                DBConnect db = new DBConnect();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GET_GiftCouponByPriority";
                DataTable tbl = db.GetData(cmd);

                return tbl;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int MyAlarmsOnHit(DateTime alarmDate, int minutes, int resultStatus, int surpriseID, int couponID, int userID)
        {
            try
            {
                DBConnect db = new DBConnect();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CREATE_MyAlarmsOnHit";
                cmd.Parameters.AddWithValue("@alarmDate", alarmDate);
                cmd.Parameters.AddWithValue("@minutes", minutes);
                cmd.Parameters.AddWithValue("@resultStatus", resultStatus);
                cmd.Parameters.AddWithValue("@supriseID", surpriseID);
                cmd.Parameters.AddWithValue("@couponID", couponID);
                cmd.Parameters.AddWithValue("@userID", userID);

                DataTable tbl = db.GetData(cmd);

                return Convert.ToInt16(tbl.Rows[0][0].ToString());
            }
            catch (Exception ex)
            {
                return 0;
                throw;
            }
        }
    }
}