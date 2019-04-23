using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneMaster : MonoBehaviour
{
    private GameObject food;


    public void ChangeScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }


    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag.Equals("Food"))
        {
            Debug.Log("Food as left our solar system.");
            Destroy(col.gameObject);
        }
    }


    public int GetCurrentScene()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
}
