
namespace Basket.API.Data
{
    public class CachedBasketRepository(IBasketRepository repository, IDistributedCache cache ) : IBasketRepository
    {
        public async Task<bool> DeleteBasket(string userName, CancellationToken token = default)
        {
            await repository.DeleteBasket(userName, token);
            await cache.RemoveAsync(userName, token);
            return true;
        }

        public async Task<ShoppingCart> GetBasket(string userName, CancellationToken token = default)
        {
            var cachedBasket = await cache.GetStringAsync(userName, token);
            if (!string.IsNullOrEmpty(cachedBasket))
            {
                var cache = JsonSerializer.Deserialize<ShoppingCart>(cachedBasket);
                if(cache != null) return cache;
            }
            var basket = await repository.GetBasket(userName, token);
            await cache.SetStringAsync(userName, JsonSerializer.Serialize(basket), token);
            return basket;
        }

        public async Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken token = default)
        {
            await repository.StoreBasket(basket, token);
            await cache.SetStringAsync(basket.UserName, JsonSerializer.Serialize(basket), token);
            return basket;
        }
    }
}
