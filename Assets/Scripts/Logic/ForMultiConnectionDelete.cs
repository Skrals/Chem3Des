using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForMultiConnectionDelete : MonoBehaviour
{
    [SerializeField] private Transform [] objects;

    private void Awake()
    {
        foreach (Transform t in objects)
        {
            if (t == null)
            {
                DeleteConnection();
            }
        }

    }
    private void DeleteConnection()
    {
        Destroy(this.gameObject);
    }
}
