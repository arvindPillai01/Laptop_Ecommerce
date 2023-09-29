using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Laptop_Ecommerce.Startup))]
namespace Laptop_Ecommerce
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            ConfigureCustomServices(app);
        }

        private void ConfigureCustomServices(IAppBuilder app)
        {
            // Create an instance of CartService and use it
            var cartService = new CartService();

            //app.Properties["CartService"] = cartService;
            // If you need to use cartService, you can do so here


            app.Use((context, next) =>
            {
                context.Set("CartService", cartService);
                return next.Invoke();
            });
        }
    }
}
