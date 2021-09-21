using UnityEngine;
using UnityEngine.UI;

public class HomeButton : MonoBehaviour
{
    [SerializeField] Button HomeOffLine = null;
    [SerializeField] Button HomeOnLine = null;
    [SerializeField] GameObject Lobby = null;
    [SerializeField] GameObject PlayerSearch = null;
    [SerializeField] GameObject GameBoard = null;

    private void Start()
    {
        HomeOffLine.onClick.AddListener(delegate
        {
            PlayerSearch.SetActive(false);
            GameBoard.SetActive(false);
            Lobby.SetActive(true);
        });
        HomeOnLine.onClick.AddListener(delegate
        {
            PlayerSearch.SetActive(false);
            GameBoard.SetActive(false);
            Lobby.SetActive(true);
        });
    }

}
