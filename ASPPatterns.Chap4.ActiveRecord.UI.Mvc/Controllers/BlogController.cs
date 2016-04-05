using ASPPatterns.Chap4.ActiveRecord.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPPatterns.Chap4.ActiveRecord.UI.Mvc.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult Index()
        {
            Post[] posts = Post.FindAll();

            if(posts.Count() > 0)
            {
                ViewData["AllPosts"] = posts;
                ViewData["LastestPost"] = Post.FindLastestPost();
                return View();
            }
            else
            {
                return Create();
            }

            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CreateComment(string id, FormCollection collection)
        {
            int postId = 0;
            int.TryParse(id, out postId);
            Post post = Post.Find(postId);

            var comment = new Comment
            {
                Post = post,
                Author = Request.Form["Author"],
                DateAdded = DateTime.Now,
                Text = Request.Form["Comment"]
            };

            comment.Save();

            return Detail(post.Id.ToString());
        }

        // GET: /Blog/Detail/1
        public ActionResult Detail(string id)
        {
            ViewData["AllPosts"] = Post.FindAll();
            var postId = 0;
            int.TryParse(id, out postId);
            ViewData["LatestPost"] = Post.Find(postId);
            return View("Index");
        }

        public ActionResult Create()
        {
            return View("AddPost");
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(FormCollection collection)
        {
            var post = new Post
            {
                DateAdded = DateTime.Now,
                Subject = Request.Form["Subject"],
                Text = Request.Form["Content"]
            };
            post.Save();

            return Detail(post.Id.ToString());
        }
    }
}