using System.Collections.Generic;

namespace Iterator
{
    public partial class Node<T>
    {
        IEnumerable<Node<T>> Traverse(Node<T> current)
        {
            yield return current;

            if (current.Left != null)
            {
                foreach (var left in Traverse(current.Left))
                {
                    yield return left;
                }
            }

            if (current.Right != null)
            {
                foreach (var right in Traverse(current.Right))
                {
                    yield return right;
                }
            }
        }

        public IEnumerable<Node<T>> PreOrder
        {
            get
            {
                foreach (var node in Traverse(this))
                {
                    yield return node;
                }
            }
        }
    }
}
