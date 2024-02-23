
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public int Count, Life;
    [SerializeField]
    TMP_Text CountDisplay, LifeDisplay;

    // Start is called before the first frame update
    void Start()
    {
        Count = 0;
        CountDisplay.text = Count.ToString();

        Life = 4;
        LifeDisplay.text = Life.ToString();
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Next()
    {
        SceneManager.LoadScene(2);
    }

    public void Return()
    {
        SceneManager.LoadScene(0);
    }

    public void MushroomCount(string add)
    {
        if (add == "Add")
        {
            Count++;
        }
        
        if (add == "Minus")
        {
            Count--;
        }

        CountDisplay.text = Count.ToString();
    }

    public void LifeCount()
    {
        Life--;
        LifeDisplay.text = Life.ToString();
    }

    // Update is called once per frame
    void Update()
    {

        if (Count <= 0)
        {
            Count = 0;
        }

        if (Life == 0)
        {
            SceneManager.LoadScene(3);
        }
    }
}
