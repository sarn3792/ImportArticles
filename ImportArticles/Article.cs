using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportArticles
{
    public class Article
    {
        public string ID { get; set; }
        public string Description { get; set; }

        public Article(string ID, string Description)
        {
            this.ID = ID;
            this.Description = Description;
        }
    }
}
