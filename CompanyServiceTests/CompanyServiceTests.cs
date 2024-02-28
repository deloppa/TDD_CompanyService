using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompanyService.Tests;

[TestClass()]
public class CompanyServiceTests
{
    private static readonly Company _main = new Company(null, 2);
    private static readonly Company _bookKeeping = new Company(_main, 3);
    private static readonly Company _manager = new Company(_main, 4);
    private static readonly Company _design = new Company(_manager, 6);
    private static readonly Company _developer = new Company(_manager, 8);
    private static readonly Company _lawer = new Company(null, 1);

    private static readonly ICompanyService companyService = new CompanyService();

    private static readonly List<Company> _companies = new List<Company>()
    {
        _main, _bookKeeping, _manager, _design, _developer, _lawer
    };

    [TestMethod()]
    public void WhenCompanyIsNull_ThenNull()
    {
        Company result = companyService.GetTopLevelParent(null);
        Assert.IsNull(result);
    }

    [TestMethod()]
    public void WhenCompanyHasNoParent_ThenCompany()
    {
        Company result = companyService.GetTopLevelParent(_main);
        Assert.AreEqual(_main, result);
    }

    [TestMethod()]
    public void WhenCompanyIsSingle_ThenCompany()
    {
        Company result = companyService.GetTopLevelParent(_lawer);
        Assert.AreEqual(_lawer, result);
    }

    [TestMethod()]
    public void WhenCompanyIsSecondInHierarchy_ThenTopCompany()
    {
        Company result = companyService.GetTopLevelParent(_bookKeeping);
        Assert.AreEqual(_main, result);
    }

    [TestMethod()]
    public void WhenCompanyIsThirdInHierarchy_ThenTopCompany()
    {
        Company result = companyService.GetTopLevelParent(_developer);
        Assert.AreEqual(_main, result);
    }

    [TestMethod()]
    public void WhenCompanyIsNull_Then0()
    {
        long result = companyService.GetEmployeeCountForCompanyAndChildren(null, _companies);
        Assert.AreEqual(0, result);
    }

    [TestMethod()]
    public void WhenListIsNull_Then0()
    {
        long result = companyService.GetEmployeeCountForCompanyAndChildren(_main, null);
        Assert.AreEqual(0, result);
    }

    [TestMethod()]
    public void WhenListIsEmpty_Then0()
    {
        long result = companyService.GetEmployeeCountForCompanyAndChildren(_main, new List<Company>());
        Assert.AreEqual(0, result);
    }

    [TestMethod()]
    public void WhenCompanyIsNullAndListIsEmpty_Then0()
    {
        long result = companyService.GetEmployeeCountForCompanyAndChildren(null, new List<Company>());
        Assert.AreEqual(0, result);
    }

    [TestMethod()]
    public void WhenCompanyIsNullAndListIsNull_Then0()
    {
        long result = companyService.GetEmployeeCountForCompanyAndChildren(null, null);
        Assert.AreEqual(0, result);
    }

    [TestMethod()]
    public void WhenCompanyIsMain_ThenCompanyEmployeesEquals23()
    {
        long result = companyService.GetEmployeeCountForCompanyAndChildren(_main, _companies);
        Assert.AreEqual(23, result);
    }

    [TestMethod()]
    public void WhenCompanyIsDeveloper_ThenCompanyEmployeesEquals8()
    {
        long result = companyService.GetEmployeeCountForCompanyAndChildren(_developer, _companies);
        Assert.AreEqual(8, result);
    }

    [TestMethod()]
    public void WhenCompanyIsManager_ThenCompanyEmployeesEquals18()
    {
        long result = companyService.GetEmployeeCountForCompanyAndChildren(_manager, _companies);
        Assert.AreEqual(18, result);
    }

    [TestMethod()]
    public void WhenCompanyIsLawer_ThenCompanyEmployeesEquals1()
    {
        long result = companyService.GetEmployeeCountForCompanyAndChildren(_lawer, _companies);
        Assert.AreEqual(1, result);
    }
}