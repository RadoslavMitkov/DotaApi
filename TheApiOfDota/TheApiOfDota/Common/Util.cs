using System;
using System.Linq;

namespace TheApiOfDota.Common
{
    public static class Util
    {
        public static int[]FindNums(int sum)
        {
            var random = new Random();
            var myArr = new int[5];

            while (myArr.Sum() != sum)
            {
                myArr[0] = random.Next(0, 28);
                myArr[1] = random.Next(0, 28);
                myArr[2] = random.Next(0, 28);
                myArr[3] = random.Next(0, 28);
                myArr[4] = random.Next(0, 28);
            }

            return myArr;
        }
    }
}
