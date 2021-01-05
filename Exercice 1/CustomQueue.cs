using System;
using System.Collections;

//For the foreach loop functionnality, we need our CustomQueue class
//to inherit from both interfaces IEnumerator and IEnumerable
public class CustomQueue<T>: IEnumerator,IEnumerable
{
	//Getter setter methods to access the head of the queue.

	public Node<T> head { get; set; }

	//Method to add an element to the queue.
	//Since it is a queue, when we add an element, we add it at the end of the queue.
	//for us, the head of the queue is the really first node of the linked and list,
	//and therefore the tail of the queue is the last node of the linked list.
	//So when we add an element to the queue, firstly it is a Node object and secondly,
	//we have to go through all the nodes of the queue until the attribute next of a node 
	//is null to insert this element.
	public void enqueueing(T data_node)
	{
		Node<T> new_node = new Node<T>(data_node);
		
		if(head == null)
			head = new_node;
		else
		{ 
            Node<T> next_node =head;
            while(next_node.next!=null)
            {
                next_node=next_node.next;
            }
            next_node.next = new_node;
		}
	}

	//Method to retrieve the first element of the queue.
	//The first element is the head so when we retrieve it, we have to set the second element
	//of the queue as the new head. This function also returns the dequeued node even if it is not necessary.
	public Node<T> dequeueing()
	{	
        //We put the head of the linked list in a variable
        Node<T> ejected_node=head;	
        //We change the head of the list by putting the second linked node
        //as the new head of the linked list
		head=head.next;
        //we return our former head node
        return ejected_node;
	}

    //Methods getNode, setNode are usefull in case we want to 
    //run through the linked list with a foreach loop to display all nodes
	//We set them to private because we don't want to allow access to the values 
	//of the nodes of the linked list.
	private Node<T> getNode(int idx)
	{
		Node<T> current = head;
		int pos = 0;
		while(current != null)
		{
			if(pos == idx)
				return current;
			current = current.next;
			pos++;
		}
		return null;
	}
	private void setNode(int idx, Node<T> node)
	{
		Node<T> current = head;
		Node<T> prev_current = null;
		int pos = 0;
		while(current != null)
		{
			if(pos == idx)
            {
				Node<T> new_node = new Node<T>(node.data);
				new_node.next = current.next;
				prev_current.next = new_node;
				break;
			}
			prev_current = current;
			current = current.next;
			pos++;
		}
	}
	
	// Override operator [] for CustomQueue objects
	//Also set to private to not allow access to the queue outside this class
	private Node<T> this[int index]
	{
		get{return getNode(index);}		
		set{setNode(index, value);}
	}
	

	//Method to print the values of the nodes of the queue from the first to the last.
	//Here, we simply start from the head, print the data of the node and then we go to the
	//node next and do the same thing. We repeat this process until attribute next of a node is null,
	//meaning we reached the end of our queue.
	public void normal_print()
	{
		Node<T> current = head;
		while(current != null)
		{
			Console.Write(current.data + " ");	
			current = current.next;
		}
        Console.WriteLine("\n");
	}

	//This method does the same thing as the one above except it uses a foreach loop.
	//Like this, it lists all the nodes of the queue and prints their data.
	//It looks simpler than the previous method inside the function but it is actually 
	//far more complicated to implement since it requires to extend IEnumerable and 
	//IEnumerator interfaces to match the specificities of our queue.
	public void foreach_print()
	{
		foreach (Node<T> node in this)
		{
			Console.WriteLine(node.data);
		}
		Console.WriteLine();
	}


    //IEnumerator and IEnumerable require these methods.
	//Only this function comes from IEnumerable interface and it is 
	//useful to transform our queue into a instance of class IEnumerator.
    public IEnumerator GetEnumerator()
    {
        return (IEnumerator)this;
    }
    
	//IEnumerator provides the 3 next functions : 
	//	MoveNext
	//	Reset
	//	Current
    int position=-1;

	//Increment the position by one to get to the next node in the queue,
	//if there is one of course (!= null)
    public bool MoveNext()
    {
		position+=1;
		if(this[position] == null)
		{
			this.Reset();
			return false;
		}
		else
		{
			return true;
		}
    }
    
	//Resets the value of position to -1 to be able to do several 
	//foreach one after the other in a same execution.
    public void Reset()
    {
        position=-1;
    }
    
	//Returns the current object we are analysing in the queue.
	//We use the overriden [] operator to access elements of our queue
	//like if it was an array.
	//Position is previously initialized, incremented and reset to - 1 after 
	//the end of the foreach loop.
    public object Current
    {
        get { return this[position];}
    }	
}