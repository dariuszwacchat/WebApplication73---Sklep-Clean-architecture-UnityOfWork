using Data.Repos;
using Data.Repos.Abs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace Data
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly ApplicationDbContext _context;


        public ICategoriesRepository CategoriesRepository { get; set; }
        public IClientsRepository ClientsRepository { get; set; }
        public IColorsProductRepository ColorsProductRepository { get; set; }
        public IColorsRepository ColorsRepository { get; set; }
        public IFavouritesRepository FavouritesRepository { get; set; } 
        public IMarkiRepository MarkiRepository { get; set; }
        public INewsletterRepository NewsletterRepository { get; set; }
        public IOrdersRepository OrdersRepository { get; set; }
        public IPhotosClientRepository PhotosClientRepository { get; set; }
        public IPhotosProductRepository PhotosProductRepository { get; set; }
        public IProductsRepository ProductsRepository { get; set; }
        public IReceiveMessagesRepository ReceiveMessagesRepository { get; set; }
        public ISendMessagesRepository SendMessagesRepository { get; set; }
        public ISizesProductRepository SizesProductRepository { get; set; }
        public ISizesRepository SizesRepository { get; set; }
        public ISubcategoriesRepository SubcategoriesRepository { get; set; }
        public ISubsubcategoriesRepository SubsubcategoriesRepository { get; set; }
        //public IUsersRepository UsersRepository { get; set; }  


        public UnityOfWork (ApplicationDbContext context)
        {
            _context = context;


            CategoriesRepository = new CategoriesRepository (_context);
            ClientsRepository = new ClientsRepository (_context);
            ColorsProductRepository = new ColorsProductRepository (_context);
            ColorsRepository = new ColorsRepository (_context);
            FavouritesRepository = new FavouritesRepository (_context);
            MarkiRepository = new MarkiRepository (_context);
            NewsletterRepository = new NewsletterRepository (_context);
            OrdersRepository = new OrdersRepository (_context);
            PhotosClientRepository = new PhotosClientRepository (_context);
            PhotosProductRepository = new PhotosProductRepository (_context);
            ProductsRepository = new ProductsRepository (_context);
            ReceiveMessagesRepository = new ReceiveMessagesRepository (_context);
            SendMessagesRepository = new SendMessagesRepository (_context);
            SizesProductRepository = new SizesProductRepository (_context);
            SizesRepository = new SizesRepository (_context);
            SubcategoriesRepository = new SubcategoriesRepository (_context);
            SubsubcategoriesRepository = new SubsubcategoriesRepository (_context);
            //UsersRepository = new UsersRepository (_context);
        }

        public async Task SaveChangesAsync ()
        {
            await _context.SaveChangesAsync ();
        } 
    }
}
