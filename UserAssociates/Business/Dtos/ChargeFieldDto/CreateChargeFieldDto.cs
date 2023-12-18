using System.ComponentModel.DataAnnotations;

namespace UserAssociates.Business.Dtos.ChargeFieldDto;

public sealed record CreateChargeFieldDto
(
    [Required] string? FieldCode,
    [Required] string? ChargeFieldName,
    [Required] string? FieldType,
    [Required] string? ChargeType,
    [Required] string? Position,
    [Required] decimal? Percentage,
    [Required] bool RoundOff,
    [Required] bool IsReadOnly,
    [Required] string? Description
);
