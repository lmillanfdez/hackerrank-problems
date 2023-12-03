bool checkBST(Node* root) {
    int minMax[2];
    
    return checkBSTSubTree(root, minMax);
}

bool checkBSTSubTree(Node* node, int minMax[])
{
    minMax[0] = node->data;
    minMax[1] = node->data;
    
    if(node->left != NULL)
    {
        int innerMinMax[2];
        
        if(!checkBSTSubTree(node->left, innerMinMax))
            return false;
        
        if(innerMinMax[1] >= node->data)
            return false;
        
        minMax[0] = innerMinMax[0];
    }
    
    if(node->right != NULL)
    {
        int innerMinMax[2];
        
        if(!checkBSTSubTree(node->right, innerMinMax))
            return false;
        
        if(innerMinMax[0] <= node->data)
            return false;
        
        minMax[1] = innerMinMax[1];
    }
    
    return true;
}