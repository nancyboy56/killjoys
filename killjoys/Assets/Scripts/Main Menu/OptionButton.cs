using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button b = GetComponent<Button>();
        b.onClick.AddListener(NextScene);
    }

    public void NextScene()
    {
        SceneManager.LoadScene("Options");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
