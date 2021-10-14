using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private GameObject danceCam;

    public GameObject[] Levels;
    
    public Text current, nextLevel;
   
    private void Awake()
    {
        danceCam = GameObject.FindGameObjectWithTag("danceCam");

        if(PlayerPrefs.HasKey("firstLevelControl") == false)
        {
            PlayerPrefs.SetInt("Level", 1);

            PlayerPrefs.SetInt("firstLevelControl", 1);
        }
        
        LevelControl();

        SliderTextControl();
        
    }

    void SliderTextControl()
    {
         
        current.text = PlayerPrefs.GetInt("Level").ToString();

        nextLevel.text = (PlayerPrefs.GetInt("Level") + 1).ToString();

    }


    void LevelControl()
    {
        if(PlayerPrefs.GetInt("Level") == 1)
        {
            danceCam.transform.localPosition = new Vector3(-1.21f, -10.43f, 0.82f);
           
            Instantiate(Levels[0]);
            
        }
        else if(PlayerPrefs.GetInt("Level") == 2)
        {
            danceCam.transform.localPosition = new Vector3(-1.21f, -10.43f, 0.82f);
            Instantiate(Levels[1]);
        }
        else if (PlayerPrefs.GetInt("Level") == 3)
        {
            danceCam.transform.localPosition = new Vector3(-1.21f, -10.43f, 0.82f);
            Instantiate(Levels[2]);
        }
        else if (PlayerPrefs.GetInt("Level") == 4)
        {
            danceCam.transform.localPosition = new Vector3(-1.21f, -10.43f, 0.82f);
            Instantiate(Levels[3]);
        }
        else if (PlayerPrefs.GetInt("Level") == 5)
        {
            danceCam.transform.localPosition = new Vector3(-1.21f, -10.43f, 0.82f);
            Instantiate(Levels[4]);
        }
        else if (PlayerPrefs.GetInt("Level") == 6)
        {
            Instantiate(Levels[5]);

            danceCam.transform.localPosition = new Vector3(0.30f, -11.1f, 148.46f);
        }
        else if (PlayerPrefs.GetInt("Level") == 7)
        {
            Instantiate(Levels[6]);

            danceCam.transform.localPosition = new Vector3(0.30f, -11.1f, 148.46f);
        }
        else if (PlayerPrefs.GetInt("Level") == 8)
        {
            Instantiate(Levels[7]);
            danceCam.transform.localPosition = new Vector3(0.30f, -11.1f, 148.46f);
        }
        else
        {
            int randomLevel = Random.Range(0, Levels.Length);

            if(randomLevel == 5 || randomLevel == 6 || randomLevel == 7)
            {
                danceCam.transform.localPosition = new Vector3(0.30f, -11.1f, 148.46f);
            }
            else
            {
                danceCam.transform.localPosition = new Vector3(-1.21f, -10.43f, 0.82f);
            }

            Instantiate(Levels[randomLevel]);   // SPAWN RANDOM LEVEL
        }
    }
}
