﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMgr : MonoBehaviour {

    // Use this for initialization
    private void Start()
    {
        
       
    }
    public void Reset()
    {
        foreach(var gb in _blockSet)
        {
            if(gb !=null)
            {
                Destroy(gb);
            }
        }
        _blockSet.Clear();
        blockIndex = 0;
        GenBlock();
    }

    HashSet<GameObject> _blockSet = new HashSet<GameObject>();

    int blockIndex = 0;
    public void GenBlock()
    {
  
  
    }
	

}
