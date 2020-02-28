using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.Collections.Generic;

public class ClassScripts : MonoBehaviour
{
    [SerializeField] private GameObject sphere = null;
    private int currentSphereOnScreen;
    private List<GameObject> sphereList;
    private List<GameObject> deleteObjectList;
    // Start is called before the first frame update
    void Start()
    {
        sphereList = new List<GameObject>();
        deleteObjectList = new List<GameObject>();
        for (int i = 0; i < 10; i++)
        {
            GameObject temp = Instantiate(sphere, new Vector3(transform.position.x + Random.Range(-8.75f, 8.75f),transform.position.y + Random.Range(-4.8f,4.8f)), Quaternion.identity);
            sphereList.Add(temp);
            currentSphereOnScreen++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (currentSphereOnScreen>0)
            {
                int a = Random.Range(0, sphereList.Count);
                deleteObjectList.Add(sphereList[a]);
                sphereList[a].SetActive(false);
                sphereList.RemoveAt(a);
                currentSphereOnScreen--;
            }
            else
            {
                Debug.Log("no object on screen");
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (deleteObjectList.Count == 0)
            {
                GameObject temp = Instantiate(sphere, new Vector3(transform.position.x + Random.Range(-8.75f, 8.75f), transform.position.y + Random.Range(-4.8f, 4.8f)), Quaternion.identity);
                sphereList.Add(temp);
                currentSphereOnScreen++;
            }
            else
            {
                int a = Random.Range(0, deleteObjectList.Count);
                sphereList.Add(deleteObjectList[a]);
                deleteObjectList[a].SetActive(true);
                deleteObjectList.RemoveAt(a);
                currentSphereOnScreen++;
            }
        }
    }
}
