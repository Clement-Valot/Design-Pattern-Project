using System;

//Simple and classic class Node with two attributes data and next accessible with
//getters and setters. We don't forget to mention the use of generics to allow multiple
//types of variable to be passed in parameters.
public class Node<T>
{
	public Node(T val)
	{
		data = val;
		next = null;
	}
	
	public T data { get; set; }
	public Node<T> next { get; set; }

}
