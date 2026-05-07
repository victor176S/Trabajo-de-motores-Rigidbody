using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{

    public NetworkTicTacToe game;

    public Button[] buttons;

    public TextMeshProUGUI turnText;

    public TextMeshProUGUI endGameText;

    // Update is called once per frame

    void Start()
    {
        InvokeRepeating(nameof(FindGame), 0.5f, 0.5f);
        
        for (int i = 0; i < buttons.Length; i++)
        { 
            int index = i;
            buttons[i].onClick.AddListener(() => game.TryTurn(index));
        }
    }
    void Update()
    {
        if(game == null) return;

        for(int i = 0; i < 9; i++)
        {
            int var = game.Board.Get(i);

            buttons[i].GetComponentInChildren<TMP_Text>().text = var == 0 ? "" : 
                                                                 var == 1 ? "X" : "O";
        }

        turnText.text = game.EndGame ? "Final de Partida" : $"Turno: {game.ThisTurn}";
    }

    void FindGame()
    {
        if (game == null)
        {
            game = FindAnyObjectByType<NetworkTicTacToe>();
        }
    }
}
