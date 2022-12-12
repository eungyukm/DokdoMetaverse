using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ViewPointController : MonoBehaviour
{
    public GameObject firstPerson;
    public GameObject thirdPerson;
    public void ClickFirstPersonView()
    {
        firstPerson.SetActive(true);
        thirdPerson.SetActive(false);
    }
    public void ClickThirdPersonView()
    {

        firstPerson.SetActive(false);
        thirdPerson.SetActive(true);
    }

    public void ClickSceneAR()
    {
        SceneManager.LoadScene("Hand2DSkeleton_Ring");
    }
}
