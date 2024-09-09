namespace Core.Entities;


public enum TaskStatus
{
    Pending,
    InProgress,
    Completed,
    Canceled,
}


public class Attachement:EntityBase
{
    public string FileName { get; private set; }
    public string FilePath { get; private set; }
    public string FileExtension { get; private set; }

    public Attachement(string fileName, string filePath, string fileExtension)
    {
        FileName = fileName;
        FilePath = filePath;
        FileExtension = fileExtension;
    }
}

public class Tags:EntityBase
{
    public string Title { get; private set; }
    public Tags(string title)
    => Title = title;
}
public class Task:EntityBase
{
    public List<string> UsersId { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public  TaskStatus Status { get; private set; }
    public int Hours { get; private set; }

    public List<Attachement> Attachements { get; private set; }
    public List<Tags> Tags { get; private set; }

    public Task(string title, string description, TaskStatus status, int hours)
    {
        UsersId = new List<string>();
        Title = title;
        Description = description;
        Status = status;
        Hours = hours;
        Attachements =  new List<Attachement>();
        Tags = new List<Tags>();
    }

    public void AddColaborator(string userId)
    => UsersId.Add(userId);

    public void RemoveColaborator(string userId)
    => UsersId.Remove(userId);

    public void AddAttachement(Attachement attachement)
    => Attachements.Add(attachement);

    public void RemoveAttachement(Attachement attachement)
    => Attachements.Remove(attachement);

    public void AddTag(Tags tag)
    => Tags.Add(tag);

    public void RemoveTag(Tags tag)
    => Tags.Remove(tag);

}