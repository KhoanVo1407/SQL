﻿using DTO;
using System;
using System.Data;

namespace DAO
{
    public class ProductDAO
    {
        private static ProductDAO instance;

        public static ProductDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new ProductDAO();
                return ProductDAO.instance;
            }
        }

        private ProductDAO() { }

        public DataTable GetAllProduct()
        {
            string query = "USP_GetAllProduct";
            try
            {
                return DataProvider.Instance.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetListProductByCategory(string category)
        {
            string query = "USP_GetListProductByCategory @Category";
            try
            {
                return DataProvider.Instance.ExecuteQuery(query, new object[] { category });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SearchProductByName(string name)
        {
            string query = string.Format("USP_SearchProductByName @Name");
            try
            {
                return DataProvider.Instance.ExecuteQuery(query, new object[] { name });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool InsertProduct(Product newProduct)
        {
            string query = string.Format("USP_InsertProduct @Name , @Price, @Discount, @Category , @Quantity, @Size, @Image");
            int result;
            try
            {
                result = DataProvider.Instance.ExecuteNonQuery(query,
                    new object[]
                    {
                        newProduct.Name,
                        newProduct.Price,
                        newProduct.Discount,
                        newProduct.Category,
                        newProduct.Quantity,
                        newProduct.Size,
                        newProduct.Image,
                    }
                );
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result > 0;
        }

        public bool UpdateProduct(Product product)
        {
            string query = string.Format("USP_UpdateFood @Id , @Name , @Price, @Discount, @Category , @Quantity, @Size, @Image");
            int result;
            try
            {
                result = DataProvider.Instance.ExecuteNonQuery(query,
                    new object[] { 
                        product.Id, 
                        product.Name,
                        product.Price,
                        product.Discount,
                        product.Category, 
                        product.Quantity,
                        product.Size,
                        product.Image
                    }
                );
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result > 0;
        }

        public bool DeleteProduct(int Id)
        {
            int result;
            try
            {
                result = DataProvider.Instance.ExecuteNonQuery("USP_DeleteProduct @Id", new object[] { Id });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result > 0;
        }
    }
}