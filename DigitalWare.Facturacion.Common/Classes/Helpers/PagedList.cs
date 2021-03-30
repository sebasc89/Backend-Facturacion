using DigitalWare.Facturacion.Common.Classes.DTO.Request;
using DigitalWare.Facturacion.Common.Classes.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DigitalWare.Facturacion.Common.Classes.Helpers
{
    public class PagedList<T>
    {
        public int TotalItems { get; set; }
        public int PageNumber { get; }
        public int PageSize { get; }
        public List<T> List { get; }
        public int TotalPages =>
              (int)Math.Ceiling(TotalItems / (double)PageSize);

        public PagedList(IQueryable<T> source, int pageNumber, int pageSize)
        {
            TotalItems = source.Count();
            PageNumber = pageNumber;
            PageSize = pageSize;
            List = source
                        .Skip(pageSize * (pageNumber - 1))
                        .Take(pageSize)
                        .ToList();
        }

        public PagedList(IQueryable<T> source, PagingParams pagingParams)
        {
            TotalItems = source.Count();
            PageNumber = pagingParams.PageNumber;
            PageSize = pagingParams.PageSize;
            List = source
                .ApplyOrderBy(pagingParams.SortProperty, pagingParams.SortType)
                .Skip(pagingParams.PageSize * (pagingParams.PageNumber - 1))
                .Take(pagingParams.PageSize)
                .ToList();
        }

        public PagedList(IQueryable<T> source, Expression<Func<T, bool>> deleg, PagingParams pagingParams)
        {
            if (deleg != null)
            {
                source = source.Where(deleg);
            }

            if (pagingParams.SortProperty != null)
            {
                source = source.ApplyOrderBy(pagingParams.SortProperty, pagingParams.SortType);
            }

            TotalItems = source.Count();
            PageNumber = pagingParams.PageNumber;
            PageSize = pagingParams.PageSize;
            List = source
                .Skip(pagingParams.PageSize * (pagingParams.PageNumber - 1))
                .Take(pagingParams.PageSize)
                .ToList();
        }

        public PagedList(List<T> source, int pageNumber, int pageSize, int totalItems)
        {
            TotalItems = totalItems;
            PageNumber = pageNumber;
            PageSize = pageSize;
            List = source.ToList();
        }
    }
}
