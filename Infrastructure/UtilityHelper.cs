using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static  class UtilityHelper
    {

        #region Reading parameters from Json file
        /// <summary>
        /// Reading parameters from Json file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static T ReadJsonFile<T>(string filePath)
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    string jsonContent = reader.ReadToEnd();
                    return JsonConvert.DeserializeObject<T>(jsonContent);
                }
            }
        }
        #endregion Reading parameters from Json file
    }
}
