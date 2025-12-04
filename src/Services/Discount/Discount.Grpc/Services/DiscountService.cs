using Mapster;
using Discount.Grpc.Data;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using Discount.Grpc.Models;

namespace Discount.Grpc.Services
{
    public class DiscountService(DiscountContext dbContext, ILogger<DiscountService> logger): DiscountProtoService.DiscountProtoServiceBase
    {
        public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            var coupon = await dbContext.Coupons.FirstOrDefaultAsync(x => x.ProductName == request.ProductName);
            if (coupon == null)
            {
                coupon = new Models.Coupon { ProductName = "No Discount", Description = "No discount", Amount = 0 };
            }
            logger.LogInformation("Discount is retrieved for productname: {productname}", request.ProductName);
            var couponModel = coupon.Adapt<CouponModel>();
            return couponModel;
        }
        public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
        {
            var coupon = request.Coupon.Adapt<Coupon>();
            if (coupon == null)
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid request."));
            dbContext.Coupons.Add(coupon);
            
            await dbContext.SaveChangesAsync();
            
            logger.LogInformation("Discount is successfully created for productname: {productname}", request.Coupon.ProductName);
            return coupon.Adapt<CouponModel>();
        }
        public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
        {
            var coupon = request.Coupon.Adapt<Coupon>();
            if (coupon == null)
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid request."));
            dbContext.Coupons.Update(coupon);

            await dbContext.SaveChangesAsync();

            logger.LogInformation("Discount is successfully updated for productname: {productname}", request.Coupon.ProductName);
            return coupon.Adapt<CouponModel>();
        }
        public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        {
            var coupon = await dbContext.Coupons.FirstOrDefaultAsync(x => x.ProductName == request.ProductName);
            if (coupon == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"Discount with porductname:{request.ProductName} was not found."));
            }
            

            dbContext.Remove(coupon);
            await dbContext.SaveChangesAsync();
            logger.LogInformation("Discount is successfully deleted for productname: {productname}", request.ProductName);
            return new DeleteDiscountResponse { Success=true} ;
        }
    }
}
