﻿// Copyright 2020 zmjack
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqSharp;

public static partial class IEnumerableExtensions
{
    public static IEnumerable<TResult> LeftJoin<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
    {
        return from left in outer
               join _in in inner on outerKeySelector(left) equals innerKeySelector(_in) into _in
               from right in _in.DefaultIfEmpty()
               select resultSelector(left, right);
    }

    public static IEnumerable<TResult> RightJoin<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
    {
        return from right in inner
               join _out in outer on innerKeySelector(right) equals outerKeySelector(_out) into _out
               from left in _out.DefaultIfEmpty()
               select resultSelector(left, right);
    }

    public static IEnumerable<TResult> FullJoin<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
    {
        var left = outer.LeftJoin(inner, outerKeySelector, innerKeySelector, resultSelector);
        var right = outer.RightJoin(inner, outerKeySelector, innerKeySelector, resultSelector);
        return left.Union(right);
    }
}
