using System;
using Telegram.Td.Api;

namespace PTClient
{
    public class Filter<TUpdate> : IFilter, ITransportUpdate
    {
        public delegate void UpdateHandler(TUpdate update);
        private readonly Predicate<TUpdate> _predicate;
        private UpdateHandler _onUpdate;
        private bool _onlyType;
        private bool _isBase;
        private bool _isUpdate;
        private bool _disposable;
        bool IFilter.Disposable { get => _disposable; set => _disposable = value; }
        bool ITransportUpdate.OnlyTypeFiltering => _onlyType;
        bool ITransportUpdate.IsBase => _isBase;

        bool ITransportUpdate.IsUpdate => _isUpdate;

        public Filter(UpdateHandler updateHandler, Predicate<TUpdate> predicate)
        {
            _onUpdate = updateHandler ?? throw new NullReferenceException("UpdateHandler cannot be null");
            _predicate = predicate ?? throw new NullReferenceException("Predicate cannot be null");
            if(typeof(TUpdate) == typeof(Update))
            {
                _isUpdate = true;
            }
            else if(typeof(TUpdate) == typeof(BaseObject))
            {
                _isBase = true;
            }
        }
        public Filter(UpdateHandler updateHandler)
        {
            _onUpdate = updateHandler ?? throw new NullReferenceException("UpdateHandler cannot be null");
            _onlyType = true;
            if (typeof(TUpdate) == typeof(Update))
            {
                _isUpdate = true;
            }
            else if (typeof(TUpdate) == typeof(BaseObject))
            {
                _isBase = true;
            }
        }
        bool IFilter.IsMatch(BaseObject update)
        {
            if (typeof(TUpdate).IsInterface)
            {
                if (!typeof(TUpdate).IsAssignableFrom(update.GetType()))
                {
                    return false;
                }
            }
            else
            {
                if (typeof(TUpdate) != update.GetType())
                {
                    return false;
                }
            }
            if (_predicate != null)
            {
                return _predicate((TUpdate)update);
            }
            else
            {
                return true;
            }
        }
        void ITransportUpdate.Transport(BaseObject update)
        {
            _onUpdate?.Invoke((TUpdate)update);
            if (_disposable)
            {
                Filtering.Filters.Remove(this);
            }
        }

    }
    public class Filter<TUpdate, TResult> : IFilter, ITransportToken
    {
        public delegate void UpdateHandler(TResult update);
        private UpdateHandler _onUpdate;
        private TResult _result;
        private bool _disposable;
        private readonly RefToken.RefToken _refToken;
        private readonly Predicate<TUpdate> _predicate;
        bool IFilter.Disposable { get => _disposable; set => _disposable = value; }

        public Filter(UpdateHandler updateHandler, Predicate<TUpdate> predicate, string objectPath)
        {
            _refToken = string.IsNullOrEmpty(objectPath) ? throw new NullReferenceException("ObjectPath cannot be empty") : new RefToken.RefToken(objectPath);
            _onUpdate = updateHandler ?? throw new NullReferenceException("UpdateHandler cannot be null");
            _predicate = predicate ?? throw new NullReferenceException("Predicate cannot be null");
        }
        public Filter(UpdateHandler updateHandler, string objectPath)
        {
            _onUpdate = updateHandler ?? throw new NullReferenceException("UpdateHandler cannot be null");
            _refToken = string.IsNullOrEmpty(objectPath) ? throw new NullReferenceException("ObjectPath cannot be empty") : new RefToken.RefToken(objectPath);
        }

        void ITransportToken.Transport()
        {
            _onUpdate?.Invoke(_result);
            if (_disposable)
            {
                Filtering.Filters.Remove(this);
            }
        }

        bool IFilter.IsMatch(BaseObject update)
        {
            if (typeof(TUpdate) == update.GetType())
            {
                if (_predicate != null)
                {
                    if (_predicate((TUpdate)update))
                    {
                        return _refToken.Select(update, out _result);
                    }
                    return false;
                }
                else
                {
                    return _refToken.Select(update, out _result);
                }
            }
            else
            {
                return false;
            }
        }

    }
}
