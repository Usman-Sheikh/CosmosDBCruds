using Newtonsoft.Json;
using System;

namespace Models
{
    public class Product
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Product_Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Product_Description { get; set; }
        
        [JsonProperty(PropertyName = "price")]
        public string Product_Price { get; set; }
        
        [JsonProperty(PropertyName = "availability")]
        public string Product_Availability { get; set; }

        public override string ToString()
        {
            return $"ID: {Id} | Name: {Product_Name} | Price: {Product_Price}";
        }
    }
}
