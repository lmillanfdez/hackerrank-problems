typedef struct node
{
    int val;
    struct node* left;
    struct node* right;
    int ht;
} node;

void computeNodeHeight(node * root){
    if(root == NULL)
        return;
    
    root->ht = max(root->left != NULL ? root->left->ht : -1, 
                    root->right != NULL ? root->right->ht : -1) + 1;
}

int getBalanceFactor(node* root){
    return (root->left != NULL ? root->left->ht : -1)
                - (root->right != NULL ? root->right->ht : -1);
}

node* rotateRight(node * root){
    node* left = root->left;
    node* result;
    
    if(getBalanceFactor(left) == 1){
        root->left = left->right;
        left->right = root;
        result = left;
    }
    else{
        result = left->right;
        left->right = result->left;
        root->left = result->right;
        
        result->left = left;
        result->right = root;
    }
    
    computeNodeHeight(result->left);
    computeNodeHeight(result->right);
    computeNodeHeight(result);
    
    return result;
}

node* rotateLeft(node * root){
    node* right = root->right;
    node* result = NULL;
    
    if(getBalanceFactor(right) == -1){
        root->right = right->left;
        right->left = root;
        result = right;
    }
    else{
        result = right->left;
        right->left = result->right;
        root->right = result->left;
        
        result->right = right;
        result->left = root;
    }
    
    computeNodeHeight(result->left);
    computeNodeHeight(result->right);
    computeNodeHeight(result);
    
    return result;
}

node * insert(node * root,int val)
{
    if(root == NULL){
        node* leaf = new node;
        leaf->val = val;
        leaf->ht = 0;

        return leaf;
    }
    
    node* subTree = NULL;
    
	if(root->val > val){
        subTree = insert(root->left, val);
        
        if(root->left == NULL || root->left->val != subTree->val)
            root->left = subTree;
    }
    else{
        subTree = insert(root->right, val);
        
        if(root->right == NULL || root->right->val != subTree->val)
            root->right = subTree;
    }
    
    int balanceFactor = getBalanceFactor(root);
    
    if(balanceFactor > -2 && balanceFactor < 2){
        computeNodeHeight(root);
        
        return root;
    }
    
    return balanceFactor == 2 ? rotateRight(root) : rotateLeft(root);
}