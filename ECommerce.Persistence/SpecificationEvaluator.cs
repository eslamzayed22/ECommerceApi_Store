using ECommerce.Domin.Contracts;
using ECommerce.Domin.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Persistence
{
    public class SpecificationEvaluator
    {
        public static IQueryable<TEntity> CreateQuery<TEntity, Tkey> (IQueryable<TEntity> EntryPoint, 
                                                                      ISpecification<TEntity, Tkey> specification) 
                                                                      where TEntity : BaseEntity<Tkey>
        {
            var query = EntryPoint;
            if (specification is not null)
            {
                //Where
                if (specification.Criteria is not null)
                {
                    query = query.Where(specification.Criteria);
                }

                //Include
                if (specification.IncludeExpression is not null && specification.IncludeExpression.Any())
                {
                    query = specification.IncludeExpression.Aggregate(query, (current, includeExp) => current.Include(includeExp));
                }           
            }
            return query;
        }
    }
}
