public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    /// 
        // Step 1: Create a new array of size 'length' to store the results
        // Step 2: Loop from 0 to length - 1
        // Step 3: For each index i, compute number * (i + 1)
        // Step 4: Store that value in the array at position i
        // Step 5: Return the completed array

    public static double[] MultiplesOf(double number, int length)
{
    // Step 1: Create a new array of size 'length' to store the results
    double[] result = new double[length];

    // Step 2: Loop from 0 to length - 1
    for (int i = 0; i < length; i++)
    {
        // Step 3: Multiply number by (i + 1)
        result[i] = number * (i + 1);
    }

    // Step 5: Return the completed array
    return result;
}


    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    /// 
    // Step 1: Calculate the index where we want to split the list
    // Step 2: Use GetRange to get the last 'amount' elements
    // Step 3: Use GetRange again to get the first part of the list (everything before the split)
    // Step 4: Clear the original list
    // Step 5: Add the last part first, then the front part to complete the rotation

    public static void RotateListRight(List<int> data, int amount)
{
    // Step 1: Calculate the split index
    int splitIndex = data.Count - amount;

    // Step 2: Slice the last 'amount' items
    List<int> end = data.GetRange(splitIndex, amount);

    // Step 3: Slice the front part
    List<int> front = data.GetRange(0, splitIndex);

    // Step 4: Clear original list
    data.Clear();

    // Step 5: Add rotated parts back in order
    data.AddRange(end);
    data.AddRange(front);
}

}
