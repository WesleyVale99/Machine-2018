using AsyncRun.Model;
using System;

namespace AsyncRun.protocol
{
    public abstract class ClinitProcess
    {
        public SendPacket send = new SendPacket();   // send.Writes()  QUE FICA NO PACOTES
        public Player player;
        public Loader LOAD;
        public ushort opcode;
        public ClinitProcess(ushort opcode)
        {
            this.opcode = opcode;
            player = Connection.INSTs().player;
            LOAD = Loader.INTs();

        }
        public byte[] NovoPacote(SendPacket receive, SendPacket BeginSend)
        {

            if (send != null)
            {
                try
                {
                    BeginSend.WriteH(opcode); //Opcode
                    BeginSend.WriteH((ushort)GetSession.INST().GetNextSessionSeed());// seed
                    BeginSend.WriteB(send.stream.ToArray()); //Bytes

                    byte[] data = Util.Encrypt(BeginSend.stream.ToArray(), player.Encrypt); // Encrypt

                    receive.WriteH((ushort)(data.Length - 2 | 0x8000));
                    receive.WriteB(data);
                    if (LOAD.LoggerReceive && GetSession.INST().floodAccounts == false)
                        Logger.Send($"{GetType().Name} [{ receive.stream.ToArray().Length}]");
                    return receive.stream.ToArray();
                }
                catch (Exception e)
                {
                    LoggerXML.Log(e.ToString(), "ERROR");
                }
                finally
                {
                    receive.Close();
                    BeginSend.Close();
                    send.Close();
                }
            }
            return null;
     
        }
        public byte[] Process()
        {
            return NovoPacote(new SendPacket(), new SendPacket());
        }
        public abstract byte[] Write();
    }
}