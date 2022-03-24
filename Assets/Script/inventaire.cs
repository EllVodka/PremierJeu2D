using UnityEngine;
using UnityEngine.UI;

public class inventaire : MonoBehaviour
{
    public int compteurPiece;

    public static inventaire instance;
    public Text compteurPieceText;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de Inventaire dans la scène");
            return;
        }
        instance = this;
    }
    public void AjoutPiece(int count)
    {
        compteurPiece += count;
        compteurPieceText.text = compteurPiece.ToString();
    }

    public void EnlevePiece(int count)
    {
        compteurPiece -= count;
        compteurPieceText.text = compteurPiece.ToString();
    }
}
