using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightManager : MonoBehaviour
{

    public GameObject[] airports;

    public GameObject airplane;

    private int num_airplanes;

    // Start is called before the first frame update
    void Start()
    {
        num_airplanes = Random.Range(1, 10); 
        for (int i = 0; i < num_airplanes; i++)
        {
            StartCoroutine(SpawnAirplanes());   
        }       
    }

    IEnumerator SpawnAirplanes()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        int departure_index;
        int arrival_index;

        departure_index = Random.Range(0, airports.Length);
        do 
        {
            arrival_index = Random.Range(0, airports.Length);
        } while(arrival_index == departure_index);

        GameObject departure_airport = airports[departure_index];
        GameObject arrival_airport = airports[arrival_index];

        Vector3 departure_position = departure_airport.transform.position;
        Vector3 arrival_position = arrival_airport.transform.position;

        // Instantiate at position (0, 0, 0) and zero rotation.
        GameObject spawnedAirplane = Instantiate(airplane, new Vector3(0, 0, 0), Quaternion.identity);
        spawnedAirplane.SetActive(true);
        spawnedAirplane.GetComponent<AirplaneManager>().startingV = departure_position;
        spawnedAirplane.GetComponent<AirplaneManager>().endingV = arrival_position;

        int timer = Random.Range(5,20);
        //yield on a new YieldInstruction that waits for a random range of seconds.
        yield return new WaitForSeconds(2f);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
}
