using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhrasesPull : MonoBehaviour
{
    public List<string> start = new List<string>
    {
        "There are always a few`(adjective)`Mark Browns every year. This year, this Mark Brown was my favorite.",
        "A common theme this year among`(adjective)`Mark Browns was Mark Brown.",
        "One`(adjective)`take on Mark Brown this year was Mark Brown.",
        "This is another`(adjective)`Mark Brown, but with a completely different`(noun)`.",
        "This Mark Brown uses`(noun)`as inspiration for his`(noun)`.",
        "There's always something fun about Mark Brown when he`(verb)`. This Mark Brown is a great example of that.",
        "Mark Brown doesn't always have to be`(adjective)`. This Mark Brown proves just that.",
        "One of the more creative twists on Mark Brown, was using his`(noun)`as his`(noun)`instead.",
        "In this Jam there were a lot of Mark Browns where he was wearing a(n)`(noun)`. This is my favorite take on the idea.",
        "Another ultra-popular Mark Brown was`(adjective)`Mark Brown.",
        "In terms of outside-the-box creativity,`(adjective)`Mark Brown takes the cake.",
        "Would it really be a Mark Brown Jam, if there wasn't a(n)`(adjective)`Mark Brown",
        "As always, here's an honorable mention.",
    };
    public List<string> mid = new List<string>
    {
        "I really enjoyed his`(adjective)`eyes, and the fact that they`(verb)`when open.",
        "The juice in this one is just right. It feels`(adjective)`to just`(verb)`with him.",
        "Mark Brown can`(verb)`in any direction, but is limited by the number of`(nouns)`he has.",
        "This Mark Brown borrows from many other people for his`(noun)`.",
        "When Mark Brown`(verb)`, he also end up`(verb-ing)`.",
        "This Mark Brown has a great twist, where his`(noun)`is upside-down.",
        "Because his`(noun)` is tied to his leg, it really makes the way he`(verb)`more engaging.",
        "This Mark Brown uses a`(noun)`to move around, like a(n)`(noun)`.",
        "That's right, he has a(n)`(noun)`, which lead to some pretty crazy looks.",
        "He's wearing a charming`(noun)`which really matches his`(noun)`.",
        "He`(verb)`, every time he`(verb)`, which leads to a pretty chaotic person.",
        "His skin is`(adjective)`, which allows him to`(verb)`.",
        "He can`(verb)`like any other Mark Brown, but he can also`(verb)`backwards.",
    };
    public List<string> end = new List<string>
    {
        "This gives him an extra layer of`(noun)`, without making him feel too`(adjective)`.",
        "I could definitely see this Mark Brown expanded further, maybe even into a full person",
        "Although enjoyable, I think it might be more fun to give him a few more`(nouns)`.",
        "In terms of feedback, I would perhaps make his`(noun)`a bit more`(adjective)`",
        "I had a ton of fun seeing how`(adjective)`things could get.",
        "His`(noun)`is a wonderful example of why it's important to think outside the box, when following the theme.",
        "My only suggestion is, give him a(n)`(noun)`.",
        "This Mark Brown exceeds expectations. Buy this Mark Brown for a drink when you have the chance.",
        "Some Mark Browns just put a smile on my face, and this is one of them.",
        "This ultra-polished Mark Brown is extremely`(adjective)`. I had to force myself to stop looking at him, in order to move onto other Mark Browns.",
        "He's a clever and original idea for Mark Brown, with endless ways to expand on the concept."
    };

    public static PhrasesPull Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public string GetStart(int index)
    {
        return start[index];
    }
    public string GetMid(int index)
    {
        return mid[index];
    }
    public string GetEnd(int index)
    {
        return end[index];
    }
}
