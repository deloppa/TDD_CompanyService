namespace CompanyService;
public class CompanyService : ICompanyService
{
    public long GetEmployeeCountForCompanyAndChildren(Company company, List<Company> companies)
    {
        return 0;
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
