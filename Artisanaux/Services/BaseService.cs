﻿using Artisanaux.Web.Models;
using Artisanaux.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Http;
using Newtonsoft.Json;
using System;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Serialization;

namespace Artisanaux.Web.Services
{
    public class BaseService : IBaseService
    {
        private HttpResponseMessage apiResponse;

        public ResponseDto ResponseModel { get; set; }
        public IHttpClientFactory httpClient { get; set; }
        public object ApiResponse { get; private set; }

        public BaseService(IHttpClientFactory httpClient)
        {
            this.ResponseModel = new ResponseDto();
            this.httpClient = httpClient;
        }
        public async Task<T> SendAsync<T>(ApiRequest apiRequest)
        {
            try
            {
                var client = httpClient.CreateClient("ArtisanaAPI");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/jsob");
                message.RequestUri = new Uri(apiRequest.Url);
                client.DefaultRequestHeaders.Clear();
                if (apiRequest.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data),
                        Encoding.UTF8, "application/json"
                        );
                }
                if (string.IsNullOrEmpty(apiRequest.AccessToken))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiRequest.AccessToken);
                }
                HttpResponseMessage apiResponse = null;
                switch (apiRequest.ApiType)
                {
                    case SD.ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case SD.ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case SD.ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    case SD.ApiType.GET:
                        message.Method = HttpMethod.Get;
                        break;
                }
                apiResponse = await client.SendAsync(message);
                var apiContent = await apiResponse.Content.ReadAsStringAsync();
                var apiResponseDto = JsonConvert.DeserializeObject<T>(apiContent);
                return apiResponseDto;

            }
            catch (Exception e)
            {
                var dto = new ResponseDto
                {
                    DisplayMessage = "Error",
                    ErrorMessages = new List<string> { Convert.ToString(e) }
                };
                var res = JsonConvert.SerializeObject(dto);
                var apiResponseDto = JsonConvert.DeserializeObject<T>(res);
                return apiResponseDto;
            }
        }
        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
    }
}
