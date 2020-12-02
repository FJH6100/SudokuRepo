using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    InputField[,] Spaces = new InputField[9, 9];
    Button CheckButton;
    Text WinText;
    string[,] Puzzle ={{"53**7****",
                        "6**195***",
                        "*98****6*",
                        "8***6***3",
                        "4**8*3**1",
                        "7***2***6",
                        "*6****28*",
                        "***419**5",
                        "****8**79"},
                       {"***26*7*1",
                        "68**7**9*",
                        "19***45**",
                        "82*1***4*",
                        "**46*29**",
                        "*5***3*28",
                        "**93***74",
                        "*4**5**36",
                        "7*3*18***"},
                       {"1**489**6",
                        "73*****4*",
                        "*****1295",
                        "**712*6**",
                        "5**7*3**8",
                        "**6*957**",
                        "9146*****",
                        "*2*****37",
                        "8**512**4"} };
    void Check()
    {
        for (int j = 0; j < 9; j++)
        {
            List<string> RowNums = new List<string>();
            for (int k = 0; k < 9; k++)
            {
                if (!RowNums.Contains(Spaces[j, k].text) && Spaces[j, k].text != null && Spaces[j, k].text != "0")
                    RowNums.Add(Spaces[j, k].text);
                else
                    return;
            }
        }
        for (int j = 0; j < 9; j++)
        {
            List<string> ColumnNums = new List<string>();
            for (int k = 0; k < 9; k++)
            {
                if (!ColumnNums.Contains(Spaces[k, j].text) && Spaces[k, j].text != null && Spaces[j, k].text != "0")
                    ColumnNums.Add(Spaces[k, j].text);
                else
                    return;
            }
        }
        List<string> SquareNums = new List<string>();
        for (int j = 0; j < 3; j++)
        {
            for (int k = 0; k < 3; k++)
            {
                if (!SquareNums.Contains(Spaces[j, k].text) && Spaces[j, k].text != null && Spaces[j, k].text != "0")
                    SquareNums.Add(Spaces[j, k].text);
                else
                    return;
            }
            SquareNums.Clear();
            for (int k = 3; k < 6; k++)
            {
                if (!SquareNums.Contains(Spaces[j, k].text) && Spaces[j, k].text != null && Spaces[j, k].text != "0")
                    SquareNums.Add(Spaces[j, k].text);
                else
                    return;
            }
            SquareNums.Clear();
            for (int k = 6; k < 9; k++)
            {
                if (!SquareNums.Contains(Spaces[j, k].text) && Spaces[j, k].text != null && Spaces[j, k].text != "0")
                    SquareNums.Add(Spaces[j, k].text);
                else
                    return;
            }
            SquareNums.Clear();
        }
        for (int j = 3; j < 6; j++)
        {
            for (int k = 0; k < 3; k++)
            {
                if (!SquareNums.Contains(Spaces[j, k].text) && Spaces[j, k].text != null && Spaces[j, k].text != "0")
                    SquareNums.Add(Spaces[j, k].text);
                else
                    return;
            }
            SquareNums.Clear();
            for (int k = 3; k < 6; k++)
            {
                if (!SquareNums.Contains(Spaces[j, k].text) && Spaces[j, k].text != null && Spaces[j, k].text != "0")
                    SquareNums.Add(Spaces[j, k].text);
                else
                    return;
            }
            SquareNums.Clear();
            for (int k = 6; k < 9; k++)
            {
                if (!SquareNums.Contains(Spaces[j, k].text) && Spaces[j, k].text != null && Spaces[j, k].text != "0")
                    SquareNums.Add(Spaces[j, k].text);
                else
                    return;
            }
            SquareNums.Clear();
        }
        for (int j = 6; j < 9; j++)
        {
            for (int k = 0; k < 3; k++)
            {
                if (!SquareNums.Contains(Spaces[j, k].text) && Spaces[j, k].text != null && Spaces[j, k].text != "0")
                    SquareNums.Add(Spaces[j, k].text);
                else
                    return;
            }
            SquareNums.Clear();
            for (int k = 3; k < 6; k++)
            {
                if (!SquareNums.Contains(Spaces[j, k].text) && Spaces[j, k].text != null && Spaces[j, k].text != "0")
                    SquareNums.Add(Spaces[j, k].text);
                else
                    return;
            }
            SquareNums.Clear();
            for (int k = 6; k < 9; k++)
            {
                if (!SquareNums.Contains(Spaces[j, k].text) && Spaces[j, k].text != null && Spaces[j, k].text != "0")
                    SquareNums.Add(Spaces[j, k].text);
                else
                    return;
            }
            SquareNums.Clear();
        }
        WinText.text = "You Win!";
        for (int j = 0; j < 9; j++)
        {
            for (int k = 0; k < 9; k++)
            {
                Spaces[j, k].image.color = Color.green;
                Spaces[j, k].enabled = false;
            }
        }
    }
    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int j = 0; j < 9; j++)
        {
            for (int k = 0; k < 9; k++)
            {
                string FieldName = j.ToString() + k.ToString();
                InputField ThisField = GameObject.Find(FieldName).GetComponent<InputField>();
                Spaces[j, k] = ThisField;
            }
        }
        CheckButton = GameObject.Find("CheckButton").GetComponent<Button>();
        CheckButton.onClick.AddListener(Check);
        WinText = GameObject.Find("WinText").GetComponent<Text>();
        GameObject.Find("Restart").GetComponent<Button>().onClick.AddListener(RestartGame);
        int RandomIndex = Random.Range(0, 3);
        string[] ThisPuzzle = new string[9];
        for (int i = 0; i < ThisPuzzle.Length; i++)
        {
            ThisPuzzle[i] = Puzzle[RandomIndex, i];
        }
        for (int j = 0; j < 9; j++)
        {
            for (int k = 0; k < 9; k++)
            {
                if (ThisPuzzle[j][k] != '*')
                {
                    Spaces[j, k].text = ThisPuzzle[j][k].ToString();
                    Spaces[j, k].image.color = Color.green;
                    Spaces[j, k].enabled = false;
                }
            }
        }
    }
}
