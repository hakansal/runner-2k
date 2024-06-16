using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poolsystem : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] cubes;
    public GameObject[] cubes2;
    public GameObject[]real_cubes2;
    public GameObject[] clouds;
    public GameObject[] real_clouds;
    public GameObject[] backgrounditems;
    public GameObject[] real_backgrounditem;
    public GameObject[] realcubes;
    public bool start;
     int random;
    public GameObject _lastcube;
    public GameObject _lastcloud;
    public GameObject _lastbackgrounditem;
    public GameObject _creater;
    private GameObject _midlecube;
     bool cube1 = false;
    public GameObject player;

    Vector3 staticvec = new Vector3(3, 0, 0);
    
    void Start()
    {
        clouds = new GameObject[4];
        cubes = new GameObject [10];
        cubes2 = new GameObject[10];
        backgrounditems = new GameObject[3];
        createevrything();
    }

   public void mover(  )
    {

        player.transform.position = _creater.transform.position + new Vector3(0.2f, 0, 0);
     

    }
   
    public void getcube2()
    {
        int control=0;
        foreach (var cube in cubes)
        {
            float y = Random.Range(-1, 2);
            cube.SetActive(true);
            var _cube = cube;
            if (_midlecube == null&&control==3) { _midlecube = _cube;
               
            }
            control++;
            _cube.transform.position = _lastcube.transform.position + new Vector3(2.5f, y, 0);
            _lastcube = _cube;
        }
        


        _creater.transform.position = _midlecube.transform.position +staticvec;
        _midlecube = null;
        cube1 = false;
        start = false;
       
        
    }
   public void getcube()
    {
        int control = 0;
        foreach (var cube in cubes2)
        {
            float y = Random.Range(-1, 2);
            cube.SetActive(true);
            var _cube = cube;
            if (_midlecube == null && control == 3) {   _midlecube = _cube; }
            control++;
            _cube.transform.position = _lastcube.transform.position + new Vector3(2.5f, y, 0);
            _lastcube = _cube;
        } 
        
        
        _creater.transform.position = _midlecube.transform.position + staticvec;
        _midlecube = null;

        
            float yk = Random.Range(-1, 2);
            int rand = Random.Range(0, backgrounditems.Length);
            backgrounditems[rand].SetActive(true);

            backgrounditems[rand].transform.position = _lastbackgrounditem.transform.position + new Vector3(17, yk, 2);
         
        foreach (var cloud in clouds)
        {

            float y = Random.Range(-1, 2);
            cloud.SetActive(true);
            var _cloud = cloud;
            _cloud.transform.position = _lastcloud.transform.position + new Vector3(5, y, 0);
            _lastcloud = _cloud;
        }
        cube1 = true;
        start = false;
        
    }
    
    void createevrything()
    {
        for (int i = 0; i < cubes.Length; i++)
        {
            random = Random.Range(0, realcubes.Length);
            var _cube = Instantiate(realcubes[random]);
            _cube.SetActive(false);
            cubes[i] = _cube;

        }
        for (int i = 0; i < cubes2.Length; i++)
        {
            random = Random.Range(0, real_cubes2.Length);
            var _cube = Instantiate(real_cubes2[random]);
            _cube.SetActive(false);
            cubes2[i] = _cube;

        }
        for (int i = 0; i < clouds.Length; i++)
        {
            random = Random.Range(0, real_clouds.Length);
            var cloud = Instantiate(real_clouds[random]);
            cloud.SetActive(false);
            clouds[i] = cloud;
        }
        for(int i = 0; i < backgrounditems.Length; i++)
        {
            random = Random.Range(0, real_backgrounditem.Length);
            var backgrounditem = Instantiate(real_backgrounditem[random]);
            backgrounditems[i] = backgrounditem;
            backgrounditem.SetActive(false);
        }
         
        
    }
      void Update()
    {
         
       
        if (start == true&&cube1==false  ) getcube();
        if (start == true && cube1 == true  ) getcube2();
        
        
    }
}
