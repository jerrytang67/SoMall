using System;
using System.Threading;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.DependencyInjection;

namespace TT.Abp.Shops
{
    public interface ICurrentShop
    {
        bool IsAvailable { get; }

        [CanBeNull] Guid? Id { get; }

        [CanBeNull] string Name { get; }

        IDisposable Change(Guid? id, string name = null);
    }

    public class CurrentShop : ICurrentShop, ITransientDependency
    {
        private readonly ICurrentShopAccessor _currentShopAccessor;

        public CurrentShop(ICurrentShopAccessor currentShopAccessor)
        {
            _currentShopAccessor = currentShopAccessor;
        }

        public virtual bool IsAvailable => Id.HasValue;
        public virtual Guid? Id => _currentShopAccessor.Current?.ShopId;

        public string Name => _currentShopAccessor.Current?.Name;

        public IDisposable Change(Guid? id, string name = null)
        {
            return SetCurrent(id, name);
        }

        private IDisposable SetCurrent(Guid? shopId, string name = null)
        {
            var parentScope = _currentShopAccessor.Current;
            _currentShopAccessor.Current = new BasicShopInfo(shopId, name);
            return new DisposeAction(() => { _currentShopAccessor.Current = parentScope; });
        }
    }

    public interface ICurrentShopAccessor
    {
        BasicShopInfo Current { get; set; }
    }

    public class AsyncLocalCurrentShopAccessor : ICurrentShopAccessor, ISingletonDependency
    {
        private readonly AsyncLocal<BasicShopInfo> _currentScope;

        public AsyncLocalCurrentShopAccessor()
        {
            _currentScope = new AsyncLocal<BasicShopInfo>();
        }

        public BasicShopInfo Current
        {
            get => _currentScope.Value;
            set => _currentScope.Value = value;
        }
    }


    public class BasicShopInfo
    {
        public BasicShopInfo(Guid? shopId, string name)
        {
            ShopId = shopId;
            Name = name;
        }

        public Guid? ShopId { get; set; }
        public string Name { get; set; }
    }
}