using System.Collections;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject patientPrefab;
    public int maxPatients;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true) // Bucle infinit del spawner
        {

            // També podriem emprar aquesta línia sense haver de modificar la classe GWorld si li posam un tag
            // if (GameObject.FindGameObjectsWithTag("Patient").Length < 8)
            if (GWorld.Instance.GetNumPatients() < maxPatients)
            {
                SpawnPatient();
                yield return new WaitForSeconds(Random.Range(2,10));
            }
            else
            {
                // Si ja n'hi ha 8, esperem un temps curt abans de tornar a comprovar
                // Això evita que el script consumeixi massa recursos
                yield return new WaitForSeconds(2);
            }
        }
    }
    void SpawnPatient()
    {
        Instantiate(patientPrefab, this.transform.position, Quaternion.identity);
        GWorld.Instance.increasePatientsCount();
    }
}
