using System.Windows;
using HIVMedicalSystem.Domain.Entities;
using HIVMedicalSystem.Service.Abstraction;
using Microsoft.Extensions.DependencyInjection;

namespace HIVMedicalSystem.WPFApplication.Windows.Staff;

public partial class ImportTestResultWindow : Window
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ITestResultService _testResultService;
    public ImportTestResultWindow(IServiceProvider serviceProvider, int customerId)
    {
        _serviceProvider = serviceProvider;
        _testResultService = _serviceProvider.GetRequiredService<ITestResultService>();
        CustomerId = customerId;
        InitializeComponent();
    }
    
    public int CustomerId { get; set; }

    private async void btnSave_Click(object sender, RoutedEventArgs e)
    {
        int cd4count = Int32.Parse(txtCD4Count.Text);
        int viralLoad = Int32.Parse(txtViralLoad.Text);
        decimal alt = Decimal.Parse(txtALT.Text);
        decimal ast = Decimal.Parse(txtAST.Text);
        decimal creatine = Decimal.Parse(txtCreatine.Text);
        string notes = txtNotes.Text;
        var result = new TestResult()
        {
            ALT = alt,
            AST = ast,
            CD4Count = cd4count,
            ViralLoad = viralLoad,
            Creatine = creatine,
            Notes = notes,
            UserId = CustomerId,
            TestDate = DateTime.Now,
            IsDeleted = false,
        };
        await _testResultService.AddNewTestResult(result);
        MessageBox.Show("Import success!");
        this.Close();
    }
}