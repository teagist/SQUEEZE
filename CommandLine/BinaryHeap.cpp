//****************************************************************************
//	Implementation File for Binary Heap
//	Programmed by: Houston Brown
//	Last Compiled Date: 10/31/2023
//****************************************************************************

#include "BinaryHeap.h"




//****************************************************************************
//		Default Constructor.
//****************************************************************************
BinaryHeap::BinaryHeap()
{
	this->heap = (HNode**)malloc(100 * sizeof(HNode*));
	this->size = 0;
}




//****************************************************************************
//		Method to perform insertion.  Helper function will be called at the
//	end to maintain the heap order property.
//
//	Parameters:
//		letter: the character half of node.
//		freq: the frequency of the character of the node.
//****************************************************************************
void BinaryHeap::Insert(char letter, int freq)
{
	HNode* temp = new HNode(letter, freq);
	InsertHelper(temp);
}




//****************************************************************************
//		Helper insertion method that will increase the dynamic heap 
//	and call method to maintain the heap property.
//
//	Parameters:
//		newNode: pointer to the newly created HNode to be inserted.
//****************************************************************************
void BinaryHeap::InsertHelper(HNode* newNode)
{
	HNode **temp = (HNode**)malloc(100 * sizeof(HNode*));
	
	for (int i = 0; i < size + 1; i++)
	{
		temp[i] = heap[i];
	}
		
	size = size + 1;
	delete[] heap;
	heap = temp;
	temp[size - 1] = newNode;
	
	// bubble sort
	for (int i = 0; i < size - 1; i++)
	{
		for (int j = 0; j < size - 1; j++)
		{
			if (heap[j]->freq > heap[j + 1]->freq)
			{
				HNode* temp = heap[j];
				heap[j] = heap[j + 1];
				heap[j + 1] = temp;
			}
		}
	}
	
	Heapify(size-1);
}




//****************************************************************************
//		Method to delete the first element of the heap array, and shift the
//	remaining elements down.
//
//	Parameters:
//		N/A.
//****************************************************************************
void BinaryHeap::Delete()
{
	HNode **temp = (HNode**)malloc(100 * sizeof(HNode*));
	for (int i = 1; i < size; i++)
	{
		temp[i-1]= heap[i];
	}
	
	size = size - 1;
	delete[] heap;
	heap = temp;

	Heapify(size);
}




//****************************************************************************
//		Method to clear the contents of the Binary Heap, and set the heap 
//	pointer to NULL.
//
//	Parameters:
//		N/A.
//****************************************************************************
void BinaryHeap::Clear()
{
	for (int i = 0; i < size; i++)
	{
		delete[] heap[i];
	}
	heap = NULL;
}




//****************************************************************************
//		Method to print the contents of the Binary Heap.
//
//	Parameters:
//		N/A.
//****************************************************************************
void BinaryHeap::Print() const
{
	cout << "\n  Heap" << endl;
	cout << "________" << endl;
	
	for (int i = 0; i < size; i++)
	{
		cout << heap[i]->item << " | " << heap[i]->freq << endl;
	}
	
	cout << endl << endl;
}




//****************************************************************************
//		Method to return the first element of the Binary Heap.
//
//	Parameters:
//		N/A.
//****************************************************************************
HNode* BinaryHeap::GetMin()
{
	if (size > 0)
	{
		HNode* temp = heap[0];
		heap[0] = heap[size - 1];
		size = size - 1;
		
		Heapify(0);
		return temp;
	}
	else
	{
		return NULL;
	}
}




//****************************************************************************
//		Method to maintain the heap order property by the frequency of the 
//	nodes.
//
//	Parameters:
//		in: beginning index.
//****************************************************************************
void BinaryHeap::Heapify(int in)
{
	int smallest = in;
	int leftV = 2 * in + 1;
	int rightV = 2 * in + 2;

	if (leftV < size && heap[leftV]->freq < heap[smallest]->freq)
	{
		smallest = leftV;
	}
	
	if (rightV < size && heap[rightV]->freq < heap[smallest]->freq)
	{		
		smallest = rightV;
	}
		
	HNode* temp = NULL;
		
	if (smallest != in)
	{
		temp = heap[smallest];
		heap[smallest] = heap[in];
		heap[in] = temp;
	}	
}
