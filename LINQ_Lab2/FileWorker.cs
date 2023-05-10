namespace LINQ_Lab2;

public class FileWorker
{
    private readonly DataContext _dataContext;

    public FileWorker(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public void create(String name)
    {
        var file = Serializer.Serialize(_dataContext);
        using (var sw = new StreamWriter(name))
        {
            sw.Write(file);
        }
    }
}