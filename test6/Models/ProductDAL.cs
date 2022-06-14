using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace test6.Models
{
    public class ProductDAL
    {
        string connectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=PRODUCTDB;Data Source=QUANG\\SQLEXPRESS";
        public IEnumerable<ProductInfo> GetAllProduct()
        {
            List<ProductInfo> emplist = new List<ProductInfo>();
            using (SqlConnection con= new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetAllProduct", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ProductInfo pro= new ProductInfo();
                    pro.ID = Convert.ToInt32(dr["ID"].ToString());
                    pro.Name = dr["Name"].ToString();
                    pro.Type = dr["Type"].ToString();
                    pro.origin = dr["origin"].ToString();
                    pro.Describe = dr["Describe"].ToString();
                    emplist.Add(pro);

                }
                con.Close();
            }
            return emplist;
        }
        public void AddProduct(ProductInfo pro )
        {
            using (SqlConnection con= new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_InsertProduct",con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", pro.Name);
                cmd.Parameters.AddWithValue("@Type", pro.Type);
                cmd.Parameters.AddWithValue("@Origin", pro.origin);
                cmd.Parameters.AddWithValue("@Describe", pro.Describe);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close(); 
            }
        }
        public void updateproduct (ProductInfo pro)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_UpdateProduct", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", pro.ID);
                cmd.Parameters.AddWithValue("@Name", pro.Name);
                cmd.Parameters.AddWithValue("@Type", pro.Type);
                cmd.Parameters.AddWithValue("@Origin", pro.origin);
                cmd.Parameters.AddWithValue("@Describe", pro.Describe);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void deleteproduct (int? proID)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_DeleteProduct", con);
                cmd.CommandType= CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProId",proID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public ProductInfo GetproductbyID(int? proID)
        {
            ProductInfo pro = new ProductInfo();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetProductById", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProID", proID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    
                    pro.ID = Convert.ToInt32(dr["ID"].ToString());
                    pro.Name = dr["Name"].ToString();
                    pro.Type = dr["Type"].ToString();
                    pro.origin = dr["origin"].ToString();
                    pro.Describe = dr["Describe"].ToString();
                   

                }
                con.Close();
            }
            return pro;
        }
    }
}
