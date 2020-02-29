using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Sitecore.Buckets.FieldTypes;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq;
using Sitecore.ContentSearch.Linq.Utilities;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Data.Items;

namespace Feature.Attendees.Subscribers
{
    public class MyEvents : IDataSource
    {
        public Item[] ListQuery(Item item)
        {
            if (!Sitecore.Context.User.IsAuthenticated)
            {
                return Array.Empty<Item>();
            }

            var user = Sitecore.Context.User.LocalName;
            var predicate = PredicateBuilder.True<SearchResultItem>();
            predicate = predicate.And(p => p["Subscribers"].Contains(user));
            predicate = predicate.And(x => x.TemplateName == "Event");
            return GetItems(predicate).ToArray();
        }

        public IEnumerable<Item> GetItems(Expression<Func<SearchResultItem, bool>> predicate)
        {
            var results = new List<Item>();

            var result = GetResultItems(predicate, "sitecore_sxa_" + Sitecore.Context.Database.Name + "_index");
            foreach (var hit in result)
            {
                var resultItem = Sitecore.Context.Database.GetItem(hit.ItemId);
                if (resultItem != null)
                {
                    results.Add(resultItem);
                }
            }

            return results;
        }

        public virtual IEnumerable<T> GetResultItems<T>(Expression<Func<T, bool>> predicate, string index) where T : SearchResultItem
        {
            var results = GetResults(predicate, index);
            foreach (var hit in results.Hits)
            {
                yield return hit.Document;
            }
        }

        public virtual SearchResults<T> GetResults<T>(Expression<Func<T, bool>> predicate, string index) where T : SearchResultItem
        {
            using (var context = ContentSearchManager.GetIndex(index).CreateSearchContext())
            {
                var query = context.GetQueryable<T>().Where(predicate);
                return query.GetResults();
            }
        }
    }
}