using System;
using System.Collections.Generic;

namespace YouTubeVideos
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Video> videos = new();

            // Video 1
            Video video1 = new("C# Abstraction Explained", "TechGuru", 480);
            video1.AddComment(new Comment("Alice", "Great explanation, very clear!"));
            video1.AddComment(new Comment("Bob", "This helped me understand abstraction."));
            video1.AddComment(new Comment("Charlie", "Can you make one on polymorphism next?"));
            videos.Add(video1);

            // Video 2
            Video video2 = new("Top 10 Programming Tips", "CodeMaster", 720);
            video2.AddComment(new Comment("Dave", "Tip #5 changed my life!"));
            video2.AddComment(new Comment("Eve", "Awesome content, keep it up."));
            video2.AddComment(new Comment("Frank", "Very practical advice, thanks!"));
            video2.AddComment(new Comment("Grace", "Already shared with my team."));
            videos.Add(video2);

            // Video 3
            Video video3 = new("Understanding OOP Principles", "DevSage", 900);
            video3.AddComment(new Comment("Hank", "Encapsulation makes so much sense now."));
            video3.AddComment(new Comment("Ivy", "The examples were perfect."));
            video3.AddComment(new Comment("Jack", "I finally get inheritance!"));
            videos.Add(video3);

            // Video 4
            Video video4 = new("C# vs Java: Which to Learn?", "PolyglotPro", 600);
            video4.AddComment(new Comment("Kevin", "Very balanced comparison."));
            video4.AddComment(new Comment("Laura", "I'm sticking with C# after this."));
            video4.AddComment(new Comment("Mona", "Clear and unbiased, thank you."));
            videos.Add(video4);

            // Display all videos
            foreach (Video video in videos)
            {
                video.DisplayVideoInfo();
            }
        }
    }
}