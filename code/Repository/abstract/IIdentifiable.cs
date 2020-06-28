using System;

namespace Repository
{
    public interface IIdentifiable<T>
    {
        T GetId();
        void SetId(T id);
    }
}