using SocialNetwork.Data;
using System.Collections;
using System.Data.Entity;
using System.Linq;

namespace SocialNetwork.ConsoleClient.Searcher
{
    public class SocialNetworkService : ISocialNetworkService
    {
        private SocialNetworkContext db;
        public SocialNetworkService()
        {
            this.db = new SocialNetworkContext();
        }
        public IEnumerable GetChatUsers(string username)
        {
            return this.db.Messages
                .Where(m => m.Friendship.FirstUser.Username == username)
                .Select(m => m.Friendship.SecondUser.Username)
                .Union(
                    this.db.Messages
                    .Where(m => m.Friendship.SecondUser.Username == username)
                    .Select(m => m.Friendship.FirstUser.Username))
                .Where(u => u != username)
                .Distinct()
                .OrderBy(u => u)
                .ToList();
        }

        public IEnumerable GetFriendships(int page = 1, int pageSize = 25)
        {
            var skip = (page - 1) * pageSize;
            var take = pageSize;

            return this.db.Friendships
                .Where(f => f.Approved)
                .OrderBy(f => f.FriendsSince)
                .Skip(skip)
                .Take(take)
                .Select(f => new
                {
                    FirstUserUsername = f.FirstUser.Username,
                    FirstUserImage = f.FirstUser.Images.Select(i => i.ImageUrl).FirstOrDefault(),
                    SecondUserUsername = f.SecondUser.Username,
                    SecondUserImage = f.SecondUser.Images.Select(i => i.ImageUrl).FirstOrDefault()
                })
                .ToList();
        }

        public IEnumerable GetPostsByUser(string username)
        {
            return this.db.Posts
                .Where(p => p.Users.Any(u => u.Username == username))
                .Select(p => new
                {
                    p.PostedOn,
                    p.Content,
                    Users = p.Users.Select(u => u.Username)
                })
                .ToList();
        }

        public IEnumerable GetUsersAfterCertainDate(int year)
        {
            return this.db.Users
                .Where(u => u.RegisteredOn.Year > year)
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    u.Username,
                    Messages = u.Messages.Select(m => m.Content),
                    Posts = u.Posts.Select(p => p.Content)
                })
                .ToList();
        }
    }
}
