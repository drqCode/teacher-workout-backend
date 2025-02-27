using System.Collections.Generic;
using System.Linq;
using GraphQL.Types.Relay.DataObjects;
using TeacherWorkout.Api.Models;

namespace TeacherWorkout.Api.GraphQL.Utils
{
    public static class ConnectionUtils
    {
        public static Connection<TSource> ToConnection<TSource>(this IEnumerable<TSource> items) 
            where TSource: IIdentifiable
        {
            var edges = items.Select(e => new Edge<TSource>
            {
                Cursor = e.Id,
                Node = e
            }).ToList();

            return new Connection<TSource>
            {
                Edges = edges,
                PageInfo = new PageInfo
                {
                    StartCursor = edges.FirstOrDefault()?.Cursor,
                    EndCursor = edges.LastOrDefault()?.Cursor,
                    HasPreviousPage = false,
                    HasNextPage = false,
                }
            };
        }
    }
}