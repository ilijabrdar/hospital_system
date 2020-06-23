
using System;
using System.ComponentModel;

namespace Model.Director
{
   public enum RenovationStatus
   {
        [Description("U toku")]
        Traje,
        [Description("Zavrseno")]
        Zavrseno,
        [Description("Zakazano")]
        Zakazano,
        [Description("Otkazano")]
        Otkazano,
   
   }
}