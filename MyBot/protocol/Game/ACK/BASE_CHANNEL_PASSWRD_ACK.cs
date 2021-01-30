using System;

namespace AsyncRun.protocol.Game.REQ
{
    public class BASE_CHANNEL_PASSWRD_ACK : ClinitProcess
    {
        public BASE_CHANNEL_PASSWRD_ACK() : base(2644)
        {
        }
        public override byte[] Write()
        {
            Logger.Error("Digite a senha...");
            string pass = Console.ReadLine();
            send.WriteC((byte)pass.Length);
            send.WriteS(pass, pass.Length);
            return Process();
        }
    }
}
