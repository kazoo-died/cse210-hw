using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        
        Video video1 = new Video("How to Make Pancakes", "CookingWithAmy", 480);
        Video video2 = new Video("Exploring the Solar System", "SpaceTime", 720);
        Video video3 = new Video("Ultimate Guitar Tutorial", "RockOn", 900);
        Video video4 = new Video("Funny Cat Compilation", "MeowTube", 300);

        
        video1.AddComment(new Comment("Liam", "Tried this recipe, and it was delicious!"));
        video1.AddComment(new Comment("Sophia", "Can you make a vegan version next time?"));
        video1.AddComment(new Comment("Noah", "Love your cooking videos!"));

        
        video2.AddComment(new Comment("Ava", "The visuals were incredible!"));
        video2.AddComment(new Comment("Ethan", "You explained everything so clearly."));
        video2.AddComment(new Comment("Olivia", "I learned so much about Jupiter!"));

        
        video3.AddComment(new Comment("Mason", "Finally nailed my first chord thanks to you!"));
        video3.AddComment(new Comment("Emma", "Your tutorials are the best!"));
        video3.AddComment(new Comment("Lucas", "Subscribed immediately."));

        
        video4.AddComment(new Comment("Mia", "That cat at 1:30 made my day 😂"));
        video4.AddComment(new Comment("James", "Cats truly rule the internet."));
        video4.AddComment(new Comment("Isabella", "So cute! I can’t stop watching."));

        
        List<Video> videos = new List<Video> { video1, video2, video3, video4 };

       
        foreach (Video video in videos)
        {
            video.DisplayDetails();
        }
    }
}
