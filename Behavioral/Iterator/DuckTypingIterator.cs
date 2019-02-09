namespace Iterator
{
    public class BinaryTreeNew<T>
    {
        private Node<T> root;

        public BinaryTreeNew(Node<T> root)
        {
            this.root = root;
        }

        public InOrderIterator<T> GetEnumerator()
        {
            return new InOrderIterator<T>(root);
        }
    }
}
