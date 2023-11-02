using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RallySimulator.Domain.Core.Errors.DomainErrors;

namespace RallySimulator.Domain.Primitives.Result
{
    public static class ResultExtensions
    {
        public static Result<T> Ensure<T>(this Result<T> result, Func<T, bool> predicate, Error error)
        {
            if (result.IsFailure)
            {
                return result;
            }
            return result.IsSuccess && predicate(result.Value) ? result : Result.Failure<T>(error);
        }
        public static Result<TOut> Map<TIn, TOut>(this Result<TIn> result, Func<TIn, TOut> func)
            => result.IsSuccess
            ? func(result.Value)
            : Result.Failure<TOut>(result.Error);
    }
}