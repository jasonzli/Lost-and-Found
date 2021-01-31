using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour
{
    [SerializeField]
    private int animalCount = 10;
    [SerializeField]
    private int foodCount = 10;
    [SerializeField]
    private GameObject animalPrefab;
    [SerializeField]
    Vector2 terrainSize;
    [SerializeField]
    private Camera animalCam;

    [SerializeField]
    private GameObject primaryAnimal;

    private GameObject[] animals;

    void Start(){
        animals = NewAnimalArray(animalCount);
        primaryAnimal = SelectPrimaryAnimal();
        primaryAnimal.GetComponent<Animal>().SetCameraToTransform(animalCam.transform);
        primaryAnimal.GetComponent<Animal>().BecomePrimal();
    }

    GameObject[] NewAnimalArray(int count) {
        GameObject[] newAnimals = new GameObject[count];
        
        for( int i = 0 ; i < newAnimals.Length; i++){
            newAnimals[i] = NewAnimal();
        }
        return newAnimals;
    }

    GameObject NewAnimal(){
        Vector3 pos = new Vector3 ( Random.Range(-terrainSize.x,terrainSize.x), 0, Random.Range(-terrainSize.y,terrainSize.y));
        var gO = Instantiate (animalPrefab, pos, Quaternion.identity, transform);
        return gO;
    }

    GameObject SelectPrimaryAnimal(){
        int pIndex = Random.Range(0,animals.Length);
        return animals[pIndex];
    }

    
}