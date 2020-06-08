using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LinqMonster : MonoBehaviour
{

    private List<Monster> _monsterList;
    private void Start()
    {
        print("sTART");
        _monsterList = new List<Monster>();
        Gen();
    }
    public void Gen() {
        _monsterList.Add(new Monster("Ogre", 10));
        _monsterList.Add(new Monster("Skeleton", 9));
        _monsterList.Add(new Monster("Giant Bat", 8));
        _monsterList.Add(new Monster("Slime", 0));
        print(":"+_monsterList.Count); print(_monsterList[0].NextLevelExperience);
        
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            IEnumerable<Monster> query = from m in _monsterList
                                         where m._CurrentExperience() >
                                         m.NextLevelRequiredExperience()
                                         orderby m.Name() descending
                                         select m;
            foreach (Monster m in query)
            {
                m.LevelUp();

            }
            print(_monsterList[0].NextLevelExperience);

        }
    }






    // Select monsters that are about to level up

}
