using Microsoft.EntityFrameworkCore;
using PostCodes.Domain.Entities;
using PostCodes.Domain.Interfaces;
using PostCodes.Infrastructure.Context;

namespace PostCodes.Infrastructure.Repository
{
    public class PostCodeRepository : IPostCodeRepository
    {
        private readonly AppDbContext _context;

        public PostCodeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddPostCodeSearch(PostCode postCode)
        {
            _context.PostCodes.Add(postCode);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PostCode>> GetSearchHistory(int? recordsNumber)
        {
            IQueryable<PostCode> query = from PostCodes in _context.PostCodes
                                         group PostCodes by PostCodes.PostCodeNumber
                                         into pc
                                         select pc.OrderByDescending(x => x.Id).FirstOrDefault();

            var result = await query.AsNoTracking().ToListAsync();
            
            if (recordsNumber == null)
                return result.OrderByDescending(x => x.Id);
            else
                return result.OrderByDescending(x => x.Date).Take((int)recordsNumber);
        }

        public async Task<IEnumerable<PostCode>> GetFullSearchHistoryByDateLimit(DateTime date)
        {
            var query = await _context.PostCodes.Where(x => x.Date >= date).OrderByDescending(x => x.Date).AsNoTracking().ToListAsync();
            return query;
        }
    }
}
