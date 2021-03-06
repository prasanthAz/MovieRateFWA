using System.Threading.Tasks;

namespace MovieRating.Business.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// Checks if this given user exists
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<bool> UserExistsAsync(int userId);
    }
}
