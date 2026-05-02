using System.Collections;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Flag : MonoBehaviour
{

    public GameObject flag;

    public bool activated;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !activated)
        {
            StartCoroutine(Move());
            activated = true;
        }
    }

    IEnumerator Move()
    {
        for (int i = 0; i < 18; i++)
        {
            flag.transform.position += new Vector3(0, 0.233f, 0);
            yield return new WaitForSeconds(0.05f);
        }
        
        yield return new WaitForSeconds(2);

        SceneManager.LoadScene("End");
    }     
}
