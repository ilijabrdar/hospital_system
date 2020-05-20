/***********************************************************************
 * Module:  IDirectorRepository.cs
 * Author:  david
 * Purpose: Definition of the Interface Repository.IDirectorRepository
 ***********************************************************************/

using Model.Users;
using System;

namespace Repository
{
   public interface IDirectorRepository : IRepository
   {
      Director GetDirectorByUsername(String username);
   }
}