/*
 * Diameter of a tree - So the definition of diameter varies so please make sure you ask the interviewer for the clarification.
 * For example - In IK they have mentioned diameter as the summation of the edge weights and the problem here is for a general tree.
 * On GeeksForGeeks - the definition is mentioned as the number of NODES in the tree.
 * On LeetCode - the definition is number of EDGES in the tree.
 * Also, in IK interview, they don't have tests for this problem and the parsing of input in which they are providing it is very complicated.
 * So here I am solving the problem for BST (Following LeetCode). Was able to get it in first go.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion.DiameterOfTree
{
    class DiameterOfTree
    {
        private int globalMax = 0;
        public int DiameterOfBinaryTree(TreeNode root)
        {
            globalMax = 0;
            RecTreeTraversal(root);
            return globalMax;
        }

        private int RecTreeTraversal(TreeNode root)
        {
            if (root == null)
                return 0;

            int leftLen = RecTreeTraversal(root.left);
            int rightLen = RecTreeTraversal(root.right);
            if(leftLen + rightLen > globalMax)
            {
                globalMax = leftLen + rightLen;
            }

            return leftLen > rightLen ? leftLen + 1 : rightLen + 1;
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
    }


}
