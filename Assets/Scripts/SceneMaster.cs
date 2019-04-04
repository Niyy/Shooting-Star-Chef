using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneMaster : MonoBehaviour
{
    public bool endLevelOutOfBounds;


    private GameObject food;


    public void ChangeScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }


    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag.Equals("Food") && endLevelOutOfBounds)
        {
            Debug.Log("Food as left our solar system.");
            this.ChangeScene(3);
        }
    }
}
