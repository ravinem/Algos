using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    public class AVL_Tree
    {
        public Node root;
        public class Node
        {
            public int height;
            public int key;
            public Node left = null;
            public Node right = null;
            public Node(int k)
            {
                key = k;
                height = 1;
            }
        }

        private int height(Node N)
        {
            if (N == null)
            {
                return 0;
            }
            return N.height;
        }

        private int getBalance(Node N)
        {
            if (N==null)
            {
                return 0;
            }
            return height(N.left) - height(N.right);
        }

        private Node getMinimum(Node n)
        {
            Node temp = n.right;
            while(temp.left != null)
            {
                temp = temp.left;
            }
            return temp;
        }

        private Node rightRotate (Node N)
        {
            Node y = N.left;
            Node t3 = y.right;
            y.right = N;
            N.left = t3;

            y.height = Math.Max(height(y.right), height(y.left)) + 1;
            N.height = Math.Max(height(N.right), height(N.left)) + 1;

            return y;
        }

        private Node leftRotate(Node N)
        {
            Node y = N.right;
            Node t1 = y.left;
            y.left = N;
            N.right = t1;

            y.height = Math.Max(height(y.right), height(y.left)) + 1;
            N.height = Math.Max(height(N.right), height(N.left)) + 1;

            return y;
        }

        public Node Insert(Node node, int key)
        {
            if (node == null)
            {
                return new Node(key);
            }
            else
            {
                if (node.key > key)
                {
                    node.left =  Insert(node.left,key);
                }
                else
                {
                    node.right =  Insert(node.right, key);
                }
            }

            node.height = Math.Max(height(node.left), height(node.right)) + 1;

            int balance = getBalance(node);

            //left left case
            if(balance > 1 && key < node.left.key)
            {
                return rightRotate(node);
            }

            //right right case
            if(balance < -1 && node.right.key < key)
            {
                return leftRotate(node);
            }

            // left right
            if(balance > 1 && key > node.left.key)
            {
                node.left =  leftRotate(node.left);
                return rightRotate(node);
            }

            if(balance < -1 && key < node.right.key)
            {
                node.right = rightRotate(node.right);
                return leftRotate(node);
            }

            return node;       
        }

        public Node Delete(Node node,int key)
        {
            if (node == null)
                return node;
            if(key < node.key)
            {
                node.left = Delete(node.left, key);
            }
            else if(key > node.key)
            {
                node.right = Delete(node.right, key);
            }
            else
            {
                Node temp = null;
                if (node.left == null || node.right == null)
                {
                    if (node.left == null)
                    {
                        temp = node.right;
                    }
                    else if (node.right == null)
                    {
                        temp = node.left;
                    }
                    if(temp==null)
                    {
                        temp = node;
                        node = null;
                    }
                    else
                    {
                        node = temp;
                    }
                }
                else
                {
                    temp = getMinimum(node.right); // get inorder successor
                    node.key = temp.key;
                    node.right = Delete(node.right, temp.key);
                }
            }

            if(node ==null)
            {
                return node;
            }
            node.height = Math.Max(height(node.left), height(node.right)) + 1;
            int balance = getBalance(node);

            if(balance > 1  && getBalance(node.left) >= 0)
            {
                return rightRotate(node);
            }
            if(balance > 1 && getBalance(node.right) < 0)
            {
                node.left = leftRotate(node.left);
                return rightRotate(node);
            }
            if (balance < -1 && getBalance(node.right) <= 0)
            {
                return leftRotate(node);
            }
            if (balance < -1 && getBalance(node.right) > 0)
            {
                node.right = rightRotate(node.right);
                return leftRotate(node);
            }

            return root;
        }
        public void preOrdertrversal(Node root)
        {
            if (root != null)
            {
                Console.WriteLine(root.key);
                preOrdertrversal(root.left);
                preOrdertrversal(root.right);
            }
        }

        public void inOrdertrversal(Node root)
        {
            if (root != null)
            {                
                inOrdertrversal(root.left);
                Console.WriteLine(root.key);
                inOrdertrversal(root.right);
            }
        }

    }
}
