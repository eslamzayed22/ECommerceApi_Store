using ECommerce.Domin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domin.Contracts
{
    public interface ISpecification<TEntity, Tkey> where TEntity : BaseEntity<Tkey>
    {
        //Include
        public ICollection<Expression<Func<TEntity, object>>> IncludeExpression { get; }

        //Where
        public Expression<Func<TEntity, bool>>? Criteria { get; }
    }
}
