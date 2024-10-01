//****************************************************************************
//	Header File for Huffman Tree Node Class
//	Programmed by: Houston Brown
//	Last Compiled Date: 10/31/2023
//****************************************************************************

#ifndef _HuffmanNode_H
#define _HuffmanNode_H

#include <iostream>
#include <iomanip>
#include <cstdlib>
#include <string>
#include <cmath>
#include "Logger.h"
using namespace std;


class HuffmanTree;
class BinaryHeap;



class HNode
{
    char item;
    int freq;
    HNode* left;
    HNode* right;

    HNode(char newItem, int newFreq): item(newItem), freq(newFreq), 
				      left(NULL), right(NULL) {};
								      
    HNode(char newItem, int newFreq, HNode* newLeft, HNode* newRight): 
			  item(newItem), freq(newFreq), left(newLeft), right(newRight) {};
	
    friend class HuffmanTree;
    friend class BinaryHeap;
};

#endif
