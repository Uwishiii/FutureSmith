using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerHitScript : MonoBehaviour
{

    //Very Buggy, very ugly, but it's good enough for test and chill

    //bool bladeFound = false;
    //bool handleFound = false;
    //bool guardFound = false;
    //
    //[SerializeField] GameObject demoSword;
    [SerializeField] GameObject hitParticle;

    //[SerializeField] List<Collider> colliders = new List<Collider>();
    AudioSource hitSound;
    private void Start()
    {
        hitSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        #region
        //if (other.gameObject.layer == 9)
        //{
        //    if (other.name == "Handle" && !handleFound)
        //    {
        //        handleFound = true;
        //        colliders.Add(other);
        //    }
        //    else
        //    {
        //        handleFound = false;
        //    }
        //
        //    if (other.name == "Blade" && !bladeFound)
        //    {
        //        bladeFound = true;
        //        colliders.Add(other);
        //    }
        //    else
        //    {
        //        bladeFound = false;
        //    }
        //
        //    if (other.name == "Guard" && !guardFound)
        //    {
        //        guardFound = true;
        //        colliders.Add(other);
        //    }
        //    else
        //    {
        //        guardFound = false;
        //    }
        //
        //    //if (bladeFound || guardFound || handleFound)
        //    //{
        //    //    colliders.Add(other);
        //    //}
        //    //else
        //    //{
        //    //    colliders.Clear();
        //    //}
        //}
        //
        //
        ////IMPORTANT!!! -> here the colliders of the children of the objects will also be added
        ////since the sword parts also have snap points with colliders the number has to be increased to acomodate for them
        ////otherwise we risk to not destroy all parts of the weapon.
        //if (colliders.Count >= 3)
        //{
        //    SpawnWeapon();
        //    foreach (var item in colliders)
        //    {
        //        Destroy(item.gameObject);
        //    }
        //}
        //
        ////to fix: Spawns a second sword most of the time idk why -.-
        //void SpawnWeapon()
        //{
        //    var sword = Instantiate(demoSword, gameObject.transform.position, Quaternion.identity);
        //}
        #endregion

        if (other.gameObject.layer == 9)
        {
            var hitParticleInstance = Instantiate(hitParticle, gameObject.transform.position, Quaternion.identity);
            hitSound.Play();
        }
    }
}
