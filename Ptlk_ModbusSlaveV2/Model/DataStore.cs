using System;
using NModbus;

namespace Ptlk_ModbusSlaveV2.Model
{
    public class DataStore : ISlaveDataStore
    {
        public event PointSource<ushort>.ValueWritedHanlder ValueWrited
        {
            add
            {
                m_holdingRegisters.ValueWrited += value;
            }
            remove
            {
                m_holdingRegisters.ValueWrited -= value;
            }
        }

        public DataStore()
        {
            m_holdingRegisters = new PointSource<ushort>(new ushort[65536]);
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