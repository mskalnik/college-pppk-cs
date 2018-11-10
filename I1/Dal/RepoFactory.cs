using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace I1.Models
{
    public static class RepoFactory
    {
        public static IRepo GetRepo()
        {
            return new Repo();
        }
    }
}