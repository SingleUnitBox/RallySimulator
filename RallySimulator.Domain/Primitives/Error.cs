﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallySimulator.Domain.Primitives
{
    public sealed class Error : ValueObject
    {
        public string Code { get; }
        public string Message  { get; }
        public Error(string code, string message)
        {
            Code = code;
            Message = message;  

        }
        internal static Error None => new Error(string.Empty, string.Empty);
        public static implicit operator string(Error error) => error?.Code ?? string.Empty;
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Code;
            yield return Message;
        }
    }
}
