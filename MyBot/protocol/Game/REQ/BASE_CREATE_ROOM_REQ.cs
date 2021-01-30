using AsyncRun;
using AsyncRun.Enums;
using System.Threading;

namespace AsyncRun.protocol.Game.REQ
{
    public class BASE_CREATE_ROOM_REQ : ReadPacket
    {
        public Base RoomCreate;
        public BASE_CREATE_ROOM_REQ() : base()
        {

        }
        public override void Avoid()
        {
            int error = ReadD();
            if (LOAD.LoggerReceive)
            {
                Logger.Sucess($"{GetType().Name} error = {error}");
            }
            if (error == 0 || error == 1)
            {
                int id = ReadD();
                string Name = ReadS(23);
                LoggerXML.Log("Parabéns você criou uma sala!", "SALAS");
                Logger.Sucess("Parabéns você criou uma sala!");
            }
            else
            {
                Logger.Error("Error ao criar a sala");
            }
        }
    }
}
