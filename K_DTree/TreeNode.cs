using System;
using System.Collections.Generic;

namespace K_DTree
{
    public class TreeNode<TKeyType,TDataType> where TKeyType : IComparable
    {
        public TreeNode<TKeyType, TDataType> Parent { get; set; }
        public TreeNode<TKeyType, TDataType> LeftSon { get; set; }
        public TreeNode<TKeyType, TDataType> RightSon { get; set; }

        public TKeyType[] Key { get; set; }
        public List<TDataType> Data { get; set; }

        public TreeNode(TKeyType[] key, List<TDataType> data)
        {
            Key = key;
            Data = data;
        }

        public bool IsList()
        {
            if (RightSon != null || LeftSon != null)
                return false;
            return true;
        }
    }
}
