using AutoMapper;
using Mango.Services.CouponAPI.DbContexts;
using Mango.Services.CouponAPI.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.CouponAPI.Repository
{
    public class CouponRespository : ICouponRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public CouponRespository(ApplicationDbContext db, IMapper mapper)
        {
            _db=db;
            _mapper=mapper;
        }

        public async Task<CouponDto> GetCouponByCode(string couponCode)
        {
            var couponFromDb = await _db.Coupons.FirstOrDefaultAsync(u => u.CouponCode==couponCode);
            return _mapper.Map<CouponDto>(couponFromDb);
        }
    }
}
