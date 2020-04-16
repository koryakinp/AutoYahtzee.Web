using AutoYahtzee.Business.DTO;
using AutoYahtzee.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace AutoYahtzee.Business.ViewModels
{
    public class ThrowListViewModel : IPageble
    {
        public readonly List<ThrowDto> Throws;

        public int TotalPages { get; private set; }
        public int CurPage { get; private set; }
        public bool HasNext { get; private set; }
        public bool HasPrev { get; private set; }

        public ThrowListViewModel(PaginatedList<Throw> throws)
        {
            Throws = throws
                .Select(q => new ThrowDto
                {
                    Id = q.Id,
                    Result = q.Result,
                    Date = q.DateCreated,
                    ImageUrl = q.ImageUrl,
                    VideoUrl = q.VideoUrl,
                    RollNumber = q.ThrowNumber
                })
                .ToList();

            TotalPages = throws.TotalPages;
            HasNext = throws.HasNextPage;
            HasPrev = throws.HasPreviousPage;
            CurPage = throws.PageIndex;
        }
    }

    public interface IPageble
    {
        public int TotalPages { get; }
        public int CurPage { get; }
        public bool HasNext { get; }
        public bool HasPrev { get; }
    }
}
