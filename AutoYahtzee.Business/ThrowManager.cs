using AutoYahtzee.Business.DTO;
using AutoYahtzee.Business.ViewModels;
using AutoYahtzee.Data;
using AutoYahtzee.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoYahtzee.Business
{
    public class ThrowManager
    {
        private readonly AutoYahtzeeContext _ctx;
        public ThrowManager(AutoYahtzeeContext ctx)
        {
            _ctx = ctx;
        }

        public YahtzeeListViewModel GetYahtzeeListViewModel()
        {
            List<string> yahtzees = BuildYahtzeesCombinations();

            var dict = _ctx
                .Throws
                .Where(q => yahtzees.Contains(q.Result))
                .Select(q => new ThrowDto
                {
                    Id = q.Id,
                    Result = q.Result,
                    Date = q.DateCreated,
                    ImageUrl = q.ImageUrl,
                    VideoUrl = q.VideoUrl,
                    RollNumber = q.ThrowNumber
                })
                .AsEnumerable()
                .GroupBy(q => q.Result.Length)
                .Select(q => new YahtzeeDto(q.ToList(), q.Key))
                .ToList();

            for (int i = 5; i < 8; i++)
            {
                if(!dict.Any(q => q.NumberOfDices == i))
                {
                    dict.Add(new YahtzeeDto(new List<ThrowDto>(), i));
                }
            }

            dict = dict.OrderBy(q => q.NumberOfDices).ToList();

            return new YahtzeeListViewModel(dict);
        }

        public ThrowListViewModel GetThrowListViewModel(int page)
        {
            var query = _ctx
                .Throws
                .Where(q => !string.IsNullOrEmpty(q.Result))
                .OrderByDescending(q => q.DateCreated);

            var data = PaginatedList<Throw>
                .Create(query, page, Consts.PAGE_SIZE);

            return new ThrowListViewModel(data);
        }

        public ThrowDto GetThrowDetails(Guid id)
        {
            return _ctx
                .Throws
                .Where(q => q.Id == id)
                .Select(q => new ThrowDto
                {
                    Id = q.Id,
                    Result = q.Result,
                    Date = q.DateCreated,
                    ImageUrl = q.ImageUrl,
                    VideoUrl = q.VideoUrl,
                    RollNumber = q.ThrowNumber
                })
                .FirstOrDefault();
        }

        private List<string> BuildYahtzeesCombinations()
        {
            List<string> yahtzees = new List<string>();

            for (int i = 5; i < 8; i++)
            {
                for (int j = 1; j < 7; j++)
                {
                    yahtzees.Add(string.Join(string.Empty, Enumerable.Repeat(j.ToString(), i)));
                }
            }

            return yahtzees;
        }
    }
}
