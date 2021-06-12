using Microsoft.EntityFrameworkCore;
using MMT.Test.Order.Entities.Interfaces;
using MMT.Test.Order.Entities.Model;
using System.Linq;

namespace MMT.Test.Order.Entities.Specifications
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec)
        {
            var query = inputQuery;

            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }

            if (spec.OrderBy != null)
            {
                query = query.OrderBy(spec.OrderBy);
            }

            if (spec.OrderByDescending != null)
            {
                query = query.OrderByDescending(spec.OrderByDescending);
            }

            if (spec.Take > 0)
            {
                query = query.Take(spec.Take);
            }

            if (spec.IsPagingEnabled)
            {
                query = query.Skip(spec.Skip).Take(spec.Take);
            }            

            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));

            // Include any string-based include statements
            query = spec.IncludeStrings.Aggregate(query,
                                    (current, include) => current.Include(include));

            return query;
        }
    }
}
