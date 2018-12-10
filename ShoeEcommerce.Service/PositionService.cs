using ShoeEcommerce.Data.Repository;
using ShoeEcommerce.Model.Advertisements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeEcommerce.Service
{
    public interface IPositionService
    {
        Task<IEnumerable<Position>> GetAllPositionsAsync();
        Task<Position> GetPositionByIdAsync(string id);
        //Task<PositionsExtended> GetPositionsWithDetailsAsync(Guid PositionsId);
        Task CreatePositionAsync(Position item);
        Task UpdatePositionAsync(Position item);
        Task DeletePositionAsync(Position item);
    }
    public class PositionService : IPositionService
    {
        IPositionRepository Repository;
        public PositionService(IPositionRepository positionRepository)
        {
            this.Repository = positionRepository;
        }

        public Task CreatePositionAsync(Position item)
        {
            throw new NotImplementedException();
        }

        public Task DeletePositionAsync(Position item)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Position>> GetAllPositionsAsync()
        {
            var item = await Repository.FindAllAsync();
            return item;
        }

        public async Task<Position> GetPositionByIdAsync(string id)
        {
            var item = await Repository.FindByConditionAync(i=>i.idPosition.Equals(id));
            return item.DefaultIfEmpty(new Position())
                    .FirstOrDefault();
        }
        public Task UpdatePositionAsync(Position item)
        {
            throw new NotImplementedException();
        }
    }
}
