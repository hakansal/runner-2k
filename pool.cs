using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pool : MonoBehaviour
{

    List<GameObject> listground;
   public  List<ObjectPoolItem> objectlist;
    public Transform firstcube;
     
    void Start()
    {
        listground = new List<GameObject>();

        foreach(ObjectPoolItem item in objectlist)
        {
            for(int i = 0; i < item.poolsize; i++)
            {
                int rand = Random.Range(0, item.objectToPool.Length);
                var obj = Instantiate(item.objectToPool[rand]);
                obj.SetActive(false);
                listground.Add(obj);
            }
        }
       
    }

    

    public void getobject()
    {
        
        for (int i = 0; i < listground.Count; i++)
        {
            listground[i].SetActive(true);
            int y = Random.Range(-1, 1);
            listground[i].transform.position = firstcube.transform.position + new Vector3(2, y, 0);
            var swap = listground[i].transform;
             
            firstcube = swap;
        }
    }
}
[System.Serializable]
public class ObjectPoolItem
{
    public int poolsize;
    public GameObject[] objectToPool;

}
