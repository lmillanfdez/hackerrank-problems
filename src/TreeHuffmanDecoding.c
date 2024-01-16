void decode_huff(node * root, string s) {
    node* tmpPointer = root;
    string result = "";
    int i = 0;
    
    if(s.length() == 1){
        cout << root->data;
        return;
    }
    
    while(i < s.length()){
        tmpPointer = s[i++] == '0' ? tmpPointer->left : tmpPointer->right;
        
        if(tmpPointer->data != 0){
            result += tmpPointer->data;
            tmpPointer = root;
        }
    }
    
    cout << result;
}