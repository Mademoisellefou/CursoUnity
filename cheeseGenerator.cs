using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cheeseGenerator : MonoBehaviour
{


    //States
    public enum SpawerState
    {
        SPAWING, WAITING, COUNTING, END
    }
    [System.Serializable]

    //Create a object
    public class Wave
    {
        //name
        public string Name;
        public Transform enemy;  
    }
    //Waves
    public Wave[] waves;
    int MaxNextWave;
    private int NextWave = 0;
    public float Diference = 5f;
    public float CountDownWave;
    public SpawerState _state = SpawerState.COUNTING;
    public float SearchCountDown = 1f;
    public Transform[] positions;

    private void Start()
    {
        CountDownWave = 0;
        MaxNextWave = waves.Length;

    }

    public bool IsAlive()
    {
        SearchCountDown -= Time.deltaTime;
        if (SearchCountDown <= 0)
        {
            SearchCountDown = 1f;
            if (GameObject.FindGameObjectWithTag("Cheese") == null)
            {
                return false;
            }
        }

        return true;
    }
    public void NextWaveSpaw()
    {
        _state = SpawerState.COUNTING;
        if (NextWave + 1 == MaxNextWave)
        {
            _state = SpawerState.END;

        }
        else
        {
            NextWave++;
        }
        CountDownWave = Diference;
    }
    private void Update()
    {
        if (SpawerState.END == _state) return;
        if (SpawerState.WAITING == _state)
        {
            if (!IsAlive())
            {
                NextWaveSpaw();
                //Debug.Log("Creating ...");
                return;
            }
            else
            {
                return;
            }
        }
        if (CountDownWave <= 0)
        {
            if (!_state.Equals(SpawerState.SPAWING))
            {

                StartCoroutine(StartSpaw(waves[NextWave]));

            }
        }
        else
        {
            CountDownWave -= Time.deltaTime;
        }
    }
    IEnumerator StartSpaw(Wave w)
    {

        _state = SpawerState.SPAWING;
        SpawEnemy(w.enemy);
        yield return new WaitForSeconds(1f);
 
        _state = SpawerState.WAITING;

        yield break;
    }
    void SpawEnemy(Transform pos)
    {
        var posRandom = positions[NextWave];
        Instantiate(pos, posRandom.position, Quaternion.identity);
        //Debug.Log(pos);
    }




}
