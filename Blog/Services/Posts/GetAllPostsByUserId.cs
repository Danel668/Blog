using Blog.Data;
using Blog.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Services.Posts
{
    [Service]
    public class GetAllPostsByUserId
    {
        private IPostManager _postManager;

        public GetAllPostsByUserId(IPostManager postManager)
        {
            _postManager = postManager;
        }

        public IEnumerable<GetAllPostsByUserIdViewModel> Do(string id)
        {
            return _postManager.GetAllPostsByUserId(id).Select(x => new GetAllPostsByUserIdViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Image = x.Image,
                Body = x.Body,
                Description = x.Description,
                Category = x.Category,
                Created = x.Created,
                CountOfComments = x.CountOfLike,
                CountOfLike = x.CountOfLike,
                InFavorites = x.InFavorites,
            });
        }

        public class GetAllPostsByUserIdViewModel
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Image { get; set; }
            public string Body { get; set; }
            public string Description { get; set; }
            public string Category { get; set; }
            public DateTime Created { get; set; }
            public int CountOfLike { get; set; }
            public bool InFavorites { get; set; }
            public int CountOfComments { get; set; }
        }
    }
}
