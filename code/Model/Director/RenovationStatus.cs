/***********************************************************************
 * Module:  RenovationStatus.cs
 * Author:  david
 * Purpose: Definition of the Class Director.RenovationStatus
 ***********************************************************************/

using System;
using System.ComponentModel;

namespace Model.Director
{
   public enum RenovationStatus
   {
        [Description("U toku")]
        InProgress,
        [Description("Zavrseno")]
        Completed,
        [Description("Zakazano")]
        Scheduled,
        [Description("Otkazano")]
        Cancelled,
   
   }
}