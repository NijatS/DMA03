using EduHome.Models;
using EduHome.Repositories.Interfaces;
using EduHome.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EduHome.Services.Implementations
{
    public class SliderService : ISliderService
    {
        private readonly ISliderRepository _repository;

        public SliderService(ISliderRepository repository)
        {
            _repository = repository;
        }

        public Task AddAsync(Slider slider)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Slider>> GetAllAsync()
        {
           return  await (await _repository.GetAllAsync(s => !s.IsDeleted)).ToListAsync();
        }

        public async Task<Slider?> GetAsync(string id)
        {
            Slider slider = await _repository.GetAsync(s => s.Id.ToString() == id && !s.IsDeleted);

            if (slider == null) {
                throw new NullReferenceException();
            }

            return slider;
            
        }

        public async Task RemoveAsync(string id)
        {
            Slider slider = await GetAsync(id);

            slider.IsDeleted = true;

            await _repository.SaveAsync();

            
        }

        public Task UpdateAsync(Slider slider)
        {
            throw new NotImplementedException();
        }
    }
}
