using _0_Framwork.Domain;
using ShopManagement.Application.Contracts.Slide;

namespace ShopMagement.Domain.SlideAgg
{
    public interface ISlideRepository : IRepository<long , Slide>
    {
        EditSlide GetDetails(long id);
        List<SlideViewModel> GetList();

    }
}
