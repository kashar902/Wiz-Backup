using System.ComponentModel.DataAnnotations;

namespace UserAssociates.Business.Dtos.FormulaBuilder;

public sealed record UpdateFormulaBuilderDto
(
    [Required] int KeyID,
    [Required] string? FormulaCode,
    [Required] string? FormulaName,
    [Required] string? Category,
    [Required] string? Description,
    [Required] string? Formula,
    [Required] bool Active
);
