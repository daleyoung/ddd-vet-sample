﻿using BlazorShared.Models.Room;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FrontDesk.Blazor.Services
{
    public class RoomService
    {
        private readonly HttpService _httpService;
        private readonly ILogger<RoomService> _logger;

        public RoomService(HttpService httpService, ILogger<RoomService> logger)
        {
            _httpService = httpService;
            _logger = logger;
        }

        public async Task<RoomDto> CreateAsync(CreateRoomRequest room)
        {
            return (await _httpService.HttpPostAsync<CreateRoomResponse>("rooms", room)).Room;
        }

        public async Task<RoomDto> EditAsync(UpdateRoomRequest room)
        {
            return (await _httpService.HttpPutAsync<UpdateRoomResponse>("rooms", room)).Room;
        }

        public async Task<string> DeleteAsync(int roomId)
        {
            return (await _httpService.HttpDeleteAsync<DeleteRoomResponse>("rooms", roomId)).Status;
        }

        public async Task<RoomDto> GetByIdAsync(int roomId)
        {
            return (await _httpService.HttpGetAsync<GetByIdRoomResponse>($"rooms/{roomId}")).Room;
        }

        public async Task<List<RoomDto>> ListPagedAsync(int pageSize)
        {
            _logger.LogInformation("Fetching rooms from API.");

            return (await _httpService.HttpGetAsync<ListRoomResponse>($"rooms")).Rooms;
        }

        public async Task<List<RoomDto>> ListAsync()
        {
            _logger.LogInformation("Fetching rooms from API.");

            return (await _httpService.HttpGetAsync<ListRoomResponse>($"rooms")).Rooms;
        }
    }
}
