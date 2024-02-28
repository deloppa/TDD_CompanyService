/// <summary> Company Service Interface Implementation </summary>
/// <author>Svitlana Bakun</author>
/// <project>CompanyService</project>
/// <version>1.0.0</version>

namespace CompanyService;
public class CompanyService : ICompanyService
{
    public long GetEmployeeCountForCompanyAndChildren(Company company, List<Company> companies)
    {
        if (company == null || companies == null || !companies.Any()) return 0;

        List<Company> children = new List<Company>();   
        Queue<Company> childrenToCheck = new Queue<Company>();
        childrenToCheck.Enqueue(company);

        while(childrenToCheck.Count > 0)
        {
            Company current = childrenToCheck.Dequeue();
            children.Add(current);

            foreach(Company c in companies) 
            { 
                if(c.Parent == current) childrenToCheck.Enqueue(c);
            }
        }

        long result = children.Sum(child => child.EmployeesCount);

        return result;
    }

    public Company GetTopLevelParent(Company child)
    {
        if (child == null) return null;

        if (child.Parent == null) return child;

        while (child.Parent != null)
        {
            child = child.Parent;
        }

        return child;
    }
}
