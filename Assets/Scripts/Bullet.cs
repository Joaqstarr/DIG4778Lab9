using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(WaitAndDisable());
    }

    IEnumerator WaitAndDisable()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }
}
