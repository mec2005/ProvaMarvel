using System;
using Xunit;
using Marvel;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Marvel.Data;
using System.Net;
using System.Threading.Tasks;

namespace Marvel.Api.Tests
{
    public class IntegrationTests: BaseTest
    {       
        [Theory]
        [InlineData("GET")]
        public async Task CharactersGetAll(string method)
        {
            //Arrange
            var request = new HttpRequestMessage(new HttpMethod(method), $"{_baseUrl}/characters");

            //Act
            var response = await _client.SendAsync(request);

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Theory]
        [InlineData(1009165)]
        [InlineData(1009191)]
        [InlineData(1009220)]
        [InlineData(1009407)]
        [InlineData(1009583)]
        public async Task ShoulGetCharactersGetByID(int characterId)
        {
            //Arrange
            var request = new HttpRequestMessage(HttpMethod.Get, $"{_baseUrl}/characters/{characterId}");

            //Act
            var response = await _client.SendAsync(request);

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }


        [Theory]
        [InlineData(1)]
        [InlineData(10)]
        [InlineData(100)]
        [InlineData(1000)]
        [InlineData(10000)]
        public async Task ShoulNotGetCharactersGetByID(int characterId)
        {
            //Arrange
            var request = new HttpRequestMessage(HttpMethod.Get, $"{_baseUrl}/characters/{characterId}");

            //Act
            var response = await _client.SendAsync(request);

            //Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
