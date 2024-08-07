﻿using EduHome.Models;

namespace EduHome.Services.Interfaces
{
    public interface ISliderService
    {
        public Task AddAsync(Slider slider);
        public Task RemoveAsync(string id);
        public Task UpdateAsync(Slider slider);
        public Task<Slider> GetAsync(string id);
        public Task<List<Slider>> GetAllAsync();
    }
}
