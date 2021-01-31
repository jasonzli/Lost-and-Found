using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyButtons;

public class TreePlanter : MonoBehaviour
{

    [SerializeField]
    private List<GameObject> treePrefabs = new List<GameObject>();
    [SerializeField]
    private List<GameObject> rockPreFabs = new List<GameObject>();

    private List<GameObject> placedTrees = new List<GameObject>();
    private List<GameObject> placedRocks = new List<GameObject>();
    [SerializeField]
    private int numOfTrees = 100;
    [SerializeField]
    private int numOfRocks = 20;
    [SerializeField]
    private Vector2 treeScale;
    [SerializeField]
    private Vector2 rockScale;
    [SerializeField]
    private float minDistance = 10f;
    [SerializeField]
    private Vector4 placementRange;


    [Button]
    void SpawnTrees(){
        int treesPlaced = 0;
        int attempts = 0;
        while( treesPlaced < numOfTrees ){

            attempts++;
            Vector3 pos = new Vector3( Random.Range(placementRange.x,placementRange.y), 0, Random.Range(placementRange.z,placementRange.w));
            float randScale = Random.Range(1f,6f);
            bool valid = true;
            for ( int i = 0; i < placedTrees.Count; i++){
                GameObject t = placedTrees[i];
                if ( Vector3.Distance(t.transform.position, pos) < minDistance * t.transform.localScale.x){
                    valid = false;
                    break;
                }
            }
            if (valid){
                attempts = 0;
                GameObject go = Instantiate(treePrefabs[Random.Range(0,treePrefabs.Count)], pos, Quaternion.identity);
                var tScale = Random.Range(treeScale.x,treeScale.y);
                go.transform.localScale = new Vector3(tScale,tScale,tScale);
                go.transform.Rotate(new Vector3( 0, Random.Range(-180f,180f), 0));
                placedTrees.Add(go);
                treesPlaced++;
            }

            if (attempts > 1000){
                break;
            }
        }
    }

    //a parametric form of the spawning eq
    void SpawnPrefab( GameObject go){}

    void SpawnRocks(){
        int rocksPlaced = 0;
        int attempts = 0;
        while( rocksPlaced < numOfRocks ){

            attempts++;
            Vector3 pos = new Vector3( Random.Range(placementRange.x,placementRange.y), 0, Random.Range(placementRange.z,placementRange.w));
            float randScale = Random.Range(1f,6f);
            bool valid = true;
            for ( int i = 0; i < placedTrees.Count; i++){
                GameObject t = placedTrees[i];
                if ( Vector3.Distance(t.transform.position, pos) < 1.2*minDistance * t.transform.localScale.x){
                    valid = false;
                    break;
                }
            }
            for ( int i = 0; i < placedRocks.Count; i++){
                GameObject t = placedRocks[i];
                if ( Vector3.Distance(t.transform.position, pos) < .4*minDistance * t.transform.localScale.x){
                    valid = false;
                    break;
                }
            }       
            if (valid){
                attempts = 0;
                GameObject go = Instantiate(rockPreFabs[Random.Range(0,rockPreFabs.Count)], pos, Quaternion.identity);
                var tScale = Random.Range(rockScale.x,rockScale.y);
                go.transform.localScale = new Vector3(tScale,tScale,tScale);
                go.transform.Rotate(new Vector3( 0, Random.Range(-180f,180f), 0));
                placedRocks.Add(go);
                rocksPlaced++;
            }

            if (attempts > 1000){
                break;
            }
        }
    }

    void Reset(){
        placedTrees = new List<GameObject>();
        placedRocks = new List<GameObject>();
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnTrees();
        SpawnRocks();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
