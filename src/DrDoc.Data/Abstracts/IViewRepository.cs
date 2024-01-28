using DrDoc.Common.Entities.Abstracts;
using DrDoc.Data.Concretes.Context;
using Microsoft.EntityFrameworkCore;

namespace DrDoc.Data.Abstracts;

public interface IViewRepository<TView> where TView : class, ITableView
{
    AppDbContext DbContext { get; init; }
    DbSet<TView> Entities { get; }
    IQueryable<TView> View { get; }
    IQueryable<TView> ViewNoTracking { get; }
}