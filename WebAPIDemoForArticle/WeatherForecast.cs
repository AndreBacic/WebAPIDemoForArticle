using MongoDB.Bson.Serialization.Attributes;
using System;

namespace WebAPIDemoForArticle
{
    public class WeatherForecast
    {
        [BsonId]
        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        [BsonIgnore]
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }
}
