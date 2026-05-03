using UnityEngine;

public class CheckPointSystem : MonoBehaviour
{

    public bool gotToCheckPoint1, gotToCheckPoint2, gotToCheckPoint3;

    public GameObject checkPoints;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        checkPoints = GameObject.FindWithTag("CheckPoint");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "FallArea 1" && gotToCheckPoint1)
        {
            this.gameObject.transform.position = checkPoints.transform.GetChild(0).transform.position;
        }

        if(other.gameObject.name == "FallArea 2" && gotToCheckPoint2)
        {
            this.gameObject.transform.position = checkPoints.transform.GetChild(1).transform.position;
        }

        if(other.gameObject.name == "FallArea 3" && gotToCheckPoint3)
        {
            this.gameObject.transform.position = checkPoints.transform.GetChild(2).transform.position;
        }

        if(other.gameObject.name == "CheckPoint 1")
        {
            gotToCheckPoint1 = true;
        }

        if(other.gameObject.name == "CheckPoint 2")
        {
            gotToCheckPoint2 = true;
        }

        if(other.gameObject.name == "CheckPoint 3")
        {
            gotToCheckPoint3 = true;
        }
    }
}
