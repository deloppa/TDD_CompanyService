/// <summary> Company Service Interface </summary>
/// <author>Svitlana Bakun</author>
/// <project>CompanyService</project>
/// <version>1.0.0</version>

namespace CompanyService;
public interface ICompanyService
{
    Company GetTopLevelParent(Company child);
    long GetEmployeeCountForCompanyAndChildren(Company company, List<Company> companies);
}
