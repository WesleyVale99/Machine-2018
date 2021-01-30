
using AsyncRun.Enums;
using AsyncRun.Model;

namespace AsyncRun.protocol.Auth.REQ
{
    public class BASE_INVENTORY_REQ : ReadPacket
    {
        public override void Avoid()
        {
            int countchara = ReadD();
            ReadQ();
            int idchara = ReadD();
            Equip_inventory equipc = (Equip_inventory)ReadC();
            ReadD();
            ///////////////////////////////////
            int countweapon = ReadD();
            ReadQ();
            int idweapon = ReadD();
            Equip_inventory equipw = (Equip_inventory)ReadC();
            ReadD();
            ///////////////////////////////////
            int countcupon = ReadD();
            ReadQ();
            int idcupon = ReadD();
            Equip_inventory equipcupon = (Equip_inventory)ReadC();
            ReadD();
            ///////////////////////////////////
            ReadD();
            if (LOAD.LoggerReceive && GetSession.INST().floodAccounts == false)
            {
                Logger.Warnnig($"countchara: {countchara}, id:{idchara}, equip: {equipc.ToString()}");
                Logger.Warnnig($"countcupon: {countweapon},  id:{idweapon}, equip: {equipw.ToString()}");
                Logger.Warnnig($"countweapon: {countcupon}, id:{idcupon}, equip: {equipcupon.ToString()}");
            }

        }
    }
}
