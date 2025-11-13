using E_Commerce.Domain.Contract;
using E_Commerce.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Serves.Specifications
{
    public class BaseSpecifications<TEntity, TKey> : ISpecifications<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        #region includes
        public ICollection<Expression<Func<TEntity, object>>> IncludeExpressions { get; } = [];
        protected void AddInclude(Expression<Func<TEntity, object>> includeExp)
        {
            IncludeExpressions.Add(includeExp);
        }
        #endregion


        #region criteria
        public Expression<Func<TEntity, bool>> Criteria { get; }
        public BaseSpecifications(Expression<Func<TEntity, bool>> criteriaExpression)
        {
            Criteria = criteriaExpression;
        }
        #endregion

        #region sorting
        public Expression<Func<TEntity, object>> OrderBy { get; private set; }
        public Expression<Func<TEntity, object>> OrderByDesc { get; private set; }

        protected void AddOrederBy(Expression<Func<TEntity, object>> orderByExpression)
        { 
            OrderBy = orderByExpression;
        }
        protected void AddOrederByDescending(Expression<Func<TEntity, object>> orderByDescendingExpression)
        { 
            OrderByDesc = orderByDescendingExpression;
        }

        #endregion

        #region Paginations
        public int Take { get; private set; }
        public int Skip { get; private set; }
        public bool IsPaginated { get; private set; }

        protected void ApplyPagination(int PageSize, int PageIndex)
        { 
           IsPaginated = true;
            Take = PageSize;
            Skip = (PageIndex-1)*PageSize;
        
        }
        #endregion

    }
}
