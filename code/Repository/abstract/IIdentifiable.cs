/***********************************************************************
 * Module:  IRepository.cs
 * Author:  david
 * Purpose: Definition of the Interface Repository.IRepository
 ***********************************************************************/

using System;

namespace Repository
{
    public interface IIdentifiable<T>
    {
        T GetId();
        void SetId(T id);
    }
}