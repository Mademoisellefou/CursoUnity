
using System;
using UnityEngine;

public class Inventory :MonoBehaviour
{

    private string _name = " ";
    //   public int CurrentLevel { get => _currentLevel; set => _currentLevel = value; }
    public int CurrentExperience { get => _currentExperience; set => _currentExperience = value; }
    public int NextLevelExperience { get => _nextLevelExperience; set => _nextLevelExperience = value; }

    private int _currentLevel = 1;

    private int _currentExperience = 0;
    private int _nextLevelExperience = 1000;

    public Inventory(string nombre, int level)
    {
        this._name = nombre;
        this._currentExperience = level;
        mostrar();
    }
    public string Name()
    {
        return _name;
    }

    public void LevelUp()
    {
        Console.WriteLine(_name + " has levelled up!");
        _currentLevel++;
        _currentExperience = 0;
        _nextLevelExperience = _currentLevel * 1000;

    }

    public void Destroy()
    {
        Destroy(this);
        print("sadsa");
    }

    internal void mostrar()
    {
        Console.WriteLine("name !" + _name + " _currentLevel;" + _currentLevel + "_currentExperience!" + _currentExperience); ;
    }

    public int _CurrentExperience()
    {
        return _currentExperience;
    }
    public int NextLevelRequiredExperience()
    {
        return _nextLevelExperience;
    }


}
