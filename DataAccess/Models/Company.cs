using System.Collections.ObjectModel;


namespace DataAccess.Models;

public class Company
{
    public Company()
    {
        Results = new ObservableCollection<Result>();
    }

    public long Id { get; set; }
    public string Name { get; set; } = null!;

    public virtual ObservableCollection<Result> Results { get; set; }
}
