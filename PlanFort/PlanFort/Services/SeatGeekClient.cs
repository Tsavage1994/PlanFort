﻿using PlanFort.Models.SeatGeekAPIModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace PlanFort.Services
{
    public class SeatGeekClient
    {
        private readonly HttpClient _client;

        public SeatGeekClient(HttpClient client)
        {
            _client = client;
        }
        public async Task<EventsResponseModel> GetAllEvents()
        {
            return await GetAsync<EventsResponseModel>
                ("/events?client_id= MjE1NjY1OTZ8MTYxNDY1MTAwMC41MDk3Mjk2");
        }
        public async Task<EventsResponseModel> GetEventByCity(string city)
        {
            return await GetAsync<EventsResponseModel>
                ($"/events?venue.city={city}&client_id=MjE1NjY1OTZ8MTYxNDY1MTAwMC41MDk3Mjk2");

            //Calling SeatGeek API and searching events for certain cities
        }


        private async Task<T> GetAsync<T>(string endPoint)
        {
            var response = await _client.GetAsync(endPoint);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStreamAsync();

                // var jsonOptions = new JsonSerializerOptions();

                var model = await JsonSerializer.DeserializeAsync<T>(content);

                return model;
            }
            else
            {
                throw new HttpRequestException("Final Space API returned bad response");
            }
        }
    }   
}
