using ECommerce.Domin.Contracts;
using ECommerce.Domin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services.Specifications
{
    public class BaseSpecification<TEntity, Tkey> : ISpecification<TEntity, Tkey> where TEntity : BaseEntity<Tkey>
    {
        #region Include
        public ICollection<Expression<Func<TEntity, object>>> IncludeExpression { get; } = [];

        protected void AddInclude(Expression<Func<TEntity, object>> includeExp)
        {
            IncludeExpression.Add(includeExp);
        }
        #endregion

        #region Where
        public Expression<Func<TEntity, bool>>? Criteria { get; }

        public BaseSpecification(Expression<Func<TEntity, bool>> CriteriaExp)
        {
            Criteria = CriteriaExp;
        }
        #endregion
    }
}
