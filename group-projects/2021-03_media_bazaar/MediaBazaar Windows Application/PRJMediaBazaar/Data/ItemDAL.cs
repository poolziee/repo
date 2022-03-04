using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using PRJMediaBazaar.Logic;

namespace PRJMediaBazaar.Data
{
    class ItemDAL : BaseDAL
    {
        public List<Item> SelectAllItems()
        {
            try
            {
                List<Item> items = new List<Item>();
                MySqlDataReader reader = executeReader("SELECT * FROM items;", null);
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader[0]);
                    String category = reader[1].ToString();
                    String subcategory = reader[2].ToString();
                    String brand = reader[3].ToString();
                    String model = reader[4].ToString();
                    String description = reader[5].ToString();
                    double stock_price = double.Parse(reader[6].ToString(), System.Globalization.CultureInfo.InvariantCulture);
                    double price = double.Parse(reader[7].ToString(), System.Globalization.CultureInfo.InvariantCulture);
                    String restock_state = reader[8].ToString();
                    int roomInShop = Convert.ToInt32(reader[9]);
                    int roomInStorage = Convert.ToInt32(reader[10]);
                    int minimumAmountInStock = Convert.ToInt32(reader[11]);
                    int inShopAmount = Convert.ToInt32(reader[12]);
                    int inStorageAmount = Convert.ToInt32(reader[13]);

                    Item item = new Item(id, category, subcategory, brand, model, description, stock_price, price, restock_state, roomInShop,
                                         roomInStorage, minimumAmountInStock, inShopAmount, inStorageAmount);
                    //  item.Image = GetItemImage(id);
                    items.Add(item);
                }
                CloseConnection();

                return items;
            }
            finally
            {
                CloseConnection();
            }
           
        } 
        public bool AddItem(String category,String subcategory ,String brand, String model, String description, String stock_price
                    , String price, String restock_state,int roomInShop, int roomInStorage,
                    int minimumAmountInStock)
        {
            try
            {
                String sql =
               "INSERT INTO items(category,subcategory,brand,model,description,stock_price,price,restock_state," +
                   "roomInShop,roomInStorage,minimumAmountInStock,inShopAmount,inStorageAmount) " +
               "VALUES(@category,@subcategory,@brand,@model,@description,@stock_price,@price,@restock_state," +
                   "@roomInShop,@roomInStorage,@minimumAmountInStock,@inShopAmount,@inStorageAmount);";

                String[] parameters = new String[] {
                category,
                subcategory,
                brand,
                model,
                description,
                stock_price.ToString(),
                price.ToString(),
                restock_state.ToString(),
                roomInShop.ToString(),
                roomInStorage.ToString(),
                minimumAmountInStock.ToString(),
                0.ToString(),
                0.ToString()};

                if (executeNonQuery(sql, parameters) != null)
                {
                    CloseConnection();

                    return true;
                }
                else
                {
                    CloseConnection();
                    return false;
                }
            }
            finally
            {
                CloseConnection();
            }
           
        }

      /*  private void AddItemImage(byte[] image)
        {
            int id = LastItemId();
            MySqlConnection conn = null;

            try
            {
                conn = new MySqlConnection(@"server=studmysql01.fhict.local;database=dbi460221;uid=dbi460221;password=lol;AllowUserVariables=true");
                //conn = new MySqlConnection("datasource = 127.0.0.1; port = 3306; username = root; password =; database = dbi460221;");
                String sql = "INSERT INTO items_images(item_id,image) " +
                        "VALUES(@id,@image);";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.Add("@image", MySqlDbType.Blob).Value = image;
                conn.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    conn.Close();
                }

            }
            catch (MySqlException ex)
            {
                conn.Close();
            }

            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

        } */
       /* public byte[] GetItemImage(int itemID)
        {
            String sql = "SELECT image FROM items_images WHERE item_id = @itemID;";
            String[] parameters = new String[] { itemID.ToString() };
            byte[] image = (byte[])executeScalar(sql, parameters);
            CloseConnection();
            return image;
        } */
        public int LastItemId()
        {
            string sql = "SELECT MAX(id) FROM items";
            int id =Convert.ToInt32(executeScalar(sql, null));
            CloseConnection();
            return id;
        }
        public bool DeleteItem(int id)
        {
            String sql = "DELETE FROM items WHERE id = @id;";
            String[] parameters = new String[] { id.ToString() };
            if (executeNonQuery(sql,parameters)!=null)
            {
                CloseConnection();
                return true;
            }
            else
            {
                CloseConnection();
                return false;
            }
        }
        public bool UpdateItem(String category,String subcategory ,String brand, String model, String description, String stock_price
                    , String price, String restock_state,int roomInShop, int roomInStorage,
                    int minimumAmountInStock, int id)
        {
            try
            {
                String sql = "UPDATE items SET category = @category,subcategory = @subcategory ,brand = @brand, model=@model, description = @description, stock_price=@stock_price , price = @price, restock_state=@restock_state , " +
                        "roomInShop = @roomInShop, roomInStorage = @roomInStorage, minimumAmountInStock = @minimumAmountInStock " +
                        "WHERE id = @id;";
                String[] parameters = new String[] { category, subcategory ,brand,model,description,stock_price,price.ToString(),restock_state,
                                                roomInShop.ToString(),roomInStorage.ToString(),
                                                minimumAmountInStock.ToString(), id.ToString() };
                if (executeNonQuery(sql, parameters) != null)
                {
                    CloseConnection();
                    return true;
                }
                else
                {
                    CloseConnection();
                    return false;
                }
            }
            finally
            {
                CloseConnection();
            }
           
        }
        private int LastRestockId()
        {
            string sql = "SELECT MAX(id) FROM restocks";
            int id = Convert.ToInt32(executeScalar(sql, null));
            CloseConnection();
            return id;
        }
        public bool UpdateItemStorageQuantity(int itemId, int newInStorageAmount)
        {
            try
            {
                String sql = "UPDATE items SET restock_state = @state, inStorageAmount = @amount  " +
                       "WHERE id = @id;";
                String[] parameters = new String[] {"stable", newInStorageAmount.ToString(), itemId.ToString()};
                if (executeNonQuery(sql, parameters) != null)
                {
                    CloseConnection();
                    return true;
                }
                else
                {
                    CloseConnection();
                    return false;
                }
            }
            finally
            {
                CloseConnection();
            }
           
        }

        private bool InsertRestockItem(int restockId, int itemId, int restockAmount)
        {
            try
            {
                String sql = "INSERT INTO restocks_items VALUES(@restockId, @itemId, @quantity) ;";
                String[] parameters = new String[] {restockId.ToString(), itemId.ToString(), restockAmount.ToString() };
                if (executeNonQuery(sql, parameters) != null)
                {
                    CloseConnection();
                    return true;
                }
                else
                {
                    CloseConnection();
                    return false;
                }
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool InsertNewRestock(Restock restock, int managerId)
        {
            try
            {
                string format = "yyyy-MM-dd";
                String sql = "INSERT INTO restocks (manager_id, date, total_price) VALUES(@managerId, @date, @totalPrice) ;";
                String[] parameters = new String[] { managerId.ToString(), DateTime.Now.Date.ToString(format), restock.GetTotalCost().ToString()};
                if (executeNonQuery(sql, parameters) != null)
                {
                    CloseConnection();
                    int restockId = LastRestockId();
                    foreach(Item i in restock.GetItemsForRestock())
                    {
                        InsertRestockItem(restockId, i.ID, i.AmountToRestock);
                        i.Restock_State = "checking";
                        UpdateItemState(i.ID, "checking");

                    }
                    return true;
                }
                else
                {
                    CloseConnection();
                    return false;
                }
            }
            finally
            {
                CloseConnection();
            }
        }

        //..................................................

        private int LastOrderId()
        {
            string sql = "SELECT MAX(id) FROM orders";
            int id = Convert.ToInt32(executeScalar(sql, null));
            CloseConnection();
            return id;
        }


       private bool UpdateItemShopQuantity(int itemId, int newInShopAmount)
        {
            try
            {
              
                    String sql = "UPDATE items SET inShopAmount = @amount  " +
                       "WHERE id = @id;";
                    String[] parameters = new String[] { newInShopAmount.ToString(), itemId.ToString() };
              
               
                if (executeNonQuery(sql, parameters) != null)
                {
                    CloseConnection();
                    return true;
                }
                else
                {
                    CloseConnection();
                    return false;
                }
            }
            finally
            {
                CloseConnection();
            }

        }

        public bool UpdateItemState(int itemId,string  state)
        {
            try
            {
                String sql = "UPDATE items SET restock_state = @state " +
                   "WHERE id = @id;";
                String[] parameters = new String[] { state, itemId.ToString() };


                if (executeNonQuery(sql, parameters) != null)
                {
                    CloseConnection();
                    return true;
                }
                else
                {
                    CloseConnection();
                    return false;
                }
            }
            finally
            {
                CloseConnection();
            }

        }


        private bool InsertOrderItem(int orderId, int itemId, int orderAmount)
        {
            try
            {
                String sql = "INSERT INTO orders_items VALUES(@orderId, @itemId, @quantity) ;";
                String[] parameters = new String[] { orderId.ToString(), itemId.ToString(), orderAmount.ToString() };
                if (executeNonQuery(sql, parameters) != null)
                {
                    CloseConnection();
                    return true;
                }
                else
                {
                    CloseConnection();
                    return false;
                }
            }
            finally
            {
                CloseConnection();
            }
        }


        public bool InsertNewOrder(Order order, int cashierId)
        {
            try
            {
                string format = "yyyy-MM-dd";
                String sql = "INSERT INTO orders (cashier_id, date, total_price) VALUES(@cashierId, @date, @totalPrice) ;";
                String[] parameters = new String[] { cashierId.ToString(), DateTime.Now.Date.ToString(format), order.GetTotalPrice().ToString() };
                if (executeNonQuery(sql, parameters) != null)
                {
                    CloseConnection();
                    int orderId = LastOrderId();
                    foreach (Item i in order.BoughtItems)
                    {
                        InsertOrderItem(orderId, i.ID, i.ScannedAmount);
                        int newInShop =i.InShopAmount - i.ScannedAmount;
                        UpdateItemShopQuantity(i.ID, newInShop);
                        i.InShopAmount = newInShop;
                        i.ScannedAmount = 0;
                    }
                    return true;
                }
                else
                {
                    CloseConnection();
                    return false;
                }
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool UpdateItemAmounts(int itemId, int newInShopAmount, int newInStorageAmount)
        {
            try
            {
                String sql = "UPDATE items SET inShopAmount = @inShopAmount, inStorageAmount = @inStorageAmount  " +
                   "WHERE id = @id;";
                String[] parameters = new String[] { newInShopAmount.ToString(),newInShopAmount.ToString(), itemId.ToString() };


                if (executeNonQuery(sql, parameters) != null)
                {
                    CloseConnection();
                    return true;
                }
                else
                {
                    CloseConnection();
                    return false;
                }
            }
            finally
            {
                CloseConnection();
            }

        }

       /* public bool UpdateItemImage(int itemID, byte[] image)
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(@"server=studmysql01.fhict.local;database=dbi460221;uid=dbi460221;password=lol;AllowUserVariables=true");
                //conn = new MySqlConnection("datasource = 127.0.0.1; port = 3306; username = root; password =; database = dbi460221;");
                String sql = "UPDATE items_images SET image = @image WHERE item_id = @itemID";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@itemID", itemID);
                cmd.Parameters.Add("@image", MySqlDbType.Blob).Value = image;
                conn.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    conn.Close();
                    return true;
                }
                else
                {
                    conn.Close();
                    return false;
                }
            }
            catch(MySqlException ex)
            {
                return false;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        } */
        public int GetIDByName(String name)
        {
            String sql = "SELECT id FROM items WHERE name = @name;";
            String[] parameters = new String[] { name };
            int id = Convert.ToInt32(executeScalar(sql, parameters));
            CloseConnection();
            return id;
        }

        public List<String> GetCategories()
        {
            string sql = null;
            MySqlDataReader dr = null;
            try
            {
                List<String> categories = new List<String>();
                 sql = "SELECT DISTINCT category FROM items;";
                 dr = executeReader(sql, null);
                while (dr.Read())
                {
                    categories.Add(dr[0].ToString());
                }
                CloseConnection();
                return categories;
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();

                }
                CloseConnection();
            }
           
        }

        public List<String> GetSubcategoriesByCategory(String category)
        {
            string sql = null;
            MySqlDataReader dr = null;
            try
            {
                List<String> subcategories = new List<String>();
                sql = "SELECT DISTINCT subcategory FROM items  WHERE category = @category;";
                String[] parameters = new String[] { category };
                dr = executeReader(sql, parameters);
                while (dr.Read())
                {
                    subcategories.Add(dr[0].ToString());
                }
                CloseConnection();
                return subcategories;
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();

                }
                CloseConnection();
            }

        }

        public List<String> GetBrandsBySubcategory(String subcategory)
        {
            string sql = null;
            MySqlDataReader dr = null;
            try
            {
                List<String> brands = new List<String>();
                 sql = "SELECT DISTINCT brand FROM items WHERE subcategory = @subcategory;";
                String[] parameters = new String[] { subcategory };
                 dr = executeReader(sql, parameters);
                while (dr.Read())
                {
                    brands.Add(dr[0].ToString());
                }
                CloseConnection();
                return brands;
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();

                }
                CloseConnection();
            }


            
        }

        public List<String> GetModelsByBrand(String brand)
        {
            string sql = null;
            MySqlDataReader dr = null;
            try
            {
                List<String> models = new List<String>();
                 sql = "SELECT DISTINCT model FROM items WHERE brand = @brand;";
                String[] parameters = new String[] { brand };
                 dr = executeReader(sql, parameters);
                while (dr.Read())
                {
                    models.Add(dr[0].ToString());
                }
                CloseConnection();
                return models;
            }

            finally
            {
                if (dr != null)
                {
                    dr.Close();

                }
                CloseConnection();
            }
   
        }
    }
}
