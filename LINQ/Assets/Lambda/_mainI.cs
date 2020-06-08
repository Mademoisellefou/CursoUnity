
using System;
using System.Collections.Generic;
using UnityEngine;

public class _mainI : MonoBehaviour
{
    private List<Inventory> _monsterList; Action mn;
    private void Start()
    {
        print("sTART");
        _monsterList = new List<Inventory>();
        Gen();
    }
    public void Gen()
    {
        _monsterList.Add(new Inventory("Ogre", 10));
        _monsterList.Add(new Inventory("Skeleton", 9));
        _monsterList.Add(new Inventory("Giant Bat", 8));
        _monsterList.Add(new Inventory("Slime", 0));
        print(":" + _monsterList.Count); 
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            _monsterList.ForEach(x => x.Destroy());
            print(_monsterList.Count);

        }
    }

    
}
