using System;
using System.Collections.Generic;
using System.IO;

namespace Extensions
{
    public static class StreamExtensions
    {
        public static byte[] ReadToEnd(this Stream stream)
        {
            var list = new List<ArraySegment<byte>>();
            var num = 0;
            byte[] array;
            int num2;
            do
            {
                array = new byte[4096];
                num2 = stream.Read(array, 0, array.Length);
                list.Add(new ArraySegment<byte>(array, 0, num2));
                num += num2;
            } while (num2 > 0);
            array = new byte[num];
            var num3 = 0;
            foreach (var current in list)
            {
                Array.Copy(current.Array, 0, array, num3, current.Count);
                num3 += current.Count;
            }
            return array;
        }
    }
}