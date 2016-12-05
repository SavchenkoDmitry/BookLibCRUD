using System;
using Newtonsoft.Json;

namespace BookLibraryCRUD
{
    class BookJsonConnector
    {
        string json;

        public Newtonsoft.Json.Linq.JArray GetInfo()
        {
            return Newtonsoft.Json.Linq.JArray.Parse(json);
        }

        public void WriteInfo(object info)
        {
            json = JsonConvert.SerializeObject(info);
        } 
    }
}
