using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class WaspController : MonoBehaviour
{
    #region UNITY EVENTS
    public void Start()
    {
        StartCoroutine("Move");
    }

    public void Update()
    {
        transform.Translate(Vector3.forward * 3f * Time.deltaTime);
    }
    #endregion

    #region HELPER FUNCTIONS
    private IEnumerator Move()
    {
        while (true)
        {
            yield return new WaitForSeconds(3.5f);
            transform.eulerAngles += new Vector3(0, 180f, 0);
        }
    }
    #endregion
}
