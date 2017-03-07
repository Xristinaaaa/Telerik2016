using SocialNetwork.ConsoleClient.Models;
using SocialNetwork.Data;
using SocialNetwork.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace SocialNetwork.ConsoleClient
{
    public class Importer
    {
        private const string postsFile = "XmlFiles/Posts.xml";
        private const string friendshipsFile = "XmlFiles/Friendships.xml";

        private readonly TextWriter textWrite;

        private Importer(TextWriter textwrite)
        {
            this.textWrite = textwrite;
        }
        public static Importer Create(TextWriter textwrite)
        {
            return new Importer(textwrite);
        }
        public void Import()
        {

            var friendships = this.Deserialize<FriendshipXmlModel>(friendshipsFile, "Friendship");
            this.ProcessFriendships(friendships);
            this.textWrite.WriteLine();

            var posts = this.Deserialize<PostXmlModel>(postsFile, "Post");
            this.ProcessPosts(posts);
            this.textWrite.WriteLine();
        }

        private IEnumerable<TModel> Deserialize<TModel>(string filename, string element)
        {
            if (!File.Exists(filename))
            {
                throw new FileNotFoundException("File not found!", filename);
            }

            var serializer = new XmlSerializer(typeof(List<TModel>), new XmlRootAttribute(element));
            IEnumerable<TModel> result;

            using (var fs = new FileStream(filename, FileMode.Open))
            {
                result = (IEnumerable<TModel>)serializer.Deserialize(fs);
            }

            return result;
        }
        private void ProcessFriendships(IEnumerable<FriendshipXmlModel> friendships)
        {
            this.textWrite.Write("Importing friendships");

            var addedFriendships = 0;
            var db = new SocialNetworkContext();

            db.Configuration.AutoDetectChangesEnabled = false;
            db.Configuration.ValidateOnSaveEnabled = false;

            var savedUsers = new HashSet<string>();

            foreach (var friendship in friendships)
            {
                var firstUser = this.GetUser(db, friendship.FirstUser, savedUsers);
                var secondUser = this.GetUser(db, friendship.SecondUser, savedUsers);

                var newFriendship = new Friendship
                {
                    Approved = friendship.Approved,
                    FriendsSince = friendship.FriendsSince,
                    FirstUser = firstUser,
                    SecondUser = secondUser,
                };

                foreach (var message in friendship.Messages)
                {
                    db.Messages.Add(new Message
                    {
                        Author = message.Author == firstUser.Username ? firstUser : secondUser,
                        Content = message.Content,
                        Friendship = newFriendship,
                        SeenOn = message.SeenOn,
                        SentOn = message.SentOn
                    });
                }

                addedFriendships++;

                if (addedFriendships % 10 == 0)
                {
                    this.textWrite.Write(".");
                }

                db.SaveChanges();

                if (addedFriendships % 100 == 0)
                {
                    db = new SocialNetworkContext();
                    db.Configuration.AutoDetectChangesEnabled = false;
                    db.Configuration.ValidateOnSaveEnabled = false;
                }
            }

            db.Configuration.AutoDetectChangesEnabled = true;
            db.Configuration.ValidateOnSaveEnabled = true;
        }
        private User GetUser(SocialNetworkContext db, UserXmlModel model, HashSet<string> addedUsersSoFar)
        {
            if (addedUsersSoFar.Contains(model.Username))
            {
                return db.Users.FirstOrDefault(u => u.Username == model.Username);
            }
            else
            {
                addedUsersSoFar.Add(model.Username);

                var user = new User
                {
                    Username = model.Username,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    RegisteredOn = model.RegisteredOn
                };

                foreach (var image in model.Images)
                {
                    user.Images.Add(new Image
                    {
                        ImageUrl = image.ImageUrl,
                        FileExtension = image.FileExtension
                    });
                }

                db.Users.Add(user);
                db.SaveChanges();

                return user;
            }
        }
        private void ProcessPosts(IEnumerable<PostXmlModel> posts)
        {
            this.textWrite.Write("Importing posts");

            var addedPosts = 0;
            var db = new SocialNetworkContext();

            db.Configuration.AutoDetectChangesEnabled = false;
            db.Configuration.ValidateOnSaveEnabled = false;

            foreach (var post in posts)
            {
                var usernames = post.Users.Split(',');
                var users = db.Users
                    .Where(u => usernames.Contains(u.Username))
                    .ToList();

                var newPost = new Post
                {
                    PostedOn = post.PostedOn,
                    Content = post.Content
                };

                foreach (var user in users)
                {
                    newPost.Users.Add(user);
                }

                db.Posts.Add(newPost);

                addedPosts++;

                if (addedPosts % 10 == 0)
                {
                    this.textWrite.Write(".");
                }
                

                if (addedPosts % 100 == 0)
                {
                    db.SaveChanges();
                    db = new SocialNetworkContext();
                    db.Configuration.AutoDetectChangesEnabled = false;
                    db.Configuration.ValidateOnSaveEnabled = false;
                }
            }

            db.SaveChanges();
            db.Configuration.AutoDetectChangesEnabled = true;
            db.Configuration.ValidateOnSaveEnabled = true;
        }
    }
}
