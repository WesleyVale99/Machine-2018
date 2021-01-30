using System;
using System.Linq;

namespace AsyncRun.protocol.Auth.ACK
{
    public class BASE_GET_LOGIN_ACK : ClinitProcess
    {
        public BASE_GET_LOGIN_ACK() : base(2672) //2672
        {
        }
        public override byte[] Write()
        {
            send.WriteC(LOAD.CLIENTE[0]);
            send.WriteH(LOAD.CLIENTE[1]);
            send.WriteH(LOAD.CLIENTE[2]);
            send.WriteC((byte)LOAD.region);
            send.WriteC((byte)LOAD.USER.Length);
            send.WriteC((byte)LOAD.PASS.Length);
            send.WriteS(LOAD.USER, LOAD.USER.Length);
            send.WriteS(LOAD.PASS, LOAD.PASS.Length);
            send.WriteB(LOAD.meuMac.Split(':').Select(x => Convert.ToByte(x, 16)).ToArray());
            send.WriteH(0);//0
            send.WriteC((byte)LOAD.CONNECTION);
            send.WriteB(player.ADDR);           //1290204106558050461 BLOODI
            send.WriteQ(LOAD.KEY);    //2019279475243070914 ELITE
            send.WriteS(LOAD.FILELISTDAT, 32);
            send.WriteD(0);// valor maximo byte 
            send.WriteS(LOAD.HARDWAREID, 32);
            send.WriteC(0);

            return Process();
        }
    }
}