namespace CompanyService;
public class Company
{
    private Company _parent;
    private long _employeesCount;

    public Company(Company parent, long employeesCount)
    {
        _parent = parent;
        _employeesCount = employeesCount;
    }

    public Company Parent
    {
        get { return _parent; }
    }

    public long EmployeesCount
    {
        get { return _employeesCount; }
    }
}
