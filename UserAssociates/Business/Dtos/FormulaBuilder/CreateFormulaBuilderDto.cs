using System.ComponentModel.DataAnnotations;

namespace UserAssociates.Business.Dtos.FormulaBuilder;

public sealed record CreateFormulaBuilderDto
(
    [Required] string? FormulaCode,
    [Required] string? FormulaName,
    [Required] string? Category,
    [Required] string? Description,
    [Required] string? Formula,
    [Required] bool Active
);