using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonFunctions : MonoBehaviour
{
    [SerializeField] InputField username;
    [SerializeField] Slider volumeSlider;
    // Start is called before the first frame update
    void Start()
    {
        if (username == null && SceneManager.GetActiveScene().name == "Main Menu") {
            username = GameObject.Find("Name").GetComponent<InputField>();
            username.text = PersistentData.Instance.GetName();
            AudioListener.volume = .5f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToInstruction()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void PlayGame()
    {
        string name = username.text;
        PersistentData.Instance.SetName(name);
        SceneManager.LoadScene("Scene1");
    }

    public void LoadMenu()
    {
        PersistentData.Instance.SetScore(0);
        SceneManager.LoadScene("Main Menu");
    }

    public void ChangeVolume() {
        AudioListener.volume = volumeSlider.value;
    }
}
