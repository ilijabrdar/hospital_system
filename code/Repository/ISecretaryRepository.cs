/***********************************************************************
 * Module:  ISecretaryRepository.cs
 * Author:  david
 * Purpose: Definition of the Interface Repository.ISecretaryRepository
 ***********************************************************************/

using Model.Users;
using System;

namespace Repository
{
   public interface ISecretaryRepository
   {
      Secretary GetSecretaryByUsername(String username);
   }
}