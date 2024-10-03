//****************************************************************************
//	Implementation File for Huffman Tree
//	Programmed by: Houston Brown
//	Last Compiled Date: 10/31/2023
//****************************************************************************

#include "HuffmanTree.h"



//****************************************************************************
//		Method to fill the Huffman Tree with the nodes from the Binary Heap
//	until there is one left.  The last node in the heap will be the root 
//	of the tree.  
//
//	Parameters:
//		minHeap: Binary Heap of nodes.
//****************************************************************************
void HuffmanTree::FillTree(BinaryHeap& minHeap)
{
	HNode* leftLeaf = NULL;
	HNode* rightLeaf = NULL;
	HNode* temp = NULL;
	
	while ( !(minHeap.GetSize() == 1) )
	{
		leftLeaf = minHeap.GetMin();
		
		rightLeaf = minHeap.GetMin();
		
		temp = new HNode('$', leftLeaf->freq + rightLeaf->freq);
		temp->left = leftLeaf;
		temp->right = rightLeaf;

		minHeap.InsertHelper(temp);
		root = temp;
	}	
	temp = minHeap.GetMin();
}




//****************************************************************************
//		Method to print the tree in level order.
//
//	Parameters:
//		N/A.
//****************************************************************************
void HuffmanTree::PrintTree() const
{
	if (!root)
	{
		cerr << "The Tree is Empty" << endl;
        return;
    }

    else
    {
    	cout << endl;
        int ctr = 0;
        while (ctr <= TreeHeight(root))
        {
            PrintLevel(ctr);
            ctr++;
            cout << endl << endl;
        }
    }
    cout << endl << endl;
}




//****************************************************************************
//		Recursively calculates the height of the tree.
//
//	Parameters:
//		subtree: pointer to the root of subtree.
//****************************************************************************
int HuffmanTree::TreeHeight(HNode* subtree) const
{
	if (subtree == NULL)
		return 0;
	else
	{
		int leftHeight = TreeHeight(subtree->left);
		int rightHeight = TreeHeight(subtree->right);
		
		if (leftHeight >= rightHeight)
			return leftHeight + 1;
		else
			return rightHeight + 1;
	}
}




//****************************************************************************
//		Calculates width to space out nodes and calls DispLevel to print
//	nodes on given level.
//
//	Parameters:
//		height: height of tree.
//****************************************************************************
void HuffmanTree::PrintLevel(int height) const
{
	HNode* temp = root;
	
	// leftmost point
	int value = pow(2, TreeHeight(root) - height + 2);
	cout << setw(value - 4) << "";
	DispLevel(temp, height, value);
}




//****************************************************************************
//		Displays the nodes on given level and will display 'x' where the
//	pointers are NULL.
//
//	Parameters:
//		subtree: node to be displayed.
//		level: current level.
//		displace: displacement.
//****************************************************************************
void HuffmanTree::DispLevel(HNode* subtree, int level, int displace) const
{
	int disp = 2 * displace;
	if (level == 0)
	{
		if (subtree == NULL)
		{
			cout << " x ";
			cout << setw(disp - 3) << "";
			return;
		}
		else
		{
			int result = ((subtree->item <= 1) ? 1: log10(subtree->item) + 1);
			cout << "<" << subtree->item << ", " << subtree->freq << ">";

			cout << setw(disp - result) << "";
		}
	}
	
	else
	{
		if (subtree == NULL && level >= 1)
		{
			DispLevel(NULL, level - 1, displace);
			DispLevel(NULL, level - 1, displace);
		}
		else
		{
			DispLevel(subtree->left, level - 1, displace);
			DispLevel(subtree->right, level - 1, displace);
		}
	}	
}




//****************************************************************************
//		Displays the nodes on given level and will display 'x' where the
//	pointers are NULL.
//
//	Parameters:
//		subtree: node to be displayed.
//		arr: array holding the codes.
//		top: index of front of code.
//****************************************************************************
void HuffmanTree::PrintCodesHelper(HNode*& subtree, int arr[], int top)
{
	if (subtree->left != NULL)
	{
		arr[top] = 0;
		PrintCodesHelper(subtree->left, arr, top + 1);
	}
	
	if (subtree->right)
	{
		arr[top] = 1;
		PrintCodesHelper(subtree->right, arr, top + 1);
	}
	
	if ( !(subtree->right && subtree->left) )
	{
		cout << "       " << subtree->item << "     |    ";
		for (int i = 0; i < top; i++)
		{
			cout << arr[i];
		}
		cout << endl;
	}
}




//****************************************************************************
//		Copy Constructor.
//****************************************************************************
HuffmanTree::HuffmanTree(const HuffmanTree& myTree)
{
    if(!myTree.root)
    {
        root = NULL;
        return;
    }
    CopyHelper(root, myTree.root);	
}




//****************************************************************************
//		Helper method to recursively allocate memory for the new tree.
//****************************************************************************
void HuffmanTree::CopyHelper(HNode*& aRoot, HNode* myRoot)
{
    if(!myRoot)
    {
        aRoot = NULL;
    }
    else
    {
        aRoot = new HNode(myRoot->item, myRoot->freq);
        CopyHelper(aRoot->left, myRoot->left);
        CopyHelper(aRoot->right, myRoot->right);
    }	
}




//****************************************************************************
//		Destructor.
//****************************************************************************
HuffmanTree::~HuffmanTree()
{
    DestroyHelper(root);
    root = NULL;	
}




//****************************************************************************
//		Helper method to recursively deallocate the tree.
//****************************************************************************
void HuffmanTree::DestroyHelper(HNode*& Tree)
{
   if (Tree != NULL)
   {
      DestroyHelper(Tree->left);
      DestroyHelper(Tree->right);
      delete Tree;
      Tree = NULL;
   }
   /*Tree = NULL;	
   Tree->left = NULL;
   Tree->right = NULL;*/
}




//****************************************************************************
//		Assignment Operator.
//****************************************************************************
HuffmanTree& HuffmanTree::operator=(const HuffmanTree& rightTree)
{
    if(this != &rightTree)
    {
        if(root != NULL)
        {
			DestroyHelper(root);
		}
		
		if(rightTree.root == NULL)
		{
			root = NULL;
		}
		else
			CopyHelper(root, rightTree.root);
    }
    return *this;	
}
