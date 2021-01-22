using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter_To_Dare : MonoBehaviour
{

    //States
    public enum SpawerState {
        SPAWING, WAITING ,COUNTING
    }
    [System.Serializable]

    //Create a object
    public class Wave {
        //name
        public string Name;
        public Transform enemy;
        public int count;
        public float rate;
    }
 //Waves
    public Wave[] waves;
    int MaxNextWave ;
    private int NextWave = 0;
    public float Diference =5f;
    public float CountDownWave;
    public SpawerState _state = SpawerState.COUNTING;
    public float SearchCountDown=1f;
    public Transform[] positions;

    private void Start()
    {
        CountDownWave = Diference;
        MaxNextWave = waves.Length;
        
    }

    public bool IsAlive() {
        SearchCountDown -= Time.deltaTime;
        if (SearchCountDown<=0) {
            SearchCountDown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }

        return true;
    }
    public void NextWaveSpaw() {
        _state = SpawerState.COUNTING;
        if (NextWave + 1 == MaxNextWave)
        {
            NextWave = 0;
        }
        else {
            NextWave++;    
        }
        CountDownWave = Diference;
    }
    private void Update()
    {
        if (SpawerState.WAITING==_state) {
            if (!IsAlive())
            {
                NextWaveSpaw();
                Debug.Log("Creating ...");
                return;
            }
            else {
                return;
            }
        }
        if (CountDownWave <= 0)
        {
            if (!_state.Equals(SpawerState.SPAWING)) {

                StartCoroutine(StartSpaw(waves[NextWave]));

            }
        }
        else {
            CountDownWave -= Time.deltaTime;
        }
    }
    IEnumerator StartSpaw(Wave w) {

        _state = SpawerState.SPAWING;
        for (int i = 0; i < w.count; i++)
        {
            SpawEnemy(w.enemy);
            yield return new WaitForSeconds(1f / w.rate);               
        }
        _state = SpawerState.WAITING;

        yield break;
    }
    void SpawEnemy(Transform pos) {
         var posRandom =positions[Random.Range(0, positions.Length)];
        Instantiate(pos, posRandom.position, Quaternion.identity);
        Debug.Log(pos);
    }


}
