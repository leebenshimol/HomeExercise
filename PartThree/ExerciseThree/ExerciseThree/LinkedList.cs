namespace PartThree
{
    class LinkedList
    {
        public Node Head;
        private Node _lastNode;
        private Node _maxNode;
        private Node _minNode;
        
        public LinkedList(int value) 
        {
            Head = new Node(value, null);
            _lastNode = Head;
            _maxNode = Head;
            _minNode = Head;

        }    

        public void Append(int value)
        {
            Node newNode = new(value, null);
            UpdateMaxMin(newNode);
            _lastNode.Next = newNode;
            _lastNode = newNode;
            
        }
        
        private void UpdateMaxMin(Node newNode)
        {
            if (_maxNode.Value < newNode.Value)
            {
                _maxNode = newNode;
            }
            else if (_minNode.Value > newNode.Value)
            {
                _minNode = newNode;
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
                if (Head == _lastNode)
                {
                    lastNodeVal = Head.Value;
                    NewMaxMin(Head);
                    Head = null;
                    _lastNode = null;
                }
                else
                {
                    Node current = Head;
                    lastNodeVal = _lastNode.Value;
                    while (current.Next != _lastNode)
                    {
                        current = current.Next;
                    }
                    current.Next = null;
                    NewMaxMin(_lastNode);
                    _lastNode = current;
                }
                return lastNodeVal;
            }
            return -1;
            
            
        }

        private void NewMaxMin(Node NodeToRemove)
        {
            if (NodeToRemove == _maxNode || NodeToRemove == _minNode)
            {
                if(NodeToRemove == _lastNode)
                {
                    _minNode.Value = -1;
                    _maxNode.Value = -1;
                }
                else
                {
                    Node current = Head;
                    _maxNode = current;
                    _minNode = current;
                    while (current != null)
                    {
                        if (current.Value > _maxNode.Value)
                        {
                            _maxNode = current;
                        }
                        else if (current.Value < _minNode.Value)
                        {
                            _minNode = current;
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
                if (Head == _lastNode)
                {
                    firstNodeVal = Head.Value;
                    NewMaxMin(Head);
                    Head = null;
                    _lastNode = null;
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
            if (_lastNode.Next == Head)
                return true;
            return false;
        }

        public Node GetMaxNode()
        {
            return _maxNode;
        }
        
        public Node GetMinNode()
        {
            return _minNode;
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
                _minNode = Head;
                _maxNode = _lastNode;
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
            Console.WriteLine("nulll");
        }


    }
}
