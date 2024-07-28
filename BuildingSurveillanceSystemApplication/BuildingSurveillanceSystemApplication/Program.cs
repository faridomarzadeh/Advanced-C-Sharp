// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

public interface IEmployee
{
    int Id{ get; set; }
    string FirstName { get; set; } 
    string LastName { get; set; }
    string JobTitle {  get; set; }
}

public class Employee : IEmployee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string JobTitle { get; set; }
}
public class EmployeeNotify : IObserver<ExternalVisitor>
{

    private IEmployee _employee = null;
    List<ExternalVisitor> _visitors = null;
    IDisposable _cancellation;
    public EmployeeNotify(IEmployee employee)
    {
        _employee = employee;
    }
    public void OnCompleted()
    {
        var heading = $"{_employee.FirstName + "    " + _employee.LastName} Daily visitor's Report";
        Console.WriteLine();

        Console.WriteLine(heading);
        Console.WriteLine(new string('-',heading.Length));
        Console.WriteLine();

        foreach(var visitor in _visitors)
        {
            visitor.InBuilding = false;
            Console.WriteLine($"{visitor.Id,-6}{visitor.FirstName,-15},{visitor.LastName,-15}{visitor.EntryDateTime.ToString("dd MM yyyy hh:mm:ss"),-25}{visitor.ExitDateTime.ToString("dd MM yyyy hh:mm:ss"),-25}");
        }
        Console.WriteLine("\n");
    }

    public void OnError(Exception error)
    {
        throw new NotImplementedException();
    }

    public void OnNext(ExternalVisitor value)
    {
        var visitor = value;
        if(visitor.EmployeeContactId == _employee.Id)
        {
            var visitorListItem = _visitors.FirstOrDefault(e => e.Id == visitor.Id);
            if(visitorListItem != null)
            {
                _visitors.Add(visitorListItem);
                Console.WriteLine($"{_employee.FirstName} {_employee.LastName}, your visitor has arrived. Visitor Id ({visitor.Id}), FirstName ({visitor.FirstName})," +
                    $" LastName({visitor.LastName}) entered the building, DateTime ({visitor.EntryDateTime.ToString("dd MM yyyy hh:mm:ss")}) ");
                Console.WriteLine();
            }
            else if(visitor.InBuilding == false)
            {
                visitorListItem.InBuilding = false;
                visitorListItem.ExitDateTime = visitor.ExitDateTime;
            }
        }
    }

    public void Subscribe(IObservable<ExternalVisitor> provider)
    {
        _cancellation = provider.Subscribe(this);
    }

    public void UnSubscribe()
    {
        _cancellation.Dispose();
        _visitors.Clear();
    }
}

public class SecurityNotify : IObserver<ExternalVisitor>
{
    public void OnCompleted()
    {
        throw new NotImplementedException();
    }

    public void OnError(Exception error)
    {
        throw new NotImplementedException();
    }

    public void OnNext(ExternalVisitor value)
    {
        throw new NotImplementedException();
    }
}
public class UnSubscriber<ExternalVisitor> : IDisposable
{
    private List<IObserver<ExternalVisitor>> _observers;
    private IObserver<ExternalVisitor> _observer;
    public UnSubscriber(List<IObserver<ExternalVisitor>> observers, IObserver<ExternalVisitor> observer)
    {
        _observers = observers;
        _observer = observer;
    }
    public void Dispose()
    {
        if (_observers.Contains(_observer))
        {
            _observers.Remove(_observer);
        }
    }
}

public class SecuritySurveillanceHub : IObservable<ExternalVisitor>
{
    private List<ExternalVisitor> _visitors;
    private List<IObserver<ExternalVisitor>> _observers;
    public IDisposable Subscribe(IObserver<ExternalVisitor> observer)
    {
        if(!_observers.Contains(observer))
            _observers.Add(observer);


        foreach(var visitor in _visitors)
        {
            observer.OnNext(visitor);
        }
        return new UnSubscriber<ExternalVisitor>(_observers,observer);
    }

    public void ConfirmExternalVisitorEntersBuilding(int id, string firstName, string lastName, 
        string companyName, string jobTitle, DateTime entryDateTime, int employeeContactId)
    {
        ExternalVisitor visitor = new ExternalVisitor
        {
            CompanyName = companyName,
            FirstName = firstName,
            LastName = lastName,
            Id = id,
            EmployeeContactId = employeeContactId,
            EntryDateTime = entryDateTime,
            JobTitle = jobTitle,
            InBuilding = true
        };
        _visitors.Add(visitor);

        //notify observers/subscribers
        foreach(var observer in _observers)
        {
            observer.OnNext(visitor);
        }
    }

    public void ConfirmExternalVisitorExitsBuilding(int externalVisitorId, DateTime exitDateTime)
    {
        var visitor = _visitors.FirstOrDefault(v => v.Id == externalVisitorId);

        if(visitor != null)
        {
            visitor.ExitDateTime = exitDateTime;
            visitor.InBuilding = false;
            foreach(var observer in _observers)
            {
                observer.OnNext(visitor);
            }
        }
    }

    public void BuildingEntryCutOffTimeReached()
    {
        if(_visitors.Where(e=>e.InBuilding==true).ToList().Count == 0)
        {
            foreach(var observer in _observers)
                observer.OnCompleted();
        }
    }
}
public class ExternalVisitor
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string CompanyName { get; set; }
    public string JobTitle { get; set; }
    public DateTime EntryDateTime { get; set; }
    public DateTime ExitDateTime { get; set; }
    public bool InBuilding {  get; set; }
    public int EmployeeContactId {  get; set; }
}