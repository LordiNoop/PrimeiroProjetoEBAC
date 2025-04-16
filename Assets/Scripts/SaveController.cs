using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveController : MonoBehaviour
{
    public static SaveController instance;

    public Color colorPlayer = Color.white;
    public Color colorEnemy = Color.white;

    public string namePlayer;
    public string nameEnemy;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public string GetName(bool isPlayer)
    {
        if (namePlayer.Length < 1)
        {
            namePlayer = "Player1";
        }
        if (nameEnemy.Length < 1)
        {
            nameEnemy = "Player2";
        }
        return isPlayer ? namePlayer : nameEnemy;
    }

    public void Reset()
    {
        nameEnemy = "";
        namePlayer = "";
        colorEnemy = Color.white;
        colorPlayer = Color.white;
    }

    public void SaveWinner(string winner)
    {
        PlayerPrefs.SetString("SavedWinner", winner);
    }

    public string GetLastWinner()
    {
        return PlayerPrefs.GetString("SavedWinner");
    }

    public void ClearSave()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
