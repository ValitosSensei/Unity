using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Calibra : MonoBehaviour
{
    [Header("Object")]
    public GameObject[] calibras; // Масив баліст
    public  GameObject[] stones; // Масив каменів гравців
    [Header("Mas")]
    private int currentPlayerIndex = 0; // Індекс поточного гравця
    private int[] playerDirections = { 1, -1 }; // Напрямки кидків гравців
    [Header("Stats")]
    private float power; // Сила балісти
    private float angle; // кут пострілу
    private float mass; // Маса снаряду
    [Header("Slider")]
    public Slider angleSlider;//слайдер кута пострілу
    public InputField powerField;// строка сили пострілу
    public Slider massSlider;//слайдер маси санряду
    
    [Header("Text")]
    public  TMP_Text MassText;//текст маси
    public TMP_Text AngleText;//текст кута
    public TMP_Text PowerText;//текст сили 
    public  TMP_Text Player;//текс номер гравця


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
            ResetStat();
            
        }

        angle = angleSlider.value;
        AngleText.text = "Кут пострілу:" + angle.ToString("F0") + "°";
        mass = massSlider.value;
        MassText.text = "Маса каменю:" + mass.ToString("F2") + " кг";

        float.TryParse(powerField.text, out power);
        PowerText.text = "Сила кидку:" + power.ToString("F0");

        Player.text = "Player:" + (currentPlayerIndex + 1).ToString("");
    }

    public void Shoot()
    {
        if (currentPlayerIndex < calibras.Length)
        {
            GameObject currentPlayerCalibra = calibras[currentPlayerIndex];
            GameObject currentPlayerStone = stones[currentPlayerIndex];
            Vector3 launchPosition = currentPlayerCalibra.transform.position;
            GameObject projectile = Instantiate(currentPlayerStone, launchPosition, Quaternion.identity) as GameObject;
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.mass = mass;

            float radians = angle * Mathf.Deg2Rad;
            Vector3 direction = new Vector3(playerDirections[currentPlayerIndex] * Mathf.Cos(radians), Mathf.Sin(radians), 0);
            rb.AddForce(direction * power, ForceMode.Impulse);

            currentPlayerIndex++;
        }

        if (currentPlayerIndex >= calibras.Length)
        {
            currentPlayerIndex = 0; 
           
        }

            
    }
    private void ResetStat()
    {
        angleSlider.value = 0;
        massSlider.value = 0;    
        powerField.text =    null; 
    }
    
}