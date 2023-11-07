using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour
{
    [SerializeField] GameObject vrHeadset;
    [SerializeField] GameObject vrHeadsetSpawnPos;
    public void ChangeScene()
    {
        SceneManager.LoadScene("SorinFurnaceScene");
    }

    public void SpawnVRHeadset()
    {
        Instantiate(vrHeadset,vrHeadsetSpawnPos.transform.position, Quaternion.identity);
    }
}
