//****************************************************************************
//	Header File for Binary Heap of Huffman Tree Nodes 
//	Programmed by: Houston Brown
//	Last Compiled Date: 10/31/2023
//****************************************************************************

#ifndef _BINARYHEAP_H
#define _BINARYHEAP_H

#include <iostream>
#include <cstdlib>
#include <string>
#include "HuffmanNode.h"
using namespace std;



class BinaryHeap
{
public:
	BinaryHeap();

	void Insert(char letter, int freq);
	void InsertHelper(HNode* newNode);
	
	void Delete();
	void Clear();
	void Print() const;

	int GetSize() const { return size; }
	HNode* GetMin();
	
private:
	HNode **heap;
	int  size;	
	
	int left(int par) {	return ((2 * par) + 1); }
	int right(int par) { return ((2 * par) + 2); }
	int parent(int child) {	return (child - 1) / 2; }

	void Heapify(int in);
};

#endif
