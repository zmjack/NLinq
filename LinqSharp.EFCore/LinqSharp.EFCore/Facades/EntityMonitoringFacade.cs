﻿using LinqSharp.EFCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqSharp.EFCore.Facades
{
    public class EntityMonitoringFacade : Facade<EntityMonitoringFacade.FacadeState>
    {
        public class FacadeState : IFacadeState
        {
            public bool Updated { get; internal set; }

            internal Dictionary<(Type, EntityState), EntityEntry[]> _entityEntries;

            /// <summary>
            /// Returns entries of the specified states.
            /// <para>The return value is always non-null.</para>
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="originEntityStates"></param>
            /// <returns></returns>
            public IEnumerable<EntityEntry> Entries<T>(params EntityState[] originEntityStates)
            {
                if (!originEntityStates.Any()) throw new ArgumentException("The argument can not be empty.", nameof(originEntityStates));

                var type = typeof(T);
                foreach (var state in originEntityStates)
                {
                    var key = (type, state);
                    if (_entityEntries.ContainsKey(key))
                    {
                        foreach (var entry in _entityEntries[key])
                        {
                            yield return entry;
                        }
                    }
                }
            }
        }

        public EntityMonitoringFacade(DbContext context, bool enableWithoutTransaction) : base(context, enableWithoutTransaction)
        {
        }

        public override void UpdateState()
        {
            State._entityEntries = _context.ChangeTracker.Entries()
                .Where(x => x.State != EntityState.Unchanged && x.State != EntityState.Detached)
                .GroupBy(x => (x.Entity.GetType(), x.State))
                .ToDictionary(g => g.Key, g => g.AsEnumerable().ToArray());
            State.Updated = true;
        }

        public override void End()
        {
            State._entityEntries = null;
            State.Updated = false;
        }

    }
}
