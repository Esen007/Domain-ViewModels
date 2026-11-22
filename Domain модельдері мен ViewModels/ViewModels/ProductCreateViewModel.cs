using System.ComponentModel.DataAnnotations;
using Domain_модельдері_мен_ViewModels.Models;

namespace Domain_модельдері_мен_ViewModels.ViewModels;

public class ProductCreateViewModel : IValidatableObject
{
    [Required(ErrorMessage = "Тауар атауын енгізіңіз.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Атау 2-ден 100 таңбаға дейін болуы керек.")]
    [RegularExpression(@"^[\p{L}\p{N} .'-]+$", ErrorMessage = "Атауда рұқсат етілмеген таңбалар бар.")]
    [Display(Name = "Тауар атауы")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Сипаттаманы енгізіңіз.")]
    [StringLength(500, MinimumLength = 10, ErrorMessage = "Сипаттама 10-нан 500 таңбаға дейін болуы керек.")]
    [Display(Name = "Сипаттама")]
    public string Description { get; set; } = string.Empty;

    [Range(typeof(decimal), "0.01", "100000000", ErrorMessage = "Баға 0,01 мен 100 000 000 аралығында болуы керек.")]
    [Display(Name = "Баға")]
    public decimal Price { get; set; }

    [Range(0, 1000000, ErrorMessage = "Қоймадағы сан 0 мен 1 000 000 аралығында болуы керек.")]
    [Display(Name = "Қоймадағы саны")]
    public int StockQuantity { get; set; }

    [Required(ErrorMessage = "Санатты таңдаңыз.")]
    [StringLength(50, ErrorMessage = "Санат 50 таңбадан аспауы керек.")]
    [Display(Name = "Санат")]
    public string Category { get; set; } = string.Empty;

    [Required(ErrorMessage = "Жеткізушінің email мекенжайын енгізіңіз.")]
    [EmailAddress(ErrorMessage = "Email мекенжайы дұрыс емес.")]
    [Display(Name = "Жеткізушінің email-ы")]
    public string SupplierEmail { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email мекенжайын қайта енгізіңіз.")]
    [Compare(nameof(SupplierEmail), ErrorMessage = "Email мекенжайлары сәйкес келмейді.")]
    [Display(Name = "Email растауы")]
    public string SupplierEmailConfirmation { get; set; } = string.Empty;

    [Range(0, 90, ErrorMessage = "Жеңілдік 0 мен 90 пайыз аралығында болуы керек.")]
    [Display(Name = "Жеңілдік (%)")]
    public int DiscountPercent { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (DiscountPercent > 0 && StockQuantity == 0)
        {
            yield return new ValidationResult(
                "Қоймада тауары жоқ өнімге жеңілдік тағайындауға болмайды.",
                [nameof(DiscountPercent), nameof(StockQuantity)]);
        }
    }

    public Product ToDomainModel()
    {
        return new Product
        {
            Name = Name.Trim(),
            Description = Description.Trim(),
            Price = Price,
            StockQuantity = StockQuantity,
            Category = Category.Trim(),
            SupplierEmail = SupplierEmail.Trim()
        };
    }
}
