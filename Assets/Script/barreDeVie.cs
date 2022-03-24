using UnityEngine;
using UnityEngine.UI;

public class barreDeVie : MonoBehaviour
{
    public Slider slider;

    public Gradient gradient;
    public Image remplir;
    public void SetMaxVie(int Vie)
    {
        slider.maxValue = Vie;
        slider.value = Vie;

        //couleur d'element de remplissage = a 1f qui est full hp
        remplir.color= gradient.Evaluate(1f);
    }

    public void SetVie(int vie)
    {
        slider.value = vie;

        //normalizedValue transforme les hp a un chiffre en 0 et 1 pour recupere la bonne couleur
        remplir.color = gradient.Evaluate(slider.normalizedValue);
    }
}
