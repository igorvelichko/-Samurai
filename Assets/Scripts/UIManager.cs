using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{


    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
