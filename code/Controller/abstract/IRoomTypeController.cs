using Controller;
using Model.Director;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Controller
{
    public interface IRoomTypeController : IController<RoomType,long>
    {
        Room CheckRoomTypeUnique(RoomType roomType);
    }
}
