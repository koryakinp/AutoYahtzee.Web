using AutoYahtzee.Business.DTO;
using AutoYahtzee.Business.ViewModels;
using AutoYahtzee.Data;
using AutoYahtzee.Data.Models;
using Microsoft.EntityFrameworkCore;
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

        public AboutViewModel GetAboutViewModel()
        {
            List<YahtzeeDto> dict = _ctx
                .Set<YahtzeeResult>()
                .FromSqlRaw("EXEC [dbo].[GetYahtzees]")
                .ToList()
                .GroupBy(q => q.ThrowId)
                .GroupBy(q => q.Count())
                .Select(q => new YahtzeeDto(q.Select(w => new ThrowDto
                {
                    Result = string.Join("", w.Select(e => e.Prediction.ToString())),
                    Date = w.First().DateCreated,
                    Id = w.First().ThrowId
                }).ToList(), q.Key))
                .ToList();

            return new AboutViewModel
            {
                NumberOfAttempts = _ctx.Throws.Count(),
                NumberOfYahtzees = dict.Select(w => w.Throws.Count).Sum(),
                YahtzeeSummary = dict
                    .Select(w => new YahtzeeSummary
                    {
                        NumberOfDices = w.NumberOfDices,
                        NumberOfYahtzee = w.Throws.Count
                    })
                    .OrderBy(w => w.NumberOfDices)
                    .ToList()
            };
        }

        public YahtzeeListViewModel GetYahtzeeListViewModel()
        {
            List<YahtzeeDto> dict = _ctx
                .Set<YahtzeeResult>()
                .FromSqlRaw("EXEC [dbo].[GetYahtzees]")
                .ToList()
                .GroupBy(q => q.ThrowId)
                .GroupBy(q => q.Count())
                .Select(q => new YahtzeeDto(q.Select(w => new ThrowDto
                {
                    Result = string.Join("", w.Select(e => e.Prediction.ToString())),
                    Date = w.First().DateCreated,
                    Id = w.First().ThrowId
                }).ToList(), q.Key))
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
            DateTime d = DateTime.UtcNow.AddMinutes(-15);

            var query = _ctx
                .Throws
                .Where(q => q.DateCreated < d)
                .OrderByDescending(q => q.DateCreated);

            var data = PaginatedList<Throws>
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
                    Result = string.Join("", q.Predictions.OrderBy(w => w.Prediction).Select(e => e.Prediction.ToString())),
                    Id = q.Id,
                    Date = q.DateCreated,
                    RollNumber = q.ThrowNumber,
                    Predictions = q.Predictions.Select(w => new PredictionDto
                    {
                        Confidence = w.Confidence,
                        Id = w.Id,
                        Prediction = w.Prediction
                    })
                    .OrderBy(w => w.Prediction)
                    .ToList()
                })
                .FirstOrDefault();
        }
    }
}
