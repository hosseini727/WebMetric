using Domain.Entities;
using Infrastructure;
using Microsoft.Testing.Platform.Extensions.Messages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using System.Linq.Expressions;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace WebMetric.Test
{
    [TestClass]
    public class CalculateMetrics
    {
        [TestMethod]
        public void ReadJsonFile_ShouldDeserializeJsonContent_Click()
        {
            // Arrange
            const string filePath = "click_test.json";
            const string jsonContent = "[ { \"impression_id\": \"c1\", \"revenue\": 8 }, { \"impression_id\": \"c2\", \"revenue\": 7 } ]";

            // Create a temporary file with the provided JSON content
            File.WriteAllText(filePath, jsonContent);

            try
            {
                // Act
                var result = UtilityHelper.ReadJsonFile<List<Click>>(filePath);

                // Assert
                Assert.IsNotNull(result);
                Assert.AreEqual(2, result.Count);
            }
            finally
            {
                // Clean up: Delete the temporary file
                File.Delete(filePath);
            }
        }

        [TestMethod]
        public void ReadJsonFile_ShouldDeserializeJsonContent_Impression()
        {
            // Arrange
            const string filePath = "impressions_test.json";
            const string jsonContent = "[ { \"id\": \"c1\", \"app_id\": 1, \"country_code\": \"US\", \"advertiser_id\": 101 }," +
                                       "{ \"id\": \"c2\", \"app_id\": 2, \"country_code\": \"CA\", \"advertiser_id\": 102 } ]";

            // Create a temporary file with the provided JSON content
            File.WriteAllText(filePath, jsonContent);

            try
            {
                // Act
                var result = UtilityHelper.ReadJsonFile<List<Impression>>(filePath);

                // Assert
                Assert.IsNotNull(result);
                Assert.AreEqual(2, result.Count);
            }
            finally
            {
                // Clean up: Delete the temporary file
                File.Delete(filePath);
            }
        }

        
    }
}