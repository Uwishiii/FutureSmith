using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCleanerScript : MonoBehaviour
{
    private void Awake()
    {
        Destroy(gameObject, 1f);
    }
}
