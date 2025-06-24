using TMPro;
using UnityEngine;

public class EmptyTemplate : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI numberText;

    public void SetNumber(int nbr)
    {
        numberText.text = nbr.ToString();
    }

}
