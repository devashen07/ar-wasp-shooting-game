using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class CollisionController : MonoBehaviour
{
    #region PUBLIC API
    public void OnTriggerEnter(Collider other)
    {
        GameObject explosion = Instantiate(Resources.Load("explosion", typeof(GameObject))) as GameObject;
        explosion.transform.position = transform.position;
        Destroy(other.gameObject);
        Destroy(explosion, 2);

        if (GameObject.FindGameObjectsWithTag("Player").Length == 0)
        {
            GameObject wasp = Instantiate(Resources.Load("wasp", typeof(GameObject))) as GameObject;
            GameObject wasp1 = Instantiate(Resources.Load("wasp1", typeof(GameObject))) as GameObject;
            GameObject wasp2 = Instantiate(Resources.Load("wasp2", typeof(GameObject))) as GameObject;
            GameObject wasp3 = Instantiate(Resources.Load("wasp3", typeof(GameObject))) as GameObject;
            GameObject wasp4 = Instantiate(Resources.Load("wasp4", typeof(GameObject))) as GameObject;
            GameObject wasp5 = Instantiate(Resources.Load("wasp5", typeof(GameObject))) as GameObject;

        }

        Destroy(gameObject);
    }
    #endregion 
}

