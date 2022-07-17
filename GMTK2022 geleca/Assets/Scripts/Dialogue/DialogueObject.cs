using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/DialogueObject")]
public class DialogueObject : ScriptableObject
{
    [SerializeField] [TextArea] private string[] sentence;
    public string[] Sentence => sentence;

    [SerializeField] private Sprite sprite;
    public Sprite Expression => sprite;

    [SerializeField] private AudioClip sound;
    public AudioClip Sound => sound;
}
