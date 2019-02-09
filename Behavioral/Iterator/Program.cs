using System.Linq;
using static System.Console;

namespace Iterator
{
    /* How traversal of data structures happens and who makes it happen */

    /*
     * An object (or a method) that facilitates the traversal of a data structure.
     */

    public partial class Node<T>
    {
        public T Value;
        public Node<T> Left, Right;
        public Node<T> Parent;

        public Node(T value)
        {
            Value = value;
        }

        public Node(T value, Node<T> left, Node<T> right)
        {
            Value = value;
            Left = left;
            Right = right;

            left.Parent = right.Parent = this;
        }
    }
    
    public class Program
    {
        static void Main(string[] args)
        {
            //      1
            //    /   \
            //   2     3

            // in order: 213

            var root = new Node<int>(1, new Node<int>(2), new Node<int>(3));

            // low level approach
            var it = new InOrderIterator<int>(root);
            while (it.MoveNext())
            {
                Write(it.Current.Value);
                Write(',');
            }
            WriteLine();

            // high level approach
            var tree = new BinaryTree<int>(root);
            WriteLine(string.Join(",", tree.InOrder.Select(x => x.Value)));

            // iterators and Duck typing
            var newTree = new BinaryTreeNew<int>(root);
            foreach (var node in newTree)
            {
                Write("{0},", node.Value);
            }
            WriteLine();

            // exercise
            WriteLine(string.Join(",", root.PreOrder.Select(x => x.Value)));
        }
    }
}
