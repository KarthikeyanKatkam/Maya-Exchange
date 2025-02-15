using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MySql.Data.MySqlClient;
using Npgsql;
using System;
using Amazon.DynamoDB;
using Redis.StackExchange;
using Cassandra;

namespace Maya.Exchange.Config
{
    public class DbConfig
    {
        private readonly IConfiguration _configuration;
        
        public DbConfig(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IMongoClient GetMongoClient()
        {
            var connectionString = _configuration["MongoDB:ConnectionString"];
            var settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
            settings.ServerSelectionTimeout = TimeSpan.FromSeconds(GetConnectionTimeout());
            settings.MaxConnectionPoolSize = GetMaxPoolSize();
            return new MongoClient(settings);
        }

        public IMongoDatabase GetMongoDatabase()
        {
            var databaseName = _configuration["MongoDB:DatabaseName"];
            return GetMongoClient().GetDatabase(databaseName);
        }

        public MySqlConnection GetMySqlConnection()
        {
            var connectionString = _configuration["MySQL:ConnectionString"];
            var connection = new MySqlConnection(connectionString);
            connection.ConnectionTimeout = GetConnectionTimeout();
            return connection;
        }

        public NpgsqlConnection GetPostgresConnection()
        {
            var builder = new NpgsqlConnectionStringBuilder
            {
                ConnectionString = _configuration["PostgreSQL:ConnectionString"],
                Timeout = GetConnectionTimeout(),
                MaxPoolSize = GetMaxPoolSize(),
                CommandTimeout = GetCommandTimeout()
            };
            return new NpgsqlConnection(builder.ConnectionString);
        }

        public AmazonDynamoDBClient GetDynamoDbClient()
        {
            var config = new AmazonDynamoDBConfig
            {
                RegionEndpoint = Amazon.RegionEndpoint.GetBySystemName(_configuration["AWS:Region"]),
                Timeout = TimeSpan.FromSeconds(GetConnectionTimeout())
            };
            return new AmazonDynamoDBClient(config);
        }

        public IConnectionMultiplexer GetRedisConnection()
        {
            var options = ConfigurationOptions.Parse(_configuration["Redis:ConnectionString"]);
            options.ConnectTimeout = GetConnectionTimeout() * 1000;
            options.SyncTimeout = GetCommandTimeout() * 1000;
            return ConnectionMultiplexer.Connect(options);
        }

        public ICluster GetCassandraCluster()
        {
            var cluster = Cluster.Builder()
                .AddContactPoints(_configuration["Cassandra:ContactPoints"].Split(','))
                .WithCredentials(_configuration["Cassandra:Username"], _configuration["Cassandra:Password"])
                .WithQueryTimeout(TimeSpan.FromSeconds(GetCommandTimeout()))
                .Build();
            return cluster;
        }

        public string GetDatabaseType()
        {
            return _configuration["Database:Type"];
        }

        public int GetConnectionTimeout()
        {
            return int.Parse(_configuration["Database:ConnectionTimeout"]);
        }

        public int GetCommandTimeout() 
        {
            return int.Parse(_configuration["Database:CommandTimeout"]);
        }

        public int GetMaxPoolSize()
        {
            return int.Parse(_configuration["Database:MaxPoolSize"]); 
        }

        public bool GetEnableRetryOnFailure()
        {
            return bool.Parse(_configuration["Database:EnableRetryOnFailure"]);
        }

        public int GetMaxRetryAttempts()
        {
            return int.Parse(_configuration["Database:MaxRetryAttempts"]);
        }

        public string GetBackupStoragePath()
        {
            return _configuration["Database:BackupStoragePath"];
        }

        public int GetBackupRetentionDays()
        {
            return int.Parse(_configuration["Database:BackupRetentionDays"]);
        }
    }
}

