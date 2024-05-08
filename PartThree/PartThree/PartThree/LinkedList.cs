namespace PartThree
{
    class LinkedList
    {
        public Node Head;
        private Node LastNode;
        private Node MaxNode;
        private Node MinNode;
        
        public LinkedList(int value) 
        {
            Head = new Node(value, null);
            LastNode = Head;
            MaxNode = Head;
            MinNode = Head;

        }    

        public void Append(int value)
        {
            Node newNode = new(value, null);
            UpdateMaxMin(newNode);
            LastNode.Next = newNode;
            LastNode = newNode;
            
        }
        
        private void UpdateMaxMin(Node newNode)
        {
            if (MaxNode.Value < newNode.Value)
            {
                MaxNode = newNode;
            }
            else if (MinNode.Value > newNode.Value)
            {
                MinNode = newNode;
            }
        }
        public void Prepend(int value)
        {
            Node newNode = new(value, Head);
            Head = newNode;
            UpdateMaxMin(newNode);
        }


        public int Pop()
        {
            if (Head != null)
            {
                int lastNodeVal = 0;
                if (Head == LastNode)
                {
                    lastNodeVal = Head.Value;
                    NewMaxMin(Head);
                    Head = null;
                    LastNode = null;
                }
                else
                {
                    Node current = Head;
                    lastNodeVal = LastNode.Value;
                    while (current.Next != LastNode)
                    {
                        current = current.Next;
                    }
                    current.Next = null;
                    NewMaxMin(LastNode);
                    LastNode = current;
                }
                return lastNodeVal;
            }
            return -1;
            
            
        }

        private void NewMaxMin(Node NodeToRemove)
        {
            if (NodeToRemove == MaxNode || NodeToRemove == MinNode)
            {
                if(NodeToRemove == LastNode)
                {
                    MinNode.Value = -1;
                    MaxNode.Value = -1;
                }
                else
                {
                    Node current = Head;
                    MaxNode = current;
                    MinNode = current;
                    while (current != null)
                    {
                        if (current.Value > MaxNode.Value)
                        {
                            MaxNode = current;
                        }
                        else if (current.Value < MinNode.Value)
                        {
                            MinNode = current;
                        }
                        current = current.Next;
                    }
                }

            }
            
        }
        public int Unqueue()
        {
            if (Head != null)
            {
                int firstNodeVal = 0;
                if (Head == LastNode)
                {
                    firstNodeVal = Head.Value;
                    NewMaxMin(Head);
                    Head = null;
                    LastNode = null;
                }
                else 
                {
                    firstNodeVal = Head.Value;
                    Node current = Head;
                    Head = Head.Next;
                    NewMaxMin(current);
                    
                }
                return firstNodeVal;
            }
            return -1;
        }

        public IEnumerable<int> ToList()
        {
            Node current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }

        }

        public bool IsCircular()
        {
            if (LastNode.Next == Head)
                return true;
            return false;
        }

        public Node GetMaxNode()
        {
            return MaxNode;
        }
        
        public Node GetMinNode()
        {
            return MinNode;
        }

        public void Sort()
        {
            Node current = Head;
            if (current != null)
            {
                List<int> valuesList = ToList().ToList();
                valuesList.Sort();
                foreach (int value in valuesList)
                {
                    if (current != null)
                    {
                        current.Value = value;
                        current = current.Next;
                    }
                }
                MinNode = Head;
                MaxNode = LastNode;
            }
        }

        public void Print()
        {
            Node current = Head;
            while (current != null) 
            {
                Console.Write(current.Value + " - > ");
                current = current.Next;
            }
            Console.WriteLine("null");
        }


    }
}
