using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField] private float time_to_stay;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SelfDestructMethod());
    }

    private IEnumerator SelfDestructMethod()
    {
        yield return new WaitForSeconds(time_to_stay);
        Destroy(gameObject);
    }
}
