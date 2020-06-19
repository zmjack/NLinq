﻿using Castle.DynamicProxy;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace LinqSharp.EFCore
{
    public static class KvEntityAccessor
    {
        public static KvEntityAccessor<TKvEntity> Create<TKvEntity>(DbSet<TKvEntity> dbSet)
            where TKvEntity : KvEntity, new()
        {
            return new KvEntityAccessor<TKvEntity>(dbSet);
        }
    }

    public class KvEntityAccessor<TKvEntity>
        where TKvEntity : KvEntity, new()
    {
        private readonly DbSet<TKvEntity> DbSet;

        public KvEntityAccessor(DbSet<TKvEntity> dbSet)
        {
            DbSet = dbSet;
        }

        public TKvEntityAgent Get<TKvEntityAgent>(string item)
            where TKvEntityAgent : KvEntityAgent, new()
        {
            var accessor = new KvEntityAccessor<TKvEntityAgent, TKvEntity>(DbSet);
            return accessor.Get(item);
        }
    }

    public class KvEntityAccessor<TKvEntityAgent, TKvEntity>
        where TKvEntityAgent : KvEntityAgent, new()
        where TKvEntity : KvEntity, new()
    {
        public DbSet<TKvEntity> DbSet;

        public KvEntityAccessor(DbSet<TKvEntity> dbSet)
        {
            DbSet = dbSet;
        }

        public void EnsureItem(string item)
        {
            var ensureItems = typeof(TKvEntityAgent).GetProperties()
                .Where(x => x.GetMethod.IsVirtual)
                .Select(x => new EnsureCondition<TKvEntity>
                {
                    [c => c.Item] = item,
                    [c => c.Key] = x.Name,
                }).ToArray();

            DbSet.EnsureMany(ensureItems);
        }

        public TKvEntityAgent Get(string item)
        {
            EnsureItem(item);

            var registry = new TKvEntityAgent();
            var registryProxy = Activator.CreateInstance(typeof(KvEntityAgentProxy<TKvEntityAgent>));

            var proxy = new ProxyGenerator().CreateClassProxyWithTarget(registry, registryProxy as IInterceptor);
            proxy.Load(DbSet, item);
            return proxy;
        }

    }
}
