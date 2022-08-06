using _0_Framwork.Application;
using _0_Framwork.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopMagement.Domain.SlideAgg;
using ShopManagement.Application.Contracts.Slide;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class SlideRepository : RepositoryBase<long, Slide>, ISlideRepository
    {
        private readonly ShopContext _context;
        public SlideRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public EditSlide GetDetails(long id)
        {
            return _context.Slides.Select(x => new EditSlide
            { 
            Id = x.Id,
            Picture = x.Picture,
            PictureAlt = x.PictureAlt,
            PictureTitle = x.PictureTitle,
            Heading = x.Heading,
            Title = x.Title,
            Text = x.Text,
            Link = x.Link,
            BtnText = x.BtnText
            
            }).FirstOrDefault(x => x.Id == id);   
        }

        public List<SlideViewModel> GetList()
        {
            return _context.Slides.Select(x => new SlideViewModel
            {
                Id = x.Id,
                Picture = x.Picture,
                Heading = x.Heading,
                Title = x.Title,
                IsRemoved = x.IsRemoved,
                CreationDate = x.CreationDate.ToFarsi()

            }).OrderByDescending(x => x.Id ).ToList();
        }
    }
}
