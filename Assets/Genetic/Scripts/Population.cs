using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Population : MonoBehaviour
{
    public GameObject individual;
    public GameObject Goal;
    public GameObject Champion;


    public int NrOfIndividuals = 10;
    public GameObject[] Individuals;
    public float FitnessSum = 0;

    private Vector2 spawn = new Vector2(-12.55f,-0.65f);
    private long k = 0;
    private float MutationRate = 0.02f;


    void Start()
    {
        Time.timeScale = 5.0f;
        Individuals = new GameObject[NrOfIndividuals];
        SpawnPlayers();

    }
 

    void FixedUpdate()
    {
        if (k % 5 == 0)
        {

            if (AllDead())
            {
                NaturalSelection();
                Champion.GetComponent<Individual>().SetAsChampion();
               StartCoroutine(PauseAndRespawn());

            }
            else
            {
                for (int i = 0; i < NrOfIndividuals; i++)
                {
                    if (Individuals[i].GetComponent<Rigidbody2D>().velocity.magnitude < Individual.MaxSpeed)
                    {
                        if (Individuals[i].GetComponent<Individual>().iterator >= Individual.CromozomSize)
                        {
                            Individuals[i].GetComponent<Individual>().Die();
                        }
                        else
                        {
                            Individuals[i].GetComponent<Individual>().MoveIndividual();
                        }
                    }
                }
            }
        }
         k++;

    }
    IEnumerator PauseAndRespawn()
    {
        enabled = false;
        yield return new WaitForSeconds(1.0f);
        enabled = true;

        RespawnAll();



    }

    private void RespawnAll()
    {
        for (int i = 0; i < NrOfIndividuals; i++)
        {
            Individuals[i].GetComponent<Individual>().Respawn();

        }
        Individuals[0].GetComponent<Individual>().SetAsChampion();


    }



    void SpawnPlayers()
    {
        GameObject individual_x;
        for (int i = 0; i < NrOfIndividuals; i++)
        {
            individual_x = Instantiate(individual, spawn, Quaternion.identity) as GameObject;
            Individuals[i] = individual_x;
            Individuals[i].GetComponent<Individual>().DistToGoalFromSpawn = Vector2.Distance(Individuals[i].transform.position, Goal.transform.position);
        }
    }
    private bool AllDead()
    {
        for (int i = 0; i < NrOfIndividuals; i++)
        {
            if (!Individuals[i].GetComponent<Individual>().dead)
                return false;
        }
        return true;

    }
    private void SetChampion()
    {
        float BestScore = Vector2.Distance(Individuals[0].transform.position, Goal.transform.position);
        Champion = Individuals[0];

        for (int i = 0; i < NrOfIndividuals; i++)
        {
            float DistanceOfCurrentIndividualToGoal = Vector2.Distance(Individuals[i].transform.position, Goal.transform.position);
            if (DistanceOfCurrentIndividualToGoal < BestScore)
            {
                BestScore = DistanceOfCurrentIndividualToGoal;
                Champion = Individuals[i];
            }
        }
    }

    private void NaturalSelection()
    {
        SetChampion();
        CalculateFitness();
        CalculateFitnessSum();

        CopyCromozom(Individuals[0], Champion);

        for (int i = 1; i < NrOfIndividuals; i++)
        {
            GameObject Parent = Selectie_MetodaRuletei();
            CopyCromozom(Individuals[i], Parent);
            Mutatie_Metoda(Individuals[i]);

        }

    }

    private void CalculateFitness()
    {
        for (int i = 0; i < NrOfIndividuals; i++)
        {
            float DistanceOfCurrentIndividualToGoal = Vector2.Distance(Individuals[i].transform.position, Goal.transform.position);

            if (Individuals[i].GetComponent<Individual>().ReachedTheGoal)
            {
                int Step = Individuals[i].GetComponent<Individual>().iterator;
                float DistToGoalFromSpawn = Individuals[i].GetComponent<Individual>().DistToGoalFromSpawn;
                Individuals[i].GetComponent<Individual>().Fitness = 1.0f / 24 + DistToGoalFromSpawn * 100 / (Step * Step);
            }
            else
            {
                Individuals[i].GetComponent<Individual>().Fitness = 10.0f / (DistanceOfCurrentIndividualToGoal * DistanceOfCurrentIndividualToGoal * DistanceOfCurrentIndividualToGoal * DistanceOfCurrentIndividualToGoal);
            }
        }
    }

    private void CalculateFitnessSum()
    {
        FitnessSum = 0;
        for (int i = 0; i < NrOfIndividuals; i++)
        {
            FitnessSum += Individuals[i].GetComponent<Individual>().Fitness;
        }
    }

    private void CopyCromozom(GameObject I1,GameObject I2)
    {
        for (int i = 0; i <Individual.CromozomSize ; i++)
        {
            I1.GetComponent<Individual>().Cromozom[i][0] = I2.GetComponent<Individual>().Cromozom[i][0];
            I1.GetComponent<Individual>().Cromozom[i][1] = I2.GetComponent<Individual>().Cromozom[i][1];
        }
    }

    private GameObject Selectie_MetodaRuletei()
    {
        float RandomSelector = Random.Range(0.0f, FitnessSum);
        float SelectorScanare = 0;

        for (int i = 0; i < NrOfIndividuals; i++)
        {
            SelectorScanare += Individuals[i].GetComponent<Individual>().Fitness;

            if(SelectorScanare>=RandomSelector)
            {
                return Individuals[i];
            }
        }
        return null;
    }

    private void Mutatie_Metoda(GameObject I)
    {
        for (int i = 0; i < Individual.CromozomSize; i++)
        {
            float Rand = Random.Range(0.0f, 1.0f);
            if(Rand<MutationRate)
            {
                I.GetComponent<Individual>().Cromozom[i] = new Vector2(Random.Range(10, -11), Random.Range(10, -11));
            }
        }
    }
}
