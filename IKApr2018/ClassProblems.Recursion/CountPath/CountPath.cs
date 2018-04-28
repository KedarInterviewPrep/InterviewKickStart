/*
 * Given MxN matrix, print all the paths from [0,0] to [M-1, N-1] cell, given the possible next steps could be to go RIGHT and DOWN.
 * 1st problem in the class.
 * 
 * NOTE:- As per the prof, try to visualize Recursion problem as STATE and TRANSITION instead of purely as solving sub-problem.
 * Personally I found this technique very useful. 
 * Tackle the problem as STATE and TRANSITIONS-
 * 1) First by finding "Engine Of Recursion" that is - 
 *      Represent the problen as the STATE and TRANSITION. Determine how the STATE and Transitions would look like.
 * 2) Second determine 
 *      Guard rails - to prevent the flow to go out of hte problem space like - out of bound of the array, to go into invalid state etc.
 *      Base Case  - the smallest problem for which we know the answer and can return. Basically terminating conditions.*      
 * 
 */

namespace ClassProblems.Recursion.CountPath
{
    public static class CountPath
    {
        public static int CountPathMain(int numRows, int numCols)
        {
            return CountPathRec(0, 0, numRows, numCols);
        }

        // row, col -> Represent the STATE. Your current position in the grid. 
        public static int CountPathRec(int row, int col, int numRows, int numCols)
        {
            // Guard conditions
            if (row >= numRows || col >= numCols)
                return 0;

            // Base Case
            if (row == numRows - 1 && col == numCols - 1)
                return 1;

            // Transitions
            return CountPathRec(row + 1, col, numRows, numCols) + CountPathRec(row, col + 1, numRows, numCols);
        }
    }
}
