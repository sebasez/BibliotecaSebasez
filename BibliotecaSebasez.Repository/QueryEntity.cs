using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BibliotecaSebasez.Repository
{
    public class QueryEntity<T>
    {
        public Expression<Func<T, bool>> Where { get; set; } = null;
    }
}
