namespace App.Wiz.Common.ServiceViewModels.CreditTermViewModels;

public class CreditTermViewModel
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public int Term { get; set; }
    public char TermUnit { get; set; }
}