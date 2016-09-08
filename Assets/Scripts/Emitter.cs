using UnityEngine;
using System.Collections;

public class Emitter : MonoBehaviour {


    public GameObject[] waves;

    private int currentWave;

    private Manager manager;

    private GameObject wave;
	// Use this for initialization
	IEnumerator Start () {

        if (waves.Length == 0)
        {
            yield break;
        }

        manager = FindObjectOfType<Manager>();

        while (true)
        {
            while(manager.IsPlaying() == false)
            {
                yield return new WaitForEndOfFrame();
            }

            wave = (GameObject)Instantiate(waves[currentWave], transform.position, Quaternion.identity);

            wave.transform.parent = transform;

            while(manager.IsPlaying() != false && wave.transform.childCount != 0)
            {
                yield return new WaitForEndOfFrame();
            }

            Destroy(wave);

            if(waves.Length <= ++currentWave || manager.IsPlaying() == false)
            {
                currentWave = 0;
            }
        }
	
	}

	
}
