using ShoeEcommerce.Data.Repository;
using ShoeEcommerce.Model.Accounts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoeEcommerce.Service
{
    public interface IEmailService
    {
        Task<IEnumerable<Email>> GetAllEmailsAsync();

        Email GetEmailByIdAsync(string id);

        //Task<EmailsExtended> GetEmailsWithDetailsAsync(Guid EmailsId);
        Task CreateEmailAsync(Email item);

        Task UpdateEmailAsync(Email item);

        Task DeleteEmailAsync(Email item);
    }

    public class EmailService : IEmailService
    {
        private IEmailRepository Repository;

        public EmailService(IEmailRepository repository)
        {
            Repository = repository;
        }

        public async Task CreateEmailAsync(Email item)
        {
            item.id = await Repository.GetNextIdAsync();
            Repository.Create(item);
            await Repository.SaveAsync();
        }

        public async Task DeleteEmailAsync(Email item)
        {
            Repository.Delete(item);
            await Repository.SaveAsync();
        }

        public async Task<IEnumerable<Email>> GetAllEmailsAsync()
        {
            return await Repository.FindAllAsync();
        }

        public Email GetEmailByIdAsync(string id)
        {
            return Repository.Find(id);
        }

        public async Task UpdateEmailAsync(Email item)
        {
            Repository.Update(item);
            await Repository.SaveAsync();
        }
    }
}