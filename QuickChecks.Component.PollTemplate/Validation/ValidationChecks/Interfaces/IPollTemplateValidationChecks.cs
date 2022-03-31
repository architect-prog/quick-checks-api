using System.Threading.Tasks;

namespace QuickChecks.Component.PollTemplate.Validation.ValidationChecks.Interfaces;

public interface IPollTemplateValidationChecks
{
    Task<bool> IsPollTemplateExists(int id);
}