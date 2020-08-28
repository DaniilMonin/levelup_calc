using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dapper;
using Microsoft.Data.Sqlite;

namespace ShopManager.Data.Db.Context
{
    public sealed class ShopManagerDapperContext
    {
        public ShopManagerDapperContext()
        {
            /*SqliteConnection connection = new SqliteConnection("Data Source=E:/LevelUp/Database/blogging.db");

            connection.Open();

            SqliteCommand writerCommand = connection.CreateCommand();

            writerCommand.Parameters.AddWithValue("@name", "demoXml");

            writerCommand.CommandText = "insert into items(name) values (@name)";

            int count = writerCommand.ExecuteNonQuery();

            IDbCommand readerCommand = connection.CreateCommand();

            readerCommand.CommandText = "select name, description from main.items;";

            IDataReader reader = readerCommand.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {
                    string name = (string)reader["name"];

                    object val = reader["description"];

                    string description = string.Empty;

                    if (val != DBNull.Value)
                    {
                        description = (string)val;
                    }

                    ProductLiteDTO product = new ProductLiteDTO()
                    {
                        Name = name,
                        Description = description
                    };
                }
            }

            connection.Close();*/
        }


        public async Task<int> RunInsertAsync()
        {
            SqliteConnection connection = new SqliteConnection("Data Source=E:/LevelUp/Database/blogging.db");

            connection.Open();

            SqliteCommand writerCommand = connection.CreateCommand();

            writerCommand.Parameters.AddWithValue("@name", "demoXml");

            writerCommand.CommandText = "insert into items(name) values (@name)";

            int countOne = await writerCommand.ExecuteNonQueryAsync().ConfigureAwait(false);

            //
            
            int countTwo = await writerCommand.ExecuteNonQueryAsync().ConfigureAwait(false);



            connection.Close();

            return countOne + countTwo;
        }

        public async Task<IEnumerable<ProductLiteDTO>> GetAllProducts()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductLiteDTO>();
                cfg.CreateMap<ProductLiteDTO, Product>();

            });

            SqliteConnection connection = new SqliteConnection("Data Source=E:/LevelUp/Database/blogging.db");

            IEnumerable<ProductLiteDTO> productsDto = null;

            await connection.OpenAsync();

            List<Product> products = new List<Product>();

            productsDto = await connection.QueryAsync<ProductLiteDTO>("select name, description from main.items");

            var mapper = config.CreateMapper();

            foreach (ProductLiteDTO productLiteDto in productsDto)
            {
                Product product = mapper.Map<Product>(productLiteDto);

                products.Add(product);
            }

            //DTO - Data Transfer Object

            //KISS - keep it simple stupid

            await connection.CloseAsync();

            return productsDto;
        }
    }

    public class ProductLiteDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class Triangle
    {

    }

    public class Product
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}