using System.Linq.Expressions;

namespace BookStore.Infrastructure.Specifications;

public class AndSpecification<T> : Specification<T>
{
    private readonly Specification<T> _left;
    private readonly Specification<T> _right;

    public AndSpecification(Specification<T> left, Specification<T> right)
    {
        _left = left;
        _right = right;
    }

    public override Expression<Func<T, bool>> ToExpression()
    {
        return Expression.Lambda<Func<T, bool>>(
            Expression.AndAlso(_left.ToExpression().Body, _right.ToExpression().Body),
            _left.ToExpression().Parameters.Single()
        );
    }
}
