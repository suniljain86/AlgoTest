using Microsoft.Extensions.Logging;
using System.Reflection;

namespace AlgoTest
{
    public interface ISortingService
    {
        void Sort(int[] array, int left, int right);
    }

    public class SortingService : ISortingService
    {
        private readonly ILogger<ISortingService> _logger;
        public SortingService(ILogger<ISortingService> logger)
        {
            _logger = logger;
        }

        // merges two subarrays of array.
        // first subarray is array[left..middle]
        // second subarray is array[middle+1..right]
        private void Merge(int[] array, int left, int middle, int right)
        {
            try
            {
                // find size of subarrays to be merged
                int leftSize = middle - left + 1;
                int rightSize = right - middle;

                // temp arrays
                int[] tempLeft = new int[leftSize];
                int[] tempRight = new int[rightSize];
                int i, j;

                // copy data to temp arrays
                for (i = 0; i < leftSize; ++i)
                    tempLeft[i] = array[left + i];
                for (j = 0; j < rightSize; ++j)
                    tempRight[j] = array[middle + 1 + j];

                // merge the temp arrays

                // initial indexes of first and second subarrays
                i = 0;
                j = 0;

                // initial index of merged subarrays
                int k = left;
                while (i < leftSize && j < rightSize)
                {
                    if (tempLeft[i] <= tempRight[j])
                    {
                        array[k] = tempLeft[i];
                        i++;
                    }
                    else
                    {
                        array[k] = tempRight[j];
                        j++;
                    }
                    k++;
                }

                // copy remaining elements of tempLeft[] if any
                while (i < leftSize)
                {
                    array[k] = tempLeft[i];
                    i++;
                    k++;
                }

                // copy remaining elements of tempRight[] if any
                while (j < rightSize)
                {
                    array[k] = tempRight[j];
                    j++;
                    k++;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"{GetType().Name}.{MethodBase.GetCurrentMethod()?.Name}: Error {ex.Message}", ex);
                throw ex;
            }
        }

        // sort the array using MergeSort
        public void Sort(int[] array, int left, int right)
        {
            try
            {
                if (left < right)
                {
                    // middle point
                    int middle = left + (right - left) / 2;

                    // sort first half and second half
                    Sort(array, left, middle);
                    Sort(array, middle + 1, right);

                    // merge the sorted halves
                    Merge(array, left, middle, right);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"{GetType().Name}.{MethodBase.GetCurrentMethod()?.Name}: Error {ex.Message}", ex);
                throw ex;
            }
        }
    }
}