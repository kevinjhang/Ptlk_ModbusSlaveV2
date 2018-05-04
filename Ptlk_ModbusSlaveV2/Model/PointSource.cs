using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using NModbus;

namespace Ptlk_ModbusSlaveV2.Model
{
    public class PointSource<T> : IPointSource<T>
    {
        public PointSource(T[] points, Action<ushort, T[]> writeHook)
        {
            m_points = points;
            m_writeHook = writeHook;
        }

        public T[] ReadPoints(ushort startAddress, ushort numberOfPoints)
        {
            return ReadBuffer(startAddress, numberOfPoints);
        }

        public void WritePoints(ushort startAddress, T[] points)
        {
            WriteBuffer(startAddress, points);
            m_writeHook.Invoke(startAddress, points);
        }

        #region Private
        private T[] ReadBuffer(ushort startAddress, ushort numberOfPoints)
        {
            T[] result = new T[numberOfPoints];
            Array.Copy(m_points, startAddress, result, 0, numberOfPoints);
            return result;
        }

        private void WriteBuffer(ushort startAddress, T[] points)
        {
            Array.Copy(points, 0, m_points, startAddress, points.Length);
        }

        private T[] m_points;
        private Action<ushort, T[]> m_writeHook;
        #endregion
    }
}