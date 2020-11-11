using MicroShopping.Models;
using MicroShopping.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroShopping.Services
{
    public class Review_RatingService : IReadable<Reviews_Ratings>,ISaveChange IUpdatable<Reviews_Ratings>, IDeletable
    {
        DataContext context;
        public Review_RatingService(DataContext _context)
        {
            context = _context;
        }


        public int Delete(int id)
        {
            context.Reviews_Ratings.Remove(context.Reviews_Ratings.FirstOrDefault(s => s.ID == id
            ));
            return 1;
        }

        public List<Reviews_Ratings> GetAll()
        {
            return context.Reviews_Ratings.ToList();
        }

        public Reviews_Ratings GetDetails(int id)
        {
            return context.Reviews_Ratings.FirstOrDefault(s => s.ID == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public int Update(int id, Reviews_Ratings model)
        {
            Reviews_Ratings reviews_Ratings = context.Reviews_Ratings.FirstOrDefault(s => s.ID == id);
            reviews_Ratings.Date = model.Date;
            reviews_Ratings.Rate = model.Rate;
            reviews_Ratings.Review = model.Review;
           
            context.SaveChanges();
            return 1;

        }
    }
}
