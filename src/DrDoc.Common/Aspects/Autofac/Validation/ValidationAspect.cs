using Castle.DynamicProxy;
using DrDoc.Common.CrossCuttingConcerns.Validation;
using DrDoc.Common.Utilities.Enums;
using DrDoc.Common.Utilities.Extensions;
using DrDoc.Common.Utilities.Interceptors;
using FluentValidation;

namespace DrDoc.Common.Aspects.Autofac.Validation;

public class ValidationAspect : MethodInterception
{
    private Type _validatorType;

    public ValidationAspect(Type validatorType)
    {
        if (!typeof(IValidator).IsAssignableFrom(validatorType))
        {
            throw new Exception(Messages.WrongValidationType.ToDisplay());
        }

        _validatorType = validatorType;
    }

    protected override void OnBefore(IInvocation invocation)
    {
        var validator = (IValidator)Activator.CreateInstance(_validatorType)!;
        var entityType = _validatorType.BaseType?.GetGenericArguments()[0];
        var entities = invocation.Arguments.Where(t => t.GetType() == entityType);

        foreach (var entity in entities)
        {
            ValidationTool.Validate(validator, entity);
        }
    }
}