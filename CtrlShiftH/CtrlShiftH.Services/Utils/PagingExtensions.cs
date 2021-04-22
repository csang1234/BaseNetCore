using CtrlShiftH.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CtrlShiftH.Services.Utils
{
    public static class PagingExtensions
    {
        /// <summary>
        /// Count page
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static int PageCount<T>(this IQueryable<T> data, int pageSize)
        {
            return (int)Math.Ceiling(data.Count() / (double)pageSize);
        }

        /// <summary>
        /// Get data of page
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static IEnumerable<T> PageData<T>(this IQueryable<T> data, int pageIndex, int pageSize) where T : class
        {
            return data.Skip(pageIndex * pageSize).Take(pageSize).AsNoTracking().AsEnumerable();
        }

        /// <summary>
        /// Base filter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static IQueryable<T> Filter<T>(this DbSet<T> data) where T : BaseEntity
        {
            return data.Where(_ => _.IsDeleted == false);
        }
    }
}