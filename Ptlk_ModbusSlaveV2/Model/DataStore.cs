using System;
using NModbus;

namespace Ptlk_ModbusSlaveV2.Model
{
    public class DataStore : ISlaveDataStore
    {
        public DataStore(Action<ushort, ushort[]> writeHook)
        {
            m_holdingRegisters = new PointSource<ushort>(new ushort[65536], writeHook);
        }

        public IPointSource<bool> CoilDiscretes => throw new NotImplementedException();
        public IPointSource<bool> CoilInputs => throw new NotImplementedException();
        public IPointSource<ushort> HoldingRegisters => m_holdingRegisters;
        public IPointSource<ushort> InputRegisters => throw new NotImplementedException();

        #region Private
        private PointSource<ushort> m_holdingRegisters;
        #endregion
    }
}