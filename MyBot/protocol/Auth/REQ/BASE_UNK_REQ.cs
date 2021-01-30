using System;

namespace AsyncRun.protocol.Auth.REQ
{
    public class BASE_UNK_REQ : ReadPacket
    {
        public override void Avoid()
        {

            int i = ReadD();
            Console.WriteLine("ONGAME" + i);
        }
    }
}
