using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhrasesPull : MonoBehaviour
{
    public List<string> start = new List<string>
    {
        "There are always a few`(adjective)`Mark Browns every year. This year, this one was my favorite.",
        "A common theme this year among Mark Browns was`(plural-noun)`.",
        "One creative take on Mark Brown this year was this.",
        "This is another`(adjective)`Mark Brown, but with a completely different`(noun)`.",
        "This Mark Brown uses`(noun)`as inspiration for his`(noun)`.",
        "There's always something fun about Mark Brown when he`(verb-s)`. This Mark is a great example of that.",
        "Mark Brown doesn't always have to be`(adjective)`. This Mark proves just that.",
        "One of the more creative twists on Mark Brown, in my opinion, was using his face as his`(noun)`instead.",
        "There were a lot Mark Browns in this Jam where he was wearing a(n)`(noun)`. This is my favorite take on that idea.",
        "Another ultra-popular for Mark Brown was`(noun)`. This Mark was my favorite.",
        "In terms of outside-the-box creativity,`(adjective)`Mark Brown takes the cake.",
        "Would it really be a Mark Brown Jam, if there wasn't a platforming Mark? One I really liked was`(adjective)`Mark Brown.",
        "As always, here's an honorable mention. I would have liked to include this Mark Brown, but he lacks`(noun)`.",
        "Every Mark Brown Jam, a Mark comes along that blows my mind a little bit. This time, that honor goes to`(adjective)`Mark Brown.",
        "This year we saw a whole bunch of Marks that`(verb)`when you touch them. My favorite of the bunch though, was this Mark.",
        "If gardening is more your thing, look no further than`(adjective)`Mark Brown.",
        "Another Mark I dug was the, very innovative,`(adjective)`Mark Brown.",
        "Here's a Mark Brown I wasn't expecting. A Mark that`(verb-s)`twice as much as normal.",
        "There are always a boatload of`(adjective)`Mark Browns. In fact, there were two in the top 100. My pick of the pair was this Mark.",
        "Here's a`(adjective)`Mark Brown with a lot of potential for growth.",
        "I love how a Mark Brown Jam can produce Marks, that are basically a funny joke. This includes`(adjective)`Mark.",
    };
    public List<string> mid = new List<string>
    {
        "I really enjoyed his creative use of his`(noun)`, and the fact that it`(verb-s)`when used.",
        "The juice in this one is just right. It feels great when he`(verb-s)`his mouth.",
        "He can`(verb)`in any direction, but is limited by the number of`(plural-noun)`he has.",
        "He borrows from many other people for his`(noun)`.",
        "When he`(verb-s)`, he also ends up spinning out of control.",
        "He has a great twist, where his`(noun)`is upside-down.",
        "Because his`(noun)`is tied to his leg, it really makes the way he`(verb-s)`more engaging.",
        "He uses a`(noun)`to move around, like a(n)`(animal)`.",
        "He has a(n)`(noun)`on his face, which lead to some pretty crazy shenanigains.",
        "He's wears a charming`(noun)`which really matches his`(noun)`.",
        "He`(verb-s)`, every time he`(verb-s)`, which leads to some pretty chaotic circumstances.",
        "His skin is`(adjective)`, which allows him to`(verb)`.",
        "He can`(verb)`like any other Mark Brown, but backwards.",
        "He's afraid, because he is being constantly chased by a`(noun)`.",
        "The idea for him is that he doesn't have a`(noun)`. This forces him to constantly adapt in a normally familiar environment.",
        "Look closer, and you'll see that he has a`(noun)`, which he uses to pick things up.",
        "Initially he seems like a funny sight gag of a Mark Brown, but he's actually a metaphor for`(noun)`.",
    };
    public List<string> end = new List<string>
    {
        "This gives him an extra layer of charm, without making him feel too`(adjective)`.",
        "I could definitely see this Mark Brown expanded further, maybe even into a full person.",
        "Although an enjoyable person, I think it might be more fun to give him a few more`(plural-noun)`.",
        "In terms of feedback, I would perhaps make his`(noun)`a bit larger.",
        "I had a ton of fun seeing how`(adjective)`he could get. This is a good one.",
        "His`(noun)`is a wonderful example of why it's important to think outside the box, when following the theme.",
        "My only suggestion is, give him a(n)`(noun)`.",
        "He really does exceed expectations. Buy him a drink, when you have the chance.",
        "Some Mark Browns just make me so`(emotion)`, and this is one of them.",
        "He is ultra-polished and extremely`(adjective)`. I had to force myself to stop reviewing him, so I could move on.",
        "He's a clever and original idea for Mark, and with endless ways to expand on him as a person.",
        "He has a great understanding of what it takes to be a(n)`(noun)`, and was a joy to review.",
        "I also liked his`(adjective)`style. If you have the time, check him out.",
        "He mixes fast-paced`(action)`with`(action)`. Good stuff.",
        "I really enjoyed this one, as he took a very`(adjective)`twist on the theme.",
        "Very`(adjective)`, though we have seen similar stuff in previous Mark Brown Jams.",
        "He is a(n)`(adjective)`Mark, with a lot of charm.",
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
