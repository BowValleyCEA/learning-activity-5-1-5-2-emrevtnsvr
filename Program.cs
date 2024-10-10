using System;
using System.Collections.Generic;
class Video
{
    public string Name { get; set; }
    public int VideoID { get; set; }
    public bool IsRented { get; set; }
    public Video(int id, string name)
    {
        VideoID = id;
        Name = name;
        IsRented = false;
    }
}
class User
{
    public string Name { get; set; }
    public int UserID { get; set; }
    public List<Video> RentedVideos { get; set; }
    public User(int id, string name)
    {
        UserID = id;
        Name = name;
        RentedVideos = new List<Video>();
    }
}
class BrickBusterPOS
{
    List<Video> videos = new List<Video>();
    List<User> users = new List<User>();
    int videoIdCounter = 1;
    int userIdCounter = 1;
    public void AddVideo(string name)
    {
        videos.Add(new Video(videoIdCounter++, name));
    }
    public void AddUser(string name)
    {
        users.Add(new User(userIdCounter++, name));
    }
    public void RentVideo(int userId, int videoId)
    {
        var user = users.Find(u => u.UserID == userId);
        var video = videos.Find(v => v.VideoID == videoId);
        if (user != null && video != null && !video.IsRented)
        {
            video.IsRented = true;
            user.RentedVideos.Add(video);
            Console.WriteLine($"{user.Name} rented {video.Name}");
        }
        else
        {
            Console.WriteLine("Video not available.");
        }
    }
    public void ReturnVideo(int userId, int videoId)
    {
        var user = users.Find(u => u.UserID == userId);
        var video = user?.RentedVideos.Find(v => v.VideoID == videoId);
        if (video != null)
        {
            video.IsRented = false;
            user.RentedVideos.Remove(video);
            Console.WriteLine($"{user.Name} returned {video.Name}");
        }
        else
        {
            Console.WriteLine("Video not found.");
        }
    }
    public void ListVideos()
    {
        foreach (var video in videos)
        {
            Console.WriteLine($"{video.VideoID}. {video.Name} (Available: {!video.IsRented})");
        }
    }
}
class Program
{
    static void Main()
    {
        BrickBusterPOS pos = new BrickBusterPOS();
        pos.AddVideo("The Matrix");
        pos.AddVideo("Inception");
        pos.AddUser("John Doe");
        bool running = true;
        while (running)
        {
            Console.WriteLine("\n1. Rent Video\n2. Return Video\n3. List Videos\n4. Exit");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Write("Enter User ID: ");
                    int rentUserId = int.Parse(Console.ReadLine());
                    Console.Write("Enter Video ID: ");
                    int rentVideoId = int.Parse(Console.ReadLine());
                    pos.RentVideo(rentUserId, rentVideoId);
                    break;
                case "2":
                    Console.Write("Enter User ID: ");
                    int returnUserId = int.Parse(Console.ReadLine());
                    Console.Write("Enter Video ID: ");
                    int returnVideoId = int.Parse(Console.ReadLine());
                    pos.ReturnVideo(returnUserId, returnVideoId);
                    break;
                case "3":
                    pos.ListVideos();
                    break;
                case "4":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}


