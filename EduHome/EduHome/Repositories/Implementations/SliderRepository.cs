using EduHome.Context;
using EduHome.Models;
using EduHome.Repositories.Interfaces;

namespace EduHome.Repositories.Implementations
{
    public class SliderRepository : Repository<Slider>, ISliderRepository
    {
        public SliderRepository(EduHomeDbContext context) : base(context)
        {
        }
    }
}
