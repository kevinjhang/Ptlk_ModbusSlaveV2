using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using NModbus;

namespace Ptlk_ModbusSlaveV2.Model
{
    public class PointSource<T> : IPointSource<T>
    {
        public delegate void ValueWritedHanlder(ushort start, T[] values);
        public event ValueWritedHanlder ValueWrited;

        public PointSource(T[] points)
        {
            m_points = points;
        }

        public T[] ReadPoints(ushort startAddress, ushort numberOfPoints)
        {
            return ReadBuffer(startAddress, numberOfPoints);
        }

        public void WritePoints(ushort startAddress, T[] points)
        {
            WriteBuffer(startAddress, points);
            ValueWrited?.Invoke(startAddress, points);
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
        #endregion
    }
}