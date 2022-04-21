namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {

            Random random = new Random();
            int[] physicalArrBF = new int[64];
            int[] physicalArrWF = new int[64];

            for (int i = 0; i < physicalArrBF.Length; i++)
            {
                physicalArrBF[i] = random.Next(1, 9);
            }

            for (int i = 0; i < physicalArrWF.Length; i++)
            {
                physicalArrWF[i] = random.Next(1, 9);
            }


            int searchTimeBF = 0;
            int avgMemoryUtilizationBF = 0;
            int totalMemoryBF = 0;

            for (int i = 0; i < 50; i++)
            {
                //simulation for best fit
                release(physicalArrBF);

                allocateBF(physicalArrBF);
                if (allocateBF(physicalArrBF) == 1) searchTimeBF++;
            }

            for (int i = 0; i < physicalArrBF.Length; i++)
            {
                totalMemoryBF += physicalArrBF[i];
            }

            avgMemoryUtilizationBF = Math.Abs(totalMemoryBF / physicalArrBF.Length);

            Console.WriteLine("AVG Memory Utilization for Best Fit: " + avgMemoryUtilizationBF);
            Console.WriteLine("ACTUAL SEARCH TIME BEST FIT: " + searchTimeBF);


            int searchTimeWF = 0;
            int avgMemoryUtilizationWF = 0;
            int totalMemoryWF = 0;

            for (int i = 0; i < 50; i++)
            {
                //simulation for worst fit
                release(physicalArrWF);

                allocateBF(physicalArrWF);
                if (allocateBF(physicalArrWF) == 1) searchTimeWF++;
            }

            for (int i = 0; i < physicalArrWF.Length; i++)
            {
                totalMemoryWF += physicalArrWF[i];
            }

            avgMemoryUtilizationWF = Math.Abs(totalMemoryWF / physicalArrWF.Length);

            Console.WriteLine("AVG Memory Utilization for Worst Fit: " + avgMemoryUtilizationWF);
            Console.WriteLine("ACTUAL SEARCH TIME WORST FIT: " + searchTimeWF);


        }


        static int release(int[] physicalArr)
        {
            Random random = new Random();

            while (true)
            {
                int randomNum = random.Next(0, physicalArr.Length);


                if (physicalArr[randomNum] > 1)
                {
                    physicalArr[randomNum] = -physicalArr[randomNum];
                    // Console.WriteLine("Index number " + randomNum);
                    return 1;
                }
            }
        }

        static int allocateBF(int[] arr)
        {
            Random random = new Random();

            int requestSize = random.Next(1, 9);
            int smallestDifference = -9999;
            int searchTime = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < 0)
                {
                    int currentDif = Math.Abs(arr[i]) - requestSize;

                    //find the smallest hole that fits request size
                    if (currentDif < smallestDifference)
                    {
                        smallestDifference = currentDif;
                    }
                    else if (currentDif < 0)
                    {
                        // Console.WriteLine("Block size is too small for request.");
                        return -1;
                    }
                    searchTime++;
                }


            }

            // Console.WriteLine("Search time for Best Fit: " + searchTime);
            return 1;


        }

        static int allocateWF(int[] arr)
        {
            Random random = new Random();

            int requestSize = random.Next(1, 9);
            int biggestDifference = -9999;
            int searchTime = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < 0)
                {
                    int currentDif = Math.Abs(arr[i]) - requestSize;

                    //find the smallest hole that fits request size
                    if (currentDif > biggestDifference)
                    {
                        biggestDifference = currentDif;
                    }
                    else if (currentDif < 0)
                    {
                        // Console.WriteLine("Block size is too small for request.");
                        return -1;
                    }
                    searchTime++;
                }
            }

            // Console.WriteLine("Search time for Worst Fit: " + searchTime);
            return 1;


        }




    }
}
