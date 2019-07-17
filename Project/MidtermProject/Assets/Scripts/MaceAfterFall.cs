using UnityEngine;
using System.Threading;
using System.Collections;
public class MaceAfterFall : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject mace;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator WaitForDisappear()
    {
        yield return new WaitForSeconds(1);
        Destroy(mace);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(WaitForDisappear());
        return;
    }
}
