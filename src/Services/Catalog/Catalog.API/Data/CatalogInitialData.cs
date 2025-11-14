using Marten.Schema;

namespace Catalog.API.Data
{
    public class CatalogInitialData : IInitialData
    {
        public async Task Populate(IDocumentStore store, CancellationToken cancellation)
        {
            using var session = store.LightweightSession();
            if (await session.Query<Product>().AnyAsync())
            {
                return;
            }
            session.Store<Product>(GetPreconfiguredProducts());
            await session.SaveChangesAsync();
        }

        private static IEnumerable<Product> GetPreconfiguredProducts() => new List<Product>
        {
            new Product { Id = Guid.NewGuid(), Name = "Mechanical Keyboard", Category = new List<string>{"Electronics","Accessories"}, Description = "A durable mechanical keyboard with customizable RGB lighting and tactile feedback.", ImageFile = "keyboard.jpg", Price = 79.99m },
            new Product { Id = Guid.NewGuid(), Name = "Wireless Mouse", Category = new List<string>{"Electronics","Accessories"}, Description = "A sleek wireless mouse with ergonomic design and long battery life.", ImageFile = "mouse.jpg", Price = 29.99m },
            new Product { Id = Guid.NewGuid(), Name = "27-inch 4K Monitor", Category = new List<string>{"Electronics","Monitors"}, Description = "A high-resolution monitor with vivid colors and fast response time.", ImageFile = "monitor.jpg", Price = 349.99m },
            new Product { Id = Guid.NewGuid(), Name = "USB-C Hub", Category = new List<string>{"Electronics","Accessories"}, Description = "A multiport hub to expand your laptop's connectivity.", ImageFile = "usbchub.jpg", Price = 49.99m },
            new Product { Id = Guid.NewGuid(), Name = "Noise Cancelling Headphones", Category = new List<string>{"Electronics","Audio"}, Description = "Over-ear headphones with active noise cancellation and long battery life.", ImageFile = "headphones.jpg", Price = 199.99m },
            new Product { Id = Guid.NewGuid(), Name = "Smartphone Stand", Category = new List<string>{"Accessories","Mobile"}, Description = "Adjustable stand for smartphones and small tablets.", ImageFile = "stand.jpg", Price = 14.99m },
            new Product { Id = Guid.NewGuid(), Name = "Portable SSD 1TB", Category = new List<string>{"Electronics","Storage"}, Description = "Compact and fast external solid-state drive for data storage.", ImageFile = "ssd.jpg", Price = 129.99m },
            new Product { Id = Guid.NewGuid(), Name = "Bluetooth Speaker", Category = new List<string>{"Electronics","Audio"}, Description = "Portable Bluetooth speaker with deep bass and waterproof design.", ImageFile = "speaker.jpg", Price = 59.99m },
            new Product { Id = Guid.NewGuid(), Name = "Smartwatch", Category = new List<string>{"Electronics","Wearables"}, Description = "A smartwatch with fitness tracking, notifications, and heart-rate monitoring.", ImageFile = "smartwatch.jpg", Price = 149.99m },
            new Product { Id = Guid.NewGuid(), Name = "Webcam 1080p", Category = new List<string>{"Electronics","Cameras"}, Description = "HD webcam for video calls and streaming.", ImageFile = "webcam.jpg", Price = 69.99m },
            new Product { Id = Guid.NewGuid(), Name = "Laptop Sleeve", Category = new List<string>{"Accessories","Laptop"}, Description = "Protective sleeve for laptops up to 15 inches.", ImageFile = "laptopsleeve.jpg", Price = 24.99m },
            new Product { Id = Guid.NewGuid(), Name = "Ergonomic Chair", Category = new List<string>{"Furniture","Office"}, Description = "Comfortable chair with lumbar support for long working hours.", ImageFile = "chair.jpg", Price = 199.99m },
            new Product { Id = Guid.NewGuid(), Name = "Desk Lamp LED", Category = new List<string>{"Furniture","Lighting"}, Description = "Energy-saving LED desk lamp with adjustable brightness.", ImageFile = "desklamp.jpg", Price = 39.99m },
            new Product { Id = Guid.NewGuid(), Name = "Wireless Charger", Category = new List<string>{"Electronics","Accessories"}, Description = "Fast wireless charger compatible with Qi-enabled devices.", ImageFile = "charger.jpg", Price = 29.99m },
            new Product { Id = Guid.NewGuid(), Name = "Gaming Mouse Pad", Category = new List<string>{"Accessories","Gaming"}, Description = "Large mouse pad with smooth surface for precise movements.", ImageFile = "mousepad.jpg", Price = 19.99m },
            new Product { Id = Guid.NewGuid(), Name = "Action Camera", Category = new List<string>{"Electronics","Cameras"}, Description = "Waterproof action camera with 4K recording capabilities.", ImageFile = "actioncamera.jpg", Price = 199.99m },
            new Product { Id = Guid.NewGuid(), Name = "External Hard Drive 2TB", Category = new List<string>{"Electronics","Storage"}, Description = "Reliable external hard drive for backup and storage.", ImageFile = "harddrive.jpg", Price = 89.99m },
            new Product { Id = Guid.NewGuid(), Name = "Smart Home Hub", Category = new List<string>{"Electronics","Smart Home"}, Description = "Control your smart devices with a single hub.", ImageFile = "smarthub.jpg", Price = 129.99m },
            new Product { Id = Guid.NewGuid(), Name = "Electric Kettle", Category = new List<string>{"Home Appliances","Kitchen"}, Description = "Fast-boiling electric kettle with auto shut-off.", ImageFile = "kettle.jpg", Price = 39.99m },
            new Product { Id = Guid.NewGuid(), Name = "Coffee Maker", Category = new List<string>{"Home Appliances","Kitchen"}, Description = "Automatic drip coffee maker with programmable timer.", ImageFile = "coffeemaker.jpg", Price = 79.99m },
        };

    }
}
