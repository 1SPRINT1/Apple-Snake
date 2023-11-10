using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Snake : MonoBehaviour
{
    public List<Transform> Tail;
    [Range(0, 10)]
    public float Speed;
    [Range(0, 3)]
    public float BonesDistance;
    public GameObject BonePrefab;

    public UnityEvent OnEat;

    private Transform _transform;

    [Space(30)] [Header("SaveCountApples")]
    public int CountAppel;
    public GameObject FinishPanel;
    public int Currentscore;

    private void Start()
    {
        _transform = GetComponent<Transform>();
    }
    private void Update()
    {
        MoveSnake(_transform.position + _transform.forward * Speed * Time.deltaTime);
        float angel = Input.GetAxis("Horizontal") * 1;
        _transform.Rotate(0, angel, 0);
        if (Currentscore > CountAppel)
        {
            CountAppel = Currentscore;
            PlayerPrefs.SetInt("Apples",CountAppel);
        }
        if (Currentscore == 5)
        {
            FinishPanel.SetActive(true);
        }

        CountAppel = PlayerPrefs.GetInt("Apples");
    }
    private void MoveSnake(Vector3 newPostion)
    {
        float sqrDistance = BonesDistance * BonesDistance;
        Vector3 lastBone = _transform.position;
        foreach (var bone in Tail)
        {
            if ((bone.position - lastBone).sqrMagnitude > sqrDistance)
            {
                var temp = bone.position;
                bone.position = lastBone;
                lastBone = temp;
            }
            else
            {
                break;
            }
        }
        _transform.position = newPostion;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            Destroy(collision.gameObject);
            var bone = Instantiate(BonePrefab);
            Tail.Add(bone.transform);
            Currentscore++;
        }
    }

    public void Home()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
