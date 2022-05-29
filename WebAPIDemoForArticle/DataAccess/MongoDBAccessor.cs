using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace WebAPIDemoForArticle.DataAccess
{
    public class MongoDBAccessor
    {
        /// <summary>
        /// The link to the MongoDB database
        /// </summary>
        private readonly IMongoDatabase _database;
        private const string _forecastCollection = "Weather Forecasts";

        public MongoDBAccessor(IConfiguration configuration)
        {
            MongoClient client = new MongoClient();
            string database = configuration.GetConnectionString("MongoDB");
            _database = client.GetDatabase(database);
        }

        /// <summary>
        /// Runs a query to get all the binary JSON (BSON) documents in the "Weather Forecasts" collection,
        /// using MongoDB's Find() method.
        /// </summary>
        public List<WeatherForecast> GetForecasts()
        {
            IMongoCollection<WeatherForecast> collection = _database.GetCollection<WeatherForecast>(_forecastCollection);
            return collection.Find(new BsonDocument()).ToList();
        }
        /// <summary>
        /// Runs a query to insert a new weather forecast into the Weather Forecasts collection
        /// </summary>
        public void CreateForecast(WeatherForecast forecast)
        {
            _database.GetCollection<WeatherForecast>(_forecastCollection)
                .InsertOne(forecast);
        }
    }
}