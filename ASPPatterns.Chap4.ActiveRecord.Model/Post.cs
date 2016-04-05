using Castle.ActiveRecord;
using Castle.ActiveRecord.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPPatterns.Chap4.ActiveRecord.Model
{
    [ActiveRecord("Posts")]
    public class Post : ActiveRecordBase<Post>
    {
        [PrimaryKey]
        public int Id { get; set; }

        [Property]
        public string Subject { get; set; }

        [Property]
        public string Text { get; set; }
        public string ShortText
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Text) && this.Text.Length > 20)
                    return Text.Substring(0, 20) + "...";
                return Text;
            }
        }

        public IList<Comment> Comments { get; set; }

        public DateTime DateAdded { get; set; }

        public static Post FindLastestPost()
        {
            var q = new SimpleQuery<Post>(@"from Post p order by p.DateAdded desc");
            return q.Execute()[0];
        }
    }
}
