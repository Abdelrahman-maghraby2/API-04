using E_Commerce.Domain.Contract;
using E_Commerce.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Persistence
{
    public static class SpecificationEvaluater
    {
        public static IQueryable<TEntity> CreateQuery<TEntity, TKey>(IQueryable<TEntity> EntryPoint,
            ISpecifications<TEntity, TKey> specifications) where TEntity : BaseEntity<TKey>
        {
            var Query = EntryPoint;
            if (specifications is not null)
            {
                if (specifications.Criteria is not null)
                { 
                    Query = Query.Where(specifications.Criteria);
                }

                if (specifications.IncludeExpressions is not null && specifications.IncludeExpressions.Any())
                {
                    foreach (var includeExp in specifications.IncludeExpressions)
                    {
                        Query = Query.Include(includeExp);
                    }
                }

                if (specifications.OrderBy is not null)
                {
                    Query=Query.OrderBy(specifications.OrderBy);
                }
                if (specifications.OrderByDesc is not null)
                {
                    Query=Query.OrderByDescending(specifications.OrderByDesc);
                }

                if (specifications.IsPaginated)
                { 
                    Query=Query.Skip(specifications.Skip).Take(specifications.Take); 
                
                }
            }
            return Query;

        }
    }
}
