using ShoeEcommerce.Data.Infrastructure;
using ShoeEcommerce.Model.Advertisements;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoeEcommerce.Data.Repository
{
    public interface IPositionRepository : IRepository<Position>
    {

    }
    public class PositionRepository : RepositoryBase<Position>, IPositionRepository
    {
        public PositionRepository(ShoeEcommerceDBContext shoeEcommerceDBContext) : base(shoeEcommerceDBContext)
        {

        }
    }
}
