using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        Button play = root.Q<Button>("Play");
        Button quit = root.Q<Button>("Quit");

        play.clicked += PlayClicked;
        quit.clicked += QuitClicked;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayClicked()
    {
        Debug.Log("Play Button Clicked");
    }

    void QuitClicked()
    {
        Debug.Log("Quit Button Clicked");
    }
}
